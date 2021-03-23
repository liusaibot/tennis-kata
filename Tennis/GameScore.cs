using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class GameScore
    {
        public static string GetPlayerGameAdvantageScore(int p1point, int p2point)
        {
            int advantage = p1point - p2point;
            string result = string.Empty;
            if (advantage == 1)
            {
                result = "Advantage player1";
            }
            else if (advantage == -1)
            {
                result = "Advantage player2";
            }
            else if (advantage >= 2)
            {
                result = "Win for player1";
            }
            else
            {
                result = "Win for player2";
            }

            return result;
        }

        public static string GetPlayerScore(int point)
        {
            string result = string.Empty;
            string[] scoreMap = { "Love", "Fifteen", "Thirty", "Forty" };
            if (point >= 0 && point <= 3)
            {
                result = scoreMap[point];
            }
            return result;
        }

        public static string GetDrawnScore(int p1point)
        {
            string score = string.Empty;
            switch (p1point)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }
            return score;
        }

        public static string GetOngoingScore(int p1point, int p2point)
        {
            string p1res = GetPlayerScore(p1point);
            string p2res = GetPlayerScore(p2point);
            return p1res + "-" + p2res;
        }
    }
}
