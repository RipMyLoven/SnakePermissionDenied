using System;

namespace SnakeMaduussTARpv23.Game
{
    internal class GameOver
    {
        public static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Green;

            string gameOverText = @"
             _____                           _____                    
            |  __ \                         |  _  |                   
            | |  \/  __ _  _ __ ___    ___  | | | |__   __  ___  _ __ 
            | | __  / _` || '_ ` _ \  / _ \ | | | |\ \ / / / _ \| '__|
            | |_\ \| (_| || | | | | ||  __/ \ \_/ / \ V / |  __/| |   
             \____/ \__,_||_| |_| |_| \___|  \___/   \_/   \___||_|   
                                                                       ";

            WriteText(gameOverText, xOffset, yOffset);
        }

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.Write(text);
        }
    }
}
