using System;
using SwinGameSDK;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyGame
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;
        private bool _selected;



        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        public float X
        {
            get => _x;
            set => _x = value;
        }

        public float Y
        {
            get => _y;
            set => _y = value;
        }


        public bool Selected
        {
            get => _selected;
            set => _selected = value;
        }

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(_color.ToArgb());
            writer.WriteLine(_x);
            writer.WriteLine(_y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            _color = Color.FromArgb(reader.ReadInteger());
            _x = reader.ReadInteger();
            _y = reader.ReadInteger();

        }

        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract bool IsAt(Point2D pt);

    }
}
