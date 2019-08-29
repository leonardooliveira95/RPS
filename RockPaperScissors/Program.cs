using Newtonsoft.Json;
using System;
using System.Linq;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string strGame = "[ [\"Armando\", \"P\"], [\"Dave\", \"S\"] ]";
            string strTournament = "[[[[\"Armando\",\"P\"],[\"Dave\",\"S\"]],[[\"Richard\",\"R\"],[\"Michael\",\"S\"]]],[[[\"Allen\",\"S\"],[\"Omer\",\"P\"]],[[\"David E.\",\"R\"],[\"Richard X.\",\"P\"]]]]";

            string[,] arr = JsonConvert.DeserializeObject<string[,]>(strGame);
            string[][,,] arrTournament = JsonConvert.DeserializeObject<string[][,,]>(strTournament);

            Game g = new Game();

            string[] winner = g.rps_game_winner(arr);
            string[] tournamentWinner = g.rps_tournament_winner(arrTournament);

            Console.WriteLine(winner[0] + " wins. Move: " + winner[1]);
            Console.WriteLine(tournamentWinner[0] + " wins. Move: " + tournamentWinner[1]);

            Console.ReadLine();
        }

        
    }
}
