using System;
using CollisionCheck.Collisions;

namespace CollisionCheck
{
    internal class CollisionDemo
    {
        private readonly World _world = new World();
        private Collision _collision;

        public void Start()
        {
            _collision =
                new FireAndFire(
                    new HeroAndFire(new WaterAndFire(new WaterAndWater(new HeroAndHero(new HeroAndWater(null))))));
            while (IsGameOver() == false)
            {
                _world.PrintTheWorld();
                MoveInput();
            }

            GameOver();
        }

        private bool IsGameOver()
        {
            return _world.Sprites.Length == 0;
        }

        private void GameOver()
        {
            Console.WriteLine("===== Game Over =====");
        }

        void MoveInput()
        {
            Console.WriteLine(
                $"Input Form (0~{_world.Positions.Length - 1}) To (0~{_world.Positions.Length - 1}) : \nex:10 24");

            string input = Console.ReadLine();

            VerificationAndParseToPositionIndex(input, out int x1, out int x2);

            Console.WriteLine(_collision.MoveSucceed(_world.Positions[x1], _world.Positions[x2])
                ? "** Move Success **"
                : "** Move Failed **");
        }

        private void VerificationAndParseToPositionIndex(string input, out int x1, out int x2)
        {
            if (string.IsNullOrEmpty(input))
            {
                InvalidInput("Input can't be Empty");
            }

            string[] parse = input.Split(' ');
            if (parse.Length != 2)
            {
                InvalidInput("Input should be two number,like: position1(Space)position2");
            }

            x1 = int.Parse(parse[0]);
            x2 = int.Parse(parse[1]);

            if (x1 < 0 || x1 > _world.Positions.Length)
            {
                InvalidInput("x1 is out of range.");
            }

            if (x2 < 0 || x2 > _world.Positions.Length)
            {
                InvalidInput("x2 is out of range.");
            }
        }

        private void InvalidInput(string cause)
        {
            Console.WriteLine("Input can't be Empty");
            MoveInput();
        }
    }
}