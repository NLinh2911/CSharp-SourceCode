using System;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "Guess a Number Game!!!";
            Console.WriteLine(@"   ______                                 _   __                __             
  / ______  _____  __________   ____ _   / | / __  ______ ___  / /_  ___  _____
 / / __/ / / / _ \/ ___/ ___/  / __ `/  /  |/ / / / / __ `__ \/ __ \/ _ \/ ___/
/ /_/ / /_/ /  __(__  (__  )  / /_/ /  / /|  / /_/ / / / / / / /_/ /  __/ /    
\____/\__,_/\___/____/____/   \__,_/  /_/ |_/\__,_/_/ /_/ /_/_.___/\___/_/     ");
            game:
            // Console.ForegroundColor = ConsoleColor.Green;          
            Game.Play();
            System.Console.WriteLine("....Press enter to play again....");
            System.Console.WriteLine("....Press any other keys to exit....");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter) {
                goto game;
            } else {
                System.Console.WriteLine("Thanks for playing my game");
            }
        }
    }
    class Game
    {
        static int Guess;
        static int Target;
        static bool GameOn;
        static int numberOfGuess = 0;
        public static void Play()
        {
            // get a random target
            Random randomTarget = new Random();
            Target = randomTarget.Next(-10, 10);
            GameOn = true;
            // print welcome msg
            System.Console.WriteLine("Welcome to Lucky Number game!");
            System.Console.WriteLine("Can you guess the lucky number? :)");
            while (GameOn)
            {
                try
                {
                    Guess = int.Parse(Console.ReadLine());
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Please enter a valid number");
                } finally
                {
                    numberOfGuess ++;
                }
                if (Guess == Target)
                {
                    System.Console.WriteLine("Match !!! You win");
                    GameOn = false;
                }
                else
                {
                    System.Console.WriteLine("Sorry, Wrong! Number of guesses: {0}", numberOfGuess);
                    System.Console.Write("Enter your guess again: ");
                }
            }
        }
    }
}
