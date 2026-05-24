using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace BrokenHouse
{
    public class ReadToFile
    {
        public void WriteToFile(Player player)
        {
            string filePath = @".\saves\save.json";
            Directory.CreateDirectory(@".\saves");

            string json = JsonSerializer.Serialize(player);
            File.WriteAllText(filePath, json);
            
            Console.WriteLine("Player Saved !");
        }

        public Player LoadPlayer()
        {
            string filePath = @".\saves\save.json";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No save file found.");
                return null;
            }

            string json = File.ReadAllText(filePath);
            Player player = JsonSerializer.Deserialize<Player>(json);

            Console.WriteLine("Player loaded !");
            return player;
        }


    }
}
