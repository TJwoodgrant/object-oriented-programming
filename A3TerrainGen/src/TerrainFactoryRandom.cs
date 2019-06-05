using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace ArtillerySeries.src
{
    public class TerrainFactoryRandom : TerrainFactory
    {

        public TerrainFactoryRandom(Rectangle windowSize, Rectangle terrainBox) : base(windowSize, terrainBox)
        {
        }

        public override Terrain Generate(Color color)
        {
            Console.WriteLine("Generating random terrain!");
            Terrain _terrain = new Terrain(WindowRect)
            {
                Map = new float[(int)WindowRect.Width]
            };

            for (int i = 0; i < _terrain.Map.Length - 1; i++)
            {
                _terrain.Map[i] = 500 + Random.Next(-20, 20);
            }


            return _terrain;
        }

        public override Terrain Generate(Color color, int averageTerrainHeight)
        {
            throw new NotImplementedException();
        }

        public override Terrain Generate(Color color, int averageTerrainHeight, float reductionCoef)
        {
            throw new NotImplementedException();
        }
    }
}
