using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    static class BulletMngr
    {
        private static Bullet[] bullets;
        private static int maxBullets;

        static BulletMngr()
        {
            maxBullets = 10;
            bullets = new Bullet[maxBullets];
            for (int i = 0; i < maxBullets; i++)
            {
                bullets[i] = new Bullet();
            }
        }

        public static Bullet GetFreeBullet()
        {
            for (int i = 0; i < maxBullets; i++)
            {
                if (!bullets[i].IsAlive)
                {
                    return bullets[i];
                }
            }
            return null;
        }

        public static void Update()
        {
            for (int i = 0; i < maxBullets; i++)
            {
                if (bullets[i].IsAlive && bullets[i].SpritePos.X <= Game.Win.Width)
                {
                    bullets[i].Update();
                }
                else
                {
                    bullets[i].IsAlive = false;
                }
            }
        }

        public static void Draw()
        {
            for (int i = 0; i < maxBullets; i++)
            {
                if (bullets[i].IsAlive)
                {
                    bullets[i].Draw();
                }
            }
        }
    }
}
