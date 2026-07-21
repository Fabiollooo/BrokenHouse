using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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
                Console.WriteLine("3 - Buy Resources ");
                Console.WriteLine("4 - Check Expenses to pay");
                Console.WriteLine("5 - Pay Expenses");
                Console.WriteLine("6 - Go to sleep");
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
                            BuyResources(player);
                            //Buy resources

                            break;

                        case 4:
                            ClearDisplay(player);
                            Console.WriteLine("Checking expenses");
                            //Display all expenses that are past/due.
                            break;

                        case 5:
                            ClearDisplay(player);
                            Console.WriteLine("Checking expenses");
                            //Display all expenses that are past/due.
                            break;

                        case 6:
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

            TypewriterEffect($"Food: {player.FoodQuantity}", 20);
            TypewriterEffect($"Medicine: {player.MedicineQuantity}", 20);

            


            foreach (Expenses bill in player.Bills)
            {
                TypewriterEffect($"{bill.ExpenseName} paid status: {bill.ExpenseIspaid}");
            }

            Console.WriteLine();
        }

        static void BuyResources(Player player)
        {
            
            TypewriterEffect("Entering shop...");
            Console.WriteLine();
            Console.WriteLine("What would you like to purchase ?");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("1 - Food");
                Console.WriteLine("2 - Medicine");
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
                        Console.WriteLine($"Are you sure that you want to purchase Food for {player.FoodPrice}");
                        string playerFoodChoice = Console.ReadLine();
                        if (playerFoodChoice == "Y" || playerFoodChoice == "y") 
                        {
                            player.Balance -= player.FoodPrice;
                            player.FoodQuantity += 1;
                            return;
                        }
                        else
                        {
                            return;
                        }
                        break;


                    case 2:
                        Console.WriteLine($"Are you sure that you want to purchase Food for {player.MedicinePrice}");
                        string playerMedicineChoice = Console.ReadLine();
                        if (playerMedicineChoice == "Y" || playerMedicineChoice == "y")
                        {
                            player.Balance -= player.MedicinePrice;
                            player.MedicineQuantity += 1;
                            return;
                        }
                        else
                        {
                            return;
                        }
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