using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
namespace SpaceShooter
{
    class Background
    {
        private Texture texture;
        private Sprite sprite;
        private Sprite sprite2;
        private float speed;
        private float offset;
        public Background()
        {
            texture = new Texture("Assets/spaceBg.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite2 = new Sprite(texture.Width, texture.Height);
            speed = 250.0f;
            offset = texture.Width - Game.Win.Width;
            sprite2.position.X = texture.Width;
        }
        public void Update()
        {
            sprite.position.X -= speed * Game.Win.DeltaTime;
            sprite2.position.X -= speed * Game.Win.DeltaTime;
            if (sprite.position.X <= -texture.Width)
            {
                sprite.position.X = sprite2.position.X + texture.Width;
            }
            if (sprite2.position.X <= -texture.Width)
            {
                sprite2.position.X = sprite.position.X + texture.Width;
            }
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
            sprite2.DrawTexture(texture);
        }
    }
}
