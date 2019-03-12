using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame.src
{
    class Rectangle : Shape
    {
        private int _width, _height;

        public Rectangle(int x, int y)
        {
            _x = x;

        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void DrawOutline()
        {
            throw new NotImplementedException();
        }

        public override bool IsAt(Point2D pt)
        {
            throw new NotImplementedException();
        }
    }
}
