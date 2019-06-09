using System;
using System.Globalization;
using System.IO;
using SwinGameSDK;
using Newtonsoft.Json;



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
            string _message = "Current Reduction value:" + reduction;

            SwinGame.StartReadingText(Color.Black, 20, SwinGame.FontNamed("mainFont"), 10, 10);

            StreamWriter _writer;
            StreamReader _reader;

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

                
                

                if (!SwinGame.ReadingText())
                {
                    try
                    {
                        string input = SwinGame.EndReadingText();
                        string[] commands = input.Split(' ');
                        switch (commands[0])
                        {
                            case "coef":
                                reduction = float.Parse(commands[1], CultureInfo.InvariantCulture.NumberFormat);
                                _terrain = _terrainFactory.Generate(Color.ForestGreen, 180, reduction);
                                _message = "Current Reduction value:" + reduction;
                                break;

                            case "save":
                                Console.WriteLine("Saving!");
                                _writer = new StreamWriter(commands[1] + ".json");
                                try
                                {
                                    _writer.Write(JsonConvert.SerializeObject(_terrain));
                                }
                                finally
                                {
                                    _writer.Close();
                                }
                                _message = "Saved " + commands[1] + ".json";


                                break;

                            case "load":
                                Console.WriteLine("Loading!");
                                _reader = new StreamReader(commands[1] + ".json");
                                try
                                {
                                    _terrain = JsonConvert.DeserializeObject<Terrain>(_reader.ReadToEnd());
                                    _terrain.WindowRect = _windowRect;
                                    _terrain.Color = Color.ForestGreen;
                                }
                                finally
                                {
                                    _reader.Close();
                                }

                                _message = "Loaded " + commands[1] + ".json";

                                break;

                        }
                        int x = 0;
                    }
                    catch (Exception e)
                    {
                        _message = ("Error in input:" + e.Message);
                        Console.WriteLine(_message);
                    }
                    
                    SwinGame.StartReadingText(Color.Black, 20, SwinGame.FontNamed("mainFont"), 10, 10);
                }

                _terrain.Draw();
                SwinGame.FillRectangle(Color.White, 8, 8, 200, 40);
                SwinGame.DrawText(_message, Color.Black, SwinGame.FontNamed("mainFont"), 10, 30);
                

                //SwinGame.DrawFramerate(0,0);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}