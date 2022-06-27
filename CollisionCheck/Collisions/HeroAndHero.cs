using CollisionCheck.Sprites;

namespace CollisionCheck.Collisions
{
    public class HeroAndHero : Collision
    {
        public HeroAndHero(Collision next) : base(next, typeof(Hero), typeof(Hero))
        {
        }


        protected override bool OnCollision(Position x1, Position x2)
        {
            return false;
        }
    }
}