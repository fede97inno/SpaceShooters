using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class Bullet
    {
        private Vector2 velocity;
        private Sprite sprite;
        private Texture texture;
        public bool IsAlive;

        public Bullet()
        {
            velocity = new Vector2(500,0);
            texture = new Texture("Assets/rocketman.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.pivot = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            IsAlive = false;
        }
        public Vector2 SpritePos { get { return sprite.position; } set { sprite.position = value; } }
        //public bool IsAlive { get { return isAlive; }}
        public void Update()
        {
            if (IsAlive)
            {
            sprite.position += velocity * Game.DeltaTime;
            }
        }

        public void Draw()
        {
            if (IsAlive)
            {
                sprite.DrawTexture(texture);
            }
        }
    }
}
