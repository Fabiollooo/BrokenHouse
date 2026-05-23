using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BrokenHouse
{
    public class Game
    {
        public void ChooseGame(Player player)
        {
            //Program.DisplayPlayerInfo(player);

            Console.WriteLine("Choose a game to play: ");
            Console.WriteLine("1 - Blackjack ");
            Console.WriteLine("2 - Roulette");
            Console.WriteLine("3 - Craps");
            Console.WriteLine("4 - Higher or Lower");
            Console.WriteLine("0 - Go Back");
            Console.WriteLine("\n");
            //Add more games later maybe


            Console.ForegroundColor = ConsoleColor.Black;
            int choice = int.Parse(Console.ReadLine());
            Console.ResetColor();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Blackjack it is...");
                    break;

                case 2:
                    Console.WriteLine("Roulette it is...");
                    
                    break;

                case 3:
                    Console.WriteLine("Craps it is...");

                    break;

                case 4:
                    Console.WriteLine("Higer or Lower it is...");

                    break;

                case 0:
                    Console.WriteLine("Exiting the casino.");
                    ClearDisplay(player);
                    return;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }//end of ChooseGame

        static void ClearDisplay(Player player)
        {
            Console.Clear();
            Program.DisplayPlayerInfo(player);
        }
    }
}
