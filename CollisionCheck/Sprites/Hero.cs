using System;

namespace CollisionCheck.Sprites
{
    public class Hero : Sprite
    {
        public Hero()
        {
            HP = 30;
        }

        public void OnHealing(int value)
        {
            HP += value;
        }

        public void OnHurt(int attack)
        {
            HP -= attack;
            if (HP <= 0)
            {
                Console.WriteLine($"Hero is Dead");
            }
        }

        public override string ToString()
        {
            return "H";
        }
    }
}