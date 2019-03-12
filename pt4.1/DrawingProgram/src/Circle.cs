using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    class Circle : Shape
    {
        private int _radius;

        public Circle(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Color = Color.LightBlue;
            _radius = 50;

        }

        public Circle() : this(0, 0)
        {
        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SwinGame.FillCircle(this.Color,
                                    this.X, this.Y,
                                    _radius);
        }

        public override void DrawOutline()
        {
            SwinGame.FillCircle(Color.Black,
                                    this.X, this.Y,
                                    _radius + 2 );
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInCircle(pt, SwinGame.CreateCircle(this.X, this.Y, _radius));
        }
    }
}
