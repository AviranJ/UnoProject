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

namespace UnoProjectWeb.App_Code
{
    [Serializable]
    public class Player
    {
        public ArrayList cards;
        public String guID;

        public Player(ArrayList cards)
        {
            this.cards = cards;
        }

        public void AddCard(Card c)
        {
            cards.Add(c);
        }

        public void Clear()
        {
            cards.Clear();
        }

        public void Remove(Card card)
        {
           foreach (Card c in cards)
            {
                if (c.Color == card.Color && c.Number == card.Number && c.special == card.Special)
                {
                    cards.Remove(c);
                }
           }
        }

        public string GUID
        {
            get
            {
                return guID;
            }
            set
            {
                guID = value;
            }
        }

        public ArrayList Cards
        {
            get
            {
                return cards;
            }
        }

        public int NumberOfCards
        {
            get
            {
                return cards.Count;
            }
        }
    }
}
