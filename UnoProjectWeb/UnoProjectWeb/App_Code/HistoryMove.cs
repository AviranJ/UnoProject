using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnoProjectWeb.App_Code
{
    public class HistoryMove
    {
        public int gameId;
        public int moveNumber;
        public string player;
        public string moveType;
        public string cardChosen;
        public string cardReceived;
        public string cardOnDeck;

        public HistoryMove(int gameId, int moveNumber, string player, string moveType,string cardChosen,string cardReceived, string cardOnDeck)
        {
            this.gameId = gameId;
            this.moveNumber = moveNumber;
            this.player = player;
            this.moveType = moveType;
            this.cardChosen = cardChosen;
            this.cardReceived = cardReceived;
            this.cardOnDeck = cardOnDeck;
        }




    }
}