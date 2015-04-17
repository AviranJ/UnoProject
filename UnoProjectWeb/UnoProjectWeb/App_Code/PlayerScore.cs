using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnoProjectWeb.App_Code
{
    public class PlayerScore
    {
        public string playerName;
        public int totalWins;

        public PlayerScore(string playerName, int totalWins)
        {
            this.playerName = playerName;
            this.totalWins = totalWins;
        }
    }
}