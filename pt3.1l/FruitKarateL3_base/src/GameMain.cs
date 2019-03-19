using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {

			FruitKarate _game = new FruitKarate ();

            SwinGame.OpenAudio();

            //Open the game window
            SwinGame.OpenGraphicsWindow("Fruit Karate", 800, 600);
            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                // check user input - space to launch fruit
                if(SwinGame.KeyTyped (KeyCode.SpaceKey))
                {
                    _game.LaunchFruit ();
                }

                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                    _game.PunchFruit(SwinGame.MousePosition());

                // check user input - click to punch fruit


                // update the postition and velocity of fruit
                _game.Update ();

                //draw the fruit
                _game.Draw ();

                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }

            SwinGame.CloseAudio();
            SwinGame.ReleaseAllResources();

        }
    }
}