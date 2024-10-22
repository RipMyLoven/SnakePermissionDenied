using System;
using System.IO;

namespace SnakeMaduussTARpv23.Services
{
    public class FileSaveRead
    {
        private const string V = @"..\..\..\Text.txt";

        public static void SaveGameData(string playerName, TimeSpan timePlayed)
        {
            string filePath = @"..\..\..\Text.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Player: {playerName}, Time Played: {timePlayed.Minutes:D2}:{timePlayed.Seconds:D2}");
                writer.WriteLine("---------------------------------------------------");
            }
        }

         public static string ReadGameData()
         {
            string filePath = V;
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new (filePath))
                {
                    return reader.ReadToEnd();
                }
            }
            else
            {
                return "No saved game data found.";
            }
        }
    }
}
