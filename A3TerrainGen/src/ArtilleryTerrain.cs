using System;
using System.Globalization;
using System.IO;
using SwinGameSDK;


namespace ArtillerySeries.src
{
    public static class ExtensionMethods
    {
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }
    }


    public class ArtilleryTerrain
    {
        
    

        public static void Main()
        {
            Rectangle _windowRect = new Rectangle()
            {
                Width = 540,
                Height = 300
            };

            Rectangle _terrainBox = new Rectangle()
            {
                Width = _windowRect.Width,
                Height = _windowRect.Height
            };

            SwinGame.OpenGraphicsWindow("Artillery Terrain Generation", (int)_windowRect.Width, (int)_windowRect.Height);
            SwinGame.LoadFontNamed("mainFont","maven_pro_regular.ttf", 14);

            Terrain _terrain;
            TerrainFactory _terrainFactory;
            float reduction = 0.45f;

            _terrainFactory = new TerrainFactoryMidpoint(_windowRect, _terrainBox);

            _terrain = _terrainFactory.Generate(Color.ForestGreen, 180, reduction);


            SwinGame.StartReadingText(Color.Black, 20, SwinGame.FontNamed("mainFont"), 10, 10);

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

                
                

                if (!SwinGame.ReadingText())
                {
                    reduction = float.Parse(SwinGame.EndReadingText(), CultureInfo.InvariantCulture.NumberFormat);
                    _terrain = _terrainFactory.Generate(Color.ForestGreen, 180, reduction);
                    SwinGame.StartReadingText(Color.Black, 20, SwinGame.FontNamed("mainFont"), 10, 10);
                }

                SwinGame.DrawText("Current Reduction value:" + reduction, Color.Black, SwinGame.FontNamed("mainFont"), 10, 30);
                _terrain.Draw();

                //SwinGame.DrawFramerate(0,0);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}