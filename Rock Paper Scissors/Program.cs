namespace Rock_Paper_Scissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.WriteLine("Do you want to play\n1 - Rock Paper Scissors\n2 - Rock Paper Scissors Lizard Spock\n");
            string gameMode = Console.ReadLine();
            if (gameMode == "1")
            {
                Console.Clear();
                RockPaperScissors.SetupVanilla();
                RockPaperScissors.Play();
            }
            else if (gameMode == "2")
            {
                Console.Clear();
                RockPaperScissors.SetupLizardSpock();
                RockPaperScissors.Play();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please pick a valid option");
                Thread.Sleep(2000);
                Console.Clear();
                MainMenu();
            }
        }
    }
}