using Microsoft.Xna.Framework;

namespace Sprint0.enemy
{

    class EnemyProjectile
    {
        private Vector2 movement;
        private Vector2 Pos;
        int destinationX;
        int destinationY;
        private int result;
        private int FrameCount;
        private Vector2 projectilePos;
        public EnemyProjectile(Vector2 direction, Vector2 currentPos, Vector2 destination, Vector2 ProjectilePos, int frameCount, int projectileFrame)

        {
            this.destinationX = (int)destination.X;
            this.destinationY = (int)destination.Y;
            this.movement = direction;
            this.Pos = currentPos;
            this.projectilePos = ProjectilePos;
            this.result = projectileFrame;
            this.FrameCount = frameCount;
        }

        public Vector2 GoriyaFire()
        {



            if (FrameCount < 100)
            {
                switch (movement.X)
                {

                    case 0:
                        if (Pos.Y < destinationY)

                            projectilePos.Y += 2;
                        else if (Pos.Y > destinationY)
                            projectilePos.Y -= 2;

                        break;
                    case 1:
                        if (Pos.X < destinationX)
                        {
                            projectilePos.X += 2;
                        }
                        else if (Pos.X > destinationX)
                        {
                            projectilePos.X -= 2;
                        }
                        break;
                }
            }
            //after the boomerang reaches the destination, it will fly back, similar logic as above, but the projectile's y and x are decreasing this time
            else if (FrameCount >= 100)
            {
                switch (movement.X)
                {

                    case 0:
                        if (Pos.Y < destinationY)

                            projectilePos.Y -= 2;
                        else if (Pos.Y > destinationY)
                            projectilePos.Y += 2;

                        break;
                    case 1:
                        if (Pos.X < destinationX)
                        {
                            projectilePos.X -= 2;
                        }
                        else if (Pos.X > destinationX)
                        {
                            projectilePos.X += 2;
                        }
                        break;
                }
            }
            return projectilePos;
        }

        public int ProjectileFrameChange()
        {
            if (FrameCount % 3 == 0)
            {
                result++;
                if (result > 2)
                    result = 0;
            }
            return result;
        }
        public Vector2 DragonFire()
        {

            return Pos;
        }
    }
}

