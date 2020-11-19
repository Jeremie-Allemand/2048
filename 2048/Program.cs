using System;

namespace _2048
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            while (!game.isGameOver()) 
            {
                Console.WriteLine("Score : " + game + "\n");
                Console.WriteLine(game.Grid);
                ConsoleKey key = Console.ReadKey().Key;
                switch (key) 
                {
                    case ConsoleKey.LeftArrow:
                        game.Shift(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        game.Shift(Direction.Right);
                        break;
                    case ConsoleKey.UpArrow:
                        game.Shift(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        game.Shift(Direction.Down);
                        break;
                }

                Console.Clear();
            }

            Console.Clear();
            Console.WriteLine("Game Over");

        }
    }
}
