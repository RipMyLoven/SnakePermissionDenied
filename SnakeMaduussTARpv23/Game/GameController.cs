using NAudio.Wave;
using SnakeMaduussTARpv23.Models;
using SnakeMaduussTARpv23.Services;
using System;
using System.Diagnostics;
using System.Threading;

namespace SnakeMaduussTARpv23.Game
{
    public class GameController
    {
        private static readonly object _consoleLock = new object();

        public static void StartGame(string playerName) 
        {
            Console.Clear();

            FileSaveRead fileSaveRead = new ();

            Console.SetWindowSize(120, 25);

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Console.ForegroundColor = ConsoleColor.Red;
            Point p = new (4, 5, '*');
            Snake snake = new (p, 4, Direction.RIGHT);
            snake.Draw();

            Obstacle obstacle1 = new (10, 10, 2, 4);
            Obstacle obstacle2 = new (20, 10, 3, 2);
            Obstacle obstacle3 = new (30, 12, 5, 5);
            Obstacle obstacle4 = new (40, 20, 2, 4);
            obstacle1.Draw();
            obstacle2.Draw();
            obstacle3.Draw();
            obstacle4.Draw();

            FoodCreator foodCreator = new (80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Stopwatch stopwatch = new ();
            stopwatch.Start();

            Thread timerThread = new (start: () =>
            {
                while (true)
                {
                    TimeSpan ts = stopwatch.Elapsed;
                    lock (_consoleLock)
                    {
                        Console.SetCursorPosition(83, 0);
                        Console.Write(new string(' ', Console.WindowWidth - 83));
                        Console.SetCursorPosition(83, 0);
                        Console.WriteLine($"Time Played: {ts.Minutes:D2}:{ts.Seconds:D2}");
                    }
                    Thread.Sleep(500);
                }
            });
            timerThread.Start();

            while (true)
            {
                lock (_consoleLock)
                {
                    if (walls.IsHit(snake) || snake.IsHitTail() || 
                        obstacle1.IsHit(snake) || obstacle2.IsHit(snake) || 
                        obstacle3.IsHit(snake) || obstacle4.IsHit(snake))
                    {
                        break;
                    }

                    if (snake.Eat(food))
                    {
                        
                        obstacle1.MoveObstacle(80, 25, snake.GetPoints(), food);
                        obstacle2.MoveObstacle(80, 25, snake.GetPoints(), food);
                        obstacle3.MoveObstacle(80, 25, snake.GetPoints(), food);
                        obstacle4.MoveObstacle(80, 25, snake.GetPoints(), food);

                        food = foodCreator.CreateFood();
                        food.Draw();
                    }
                    else
                    {
                        snake.Move();
                    }

                    Thread.Sleep(100); 

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        snake.HandleKey(key.Key);
                    }
                }
            }

            stopwatch.Stop();
            FileSaveRead.SaveGameData(playerName, stopwatch.Elapsed);

            GameOver.WriteGameOver();
            Console.ReadLine();
        }
    }
}
