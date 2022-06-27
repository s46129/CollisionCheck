using CollisionCheck.Sprites;

namespace CollisionCheck.Collisions
{
    public class FireAndFire : Collision
    {
        public FireAndFire(Collision next) : base(next, typeof(Fire), typeof(Fire))
        {
        }


        protected override bool OnCollision(Position x1, Position x2)
        {
            return false;
        }
    }
}