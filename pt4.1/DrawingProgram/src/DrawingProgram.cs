using System;
using SwinGameSDK;

namespace MyGame
{
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
                        Circle newCircle = new Circle();
                        newCircle.X = x;
                        newCircle.Y = y;
                        newShape = newCircle;
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        Line newLine = new Line();
                        newLine.X = x;
                        newLine.Y = y;
                        newShape = newLine;
                    } else
                    {
                        Rectangle newRect = new Rectangle();
                        newRect.X = x;
                        newRect.Y = y;
                        newShape = newRect;
                    }

                    myDrawing.AddShape(newShape);
                }


                if(SwinGame.KeyDown(KeyCode.LKey))
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