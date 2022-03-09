using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.LevelClass;

namespace Sprint0.Command
{
    class AddProjectileToLevel : ICommand
    {
        private readonly LevelManager manager;
        private IProjectile stagedProjectile;
        
        public void LoadCommand(Object obj)
        {
            stagedProjectile = obj as IProjectile;
        }
        public AddProjectileToLevel(LevelManager m)
        {
            manager = m; 
        }

        public void Execute()
        {
            manager.CurrentRoom.ProjectileList.Add(stagedProjectile);
            manager.CurrentRoom.ColliderDetector.AddToList(stagedProjectile as IBoxCollider);
        }
    }
}
