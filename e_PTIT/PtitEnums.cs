using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_PTIT
{
    public class PtitEnums
    {
        public enum GameType
        {
            Matching=1,
            SelectOne=2,
            WriteAnswer=3,
            FindDifference=4,
            Crossword=5
        }

        public enum GameMenuType
        {
            Language=1,
            Logical=2,
            Mathematical=3,
            Others=4
        }
    }

    public static class Constants
    {
        public const string SHOW_ANSWER = "Պատասխան";
    }
}
