using Microsoft.Xna.Framework;

namespace Sprint0.PlayerClass
{
    public class PlayerUpDamage : IState
    {
        private Player player;
        private int currentFrame;

        public PlayerUpDamage(Player instance)
        {
            player = instance;
            currentFrame = 1;
        }

        public void ChangeDirection(Player.Directions dir)
        {
            //Only should be able to move after a certain amount of frames afterwards it should blink..but what about
            //transitioning states and carrying over the blink the time. Might have to be a instance variable for damaged time
            //Only real reason to have a state is for the knockback. Kinda violates the state machine but that's all I can do
            //k
            return;
        }

        public void Update()
        {
            player.Speed = Player.KNOCKBACK_SPEED;
            if (currentFrame <= Player.DAMAGED_DURATION / 2)
            {
                player.SourceRectangle = new Rectangle(789, 93, 113, 150);
                player.DrawOffset = new Vector2(0, 0);
            }
            else if (currentFrame <= Player.DAMAGED_DURATION)
            {
                player.SourceRectangle = new Rectangle(637, 93, 133, 161);
                player.DrawOffset = new Vector2(0, 0);
            }
            else
            {
                player.Speed = Player.MOVE_SPEED;
                player.State = new PlayerUpIdle(player);
            }
            currentFrame++;
            player.Move(0, 1);
        }


        public void Attack()
        {
            return;
        }
    }
}