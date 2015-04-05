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

namespace UnoProjectWeb.enums
{
    public enum UnoCards
    {
        Back = -1,
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Plus2 = 10,
        Skip = 11,
        Reverse = 12,
        WildCard = 13,
        DrawTwo = 14,
        DrawFour = 15,
    }
}
