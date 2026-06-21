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
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n╔════════════════════════════════╗");
                Console.WriteLine("║     CHOOSE A GAME TO PLAY      ║");
                Console.WriteLine("╚════════════════════════════════╝\n");
                Console.ResetColor();
            
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  1 - Blackjack ");
                Console.WriteLine("  2 - Roulette ");
                Console.WriteLine("  3 - Craps ");
                Console.WriteLine("  4 - Higher or Lower ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("  0 - Go Back");
                Console.ResetColor();
                Console.WriteLine();
                //Add more games later maybe


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
                        Console.WriteLine("Blackjack it is...");
                        ClearDisplay(player);
                        PlayBlackjack(player);
                        break;

                    case 2:
                        Console.WriteLine("Roulette it is...");
                    
                        break;

                    case 3:
                        Console.WriteLine("Craps it is...");
                        ClearDisplay(player);
                        PlayCraps(player);

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
                        System.Threading.Thread.Sleep(1000);
                        ClearDisplay(player);
                        break;
                }
            }
        }//end of ChooseGame

        

        static void PlayBlackjack(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n╔═══════════════════════════════════╗");
            Console.WriteLine("║    WELCOME TO BLACKJACK           ║");
            Console.WriteLine("╚═══════════════════════════════════╝\n");
            Console.ResetColor();

            double playerBet = 0;
            bool playerWin = false;
            PlaceBet(player, ref playerBet );
            ClearDisplay(player);


            int playerCard1 = 0;
            int playerCard2 = 0;
            int dealerCard1 = 0;
            int dealerCard2 = 0;
            int sumPlayerCards = 0;
            int sumDealerCards = 0;
            bool roundOver = false;
            bool gameTied = false;

            bool playerPlays = true;
            while (playerPlays)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"--- Current bet ({playerBet})  ---");


                Console.WriteLine(">>> New Round Started <<<\n");
                Console.ResetColor();

                Random rand = new Random();
                //Player hand
                    playerCard1 = rand.Next(1, 11);
                    playerCard2 = rand.Next(1, 11);
                    sumPlayerCards = playerCard1 + playerCard2;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypewriterEffect($"┌─ {player.Name}'s Hand ─┐", 5);
                    Console.ResetColor();
                    TypewriterEffect($"   Card 1: {playerCard1}  |   Card 2: {playerCard2}", 10);
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypewriterEffect($"  Total: {sumPlayerCards}", 10);
                    Console.ResetColor();
                    Console.WriteLine();

                //Dealer hand
                    dealerCard1 = rand.Next(1, 11);
                    dealerCard2 = rand.Next(1, 11);
                    sumDealerCards = dealerCard1 + dealerCard2;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    TypewriterEffect($"┌─ Dealer's Hand ─┐", 5);
                    Console.ResetColor();
                    TypewriterEffect($"   Card 1: {dealerCard1}  |   Card 2: [Hidden]", 10);



                ////////////////////////////////////////////////////////////////////////////////////////
                //Player Hit or Stand

                Console.WriteLine();
                bool PlayerHits = true;

                while (PlayerHits == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("─────────────────────────────────");
                    Console.ResetColor();
                    Console.Write("> Hit (h) or Stand (s)? ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("> ");
                    Console.ResetColor();
                    string playerTurnChoice = Console.ReadLine();

           
                    if (playerTurnChoice == "h" || playerTurnChoice == "H")
                    {
                        int newCard = rand.Next(1, 11);
                        sumPlayerCards += newCard;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypewriterEffect($" You drew a {newCard}!", 10);

                        Console.ForegroundColor = ConsoleColor.Green;
                        TypewriterEffect($" New Total: {sumPlayerCards}", 10);
                        Console.ResetColor();

                        if(sumPlayerCards > 21)
                        {
                            CheckBlackjackbust(sumPlayerCards, sumDealerCards, roundOver, ref playerWin, ref gameTied);
                            PlayerHits = false;
                            roundOver = true;
                        }
                        else if (sumPlayerCards == 21)
                        {
                            CheckBlackjackbust(sumPlayerCards, sumDealerCards, roundOver, ref playerWin, ref gameTied);
                        }

                    }
                    else if (playerTurnChoice == "s" || playerTurnChoice == "S")
                    {
                        PlayerHits = false;
                        if(sumDealerCards <= 17)
                        {
                            while (sumDealerCards <= 17)
                            {
                                sumDealerCards += rand.Next(1, 11);
                            }
                        }


                        TypewriterEffect("\nPlayer stands.", 10);
                        TypewriterEffect("Dealer is checking cards...", 30);
                        System.Threading.Thread.Sleep(2000);
                        CheckBlackjackbust(sumPlayerCards, sumDealerCards, roundOver, ref playerWin, ref gameTied);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter 'h' or 's'.");
                    }

                }

                BetReward(player, ref playerBet, ref playerWin, ref gameTied);

                ////////////////////////////////////////////////////////////////////////////////////////


                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("═══════════════════════════════════");
                Console.ResetColor();
                Console.Write("Would you like to play again? (y/n) ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("> ");
                Console.ResetColor();
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

        static void CheckBlackjackbust(int sumPlayerCards,int sumDealerCards, bool roundOver, ref bool playerWin, /*ref bool game,*/ ref bool gameTied)
        {    

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("═══════════════════════════════════");
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($" Your Hand:  {sumPlayerCards}");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($" Dealer Hand: {sumDealerCards}");
            Console.ResetColor();

            //Bust Checker
            if (roundOver == false)
            {
                //Check player bust uwu
                if (sumPlayerCards > 21)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypewriterEffect("\nPlayer busts! Dealer wins.");
                    Console.ResetColor();
                    roundOver = true;
                    playerWin = false;
                }
                else if (sumPlayerCards == 21 && sumPlayerCards > sumDealerCards)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypewriterEffect("\nPlayer hit blackjack! Player wins.", 30);
                    Console.ResetColor();
                    playerWin = true;
                }
                else if (sumDealerCards > 21)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypewriterEffect("\nDealer busts! Player wins.", 30);
                    Console.ResetColor();
                    roundOver = true;
                    playerWin = true;
                }
                else if (sumPlayerCards > sumDealerCards)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypewriterEffect("\nPlayer wins!", 30);
                    Console.ResetColor();
                    roundOver = true;
                    playerWin = true;
                }
                else if (sumDealerCards > sumPlayerCards)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypewriterEffect("\nDealer wins!", 30);
                    Console.ResetColor();
                    roundOver = true;
                    playerWin= false;
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                    roundOver = true;
                    gameTied = true;
                    //No one wins here add an acception !!!!!!!!
                }

            }
        }


        static void PlayCraps(Player player)
        {
            
            TypewriterEffect("Welcome to Craps !", 20);
            //Select bet

            int PlayerDice1 = 0;
            int PlayerDice2 = 0;
            int PlayerDiceSum;
            int DealerDice1 = 0;
            int DealerDice2 = 0;
            int DealerDiceSum = 0;
            bool PlayerPointRoll = true;
            int PlayerPointSum = 0;

            TypewriterEffect("Roll the Dice... (R)", 20);
            string PlayerRoll = Console.ReadLine();
            if (PlayerRoll == "R" || PlayerRoll == "r")
            {
                Random rand = new Random();
                PlayerDice1 = rand.Next(1, 6);
                TypewriterEffect($"You rolled a {PlayerDice1} !", 20);
                PlayerDice2 = rand.Next(1, 6);
                TypewriterEffect($"You rolled a {PlayerDice2} !", 20);

                PlayerDiceSum = PlayerDice1 + PlayerDice2;
                Console.WriteLine("--------------");
                TypewriterEffect($"Total: {PlayerDiceSum} ", 20);

                Console.WriteLine();
                System.Threading.Thread.Sleep(800);
                if (PlayerDiceSum == 7 || PlayerDiceSum == 11)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congrats the Player wins\n");
                    Console.ResetColor();
                    //Add bet reward here

                    System.Threading.Thread.Sleep(2000);
                    ClearDisplay(player);
                }
                else if (PlayerDiceSum == 2 || PlayerDiceSum == 3 || PlayerDiceSum == 12)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dealer wins...\n");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(2000);
                    ClearDisplay(player);
                }
                else if (PlayerDiceSum == 4 || PlayerDiceSum == 5 || PlayerDiceSum == 6 || PlayerDiceSum == 8 || PlayerDiceSum == 9 || PlayerDiceSum == 10 )
                {
                    PlayerPointSum = PlayerDiceSum;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("***************");
                    Console.WriteLine("Point Break !");
                    Console.WriteLine("***************\n");
                    Console.ResetColor();
                    while (PlayerPointRoll == true)
                    {
                        TypewriterEffect("Roll the Dice... (R)", 20);
                        PlayerRoll = Console.ReadLine();
                        if (PlayerRoll == "R" || PlayerRoll == "r")
                        {
                            PlayerDice1 = rand.Next(1, 6);
                            TypewriterEffect($"You rolled a {PlayerDice1} !", 20);
                            PlayerDice2 = rand.Next(1, 6);
                            TypewriterEffect($"You rolled a {PlayerDice2} !", 20);
                            PlayerPointSum = PlayerDice1 + PlayerDice2;
                            
                            Console.WriteLine("--------------");
                            TypewriterEffect($"Total: {PlayerPointSum} ", 20);


                            if (PlayerPointSum == 7)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("--------------------");
                                Console.WriteLine("Dealer wins !");
                                Console.WriteLine("--------------------\n");
                                Console.ResetColor();
                                
                                System.Threading.Thread.Sleep(1000);
                                ClearDisplay(player);
                                PlayerPointRoll = false;
                                //return;
                            }
                            else if (PlayerPointSum == PlayerDiceSum)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("--------------------");
                                Console.WriteLine("Congrats the Player wins !");
                                Console.WriteLine("--------------------\n");
                                Console.ResetColor();
                                System.Threading.Thread.Sleep(1000);
                                ClearDisplay(player);

                                PlayerPointRoll = false;
                                //return;
                            }
                            else
                            {
                                Console.WriteLine("Neutral Roll...");
                                Console.WriteLine("Roll again");
                                System.Threading.Thread.Sleep(1000);
                                ClearDisplay(player);
                                Console.WriteLine($"The Point: {PlayerDiceSum}");
                            }
                        }
                    }
                }
                else 
                {
                    Console.WriteLine("Jew");
                }
            }


        }

        static void PlaceBet(Player player, ref double playerBet)
        {
            TypewriterEffect("Please enter your bet value !", 20);
            playerBet = int.Parse(Console.ReadLine());

            while (true)
            {
                if(playerBet > player.Balance)
                {
                    TypewriterEffect("Insuficiant funds !", 20);
                    TypewriterEffect("Broke boy !", 5);
                    System.Threading.Thread.Sleep(2000);
                    ClearDisplay(player);
                    PlaceBet(player, ref playerBet);
                }
                else
                {
                    TypewriterEffect("Bet successful", 20);
                    player.Balance -= playerBet;
                    return;
                }

            }

        }

        static void BetReward(Player player,ref double playerBet, ref bool playerWin, ref bool gameTied)
        {
            if (playerWin == true)
            {
                player.Balance += (playerBet * 2);
                TypewriterEffect($"Congrats you won {playerBet * 2} !", 20);
            }
            else if(gameTied == true)
            {
                TypewriterEffect($"Game Tied !, You won {playerBet}", 20);
                player.Balance += playerBet;
                gameTied = false;
            }
            else
            {
                TypewriterEffect($"Unlucky lil bro, you lost {playerBet} !", 20);

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
