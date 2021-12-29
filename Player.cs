using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
namespace SpaceShooter
{
    class Player
    {
        private Sprite sprite;
        private Texture texture;

        private Vector2 velocity;
        private float speed;
        
        private bool isAlive;
        private bool spacePressed;
        public Vector2 Position { 
            get
            {
                return sprite.position; 
            }
            set 
            {
                sprite.position = value;
            }
        }
        public Player()
        {
            texture = new Texture("Assets/player_ship.png");
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.pivot = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            isAlive = true;
            speed = 250.0f;

            spacePressed = false;
        }

        public void Input()
        {
            if (Game.Win.GetKey(KeyCode.W) && sprite.position.Y - sprite.Height * 0.5f >= 0)
            {
                velocity.Y = -speed;
            }
            else if(Game.Win.GetKey(KeyCode.S) && sprite.position.Y + sprite.Height * 0.5f <= Game.Win.Height)
            {
                velocity.Y = speed;
            }
            else
            {
                velocity.Y = 0;
            }

            if (Game.Win.GetKey(KeyCode.A) && sprite.position.X - sprite.Width * 0.5f >= 0)
            {
                velocity.X = -speed;
            }
            else if (Game.Win.GetKey(KeyCode.D) && sprite.position.X + sprite.Width * 0.5f <= Game.Win.Width)
            {
                velocity.X = speed;
            }
            else
            {
                velocity.X = 0;
            }
            if (Game.Win.GetKey(KeyCode.Esc))
            {
                Game.Win.Close();
            }

            if (Game.Win.GetKey(KeyCode.Space))
            {
                Bullet b = BulletMngr.GetFreeBullet();
                if (spacePressed)
                {
                    return;
                }
                if (b != null)
                {
                    b.SpritePos = new Vector2(sprite.position.X + texture.Width * 0.5f, sprite.position.Y);
                    b.IsAlive = true;
                    spacePressed = true;
                }
            }
            else
            {
                spacePressed = false;
            }
        }

        public void Update()
        {
            if (velocity.X != 0 && velocity.Y != 0)
            {
                velocity = velocity.Normalized()*speed;
            }

            sprite.position += velocity * Game.DeltaTime;
       
        }

        public void Draw()
        {
            if (isAlive)
            {
                sprite.DrawTexture(texture);
            }
        }
    }
}
