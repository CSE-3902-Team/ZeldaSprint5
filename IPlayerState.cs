using System;
using Sprint0;

public interface IPlayerState 
{
		void ChangeDirection(Player.Directions dir);
		void Update();
		void Attack();
        void UseItem(IProjectile proj) { return; }
		void DamageLink(Player.Directions dir);
}
