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
using System.Drawing;
using System.IO;
using System.Reflection;
using UnoProjectWeb.enums;

namespace UnoProjectWeb.App_Code
{
    
    public class Card
    {
        public UnoCards number;
        public UnoColours color;
        public int imageListOffset;
        //public Image cardImage;

        public Card(UnoCards num, int off, UnoColours col)
        {
            this.number = num;
            this.imageListOffset = off;
            this.color = col;
            //string name = "Uno.Images." + GameData.cardImageList[off];
        }

        public override string ToString()
        {
            return (string)(object)this.number + (object)" of " + this.color.ToString();
        }
    }
}
