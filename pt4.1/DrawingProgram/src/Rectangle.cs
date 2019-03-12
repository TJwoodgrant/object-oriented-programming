using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    class Rectangle : Shape
    {
        private int _width, _height;

        public Rectangle(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Color = Color.Green;
            _width = 100;
            _height = 100;

        }
        
        public Rectangle() : this(0, 0)
        {
        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SwinGame.FillRectangle(this.Color,
                                    this.X, this.Y,
                                    _width, _height);
        }

        public override void DrawOutline()
        {
            SwinGame.FillRectangle(Color.Black,
                                    this.X - 2, this.Y - 2,
                                    _width + 4, _height + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, SwinGame.CreateRectangle(this.X, this.Y, _width, _height));
        }
    }
}
