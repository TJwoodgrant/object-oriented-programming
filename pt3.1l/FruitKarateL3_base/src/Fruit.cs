using System;
using SwinGameSDK;

namespace MyGame
{
	public class Fruit 
	{
      
		private FruitKind _kind;

        protected Point2D _position;
        protected Vector _velocity;

        private bool _alive;
        private Random _random = new Random();

        private Circle _hitBox;

        protected Bitmap MyBitmap()
		{
			switch (_kind)
			{
				case FruitKind.Cherry: 		return SwinGame.BitmapNamed("Cherry");
				case FruitKind.Gooseberry:	return SwinGame.BitmapNamed("Gooseberry");
				case FruitKind.Blueberry:	return SwinGame.BitmapNamed("Blueberry");
				case FruitKind.Pomegranate:	return SwinGame.BitmapNamed("Pomegranate");
				case FruitKind.Apricot: 	return SwinGame.BitmapNamed("Apricot");
				case FruitKind.Raspberry: 	return SwinGame.BitmapNamed("Raspberry");
				case FruitKind.Blackberry: 	return SwinGame.BitmapNamed("Blackberry");
				case FruitKind.Strawberry: 	return SwinGame.BitmapNamed("Strawberry");
				case FruitKind.Currant:		return SwinGame.BitmapNamed("Currant");
			default: 
				return SwinGame.BitmapNamed("Currant");
			}
		}

        public Fruit()
        {
            _position.X = 0;
            _position.Y = SwinGame.ScreenHeight ();

            _velocity.X = 4.0f;
            _velocity.Y = -7.0f + (float)_random.NextDouble() * 4 - 2;

            _kind = FruitKind.Cherry;
            _alive = true;

        }

        public virtual void Update()
        {
            // update my position
            _position = SwinGame.AddVectors (_position, _velocity);
            _velocity = SwinGame.AddVectors (_velocity, SwinGame.VectorTo (0, 0.05f));

            // update hitbox
            Point2D hitboxposition = new Point2D();
            hitboxposition.X = _position.X + MyBitmap().Width / 2;
            hitboxposition.Y = _position.Y + MyBitmap().Height / 2;

            _hitBox = SwinGame.BitmapCircle(MyBitmap(), hitboxposition);

        }

        public virtual void Draw()
        {
            SwinGame.DrawBitmap (MyBitmap (), _position.X, _position.Y);
            SwinGame.DrawCircle(Color.Black, _hitBox);
        }

        public virtual void Splat()
        {
            SwinGame.PlayMusic("Splat");
            _alive = false;
        }

        public bool IsAt(Point2D point)
        {
            

            SwinGame.DrawCircle(Color.Black, _hitBox);
            return SwinGame.PointInCircle(point, _hitBox);
                
        }

        public bool Alive
        {
            get => _alive;
        }


	}


}
