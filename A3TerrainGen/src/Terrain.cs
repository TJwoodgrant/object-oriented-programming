using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace ArtillerySeries.src
{
    public class Terrain
    {
        float[] _terrainMap; 
        Rectangle _windowRect;
        Point2D _pos;
        private Color _color;
        

        public Terrain(Rectangle windowRect)
        {
            _windowRect = windowRect;
            _pos = new Point2D();
        }

        public float[] Map { get => _terrainMap; set => _terrainMap = value; }
        public Color Color { get => _color; set => _color = value; }
        public Point2D Pos { get => _pos; }
        public Rectangle WindowRect { get => _windowRect; set => _windowRect = value; }

        public virtual void Draw()
        {
            for (int i = 0; i < _terrainMap.Length; i++)
            {
                SwinGame.DrawLine(_color, i, _windowRect.Height, i, (int)Math.Round(_terrainMap[i]));
            }
        }
    }
}
