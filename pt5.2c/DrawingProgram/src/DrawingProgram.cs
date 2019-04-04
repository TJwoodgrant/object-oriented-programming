using System;
using System.IO;
using SwinGameSDK;

//At about 18 of 5.2C

namespace MyGame
{
    public static class ExtensionMethods
    {
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }
    }


    public class DrawingProgram
    {

        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }


        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("DrawingProgram", 1600, 900);
            SwinGame.ShowSwinGameSplashScreen();


            ShapeKind kindToAdd = ShapeKind.Circle;

            Drawing myDrawing = new Drawing();


            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    int x = (int)SwinGame.MouseX();
                    int y = (int)SwinGame.MouseY();

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        Circle newCircle = new Circle();;
                        newShape = newCircle;
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        Line newLine = new Line();
                        newShape = newLine;
                    } else
                    {
                        Rectangle newRect = new Rectangle();
                        newShape = newRect;
                    }
                    newShape.X = x;
                    newShape.Y = y;
                    myDrawing.AddShape(newShape);
                }


                if (SwinGame.KeyDown(KeyCode.SKey))
                {
                    myDrawing.Save("C:\\Users\\Mikan\\Desktop\\TestDrawing.txt");
                }

                if (SwinGame.KeyDown(KeyCode.OKey))
                {
                   myDrawing.Load("C:\\Users\\Mikan\\Desktop\\TestDrawing.txt");
                    
                }

                if (SwinGame.KeyDown(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SwinGame.KeyDown(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SwinGame.KeyDown(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SwinGame.KeyDown(KeyCode.SpaceKey))
                {
                   myDrawing.Background = SwinGame.RandomRGBColor(255);
                }

                if (SwinGame.KeyDown(KeyCode.DeleteKey)  || SwinGame.KeyDown(KeyCode.BackspaceKey))
                {
                    myDrawing.DeleteSelectedShapes();
                }

                if (SwinGame.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SwinGame.MousePosition());
                }




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