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


            Drawing myDrawing = new Drawing();


            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    myDrawing.AddShape(new Shape((int)SwinGame.MousePosition().X, (int)SwinGame.MousePosition().Y));
                }

                if (SwinGame.KeyDown(KeyCode.SpaceKey))
                {
                   myDrawing.Background = SwinGame.RandomRGBColor(255);
                }

                //Step 19

                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
               
                myDrawing.Draw();

                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}