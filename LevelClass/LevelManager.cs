using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.TileClass;
using Sprint0.ItemClass;
using Sprint0.Collision;
using Sprint0.PlayerClass;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Sprint0.enemy;
using Sprint0.DoorClass;
using Microsoft.Xna.Framework.Content;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System;
using Sprint0.Command;
using Sprint0.StateClass;
using Sprint0.Projectile;

namespace Sprint0.LevelClass
{
	public class LevelManager
	{
        private HUD headsUpDisplay;
		private SpriteBatch batch;
		private List<Room> roomList;
        private int currentRoom;
        private int numRooms;
        private const int OFFSET = 256; //used in sprint4 because we need to push the level down to have the inventory/map on the top of the screen
        private bool _2player;

		private ItemSpriteFactory itemFactory;
		private DoorFactory doorFactory;
        private EnemyFactory enemyFactory;
        private TileFactory tileFactory;
        private ProjectileFactory projectileFactory;
		private Player _player1;
        private Player _player2;
        private Vector2 center;
        private List<AItem> combineList;
        private List<ADoor> doorList;
        private List<AItem> itemList;
        private List<IEnemySprite> enemyList;
        private List<ITile> tileList;
        private Dictionary<IEnemySprite, AItem> enemyHoldItem;
        private GameState _gameState;
        ICommand command;

        
        public GameState gameState 
        {
            set { _gameState = value; }
        }

        public Texture2D ProjectileTexture
        {
            get { return projectileTexture; }
        }
        
        public List<Room> RoomList
        {
            get { return roomList; }
        }

        public ProjectileFactory ProjectileFactory
        {
            get { return projectileFactory; }
        }

        public Player Player1
        {
            get { return _player1; }
        }

        public Player Player2
        {
            get { return _player2; }
        }

        public Room CurrentRoom
        {
            get { return roomList[currentRoom]; }
        }
        public bool TwoPlayer
        {
            get { return _2player; }
        }
        

        //these need to be gotten rid of

        private Texture2D player1Texture;
        private Texture2D player2Texture;
        private Texture2D projectileTexture;

  

        private static LevelManager instance = new LevelManager();

		public void initialize(SpriteBatch aBatch, ContentManager Content, ICollision collider, Vector2 center, bool twoPlayer)
		{
			itemFactory = ItemSpriteFactory.Instance;
			doorFactory = DoorFactory.Instance;
            enemyFactory = EnemyFactory.Instance;
            tileFactory = TileFactory.Instance;
			batch = aBatch;
            this.center = center;
            currentRoom = 0;
            numRooms = 5;
            roomList = new List<Room>();
            player1Texture = Content.Load<Texture2D>("player1SheetV5");
            player2Texture = Content.Load<Texture2D>("player2SheetV5");
            projectileTexture = Content.Load<Texture2D>("itemsAndWeapons1");
            _2player = twoPlayer;
            _player1 = new Player(player1Texture, batch, new ProjectileBomb(projectileTexture, batch, new Vector2(140, 200+OFFSET), new Vector2(1, 0)), new Vector2(515, 500+OFFSET), Content.Load<Texture2D>("solid navy tile"), command);
            if (_2player)
            {
                _player2 = new Player(player2Texture, batch, new ProjectileBomb(projectileTexture, batch, new Vector2(140, 200 + OFFSET), new Vector2(1, 0)), new Vector2(515, 500 + OFFSET), Content.Load<Texture2D>("solid navy tile"), command,_player1.Inventory);
            }
            

            //load everything with the items shown on screen
            itemFactory.LoadAllTextures(Content);
            itemFactory.setBatch(batch);
            doorFactory.LoadAllTextures(Content);
            doorFactory.setBatch(batch);
            enemyFactory.LoadAllTextures(Content);
            enemyFactory.initialize(batch, _player1);
            tileFactory.LoadAllTextures(Content);
            tileFactory.setBatch(batch);
            projectileFactory = new ProjectileFactory(projectileTexture, batch, this);

        }

        public static LevelManager Instance
		{
			get
			{
				return instance;
			}
		}

		private LevelManager()
		{
            command = new AddProjectileToLevel(this);
        }

