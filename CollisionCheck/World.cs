using System;
using System.Linq;
using CollisionCheck.Sprites;

namespace CollisionCheck
{
    internal class World
    {
        private Position[] _positions;
        public Position[] Positions => _positions;

        private Sprite[] _sprites;
        public Sprite[] Sprites => _sprites;

        private readonly Random _random = new Random();


        public World()
        {
            InitialPosition(30);
            InitialSprite(10);
            SetSpritesToPosition();
            RandomPosition();
        }

        private void SetSpritesToPosition()
        {
            for (int i = 0; i < _sprites.Length; i++)
            {
                _positions[i].Sprite = _sprites[i];
            }
        }

        public void PrintTheWorld()
        {
            Console.WriteLine("\n----- Print the world -----\n");
            Console.Write("_");
            for (var index = 0; index < _positions.Length; index++)
            {
                var position = _positions[index];
                string sign = index.ToString();
                if (position.Sprite != null)
                {
                    sign = position.Sprite.ToString();
                }

                Console.Write(sign + "_");
            }

            Console.WriteLine("\n--------------------------\n");
        }

        private void InitialSprite(int count)
        {
            _sprites = new Sprite[count];
            for (int i = 0; i < _sprites.Length; i++)
            {
                Sprite sprite = RandomSprite();
                _sprites[i] = sprite;
            }
        }

        private void InitialPosition(int count)
        {
            _positions = new Position[count];
            for (int i = 0; i < count; i++)
            {
                _positions[i] = new Position();
            }
        }

        private Sprite RandomSprite()
        {
            switch (_random.Next(0, 3))
            {
                case 0:
                    return new Hero();
                case 1:
                    return new Fire();
                default:
                    return new Water();
            }
        }

        private void RandomPosition()
        {
            _positions = _positions.OrderBy(x => _random.Next(_positions.Length)).ToArray();
        }
    }
}