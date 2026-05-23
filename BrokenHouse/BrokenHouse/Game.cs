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
                    PlayBlackjack(player);
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
        static void TypewriterEffect(string text, int delayMs = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        static void PlayBlackjack(Player player)
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("Welcome to Blackjack!");
            // Implement Blackjack game logic here

            int playerBet = 0;
            int playerCard1 = 0;
            int playerCard2 = 0;
            int dealerCard1 = 0;
            int dealerCard2 = 0;
            int sumPlayerCards = 0;
            int sumDealerCards = 0;
            bool roundOver = false;

            bool playerPlays = true;
            while (playerPlays)
            {
                Console.WriteLine("New game has begun !");
                Random rand = new Random();
                //Player hand
                playerCard1 = rand.Next(1, 11);
                playerCard2 = rand.Next(1, 11);
                sumPlayerCards = playerCard1 + playerCard2;
                TypewriterEffect($"Card 1: {playerCard1} & Card 2: {playerCard2} || {sumPlayerCards}", 10);
                //TypewriterEffect($"Total: {sumPlayerCards}", 10);
                Console.WriteLine("\n");

                //Dealer hand
                dealerCard1 = rand.Next(1, 11);
                dealerCard2 = rand.Next(1, 11);
                sumDealerCards = dealerCard1 + dealerCard2;
                TypewriterEffect($"Dealer's Card 1: {dealerCard1} & Dealer's Card 2: ... ", 10);



                //Player Hit or Stand
                //Fix hitting logic, currently only give the opportunity to hit once, need to allow player to hit multiple times until they choose to stand or bust
                Console.WriteLine("\n");
                Console.WriteLine("Hit (h) or Stand (s)");
                string playerTurnChoice = Console.ReadLine();
                if (playerTurnChoice == "h" || playerTurnChoice == "H")
                {
                    //Player hits
                    sumPlayerCards += rand.Next(1,11);
                    TypewriterEffect($"Total: {sumPlayerCards}", 10);
                }

                TypewriterEffect("Dealer is checking cards...", 30);
                System.Threading.Thread.Sleep(2000);

                //Bust Check
                if (roundOver == false)
                {
                    //Check player bust
                    if(sumPlayerCards > 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Player busts! Dealer wins.");
                        Console.ResetColor();
                        roundOver = true;      
                    }
                    else if(sumPlayerCards == 21 && sumPlayerCards > sumDealerCards)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Player blackjack! Dealer wins.");
                        Console.ResetColor();
                    }
                    else if (sumDealerCards > 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Dealer busts! Player wins.");
                        Console.ResetColor();
                        roundOver = true;
                    }
                    else if (sumPlayerCards > sumDealerCards)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Player wins!");
                        Console.ResetColor();
                        roundOver = true;
                    }
                    else if (sumDealerCards > sumPlayerCards)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Dealer wins!");
                        Console.ResetColor();
                        roundOver = true;
                    }
                    else
                    {
                        Console.WriteLine("It's a tie!");
                        roundOver = true;
                    }
                }


                //if(roundOver == True)
                //{
                    Console.WriteLine("\nWould you like to play again (Y/N) ?");
                    string playerContinue = Console.ReadLine();
                    if(playerContinue == "n" || playerContinue == "N")
                    {
                        playerPlays = false;
                        ClearDisplay(player);
                        return;
                    }

                //}

            }

        }
    }
}
