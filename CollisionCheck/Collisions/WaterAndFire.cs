using CollisionCheck.Sprites;

namespace CollisionCheck.Collisions
{
    public class WaterAndFire : Collision
    {
        public WaterAndFire(Collision next) : base(next, typeof(Water), typeof(Fire))
        {
        }

        protected override bool OnCollision(Position x1, Position x2)
        {
            x1.Sprite = null;
            x2.Sprite = null;
            return true;
        }
    }
}