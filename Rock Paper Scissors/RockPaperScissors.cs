using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public static class RockPaperScissors
    {
        private static int turn = 0;
        private static string winner = "";
        private static List<Move> moveTypes = new List<Move>();

        public static void SetupVanilla()
        {
            moveTypes.Clear();
            turn = 0;
            winner = "";

            Move rock = new Move("Rock", "1");
            Move paper = new Move("Paper", "2");
            Move scissors = new Move("Scissors", "3");

            rock.WinsAgainst.Add(scissors);
            paper.WinsAgainst.Add(rock);
            scissors.WinsAgainst.Add(paper);

            moveTypes.Add(rock);
            moveTypes.Add(paper);
            moveTypes.Add(scissors);
        }

        public static void SetupLizardSpock()
        {
            SetupVanilla();

            Move rock = moveTypes.FirstOrDefault(x => x.Name == "Rock");
            Move paper = moveTypes.FirstOrDefault(x => x.Name == "Paper");
            Move scissors = moveTypes.FirstOrDefault(x => x.Name == "Scissors");

            Move lizard = new Move("Lizard", "4");
            Move spock = new Move("Spock", "5");

            rock.WinsAgainst.Add(lizard);
            lizard.WinsAgainst.Add(spock);
            spock.WinsAgainst.Add(scissors);
            scissors.WinsAgainst.Add(lizard);
            lizard.WinsAgainst.Add(paper);
            paper.WinsAgainst.Add(spock);
            spock.WinsAgainst.Add(rock);

            moveTypes.Add(lizard);
            moveTypes.Add(spock);
        }

        public static void Play()
        {
            Console.Clear();
            string playInstructions = "Choose your move:\n";
            foreach(Move move in moveTypes)
            {
                playInstructions += $"{move.Index} - {move.Name}\n";
            }

            Console.WriteLine(playInstructions);
            PlayTurn(Console.ReadLine());
        }

        private static void PlayTurn(string move)
        {
            //Player move
            Move playerMove = moveTypes.FirstOrDefault(x => x.Index == move);
            if(playerMove != null)
            {
                Console.Clear();
                Console.WriteLine($"You chose {playerMove.Name}");
                playerMove.Uses++;
                turn++;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please pick a valid option");
                Thread.Sleep(2000);
                Console.Clear();
                Play();
            }

            //Computer move
            Random random = new Random();
            Move computerMove = moveTypes[random.Next(moveTypes.Count)];
            Console.WriteLine($"The computer chose {computerMove.Name}\n");
            computerMove.Uses++;

            //Compare moves
            if(playerMove.WinsAgainst.Contains(computerMove))
            {
                winner = "Player";
                Console.WriteLine("You win!");
                Console.WriteLine("Press any key to return to view game stats...");
                Console.ReadKey();
                LogStats();
            }
            else if(computerMove.WinsAgainst.Contains(playerMove))
            {
                winner = "Computer";
                Console.WriteLine("You lose!");
                Console.WriteLine("Press any key to return to view game stats...");
                Console.ReadKey();
                LogStats();
            }
            else
            {
                Console.WriteLine("It's a draw!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Play();
            }
        }

        private static void LogStats()
        {
            Console.Clear();
            Move mostUsed = null;

            foreach(Move move in moveTypes)
            {
                if(mostUsed == null)
                {
                    mostUsed = move;
                }
                else if(move.Uses > mostUsed.Uses)
                {
                    mostUsed = move;
                }
            }

            Console.WriteLine("Game Stats\n");
            Console.WriteLine($"Winner: {winner}");
            Console.WriteLine($"Turns taken: {turn}");
            Console.WriteLine($"Most used move: {mostUsed.Name} ({mostUsed.Uses} times)\n");

            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
            Console.Clear();
            Program.MainMenu();
        }
    }
}
