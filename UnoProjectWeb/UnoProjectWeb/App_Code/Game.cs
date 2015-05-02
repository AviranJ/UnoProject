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
    public class Game
    {
        public Player p1, p2;
        public String turn;
        public ArrayList deck;
        public Card lastCard;

        public Game() {
            Random r = new Random();

            for (int i = 1; i <= 9; i++)
            {
                Card c1 = new Card("Green", 1);
                Card c2 = new Card("Red", 1);
                Card c3 = new Card("Blue", 1);
                Card c4 = new Card("Yellow", 1);
                deck.Add(c1);
                deck.Add(c2);
                deck.Add(c3);
                deck.Add(c4);
            }
            int numOfCards = 36;
            ArrayList p1Cards= new ArrayList();
            ArrayList p2Cards = new ArrayList();

            for (int i = 1; i <= 7; i++)
            {
                int random1 = r.Next(numOfCards);
                Card c1 = (Card)deck[random1];
                p1Cards.Add(c1);
                deck.Remove(deck[random1]);

                int random2 = r.Next(numOfCards-1);
                Card c2 = (Card)deck[r.Next(numOfCards-1)];
                p2Cards.Add(c2);
                deck.Remove(deck[random2]);

                numOfCards -= 2;
            }
            p1 = new Player(p1Cards);
            p2 = new Player(p2Cards);

            int random = r.Next(numOfCards);
            lastCard = (Card)deck[random];
            deck.Remove(deck[random]);

            turn = p1.GUID;
        }

        public Player Player1
        {
            get
            {
                return p1;
            }
        }

        public Player Player2
        {
            get
            {
                return p2;
            }
        }

    }
}
