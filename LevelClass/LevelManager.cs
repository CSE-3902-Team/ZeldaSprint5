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

namespace Sprint0.LevelClass
{
	public class LevelManager
	{
		private SpriteBatch batch;
		private Room[] roomList;
        private int currentRoom;
        private int numRooms;

		private ItemSpriteFactory itemFactory;
		private DoorFactory doorFactory;
        private EnemyFactory enemyFactory;
        private TileFactory tileFactory;
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



        //these need to be gotten rid of

        private Texture2D playerTexture;
        private Texture2D projectileTexture;

        
        


        private static LevelManager instance = new LevelManager();

		public void initialize(SpriteBatch aBatch, ContentManager Content, ICollision collider, Vector2 center)
		{
			itemFactory = ItemSpriteFactory.Instance;
			doorFactory = DoorFactory.Instance;
            enemyFactory = EnemyFactory.Instance;
			batch = aBatch;
            this.center = center;
            currentRoom = 0;
            numRooms = 5;
            roomList = new Room[numRooms];

            playerTexture = Content.Load<Texture2D>("playerSheet");
            projectileTexture = Content.Load<Texture2D>("itemsAndWeapons1");
            _player = new Player(playerTexture, batch, new ProjectileBomb(projectileTexture, batch, new Vector2(140, 200), new Vector2(1, 0)), new Vector2(100, 200), Content.Load<Texture2D>("solid navy tile"));




            





            //load everything with the items shown on screen
            itemFactory.LoadAllTextures(Content);
            itemFactory.setBatch(batch);
            doorFactory.LoadAllTextures(Content);
            doorFactory.setBatch(batch);
            

            


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
            

            //roomWalls = new RoomWalls(Content.Load<Texture2D>("roomwalls"), batch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            roomWalls = new RoomWalls(Content.Load<Texture2D>("roomwalls"), batch, center);





            

            




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