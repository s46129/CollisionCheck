using System;
using CollisionCheck.Sprites;

namespace CollisionCheck.Collisions
{
    public class HeroAndFire : Collision
    {
        public HeroAndFire(Collision next) : base(next, typeof(Hero), typeof(Fire))
        {
        }


        protected override bool OnCollision(Position x1, Position x2)
        {
            Position heroPosition = FindTarget<Hero>(x1, x2);
            (heroPosition.Sprite as Hero)?.OnHurt(10);
            Console.WriteLine($"Hero HP : {heroPosition.Sprite.HP}(-10)");
            Position firePosition = FindTarget<Fire>(x1, x2);
            firePosition.Sprite = heroPosition.Sprite;
            heroPosition.Sprite = null;
            return true;
        }
    }
}