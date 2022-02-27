using System;
using System.Collections.Generic;
using System.Text;


namespace Sprint0.Collision
{
    class SortSweep : ICollision 
    {
        Game1 myGame;
        private List<CollisionObject> xList; 
        SortSweep(Game1 g) {
            myGame = g; 
        }
        public void HandleCollisions()
        {
            loadLists()
            sortX()
            sortY()
            assignHandlers();
            return; 
        }

        private void loadLists()

    }
}
