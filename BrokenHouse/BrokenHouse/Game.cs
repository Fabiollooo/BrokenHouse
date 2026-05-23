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
                Console.WriteLine("New game has begun !\n");
                Random rand = new Random();
                //Player hand
                    playerCard1 = rand.Next(1, 11);
                    playerCard2 = rand.Next(1, 11);
                    sumPlayerCards = playerCard1 + playerCard2;
                TypewriterEffect($"{player.Name}'s Card 1: {playerCard1} & Card 2: {playerCard2} || {sumPlayerCards}", 10);
                Console.WriteLine("\n");

                //Dealer hand
                    dealerCard1 = rand.Next(1, 11);
                    dealerCard2 = rand.Next(1, 11);
                    sumDealerCards = dealerCard1 + dealerCard2;
                    TypewriterEffect($"Dealer's Card 1: {dealerCard1} & Dealer's Card 2: ... ", 10);



                ////////////////////////////////////////////////////////////////////////////////////////
                //Player Hit or Stand
                //Fix hitting logic, currently only give the opportunity to hit once, need to allow player to hit multiple times until they choose to stand or bust
                //Also fix the dealer logic, currently the dealer does not hit at all, need to implement logic for dealer to hit until they reach 17 or higher


                Console.WriteLine("\n");
                bool PlayerHits = true;

                while (PlayerHits == true)
                {
                    Console.WriteLine("Hit (h) or Stand (s)");
                    string playerTurnChoice = Console.ReadLine();

                    //Player hits 
                    if (playerTurnChoice == "h" || playerTurnChoice == "H")
                    {
                        sumPlayerCards += rand.Next(1, 11);
                        TypewriterEffect($"Total: {sumPlayerCards}", 10);
                        if(sumPlayerCards > 21)
                        {
                            CheckBlackjackbust(sumPlayerCards, sumDealerCards, roundOver);
                            PlayerHits = false;
                            roundOver = true;
                        }
                        else if (sumPlayerCards == 21)
                        {
                            CheckBlackjackbust(sumPlayerCards, sumDealerCards, roundOver);
                        }

                    }
                    else if (playerTurnChoice == "s" || playerTurnChoice == "S")
                    {
                        PlayerHits = false;
                        TypewriterEffect("\nPlayer stands.", 10);
                        TypewriterEffect("Dealer is checking cards...", 30);
                        System.Threading.Thread.Sleep(2000);
                        CheckBlackjackbust(sumPlayerCards, sumDealerCards, roundOver);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter 'h' or 's'.");
                    }

                }

                ////////////////////////////////////////////////////////////////////////////////////////




                


               
                Console.WriteLine("\nWould you like to play again (Y/N) ?");
                string playerContinue = Console.ReadLine();
                if(playerContinue == "n" || playerContinue == "N")
                {
                    playerPlays = false;
                    ClearDisplay(player);
                    return;
                }
                else if(playerContinue == "y" || playerContinue == "Y")
                {
                    playerPlays = false;
                    ClearDisplay(player);
                    PlayBlackjack(player);

                }

                

            }




        }//End of PlayBlackjack

        static void CheckBlackjackbust(int sumPlayerCards,int sumDealerCards, bool roundOver)
        {
            //Bust Checker
            if (roundOver == false)
            {
                //Check player bust uwu
                if (sumPlayerCards > 21)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlayer busts! Dealer wins.");
                    Console.ResetColor();
                    roundOver = true;
                }
                else if (sumPlayerCards == 21 && sumPlayerCards > sumDealerCards)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPlayer hit blackjack! Dealer wins.");
                    Console.ResetColor();
                }
                else if (sumDealerCards > 21)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nDealer busts! Player wins.");
                    Console.ResetColor();
                    roundOver = true;
                }
                else if (sumPlayerCards > sumDealerCards)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPlayer wins!");
                    Console.ResetColor();
                    roundOver = true;
                }
                else if (sumDealerCards > sumPlayerCards)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDealer wins!");
                    Console.ResetColor();
                    roundOver = true;
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                    roundOver = true;
                }

                Console.WriteLine($"Player Hand: {sumPlayerCards}");
                Console.WriteLine($"Dealer Hand: {sumDealerCards}");
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
    }
}
