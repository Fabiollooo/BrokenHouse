namespace BrokenHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter your characters name:");
            string CharacterName = Console.ReadLine();
            //Console.WriteLine("Welcome " + CharacterName + " !");
            ClearDisplay();
            


                                       // name, balance, current day, daily income
            Player player = new Player(CharacterName, 0.0, 1, 200.00);
            Family family = new Family();
            Game game = new Game();


            Console.WriteLine($"Name: { player.Name},  Balance: { player.Balance}, Day: {player.CurrentDay}, Daily Income: {player.DailyIncome}");
            Console.WriteLine("\n******************\n");

            while (true)
            {

            
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1 - Go to the Casino");
                Console.WriteLine("2 - Go Home");
                Console.WriteLine("\n");

                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("You're walking to the casino...");
                        game.ChooseGame();
                        break;

                    case 2:
                        Console.WriteLine("You're going Home...");
                        DisplayFamilyGreeting(family);
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }



        }// End of Main method


        static void DisplayFamilyGreeting(Family family)
        {
            TypewriterEffect($"Your Wife {family.Members[0].Name} welcomes you home.", 50);
            TypewriterEffect($"Suddenly your daughter {family.Members[1].Name} runs out of her room and also welcomes you back !", 50);
            
        }

        //Type writer effect for text display
        static void TypewriterEffect(string text, int delayMs = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        static void ClearDisplay() 
        {
            Console.Clear();
        }

    }
}

// **********  Example of Coloured fonts  ****************
//Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine("This is red text");
//Console.ResetColor();  

// **********  Example of Delayed cli  ****************
//System.Threading.Thread.Sleep(2000);