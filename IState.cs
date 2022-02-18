using System;
using Sprint0;

public interface IState 
{
		void ChangeDirection();
		void Update();
		void Attack();
		void UseItem(IProjectile proj) { return; }
}
