namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            if(IsDeuce()) return "Deuce";

            if(IsEqualScoreline() == true && !IsDeuce()) return GetDrawnScore();

            if(PlayerHasWinningAdvantage()) return GetPlayerGameAdvantage();

            if (IsOngoingGame()) return GetOngoingScore();

            return string.Empty;
            
        }

        public bool IsEqualScoreline()
        {
            return p1point == p2point;
        }

        public bool IsDeuce()
        {
            return IsEqualScoreline() && p1point > 2;
        }

        public bool PlayerHasWinningAdvantage()
        {
            return !IsDeuce() && (p1point > 3 || p2point > 3);
        }

        public bool IsOngoingGame()
        {
            if ((p1point < 4 && p2point < 4) && (p1point + p2point < 6)) return true;
            return false;
        }

        public string GetPlayerGameAdvantage()
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

        public string GetPlayerScore(int point)
        {
            string result = string.Empty;
            string[] scoreMap = { "Love", "Fifteen", "Thirty", "Forty" };
            if (point >= 0 && point <= 3)
            {
                result = scoreMap[point];
            }
            return result;
        }

        public string GetDrawnScore()
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

        public string GetOngoingScore()
        {
            p1res = GetPlayerScore(p1point);
            p2res = GetPlayerScore(p2point);
            return p1res + "-" + p2res;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

