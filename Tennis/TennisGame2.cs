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

            if(PlayerHasWinningAdvantage()) return GetPlayerGameAdvantageScore();

            if (IsOngoingGame()) return GetOngoingScore();

            return string.Empty;
            
        }

        public bool IsEqualScoreline()
        {
            return GameState.IsEqualScoreline(p1point, p2point);
        }

        public bool IsDeuce()
        {
            return GameState.IsDeuce(p1point, p2point);
        }

        public bool PlayerHasWinningAdvantage()
        {
            return GameState.PlayerHasWinningAdvantage(p1point, p2point);
        }

        public bool IsOngoingGame()
        {
            return GameState.IsOngoingGame(p1point, p2point);
        }

        public string GetPlayerGameAdvantageScore()
        {
            return GameScore.GetPlayerGameAdvantageScore(p1point, p2point);            
        }

        public string GetPlayerScore(int point)
        {
            return GameScore.GetPlayerScore(point);
        }

        public string GetDrawnScore()
        {
            return GameScore.GetDrawnScore(p1point);
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

