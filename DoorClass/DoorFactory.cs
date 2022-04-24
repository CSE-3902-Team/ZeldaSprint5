﻿using Microsoft.Xna.Framework;
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
			Hole = 4,
			WeakWall = 5,
			Invisible = 6
		}

		public enum Side
		{
			Top = 0,
			Left = 1,
			Right = 2,
			Bottom = 3,
			Floor = 4,
			Ceiling = 5
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

		public DoorFactory.Door getDoor(string key)
		{
			if (key.Contains("WeakWall"))
			{
				return Door.WeakWall;
			}
			else if (key.Contains("Normal"))
			{
				return Door.Open;
			}
			else if (key.Contains("Key"))
			{
				return Door.Locked;
			}
			else if (key.Contains("Hole"))
			{
				return Door.Hole;
			}
			else if (key.Contains("Gate"))
			{
				return Door.Closed;
			}
			else if (key.Contains("Wall")) 
			{
				return Door.Wall;
			}
			else if (key.Contains("Invisible"))
			{
				return Door.Invisible;
			}
			else
			{
				throw new ArgumentException(key + " is not a door type");
			}
		}

		public DoorFactory.Side getSide(string key)
		{
			if (key.Contains("top"))
			{
				return Side.Top;
			}
			else if (key.Contains("left"))
			{
				return Side.Left;
			}
			else if (key.Contains("right"))
			{
				return Side.Right;
			}
			else if (key.Contains("bottom"))
			{
				return Side.Bottom;
			}
			else if (key.Contains("ceiling"))
			{
				return Side.Ceiling;
			}
			else
			{
				throw new ArgumentException(key + " does not contain a side type");
			}
		}

		public bool isADoor(string key)
		{
			if (key.Contains("Door") || key.Contains("WeakWall"))
			{
				return true;
			}
			else
            {
				return false;
            }
		}


		public ADoor CreateDoorSprite(Door doorNum, Side doorSide, int roomConnection)
		{
			switch (doorNum)
			{
				case Door.Wall:
					return new DoorWall(doorSheet, batch, doorSide);
				case Door.Open:
					return new DoorOpen(doorSheet, batch, doorSide, roomConnection);
				case Door.Locked:
					return new DoorLocked(doorSheet, batch, doorSide, roomConnection);
				case Door.Closed:
					return new DoorClosed(doorSheet, batch, doorSide, roomConnection);
				case Door.Hole:
					return new DoorHole(doorSheet, batch, doorSide, roomConnection);
				case Door.WeakWall:
					return new WeakWall(doorSheet, batch, doorSide, roomConnection);
				case Door.Invisible:
					return new DoorInvisible(doorSheet, batch, doorSide, roomConnection);
				default:
					return new DoorWall(doorSheet, batch, doorSide);
			}
		}

		public static Side InvertSide(Side target)
		{
			if (target == Side.Top)
			{
				return Side.Bottom;
			}
			else if (target == Side.Bottom)
			{
				return Side.Top;
			}
			else if (target == Side.Left)
			{
				return Side.Right;
			}
			else
			{
				return Side.Left;
			}
		}
	}
}
