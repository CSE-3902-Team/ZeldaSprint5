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

namespace Sprint0.LevelClass
{
	public class LevelManager
	{
		private SpriteBatch batch;
		private List<Room> roomList;
        private int currentRoom;
        private int numRooms;
        private const int OFFSET = 256; //used in sprint4 because we need to push the level down to have the inventory/map on the top of the screen

		private ItemSpriteFactory itemFactory;
		private DoorFactory doorFactory;
        private EnemyFactory enemyFactory;
        private TileFactory tileFactory;
		private Player _player;
        private Vector2 center;

        private List<ADoor> doorList;
        private List<AItem> itemList;
        private List<IEnemySprite> enemyList;
        private List<ITile> tileList;
        ICommand command;
        SoundManager soundManager;




        public Texture2D ProjectileTexture
        {
            get { return projectileTexture; }
        }
        
        public SoundManager SoundManager
        {
            get { return soundManager; }
        }
        public Player Player
        {
            get { return _player; }
        }

        public Room CurrentRoom
        {
            get { return roomList[currentRoom]; }
        }

        //these need to be gotten rid of

        private Texture2D playerTexture;
        private Texture2D projectileTexture;

        
        


        private static LevelManager instance = new LevelManager();

		public void initialize(SpriteBatch aBatch, ContentManager Content, ICollision collider, Vector2 center)
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

            playerTexture = Content.Load<Texture2D>("playerSheet");
            projectileTexture = Content.Load<Texture2D>("itemsAndWeapons1");
            
            _player = new Player(playerTexture, batch, new ProjectileBomb(projectileTexture, batch, new Vector2(140, 200+OFFSET), new Vector2(1, 0)), new Vector2(200, 200+OFFSET), Content.Load<Texture2D>("solid navy tile"), command);
            soundManager = new SoundManager();
            soundManager.LoadAllSounds(Content);



            //load everything with the items shown on screen
            itemFactory.LoadAllTextures(Content);
            itemFactory.setBatch(batch);
            doorFactory.LoadAllTextures(Content);
            doorFactory.setBatch(batch);
            enemyFactory.LoadAllTextures(Content);
            enemyFactory.initialize(batch, _player);
            tileFactory.LoadAllTextures(Content);
            tileFactory.setBatch(batch);
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
            Vector2 position1;
            tileDoor = fields[0];
            position = new Vector2(Int32.Parse(fields[1]), Int32.Parse(fields[2])+OFFSET);
            position1 = new Vector2(Int32.Parse(fields[1]), Int32.Parse(fields[2])+50+OFFSET);
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


            if (doorFactory.isADoor(tileDoor))
            {
                doorList.Add(doorFactory.CreateDoorSprite(doorFactory.getDoor(tileDoor), doorFactory.getSide(tileDoor)));
            }
            else if(tileFactory.IsTile(tileDoor))
            {
                tileList.Add(tileFactory.CreateTileSprite(tileFactory.GetTile(tileDoor), position));
            }
            if (enemy.Length > 0) {
                enemyList.Add(enemyFactory.CreateEnemySprite(enemyFactory.GetEnemy(enemy), position1, command));
            }
            if (item.Length > 0) {
                itemList.Add(itemFactory.CreateItemSprite(itemFactory.GetItem(item), position));
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
                roomList.Add(new Room(doorList.ToArray(), enemyList, itemList.ToArray(), tileList.ToArray(), _player));
            }
        }



        public Room StartRoom() {
            return roomList[0];
        }


    public Room SwitchRoom()
		{
            if (currentRoom < roomList.Count-1) 
            {
                currentRoom++;
            }
            else 
            {
                currentRoom = 0;
            }
            return roomList[currentRoom];
		}

	}
}