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

namespace UnoProjectWeb.App_Code
{
    internal class Player
    {
        public Cards cards = new Cards();

        public void AddCard(Card c)
        {
            this.cards.Add(c);
        }

        public void Clear()
        {
            this.cards.Clear();
        }
    }
}
