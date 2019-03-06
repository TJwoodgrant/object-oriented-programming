using System;
using System.Collections.Generic;
using SwinGameSDK;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Drawing
    {

        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this(Color.White)
        {

        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void Draw()
        {
            SwinGame.ClearScreen(_background);
            foreach(Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        public void SelectShapesAt(Point2D point)
        {
            foreach(Shape s in _shapes)
            {
                s.Selected = s.IsAt(point);
            }
        }


        /* ----------------------------------
                      Properties
        .  ----------------------------------*/

        public int ShapeCount
        {
            get { return _shapes.Count;  }
        }

        public List<Shape> SelectedShapes()
        {
            List<Shape> _selectedShapes = new List<Shape>;
            foreach(Shape s in _shapes)
            {
                if (s.Selected)
                    _selectedShapes.Add(s);
            }

            return _selectedShapes;
        }
        


        public Color Background
        {
            get {  return _background; }
            set { _background = value; }
        }

    }
}
