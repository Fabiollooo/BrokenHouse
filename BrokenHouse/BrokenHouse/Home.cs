using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BrokenHouse
{
    public class Home
    {
        public void ChooseHomeOption(Player player, Family family)
        {

            while (true)
            {
                //Program.DisplayPlayerInfo(player);

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
                            ClearDisplay(player);
                            //Console.WriteLine("Check up on your family");
                            CheckFamilyMemberStats(family);
                        
                            break;

                        case 2:
                            ClearDisplay(player);
                            Console.WriteLine("Checking expenses");
                            //Display all expenses that are past/due.
                            break;

                        case 3:
                            ClearDisplay(player);
                            Console.WriteLine("Take a rest");
                            //Progesses to the next day, and adds the daily income to the player's balance.
                            break;

                        case 0:
                            Console.WriteLine("Exiting home.");
                            ClearDisplay(player);
                            return;

                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }

            }

        }//end of HomeOption

        static void CheckFamilyMemberStats(Family family)
        {
            Console.WriteLine("\nChecking family status...");
            TypewriterEffect($"{family.Members[0].MemberType}, {family.Members[0].Name}, Hunger: {family.Members[0].Hunger} ,{family.Members[0].Age}, Alive: {family.Members[0].IsAlive}, Sick: {family.Members[0].IsSick}", 40);
            TypewriterEffect($"{family.Members[1].MemberType}, {family.Members[1].Name}, Hunger: {family.Members[1].Hunger} ,{family.Members[1].Age}, Alive: {family.Members[1].IsAlive}, Sick: {family.Members[1].IsSick}\n", 40);
            
        }

        static void ClearDisplay(Player player)
        {
            Console.Clear();
            Program.DisplayPlayerInfo(player);

        }

        static void TypewriterEffect(string text, int delayMs = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        public static void DisplayPlayerInfo(Player player)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("******************\n");
            Console.ResetColor();
            Console.WriteLine($"Name: {player.Name},  Balance: {player.Balance}, Day: {player.CurrentDay}, Daily Income: {player.DailyIncome}");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n******************\n");
            Console.ResetColor();

        }
    }
}