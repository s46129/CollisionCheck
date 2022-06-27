using System;
using CollisionCheck.Sprites;

namespace CollisionCheck.Collisions
{
    internal class HeroAndWater : Collision
    {
        public HeroAndWater(Collision next) : base(next, typeof(Hero), typeof(Water))
        {
        }

        protected override bool OnCollision(Position x1, Position x2)
        {
            Position heroPosition = FindTarget<Hero>(x1, x2);
            (heroPosition.Sprite as Hero)?.OnHealing(10);
            Console.WriteLine($"Hero HP is {heroPosition.Sprite.HP.ToString()}(+10)");
            Position firePosition = FindTarget<Water>(x1, x2);
            firePosition.Sprite = heroPosition.Sprite;
            heroPosition.Sprite = null;
            return true;
        }
    }
}