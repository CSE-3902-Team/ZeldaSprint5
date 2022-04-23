using System;
using Sprint0;

public interface IPlayerState 
{
		void ChangeDirection(Player.Directions dir);
		void Update();
		void Attack();
		void UseItem() { return; }
		void DamageLink(Player.Directions dir);
}
