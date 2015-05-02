using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;


/// <summary>
/// Summary description for Fraction
/// </summary>

namespace UnoProjectWeb.App_Code
{
    [Serializable]
    public class Fraction
    {
        public ArrayList cards;
        public string turn;
        public int numOfCards;
        public int oponnentCards;
        public int packOfCards;
        public Card lastCard;
        public string clientGuid;
        public string player;

        public Fraction(ArrayList cards, string turn, int oponnentCards, Card lastCard, int packOfCards)
        {
            this.cards = cards;
            this.turn = turn;
            this.numOfCards=cards.Count;
            this.oponnentCards = oponnentCards;
            this.lastCard = lastCard;
            this.packOfCards = packOfCards;
        }

        public string ClientGuid
        {
            set
            {
                clientGuid = value;
            }
        }



    }
}

