using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();

            Shape myShape = new Shape();




            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X  = SwinGame.MousePosition().X;
                    myShape.Y  = SwinGame.MousePosition().Y;
                }



                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
               
                myShape.Draw();

                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}