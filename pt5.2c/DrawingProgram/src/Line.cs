using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    class Line : Shape
    {
        private int _length;

        public Line(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Color = Color.MistyRose;
            _length = 100;

        }

        public Line() : this(0, 0)
        {
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_length);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _length = reader.ReadInteger();
        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SwinGame.DrawLine(this.Color,
                                    this.X, this.Y, this.X + _length, this.Y);
        }

        public override void DrawOutline()
        {
            SwinGame.FillRectangle(Color.Black,
                                    this.X - 2, this.Y - 1,
                                    _length + 5, 3);
        }

        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, SwinGame.CreateRectangle(this.X, this.Y, this.X + _length, this.Y));
        }
    }
}