        private void parseFields(string[] fields) 
        {
            //Console.WriteLine(fields.ToString());
            string tileDoor;
            Vector2 position;
            string enemy;
            string item;
            int roomConnection;
            Vector2 position1;
            tileDoor = fields[0];
            position = new Vector2(Int32.Parse(fields[1]), Int32.Parse(fields[2])+OFFSET);
            if (fields.Length >= 4)
            {
                enemy = fields[3];
            }
            else 
            {
                enemy = "";
            }

            if (fields.Length >= 5)
            {
                item = fields[4];
            }
            else
            {
                item = "";
            }
            if (fields.Length >= 6)
            {
                roomConnection = int.Parse(fields[5]);
            }
            else
            {
                roomConnection = 0;
            }


            if (doorFactory.isADoor(tileDoor))
            {
                doorList.Add(doorFactory.CreateDoorSprite(doorFactory.getDoor(tileDoor), doorFactory.getSide(tileDoor), roomConnection));
            }
            else if(tileFactory.IsTile(tileDoor))
            {
                tileList.Add(tileFactory.CreateTileSprite(tileFactory.GetTile(tileDoor), position));
            }
            if (enemy.Length > 0 && item.Length<=0) {
                enemyList.Add(enemyFactory.CreateEnemySprite(enemyFactory.GetEnemy(enemy), position, command));
            }
          else  if (item.Length > 0 && enemy.Length<=0) {
                
                itemList.Add(itemFactory.CreateItemSprite(itemFactory.GetItem(item), position));
            }
            else if (item.Length > 0 && enemy.Length > 0)
            {
                enemyHoldItem.Add(enemyFactory.CreateEnemySprite(enemyFactory.GetEnemy(enemy), position, command), itemFactory.CreateItemSprite(itemFactory.GetItem(item), position));
               
          
            }
        }

        private TextFieldParser PrepareforNewRoom(string file) {
            TextFieldParser parser = new TextFieldParser(file);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = false;
            parser.TrimWhiteSpace = true;

            doorList = new List<ADoor>();
            itemList = new List<AItem>();
            enemyList = new List<IEnemySprite>();
            tileList = new List<ITile>();
            enemyHoldItem = new Dictionary<IEnemySprite, AItem>();

            return parser;
    }

		public void LoadRooms()
		{
            TextFieldParser parser;

            string[] roomFiles = Directory.GetFiles(@"..\..\..\RoomCSVFiles\", "*.csv");
            string[] fields;
            
            foreach (string file in roomFiles) {
                //Console.WriteLine(file);
                parser = PrepareforNewRoom(file);
                while (parser.PeekChars(1) != null) 
                {
                    fields = parser.ReadFields();
                    parseFields(fields);
                }

                if (_2player)
                {
                    roomList.Add(new Room(doorList.ToArray(), enemyList, itemList.ToArray(), tileList.ToArray(), _player1, _player2, enemyHoldItem));
                }
                else
                {
                    roomList.Add(new Room(doorList.ToArray(), enemyList, itemList.ToArray(), tileList.ToArray(), _player1, enemyHoldItem));
                }

            }
        }

        public void RoomTransition(int destination, DoorFactory.Side side)
        {
            int previousRoom = currentRoom;
            currentRoom = destination;
            if (previousRoom == 19 || previousRoom == 5)
            {
                SoundManager.instance.PauseAllSounds();
                SoundManager.instance.Play(SoundManager.Sound.BG_MUSIC);
            }
            else if (currentRoom == 19 || currentRoom == 5)
            {
                SoundManager.instance.PauseAllSounds();
                SoundManager.instance.Play(SoundManager.Sound.Boss);
            }
            _gameState.startTransition(side, destination, roomList[currentRoom]);
        }



        public Room StartRoom() {
            currentRoom = 17;
            return roomList[currentRoom];
        }

        public int currentRoomNum {
            get { return currentRoom; }
        }
        

    public Room SwitchRoom()
		{
            int previousRoom = currentRoom;
            if (currentRoom < roomList.Count-1) 
            {
                currentRoom++;
                _gameState.startTransition(DoorFactory.Side.Ceiling, currentRoom, roomList[currentRoom]);
            }
            else 
            {
                currentRoom = 0;
                _gameState.startTransition(DoorFactory.Side.Ceiling, currentRoom, roomList[currentRoom]);
            }
            if (previousRoom == 19 || previousRoom == 5)
            {
                SoundManager.instance.PauseAllSounds();
                SoundManager.instance.Play(SoundManager.Sound.BG_MUSIC);
            }
            else if (currentRoom == 19 || currentRoom == 5)
            {
                SoundManager.instance.PauseAllSounds();
                SoundManager.instance.Play(SoundManager.Sound.Boss);
            }

            return roomList[currentRoom];
		}
	}
}