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
using Sprint0.Command;

namespace Sprint0.LevelClass
{
	public class LevelManager
	{
		private Texture2D doorSheet;
		private SpriteBatch batch;
		private int currentItem;
		private Room[] roomList;
        private int currentRoom;
        private int numRooms;

		private ItemSpriteFactory itemFactory;
		private DoorFactory doorFactory;
		private Player _player;
        private Vector2 center;

        public Texture2D ProjectileTexture
        {
            get { return projectileTexture; }
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
        private ITile tile;
        private Texture2D tileTexture;
        private ITile[] tileList;

        private Texture2D playerTexture;
        private Texture2D projectileTexture;

        private Texture2D enemyTexture;
        private Texture2D dragonTexture;
        private Texture2D npcTexture;

        
        


        private static LevelManager instance = new LevelManager();

		public void initialize(SpriteBatch aBatch, ContentManager Content, ICollision collider, Vector2 center)
		{
			itemFactory = ItemSpriteFactory.Instance;
			doorFactory = DoorFactory.Instance;
			batch = aBatch;
            this.center = center;
            currentRoom = 0;
            numRooms = 5;
            roomList = new Room[numRooms];
            
            

            tileTexture = Content.Load<Texture2D>("bricks");
            playerTexture = Content.Load<Texture2D>("playerSheet");
            projectileTexture = Content.Load<Texture2D>("itemsAndWeapons1");
            tile = new BrickTile(tileTexture, batch, new Vector2(128, 128));
            tileList = new ITile[]
            {
                new BrickTile(Content.Load<Texture2D>("bricks"), batch, new Vector2(128, 128)),
                new SandTile(Content.Load<Texture2D>("sandtile"), batch, new Vector2(128, 128)),
                new SilverLinesTile(Content.Load<Texture2D>("silverlines"), batch, new Vector2(128, 128)),
                new SolidBlackTile(Content.Load<Texture2D>("solid black tile"), batch, new Vector2(128, 128)),
                new SolidBlueTile(Content.Load<Texture2D>("solid blue tile"), batch, new Vector2(128, 128)),
                new SolidNavyTile(Content.Load<Texture2D>("solid navy tile"), batch, new Vector2(128, 128)),
                new StairsTile(Content.Load<Texture2D>("stairs"), batch, new Vector2(128, 128)),
                new StatueTile1(Content.Load<Texture2D>("statue1"), batch, new Vector2(128, 128)),
                new StatueTile2(Content.Load<Texture2D>("statue2"), batch, new Vector2(128, 128)),
                new StatueTile2(Content.Load<Texture2D>("tile with square in middle"), batch, new Vector2(128, 128)),
                new LeftFire(Content.Load<Texture2D>("LeftFire"), batch, new Vector2(128, 128)),
                new RightFire(Content.Load<Texture2D>("RightFire"), batch, new Vector2(128, 128)),
                new Text(Content.Load<Texture2D>("textsprite"), batch, new Vector2(128, 128)),

        };

            ICommand command = new AddProjectileToLevel(this);
            _player = new Player(playerTexture, batch, new ProjectileBomb(projectileTexture, batch, new Vector2(140, 200), new Vector2(1, 0)), new Vector2(200, 200), Content.Load<Texture2D>("solid navy tile"), command);



            //load everything with the items shown on screen
            itemFactory.LoadAllTextures(Content);
            itemFactory.setBatch(batch);
            doorFactory.LoadAllTextures(Content);
            doorFactory.setBatch(batch);
            

            enemyTexture = Content.Load<Texture2D>("Enemy");
            npcTexture = Content.Load<Texture2D>("oldman1");
            dragonTexture = Content.Load<Texture2D>("dragon");


            //from here down should go in load rooms

            IEnemySprite[] EnemyList;

            ADoor leftDoor;
            ADoor topDoor;
            ADoor rightDoor;
            ADoor bottomDoor;
            AItem item;
            IEnemySprite enemySprite;
            ITile tile1;
            ITile tile2;
            ITile roomWalls;

            Vector2 temp = new Vector2(400, 200);
            EnemyList = new IEnemySprite[] {

            new enemyGel(enemyTexture, batch, temp,_player),
            new enemyGoriya(enemyTexture, batch, temp),
            new enemyBat(enemyTexture, batch, temp,_player),
            new enemyHand(enemyTexture, batch, temp,_player),
            new enemySkeleton(enemyTexture, batch, temp,_player),
             new oldMan(npcTexture, batch, temp),
             new bossDragon(dragonTexture, batch, temp)
            };

            //roomWalls = new RoomWalls(Content.Load<Texture2D>("roomwalls"), batch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            roomWalls = new RoomWalls(Content.Load<Texture2D>("roomwalls"), batch, center);


            item = itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Compass, new Vector2(300, 100));

            enemySprite = new enemySkeleton(enemyTexture, batch, temp,_player);

            tile1 = new SolidNavyTile(Content.Load<Texture2D>("solid navy tile"), batch, new Vector2(440, 400));

            tile2 = new SolidNavyTile(Content.Load<Texture2D>("solid navy tile"), batch, new Vector2(300, 400));
            

            //room1////////////////////////////////////////////////////////////////////////////
            ITile roomWalls1 = new RoomWalls(Content.Load<Texture2D>("roomwalls"), batch, center);
            ADoor[] doorList1 = new ADoor[] {
                doorFactory.CreateDoorSprite(DoorFactory.Door.Open, DoorFactory.Side.Left),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Open, DoorFactory.Side.Top),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Open, DoorFactory.Side.Right),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Open, DoorFactory.Side.Bottom)
            };
            List<IEnemySprite> enemyList1 = new List<IEnemySprite> {
                new enemyGel(enemyTexture, batch, temp,_player),
                new enemyGoriya(enemyTexture, batch, temp)
            };
            AItem[] itemList1 = new AItem[] {
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Arrow, new Vector2(128+128, 128)),
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Bomb, new Vector2(128+64+128, 128))
            };
            ITile[] tileList1 = new ITile[]
            {
                new BrickTile(Content.Load<Texture2D>("bricks"), batch, new Vector2(128, 128)),
                new SandTile(Content.Load<Texture2D>("sandtile"), batch, new Vector2(128+64, 128)),
                tile1,
                tile2
            };
            roomList[0] = new Room(roomWalls1, doorList1, enemyList1, itemList1, tileList1, Player);

            //room 2///////////////////////////////////////////////////////////////////////////////
            ITile roomWalls2 = new RoomWalls(Content.Load<Texture2D>("roomwalls"), batch, center);
            ADoor[] doorList2 = new ADoor[] {
                doorFactory.CreateDoorSprite(DoorFactory.Door.Wall, DoorFactory.Side.Left),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Wall, DoorFactory.Side.Top),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Wall, DoorFactory.Side.Right),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Wall, DoorFactory.Side.Bottom)
            };
            List<IEnemySprite> enemyList2 = new List<IEnemySprite> {
                new enemyBat(enemyTexture, batch, temp,_player),
                new enemyHand(enemyTexture, batch, temp,_player)
            };
            AItem[] itemList2 = new AItem[] {
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Bow, new Vector2(128+128, 128)),
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Clock, new Vector2(128+128+64, 128))
            };
            ITile[] tileList2 = new ITile[]
            {
                new SilverLinesTile(Content.Load<Texture2D>("silverlines"), batch, new Vector2(128, 128)),
                new SolidBlackTile(Content.Load<Texture2D>("solid black tile"), batch, new Vector2(128+64, 128)),
                new SolidBlueTile(Content.Load<Texture2D>("solid blue tile"), batch, new Vector2(128, 128+64))
            };
            roomList[1] = new Room(roomWalls2, doorList2, enemyList2, itemList2, tileList2, Player);

            //room 3///////////////////////////////////////////////////////////////////////////////
            ITile roomWalls3 = new RoomWalls(Content.Load<Texture2D>("roomwalls"), batch, center);
            ADoor[] doorList3 = new ADoor[] {
                doorFactory.CreateDoorSprite(DoorFactory.Door.Locked, DoorFactory.Side.Left),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Locked, DoorFactory.Side.Top),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Locked, DoorFactory.Side.Right),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Locked, DoorFactory.Side.Bottom)
            };
            List<IEnemySprite> enemyList3 = new List<IEnemySprite> {
                new enemyHand(enemyTexture, batch, temp,_player),
                new enemySkeleton(enemyTexture, batch, temp,_player)
            };
            AItem[] itemList3 = new AItem[] {
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Compass, new Vector2(128+128, 128)),
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Fairy, new Vector2(128+64+128, 128))
            };
            ITile[] tileList3 = new ITile[]
            {
                new SolidNavyTile(Content.Load<Texture2D>("solid navy tile"), batch, new Vector2(128, 128)),
                new StairsTile(Content.Load<Texture2D>("stairs"), batch, new Vector2(128+64, 128)),
                new StatueTile1(Content.Load<Texture2D>("statue1"), batch, new Vector2(128+128, 128))
            };
            roomList[2] = new Room(roomWalls3, doorList3, enemyList3, itemList3, tileList3, Player);

            //room 4/////////////////////////////////////////////////////////////////////////////
            ITile roomWalls4 = new RoomWalls(Content.Load<Texture2D>("roomwalls"), batch, center);
            ADoor[] doorList4 = new ADoor[] {
                doorFactory.CreateDoorSprite(DoorFactory.Door.Hole, DoorFactory.Side.Left),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Hole, DoorFactory.Side.Top),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Hole, DoorFactory.Side.Right),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Hole, DoorFactory.Side.Bottom)
            };
            List<IEnemySprite> enemyList4 = new List<IEnemySprite> {
                new oldMan(npcTexture, batch, temp),
                new bossDragon(dragonTexture, batch, temp)
            };
            AItem[] itemList4 = new AItem[] {
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Heart, new Vector2(128+128, 128)),
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.HeartContainer, new Vector2(128+64+128, 128))
            };
            ITile[] tileList4 = new ITile[]
            {
                new StatueTile2(Content.Load<Texture2D>("statue2"), batch, new Vector2(128, 128)),
                new StatueTile2(Content.Load<Texture2D>("tile with square in middle"), batch, new Vector2(128+64, 128))
            };
            roomList[3] = new Room(roomWalls4, doorList4, enemyList4, itemList4, tileList4, Player);

            //room 5////////////////////////////////////////////////////////////////////////////
            ITile roomWalls5 = new RoomWalls(Content.Load<Texture2D>("roomwalls"), batch, center);
            ADoor[] doorList5 = new ADoor[] {
                doorFactory.CreateDoorSprite(DoorFactory.Door.Closed, DoorFactory.Side.Left),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Closed, DoorFactory.Side.Top),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Closed, DoorFactory.Side.Right),
                doorFactory.CreateDoorSprite(DoorFactory.Door.Closed, DoorFactory.Side.Bottom)
            };
            List<IEnemySprite> enemyList5 = new List<IEnemySprite>
            {
                
            };
            AItem[] itemList5 = new AItem[] {
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Key, new Vector2(128+128, 128)),
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Map, new Vector2(128+64+128, 128)),
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Rupee, new Vector2(128+128, 128+64)),
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.TriforcePiece, new Vector2(128+64+128, 128+64)),
                itemFactory.CreateItemSprite(ItemSpriteFactory.Item.WoodenBoomerang, new Vector2(128+128+128, 128))
            };
            ITile[] tileList5 = new ITile[]
            {
                new LeftFire(Content.Load<Texture2D>("LeftFire"), batch, new Vector2(128, 128)),
                new RightFire(Content.Load<Texture2D>("RightFire"), batch, new Vector2(128+64, 128)),
                new Text(Content.Load<Texture2D>("textsprite"), batch, new Vector2(128, 128+64+128))
            };
            roomList[4] = new Room(roomWalls5, doorList5, enemyList5, itemList5, tileList5, Player);




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
		}

		public void LoadRooms()
		{
            



        }

        public Room StartRoom() {
            return roomList[0];
        }


    public Room SwitchRoom()
		{
            if (currentRoom < numRooms-1) {
                currentRoom++;
            }
            else {
                currentRoom = 0;
            }
            return roomList[currentRoom];
		}

	}
}