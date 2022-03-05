using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace Sprint0.DoorClass
{
	public class DoorFactory
	{
		private Texture2D doorSheet;
		private SpriteBatch batch;
		private int currentItem;

		public enum Door
		{
			Wall = 0,
			Open = 1,
			Locked = 2,
			Closed = 3,
			Hole = 4
		}

		public enum Side
		{
			Top = 0,
			Left = 1,
			Right = 2,
			Bottom = 3
		}

		private static DoorFactory instance = new DoorFactory();

		public void setBatch(SpriteBatch aBatch)
		{
			batch = aBatch;
		}

		public static DoorFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private DoorFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			doorSheet = content.Load<Texture2D>("Doors");

		}


		public ADoor CreateDoorSprite(Door doorNum, Side doorSide)
		{
			switch (doorNum)
			{
				case Door.Wall:
					return new DoorWall(doorSheet, batch, doorSide);
				case Door.Open:
					return new DoorOpen(doorSheet, batch, doorSide);
				case Door.Locked:
					return new DoorLocked(doorSheet, batch, doorSide);
				case Door.Closed:
					return new DoorClosed(doorSheet, batch, doorSide);
				case Door.Hole:
					return new DoorHole(doorSheet, batch, doorSide);
				default:
					return new DoorWall(doorSheet, batch, doorSide);
			}
		}

	}
}
