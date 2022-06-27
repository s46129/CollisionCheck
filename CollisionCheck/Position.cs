using System;
using CollisionCheck.Sprites;

namespace CollisionCheck
{
    public class Position
    {
        public Sprite Sprite = null;

        public bool IsSpriteEqual(Type type)
        {
            if (Sprite == null)
            {
                return type == null;
            }

            return Sprite.GetType() == type;
        }
    }
}