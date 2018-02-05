using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
namespace Snake2
{
    class Program
    {
        // Game Settings
        static bool gameOn = false;
        static int score = 0;
        // Food
        static Random rnd = new Random();
        static Point food = new Point(10, 10);
        // Direction
        enum Direction { Left, Right, Up, Down };
        static Direction direction = Direction.Left;
        static string headSymbol = "<";
        static string bodySymbol = "*";
        static string foodSymbol = "@";
        // create a snake which is a list of points
        static List<Point> snake = new List<Point>();

        static void StartGame()
        {
            // set up terminal size, background colors, etc.
            Console.CursorVisible = (false);
            Console.Title = "Snaaaaake!";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize(60, 30);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.Clear();
            Console.SetCursorPosition(Console.BufferWidth / 3, Console.BufferHeight / 3);
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(@"
    __             _            ___                     
    / _\_ __   __ _| | _____    / _ \__ _ _ __ ___   ___ 
    \ \| '_ \ / _` | |/ / _ \  / /_\/ _` | '_ ` _ \ / _ \
    _\ \ | | | (_| |   <  __/ / /_\\ (_| | | | | | |  __/
    \__/_| |_|\__,_|_|\_\___| \____/\__,_|_| |_| |_|\___|                                                       
                                ");
            Console.SetCursorPosition(Console.BufferWidth / 3, Console.CursorTop);
            System.Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.Beep(320, 250);
            gameOn = true;
            // initialise the snake with 5 blocks starting at (10, 10)
            for (int i = 0; i < 5; i++)
            {
                snake.Add(new Point(50 + i, 10));
            }
            Console.Clear();
        }
        static void DrawSnake()
        {
            for (int i = 0; i < snake.Count; i++)
            {
                try
                {
                    Console.SetCursorPosition(snake[i].X, snake[i].Y);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    if (i == 0)
                    {
                        Console.Write(headSymbol);
                    }
                    else
                    {
                        if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
                        {
                            gameOn = false;
                        }
                        else
                        {
                            Console.Write(bodySymbol);
                        }
                    }
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    gameOn = false;
                }
            }
        }
        static void DrawFood()
        {
            Console.SetCursorPosition(food.X, food.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(foodSymbol);
        }
        static void DrawScore()
        {
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score: {0}", score);
        }
        static void Move()
        {
            while (gameOn)
            {
                // move the snake
                // get snake head postion
                Point head = snake[0];
                // move the snake by 1 unit towards the direction
                if (direction == Direction.Left)
                    head.X--;
                if (direction == Direction.Right)
                    head.X++;
                if (direction == Direction.Up)
                    head.Y--;
                if (direction == Direction.Down)
                    head.Y++;
                // insert new head point 
                snake.Insert(0, head);
                if (head.X == food.X && head.Y == food.Y)
                {
                    Console.Beep(320, 250);
                    food = new Point();
                    food.X = rnd.Next(2, Console.WindowWidth - 2);
                    food.Y = rnd.Next(2, Console.WindowHeight - 2);
                    score++;
                }
                else
                {
                    var tail = snake[snake.Count - 1];
                    Console.SetCursorPosition(tail.X, tail.Y);
                    System.Console.WriteLine(" ");
                    snake.RemoveAt(snake.Count - 1);
                }
                // draw snake 
                DrawSnake();
                // draw food 
                DrawFood();
                // draw score
                DrawScore();
                // delay thread to see changes
                Thread.Sleep(100);
            }
            Console.Clear();
            Console.Beep(500, 650);
            Console.SetCursorPosition(Console.BufferWidth / 3, Console.BufferHeight / 3);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine(@"
                                                    
            _____                  _____             
            |   __|___ _____ ___   |     |_ _ ___ ___ 
            |  |  | .'|     | -_|  |  |  | | | -_|  _|
            |_____|__,|_|_|_|___|  |_____|\_/|___|_|  
                                                    
                            ");
            Console.SetCursorPosition(Console.BufferWidth / 2, Console.CursorTop);
            System.Console.WriteLine("Score: {0}", score);
        }
        static void Main(string[] args)
        {
            //
            StartGame();

            // Threading
            Thread thread = new Thread(Move);
            thread.IsBackground = false;
            thread.Start();

            while (gameOn)
            {
                // handle input
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Escape:
                            gameOn = false;
                            break;
                        case ConsoleKey.UpArrow:
                            if (direction != Direction.Down)
                            {
                                direction = Direction.Up;
                                headSymbol = "^";
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (direction != Direction.Up)
                            {
                                direction = Direction.Down;
                                headSymbol = "v";
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (direction != Direction.Right)
                            {
                                direction = Direction.Left;
                                headSymbol = "<";
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (direction != Direction.Left)
                            {
                                direction = Direction.Right;
                                headSymbol = ">";
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.ReadKey(true);
            Console.ResetColor();
            Console.Clear();
        }
    }
}
