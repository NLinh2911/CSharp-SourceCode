using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
namespace SnakeGame
{
    class Program
    {
        // Game settings
        static bool gameOn = false;
        static int score = 0;
        static int X = 30;
        static int Y = 15;
        static List<Point> snake = new List<Point>();
        static string direction = "left";
        static string headSymbol = "<";
        static string bodySymbol = "*";
        static string foodSymbol = "@";
        static Point food = new Point(10, 10);
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            //
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            // Change size
            Console.Title = "Snake Game";
            Console.CursorVisible = (false);
            Console.SetWindowSize(60, 30);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
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
            System.Console.WriteLine("Press any key to start the game");
            Console.ReadKey();
            Console.Beep(500,650);
            gameOn = true;
            // initialise snake
            for (int i = 0; i < 5; i++)
            {
                snake.Add(new Point(X + i, Y));
            }
            Thread thread = new Thread(Move);
            thread.IsBackground = true;
            thread.Start();

            while (gameOn == true)
            {
                // handle key inputs
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    gameOn = false;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (direction != "down")
                    {
                        direction = "up";
                        headSymbol = "^";
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (direction != "up")
                    {
                        direction = "down";
                        headSymbol = "v";
                    }
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (direction != "right")
                    {
                        direction = "left";
                        headSymbol = "<";

                    }
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (direction != "left")
                    {
                        direction = "right";
                        headSymbol = ">";

                    }
                }

            }

        }
        static void Move()
        {
            while (gameOn)
            {
                Point head = snake[0];
                if (direction == "up")
                {
                    head.Y--;
                }
                if (direction == "down")
                {
                    head.Y++;
                }
                if (direction == "left")
                {
                    head.X--;
                }
                if (direction == "right")
                {
                    head.X++;
                }
                snake.Insert(0, head);
                if (snake[0].X == food.X && snake[0].Y == food.Y)
                {
                    Console.Beep(500,650);
                    food = new Point();
                    food.X = rnd.Next(2, Console.BufferWidth - 2);
                    food.Y = rnd.Next(2, Console.BufferHeight - 2);
                    // increase score
                    score++;
                }
                else
                {
                    snake.RemoveAt(snake.Count - 1);
                }
                Console.Clear();
                // draw snake
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                for (int i = 0; i < snake.Count; i++)
                {
                    try
                    {
                        Console.SetCursorPosition(snake[i].X, snake[i].Y);
                        if (i == 0)
                        {
                            System.Console.WriteLine(headSymbol);
                        }
                        else
                        {
                            if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
                            {
                                gameOn = false;
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine(bodySymbol);
                            }
                        }
                    }
                    catch (System.Exception)
                    {
                        gameOn = false;
                        break;
                    }
                }
                // draw food
                Console.SetCursorPosition(food.X, food.Y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(foodSymbol);
                // draw score
                Console.SetCursorPosition(1, 1);
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("Score: " + score);
                Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.Beep(500,650);
            Console.SetCursorPosition(Console.BufferWidth / 3, Console.BufferHeight / 3);
            System.Console.WriteLine(@"
                                                    
            _____                  _____             
            |   __|___ _____ ___   |     |_ _ ___ ___ 
            |  |  | .'|     | -_|  |  |  | | | -_|  _|
            |_____|__,|_|_|_|___|  |_____|\_/|___|_|  
                                                    
                            ");
            Console.SetCursorPosition(Console.BufferWidth / 2, Console.CursorTop);
            System.Console.WriteLine("Score: {0}", score);
        }
    }
}

