using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
namespace SpaceShooter
{
    static class Game
    {
        static Window window;
        static Player player;
        static Background background;
        public static void Init()
        {
            window = new Window(1280, 720,"SpaceShooter");
            player = new Player();
            player.Position = new Vector2(100, window.Height * 0.5f);
            background = new Background();
        }

        public static float DeltaTime { get { return window.DeltaTime; } }
        public static Window Win { get { return window; } }
        public static void Play()
        {
            while (window.IsOpened)
            {
                //INPUT 
                player.Input();
                //UPDATE
                background.Update();
                BulletMngr.Update();
                player.Update();
                //DRAW
                background.Draw();
                BulletMngr.Draw();
                player.Draw();
                window.Update();
            }
        }
    }
}
