using System;
using SwinGameSDK;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;

        public Shape(int x, int y)
        {
            _color = Color.Green;
            _x = x;
            _y = y;
            _width = 100;
            _height = 100;

        }

        public Shape() : this(0, 0)
        {

        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public bool Selected { get => _selected; set => _selected = value; }

        public void Draw()
        {
            if (Selected)
                DrawOutline();
            SwinGame.FillRectangle(_color,
                                    _x, _y,
                                    _width, _height);

        }

         void DrawOutline()
        {
            SwinGame.FillRectangle(Color.Black,
                                    _x-2, _y-2,
                                    _width+2, _height+2);
        }

        public bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, SwinGame.CreateRectangle(_x, _y, _width, _height));
        }

    }
}
