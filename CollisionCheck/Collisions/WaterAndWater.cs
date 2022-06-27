using CollisionCheck.Sprites;

namespace CollisionCheck.Collisions
{
    public class WaterAndWater : Collision

    {
        public WaterAndWater(Collision next) : base(next, typeof(Water), typeof(Water))
        {
        }

        protected override bool OnCollision(Position x1, Position x2)
        {
            return false;
        }
    }
}