using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class FruitKarate
	{
        private List<Fruit> _fruit = new List<Fruit> ();
        private int _bgAnimation;

        public void HurtBackground()
        {
            _bgAnimation = 20;
        }


		private void LoadResources ()
		{
            SwinGame.LoadMusicNamed("Splat", "Splat-SoundBible.com-1826190667.wav");

			SwinGame.LoadBitmapNamed ("Cherry", "Cherry.png");
			SwinGame.LoadBitmapNamed ("Gooseberry", "Gooseberry.png");
			SwinGame.LoadBitmapNamed ("Blueberry", "Blueberry.png");
			SwinGame.LoadBitmapNamed ("Pomegranate", "Pomegranate.png");
			SwinGame.LoadBitmapNamed ("Apricot", "Apricot.png");
			SwinGame.LoadBitmapNamed ("Raspberry", "Raspberry.png");
			SwinGame.LoadBitmapNamed ("Blackberry", "Blackberry.png");
			SwinGame.LoadBitmapNamed ("Strawberry", "Strawberry.png");
			SwinGame.LoadBitmapNamed ("Currant", "Currant.png");

			SwinGame.LoadSoundEffectNamed ("Splat", "Splat-SoundBible.com-1826190667.wav");
		}

		public FruitKarate ()
		{
			LoadResources ();
            _bgAnimation = 0;
		}

        public void LaunchFruit()
        {
            Fruit f = new Fruit ();
            _fruit.Add (f);

        }

        public void PunchFruit(Point2D point)
        {

            for (int i = _fruit.Count - 1; i >= 0; i--)
            {
                Fruit f = _fruit[i];
                if (f.IsAt(point))
                {
                    f.Splat();
                    _fruit.Remove(f);
                    HurtBackground();
                }
            }
        }

        public void Update()
        {
            foreach(Fruit f in _fruit)
            {
                f.Update ();
                if (!f.Alive)
                {
                    _fruit.Remove(f);
                    continue;
                }
            }
            _bgAnimation--;
            if (_bgAnimation < 0)
                _bgAnimation = 0;
        }

        public void Draw()
        {
            float colorDeg = 1 - (float)(0.5 * Math.Sin(Math.PI * _bgAnimation / (20 * 2)));


            Color c = SwinGame.RGBAFloatColor(1.0f, colorDeg, colorDeg, 1.0f);
            SwinGame.ClearScreen(c);
            //SwinGame.DrawText("Color: " + colorDeg, Color.Black, 50, 50);
            foreach (Fruit f in _fruit) {
                f.Draw ();
            }
            
        }
		
	}
}

