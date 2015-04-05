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
        public int number;
        public string color;
        public string special;

        public Card(String color, int number)
        {
            this.color = color;
            this.number = number;
            special = null;
        }
        public Card(String special,String color)
        {
            this.special = special;
            this.color = color;
            number = 0;
        }

        public bool isSpecial
        {
            get
            {
                return special != null;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public string Special
        {
            get
            {
                return special;
            }
            set
            {
                special = value;
            }
        }


        // add, remove, clear functions
    }
}
