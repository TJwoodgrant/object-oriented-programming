using System;
using SwinGameSDK;

namespace MyGame
{
	public class ToughFruit : Fruit
	{
		private int lives;

		public ToughFruit () : base()
		{
			lives = 3;
		}

		public override void Splat ()
		{
			lives--;

		}

		public override void Draw ()
		{
			base.Draw ();

			Bitmap bmp = MyBitmap ();

			switch (lives)
			{
			case 1: 
				SwinGame.FillRectangle (SwinGame.RGBAColor (255, 0, 0, 100), _position.X, _position.Y, bmp.Width, bmp.Height);
				break;
			case 2: 
				SwinGame.FillRectangle (SwinGame.RGBAColor (0, 255, 255, 100), _position.X, _position.Y, bmp.Width, bmp.Height);
				break;
			case 3: 
				SwinGame.FillRectangle (SwinGame.RGBAColor (0, 255, 0, 100), _position.X, _position.Y, bmp.Width, bmp.Height);
				break;

			}
		}
	}
}

