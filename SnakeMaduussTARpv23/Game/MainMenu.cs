using System;
using System.IO;
using System.Threading;
using SnakeMaduussTARpv23.Services;

namespace SnakeMaduussTARpv23.Game
{
    public class MainMenu
    {
        private FileSaveRead fileService = new FileSaveRead();
        public void Display()
        {
            string[] buttons = { "Start Game", "Leaderboard", "Exit" };
            int selectedButton = 0;
            ConsoleKey key;

            do
            {
                DrawMenu(buttons, selectedButton);
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedButton = (selectedButton - 1 + buttons.Length) % buttons.Length;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedButton = (selectedButton + 1) % buttons.Length;
                }
            } while (key != ConsoleKey.Enter);

            switch (selectedButton)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    ShowLeaderboard();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }

        private static void StartGame()
        {
            Console.Clear();
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            Console.Clear();

            GameController.StartGame(playerName);
        }

        private static void DrawMenu(string[] buttons, int selectedButton)
        {
            Console.Clear();
            string[] title = GetTitle();
            int xOffset = 10;
            int yOffset = 5;

            Console.SetCursorPosition(xOffset, yOffset);
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var line in title)
            {
                Console.SetCursorPosition(xOffset, Console.CursorTop);
                Console.WriteLine(line);
            }
            Console.ResetColor();

            Console.SetCursorPosition(xOffset, yOffset + title.Length + 2);
            for (int i = 0; i < buttons.Length; i++)
            {
                Console.SetCursorPosition(xOffset, Console.CursorTop);
                if (i == selectedButton)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"  > {buttons[i]}  ");
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine($"    {buttons[i]}  ");
                }
            }
            Console.ResetColor();
        }

        private void ShowLeaderboard()
        {
            Console.Clear();
            Console.WriteLine("Leaderboard:\n");

            string leaderboardData = FileSaveRead.ReadGameData();

            if (!string.IsNullOrEmpty(leaderboardData))
            {
                Console.WriteLine(leaderboardData);
            }
            else
            {
                Console.WriteLine("No leaderboard data available.");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey(true);
            Display();
        }

        private static void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Exiting the game. Goodbye!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

        private static string[] GetTitle()
        {
            return
            [
                "   SSSSSSSSSSSSSSS                                     kkkkkkkk                               ",
                " SS:::::::::::::::S                                    k::::::k                               ",
                "S:::::SSSSSS::::::S                                    k::::::k                               ",
                "S:::::S     SSSSSSS                                    k::::::k                               ",
                "S:::::S            nnnn  nnnnnnnn      aaaaaaaaaaaaa    k:::::k    kkkkkkk    eeeeeeeeeeee    ",
                "S:::::S            n:::nn::::::::nn    a::::::::::::a   k:::::k   k:::::k   ee::::::::::::ee  ",
                " S::::SSSS         n::::::::::::::nn   aaaaaaaaa:::::a  k:::::k  k:::::k   e::::::eeeee:::::ee",
                "  SS::::::SSSSS    nn:::::::::::::::n           a::::a  k:::::k k:::::k   e::::::e     e:::::e",
                "    SSS::::::::SS    n:::::nnnn:::::n    aaaaaaa:::::a  k::::::k:::::k    e:::::::eeeee::::::e",
                "       SSSSSS::::S   n::::n    n::::n  aa::::::::::::a  k:::::::::::k     e:::::::::::::::::e ",
                "            S:::::S  n::::n    n::::n a::::aaaa::::::a  k:::::::::::k     e::::::eeeeeeeeeee  ",
                "            S:::::S  n::::n    n::::na::::a    a:::::a  k::::::k:::::k    e:::::::e           ",
                "SSSSSSS     S:::::S  n::::n    n::::na::::a    a:::::a k::::::k k:::::k   e::::::::e          ",
                "S::::::SSSSSS:::::S  n::::n    n::::na:::::aaaa::::::a k::::::k  k:::::k   e::::::::eeeeeeee  ",
                "S:::::::::::::::SS   n::::n    n::::n a::::::::::aa:::ak::::::k   k:::::k   ee:::::::::::::e  ",
                " SSSSSSSSSSSSSSS     nnnnnn    nnnnnn  aaaaaaaaaa  aaaakkkkkkkk    kkkkkkk    eeeeeeeeeeeeee  ",
            ];
        }
    }
}
