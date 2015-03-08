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
using UnoProjectWeb.enums;
using System.Collections;

namespace UnoProjectWeb.App_Code
{
    internal class ApplicationData
    {
        private static Timer timer = new Timer();
        private static long start = 0L;;

        public static int GetPoint(Card card)
        {
            if (card.number > UnoCards.Zero && card.number <= UnoCards.Nine)
                return (int)card.number;
            if (card.number > UnoCards.Nine && card.number < UnoCards.WildCard)
                return 20;
            return card.number >= UnoCards.WildCard && card.number <= UnoCards.DrawFour ? 50 : 0;
        }

        public static Card GetBiggestCard(Cards cards)
        {
            Card card1 = (Card)null;
            UnoCards unoCards = UnoCards.Back;
            foreach (Card card2 in (ArrayList)cards)
            {
                if (card2.number > unoCards)
                {
                    card1 = card2;
                    unoCards = card2.number;
                }
            }
            return card1;
        }

        public static Random GetRandomObject()
        {
            return new Random((int)(DateTime.Now.Ticks ^ (long)int.MaxValue));
        }

    }
}
