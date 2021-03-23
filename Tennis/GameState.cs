using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class GameState
    {
        public static bool IsEqualScoreline(int p1point, int p2point)
        {
            return p1point == p2point;
        }

        public static bool IsDeuce(int p1point, int p2point)
        {
            return IsEqualScoreline(p1point, p2point) && p1point > 2;
        }

        public static bool PlayerHasWinningAdvantage(int p1point, int p2point)
        {
            return !IsDeuce(p1point, p2point) && (p1point > 3 || p2point > 3);
        }

        public static bool IsOngoingGame(int p1point, int p2point)
        {
            if ((p1point < 4 && p2point < 4) && (p1point + p2point < 6)) return true;
            return false;
        }
    }
}
