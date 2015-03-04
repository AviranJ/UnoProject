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
using UnoProjectWeb.enums;

namespace UnoProjectWeb.App_Code
{
    internal class OpenDeck : ArrayList
    {
        public Card this[int index]
        {
            get
            {
                if (index < this.Count)
                    return (Card)base[index];
                return (Card)null;
            }
        }

        public void Add(Card c)
        {
            this.Add((object)c);
            GameData.RunningColor = c.color;
        }

        public override void Clear()
        {
            base.Clear();
            GameData.form.lblColorRunning.Text = "";
        }

        public Cards GetCards()
        {
            Cards cards = new Cards();
            foreach (Card card in (ArrayList)this)
                cards.Add(card);
            return cards;
        }

        public Card LastCard()
        {
            if (this.Count > 0)
                return (Card)base[this.Count - 1];
            return (Card)null;
        }
    }
}
