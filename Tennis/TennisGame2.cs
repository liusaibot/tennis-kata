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
            var score = string.Empty;
            bool isEqualScore = IsEqualScoreline();
            bool isDeuceScore = IsDeuce();
            bool hasWinningAdvantage = playerHasWinningAdvantage();

            if (isDeuceScore) return "Deuce";

            if (isEqualScore && !isDeuceScore)
            {
                score = showDrawnScore();
                return score;
            }

            if(hasWinningAdvantage) {
                score = GetPlayerGameAdvantage();
                return score;
            }

            p1res = LookUpScoreMap(p1point);
            p2res = LookUpScoreMap(p2point);
            score = p1res + "-" + p2res;

            return score;
        }

        public bool IsEqualScoreline()
        {
            return p1point == p2point;
        }

        public bool IsDeuce()
        {
            return IsEqualScoreline() && p1point > 2;
        }

        public bool playerHasWinningAdvantage(){
            return !IsDeuce() && (p1point > 2 || p2point > 2);
        }

        public string GetPlayerGameAdvantage(){
            int advantage = p1point - p2point;
            string result = string.Empty;
            if(advantage == 1){
                result = "Advantage Player1";
            } else if(advantage == -1) {
                result = "Advantage Player2";                
            } else if(advantage >= 2){
                result = "Win for player1";
            } else {
                result = "Win for player2";
            }

            return result;
        }

        public string LookUpScoreMap(int point)
        {
            string result = string.Empty;
            string[] scoreMap = { "Love", "Fifteen", "Thirty", "Forty" };
            if(point >= 0 && point < 3) {
                result = scoreMap[point];
            }
            return result;
        }

        public string showDrawnScore()
        {
            string score = string.Empty;
            switch(p1point)
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

