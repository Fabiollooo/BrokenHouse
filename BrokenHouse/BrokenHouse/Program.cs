using System.Numerics;
using System.IO;
using System.Text.Json;

namespace BrokenHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string CharacterName;
            Player player;
            ReadToFile saveSystem = new ReadToFile();


            string filePath = @".\saves\save.json";
            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                Console.WriteLine("Character found !");
                TypewriterEffect("Loading character...\n\n", 20);
                System.Threading.Thread.Sleep(1000);
                player = saveSystem.LoadPlayer();
                CharacterName = player.Name;
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("Enter your characters name:");
                CharacterName = Console.ReadLine();
                player = new Player(CharacterName, 0.0, 1, 200.00);
                saveSystem.WriteToFile(player);
                System.Threading.Thread.Sleep(2000);

            }
                                       // name, balance, current day, daily income
            //Player player = new Player(CharacterName, 0.0, 1, 200.00);
            Family family = new Family();
            Game game = new Game();
            Home home = new Home();

            ClearDisplay(player);
            
            while (true)
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1 - Go to the Casino");
                Console.WriteLine("2 - Go Home");
                Console.WriteLine("3 - Save game");
                Console.WriteLine("4 - Restart game");
                Console.WriteLine("\n");

                Console.ForegroundColor = ConsoleColor.Black;
                int choice = int.Parse(Console.ReadLine());
                Console.ResetColor();
                switch(choice)
                {
                    case 1:
                        ClearDisplay(player);
                        TypewriterEffect("You're walking to the casino...", 20);
                        game.ChooseGame(player);
                        break;

                    case 2:
                        TypewriterEffect("You're walking Home...", 20);
                        DisplayFamilyGreeting(family, player);
                        home.ChooseHomeOption(player, family);
                        break;

                    case 3:
                        TypewriterEffect("Saving game...", 20);
                        saveSystem.WriteToFile(player);
                        break;

                    case 4:
                        TypewriterEffect("Restarting game", 40);
                        //Restart game to default, overwrite the previous character
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }



        }// End of Main method


        static void DisplayFamilyGreeting(Family family,  Player player)
        {
            TypewriterEffect($"Your Wife {family.Members[0].Name} welcomes you home.", 20);
            TypewriterEffect($"Suddenly your daughter {family.Members[1].Name} runs out of her room and also welcomes you back !", 20);
            System.Threading.Thread.Sleep(2000);
            ClearDisplay(player);

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
                Console.WriteLine("************************************\n");
                Console.ResetColor();
                    Console.WriteLine($"Name: {player.Name},  Balance: {player.Balance}, Day: {player.CurrentDay}, Daily Income: {player.DailyIncome}");
                Console.ForegroundColor= ConsoleColor.DarkBlue;
                Console.WriteLine("\n************************************\n");
            Console.ResetColor();

        }

        static void ClearDisplay(Player player) 
        {
            Console.Clear();
            DisplayPlayerInfo(player);
        }

    }
}

// **********  Example of Coloured fonts  ****************
//Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine("This is red text");
//Console.ResetColor();  

// **********  Example of Delayed cli  ****************
//System.Threading.Thread.Sleep(2000);