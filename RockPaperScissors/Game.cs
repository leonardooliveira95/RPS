using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RockPaperScissors
{
    public class Game
    {
        private readonly string[] PLAYER_STRATEGIES = new[] { "R", "P", "S" };

        public string[] rps_game_winner(string[,] arr)
        {
            if (arr.GetLength(0) != 2 || arr.GetLength(1) != 2)
            {
                throw new WrongNumberOfPlayersError("Number of players not equal to 2");
            }

            if (!PLAYER_STRATEGIES.Any(x => arr[0, 1].ToUpper().Contains(x)) ||
                !PLAYER_STRATEGIES.Any(x => arr[1, 1].ToUpper().Contains(x)))
            {
                throw new NoSuchStrategyError("The strategy must be R, P or S");
            }

            string strategy1 = arr[0, 1].ToUpper();
            string strategy2 = arr[1, 1].ToUpper();

            //If both player play the same strategy, player 1 wins
            if (strategy1 == strategy2)
            {
                return return_winner(arr, 0);
            }
            
            //Rock beats scissors
            if (strategy1 == PLAYER_STRATEGIES[0] && strategy2 == PLAYER_STRATEGIES[2])
            {
                return return_winner(arr, 0);
            }

            //Scissors beats paper
            if(strategy1 == PLAYER_STRATEGIES[2] && strategy2 == PLAYER_STRATEGIES[1])
            {
                return return_winner(arr, 0);
            }

            //Paper beats rock
            if (strategy1 == PLAYER_STRATEGIES[1] && strategy2 == PLAYER_STRATEGIES[0])
            {
                return return_winner(arr, 0);
            }
            
            return return_winner(arr, 1);
        }

        public string[] return_winner(string[,] arr, int winner)
        {
            return Enumerable.Range(0, arr.GetLength(1))
                .Select(x => arr[winner, x])
                .ToArray();
        }

        public string[] rps_tournament_winner(string[][,,] arr)
        {
            string[,,] res = new string[arr.Length * arr[0].GetLength(0),arr[1].GetLength(1),arr[0].GetLength(2)];

            int pos = 0;

            //Array
            for(int i = 0; i < arr.Length; i++)
            {
                //Round
                for(int j = 0;j < arr[i].GetLength(0); j++)
                {
                    //Player
                    for(int k = 0; k < arr[i].GetLength(1); k++)
                    {
                        //Strategy
                        for(int l = 0;l < arr[i].GetLength(2); l++)
                        {
                            res[pos, k, l] = arr[i][j, k, l];
                        }
                    }

                    pos++;
                }
            }

            return calculate_winner(res);
        }

        private string[] calculate_winner(string[,,] round)
        {
            while (round.GetLength(0) > 1)
            {
                int pos = 0;
                int len = round.GetLength(0) / 2;
                string[,,] res = new string[len, round.GetLength(1), round.GetLength(2)];

                for (int j = 0; j < round.GetLength(0); j++)
                {
                    string[,] game = create_game(j, round);
                    string[] game_winner = rps_game_winner(game);

                    if (j % 2 == 0)
                    {
                        //Player name
                        res[pos, 0, 0] = game_winner[0];

                        //Player strategy
                        res[pos, 0, 1] = game_winner[1];
                    }
                    else
                    {
                        //Player name
                        res[pos, 1, 0] = game_winner[0];

                        //Player strategy
                        res[pos, 1, 1] = game_winner[1];

                        pos++;
                    }
                }

                round = res;
            }

            string[,] finalGame = create_game(0, round);

            return rps_game_winner(finalGame);
        }

        private string[,] create_game(int index, string[,,] round)
        {
            string[,] game = new string[2, 2];

            for (int k = 0; k < round.GetLength(1); k++)
            {
                for (int l = 0; l < round.GetLength(2); l++)
                {
                    game[k, l] = round[index, k, l];
                }
            }

            return game;
        }
    }
}
