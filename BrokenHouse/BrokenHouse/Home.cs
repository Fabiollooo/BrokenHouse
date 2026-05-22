using System;
using System.Collections.Generic;
using System.Text;

namespace BrokenHouse
{
    public class Home
    {
        public void ChooseHomeOption(Player player)
        {
            Program.DisplayPlayerInfo(player);

            Console.WriteLine("Choose a game to play: ");
            Console.WriteLine("1 - Check Family Status");
            Console.WriteLine("2 - Check Expenses to pay");
            Console.WriteLine("3 - Go to sleep");
            Console.WriteLine("0 - Exit the house");
            Console.WriteLine("\n");
            

            Console.ForegroundColor = ConsoleColor.Black;
            int choice = int.Parse(Console.ReadLine());
            Console.ResetColor();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Check up on your family");
                    break;

                case 2:
                    Console.WriteLine("Checking expenses");
                    //Display all expenses that are past/due.
                    break;

                case 3:
                    Console.WriteLine("Take a rest");
                    //Progesses to the next day, and adds the daily income to the player's balance.
                    break;

                case 0:
                    Console.WriteLine("Exiting home.");
                    ClearDisplay();
                    return;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

        }//end of HomeOption

        static void ClearDisplay()
        {
            Console.Clear();
        }
    }
}