using System;
using CollisionCheck.Sprites;

namespace CollisionCheck.Collisions
{
    public abstract class Collision
    {
        private readonly Collision _next;
        private readonly Type _type1;
        private readonly Type _type2;

        protected Collision(Collision next, Type type1, Type type2)
        {
            _next = next;
            _type1 = type1;
            _type2 = type2;
        }

        public bool MoveSucceed(Position x1, Position x2)
        {
            return CheckType(x1, x2, _type1, _type2) ? OnCollision(x1, x2) : MoveNext(x1, x2);
        }

        protected abstract bool OnCollision(Position x1, Position x2);

        private bool CheckType(Position x1, Position x2, Type type1, Type type2)
        {
            return x1.IsSpriteEqual(type1) && x2.IsSpriteEqual(type2) ||
                   x1.IsSpriteEqual(type2) && x2.IsSpriteEqual(type1);
        }

        private bool MoveNext(Position x1, Position x2)
        {
            return _next == null || _next.MoveSucceed(x1, x2);
        }

        protected Position FindTarget<T>(Position x1, Position x2) where T : Sprite
        {
            if (x1.IsSpriteEqual(typeof(T)))
            {
                return x1;
            }
            else if (x2.IsSpriteEqual(typeof(T)))
            {
                return x2;
            }

            return null;
        }
    }
}