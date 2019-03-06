using System;
using System.Collections.Generic;
using SwinGameSDK;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.src
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


        /* ----------------------------------
                      Properties
        .  ----------------------------------*/

        public int ShapeCount
        {
            get { return _shapes.Count;  }
        }
        


        public Color Background
        {
            get {  return _background; }
            set { _background = value; }
        }

    }
}
