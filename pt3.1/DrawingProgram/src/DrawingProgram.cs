using System;
using SwinGameSDK;

namespace MyGame
{
    public class DrawingProgram
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("DrawingProgram", 1600, 900);
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

                if (SwinGame.KeyDown(KeyCode.SpaceKey))
                {
                    if (myShape.IsAt(SwinGame.MousePosition()))
                    {
                        myShape.Color = SwinGame.RandomRGBColor(255);
                    }
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