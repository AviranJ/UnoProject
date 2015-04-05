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
    public class Game
    {
        public Player p1, p2;
        public String turn;
        public ArrayList deck;
        public Card lastCard;

        public Game() {
        
        }

    }
}
