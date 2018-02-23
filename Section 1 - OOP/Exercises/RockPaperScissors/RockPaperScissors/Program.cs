using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.BLL;
using RockPaperScissors.BLL.Players;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            //RPSChoice choice = RPSChoice.Rock;

            IChoiceGetter p1 = new HumanPlayer(); //could use var, but having the left side be an interface makes things more explicit
            IChoiceGetter p2 = new RandomPlayer();

            var engine = new GameEngine(p1, p2);

            int p1Wins = 0;
            int p2Wins = 0;
            int draws = 0;
            int gameNumber = 1;

            for (int i = 0; i < 100; i++)
            {
                RoundResults result = engine.PlayerRound();

                Console.WriteLine($"Player 1 played {result.P1Choice} and Player 2 played {result.P2Choice}. Game number: {gameNumber}");

                if (result.Result < 0)
                {
                    p1Wins++;
                    Console.WriteLine("Player 1 wins!");
                }
                else if (result.Result > 0)
                {
                    p2Wins++;
                    Console.WriteLine("Player 2 wins!");
                }
                else
                {
                    draws++;
                    Console.WriteLine("Draw!");

                }

                gameNumber++;
            }

            Console.WriteLine("After 100 games: ");
            Console.WriteLine("Player 1 wins: " + p1Wins);
            Console.WriteLine("Player 2 wins: " + p2Wins);
            Console.WriteLine("Draws: " + draws);

            Console.ReadLine();
        }
    }
}
