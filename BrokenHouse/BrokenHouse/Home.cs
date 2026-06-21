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
           
                Console.WriteLine("Choose a game to play: ");
                Console.WriteLine("1 - Check Family Status");
                Console.WriteLine("2 - Check Resource stocks");
                Console.WriteLine("3 - Check Expenses to pay");
                Console.WriteLine("4 - Go to sleep");
                Console.WriteLine("0 - Exit the house");
                Console.WriteLine("\n");

                Console.ForegroundColor = ConsoleColor.Black;
                string input = Console.ReadLine();
                Console.ResetColor();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    System.Threading.Thread.Sleep(1000);
                    ClearDisplay(player);
                    continue;
                }

                switch (choice)
                    {
                        case 1:
                            ClearDisplay(player);
                            CheckFamilyMemberStats(family);
                        
                            break;
                        
                        
                        case 2:
                            ClearDisplay(player);
                            //Check resources 
                            CheckResources(player);
                            break;

                        case 3:
                            ClearDisplay(player);
                            Console.WriteLine("Checking expenses");
                            //Display all expenses that are past/due.
                            break;

                        case 4:
                            SleepProceedDay(player, family);
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
                            System.Threading.Thread.Sleep(1000);
                            ClearDisplay(player);
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

        static void CheckResources(Player player)
        {
            Console.WriteLine("Checking resources...\n");
            foreach (Items item in player.Inventory)
            {
                TypewriterEffect($"{item.ItemName}, {item.ItemQuantity}",20);
            }

            foreach(Expenses bill in player.Bills)
            {
                TypewriterEffect($"{bill.ExpenseName} paid status: {bill.ExpenseIspaid}");
            }

            Console.WriteLine();
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

        static void SleepProceedDay(Player player, Family family)
        {
            TypewriterEffect("Going to sleep...", 30);
            player.CurrentDay += 1;
        }



    }//end of Home class
}