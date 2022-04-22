using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.LevelClass;

namespace Sprint0.Projectile
{
    class ProjectileFactory
    {
        Texture2D projectileTexture;
        SpriteBatch batch;
        LevelManager manager;

        public ProjectileFactory(Texture2D t, SpriteBatch s, LevelManager m) 
        {
            projectileTexture = t;
            batch = s;
            manager = m;
        }
        public enum PNames{
            PBomb,
            PBoomerang,
            PSpecialBoomerang,
            PNormalArrow,
            PSpecialArrow,
            PFireball,
            PSword,
            Bomb,
        }

        public void LauchProjectile(PNames projectileName, Vector2 startPosition,Vector2 direction) 
        {
            IProjectile stagedProjectile;
            switch (projectileName) {
                case PNames.PBomb:
                    stagedProjectile = new ProjectilePlayerBomb(projectileTexture, batch, startPosition, direction);
                    break;
                case PNames.Bomb:
                    stagedProjectile = new ProjectileBomb(projectileTexture, batch, startPosition, direction);
                    break;
                case PNames.PBoomerang:
                    stagedProjectile = new ProjectilePlayerBoomerang(projectileTexture, batch, startPosition, direction);
                    break;
                case PNames.PFireball:
                    stagedProjectile = new ProjectilePlayerFireball(projectileTexture, batch, startPosition, direction);
                    break;
                case PNames.PNormalArrow:
                    stagedProjectile = new ProjectilePlayerNormalArrow(projectileTexture, batch, startPosition, direction);
                    break;
                case PNames.PSpecialArrow:
                    stagedProjectile = new ProjectilePlayerSpecialArrow(projectileTexture, batch, startPosition, direction);
                    break;
                case PNames.PSpecialBoomerang:
                    stagedProjectile = new ProjectilePlayerSpecialBoomerang(projectileTexture, batch, startPosition, direction);
                    break;
                case PNames.PSword:
                    stagedProjectile = new ProjectilePlayerSword(startPosition, ConvertToPlayerDirection(direction));
                    break;
                default:
                    stagedProjectile = new ProjectilePlayerSword(startPosition, ConvertToPlayerDirection(direction));
                    break;
            }
            AddProjectileToLevel(stagedProjectile);
        }

        private Player.Directions ConvertToPlayerDirection(Vector2 dir) 
        {
            if (dir.X == 1) { return Player.Directions.Right; }
            if (dir.X == -1) { return Player.Directions.Left; }
            if (dir.Y == 1) { return Player.Directions.Down; }
            if (dir.Y == 1) { return Player.Directions.Up; }
            throw new ArgumentException(message: "Direction doesn't convert to Player direction", paramName: nameof(dir));
        }

        private void AddProjectileToLevel(IProjectile stagedProjectile) 
        {
            manager.CurrentRoom.ProjectileList.Add(stagedProjectile);
            manager.CurrentRoom.ColliderDetector.AddToList(stagedProjectile as IBoxCollider);
        }
    }
}
