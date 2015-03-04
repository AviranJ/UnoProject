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

namespace UnoProjectWeb.App_Code
{
    internal class GameData
    {
        public static string[] cardImageList = new string[55];
        public static Player player = new Player();
        public static Player opponnent = new Player();
        public static Deck deck = new Deck();
        public static OpenDeck openCards = new OpenDeck();
        public static Card backFacingCard = (Card)null;
        private static int totalPlayerScore = 0;
        private static int totalOpponentScore = 0;
        public static int playerScore = 0;
        public static int opponentScore = 0;
        public static string playerName = string.Empty;
        public static bool flagDirty = true;
        private static UnoColours runningColor = UnoColours.NoColor;
        public const int OverLappedRegionWidthRatio = 4;

        public static int TotalPlayerScore
        {
            get
            {
                return GameData.totalPlayerScore;
            }
            set
            {
                GameData.totalPlayerScore = value;
                //GameData.form.lblPlayerScore.Text = GameData.totalPlayerScore.ToString();
            }
        }

        public static int TotalOpponentScore
        {
            get
            {
                return GameData.totalOpponentScore;
            }
            set
            {
                GameData.totalOpponentScore = value;
                //GameData.form.lblOpponentScore.Text = GameData.totalOpponentScore.ToString();
            }
        }

        public static UnoColours RunningColor
        {
            get
            {
                return GameData.runningColor;
            }
            set
            {
                GameData.runningColor = value;
                //if (GameData.runningColor == UnoColours.NoColor)
                //    GameData.form.lblColorRunning.Text = "Any color";
                //else
                //    GameData.form.lblColorRunning.Text = GameData.runningColor.ToString();
            }
        }

        private static void readConfig()
        {
            if (GameData.form.Args.Length > 0)
            {
                Arguments arguments = new Arguments(GameData.form.Args);
                if (arguments["debug"] != null)
                {
                    int num = Convert.ToInt32(arguments["debug"]);
                    Data.LogLevel = num < 1 || num > 3 ? 1 : num;
                }
                else
                    Data.LogLevel = 1;
            }
            else
                Data.LogLevel = 1;
            Logger.Write(1, "The log level set is = " + (object)Data.LogLevel);
            Logger.FuncExit("GameData.readConfig");
        }

        private static void buildImageList()
        {
            int num1 = 0;
            string[] strArray1 = GameData.cardImageList;
            int index1 = num1;
            int num2 = 1;
            int num3 = index1 + num2;
            string str1 = "back.png";
            strArray1[index1] = str1;
            string[] strArray2 = GameData.cardImageList;
            int index2 = num3;
            int num4 = 1;
            int num5 = index2 + num4;
            string str2 = "+4.png";
            strArray2[index2] = str2;
            string[] strArray3 = GameData.cardImageList;
            int index3 = num5;
            int num6 = 1;
            int num7 = index3 + num6;
            string str3 = "wild.png";
            strArray3[index3] = str3;
            string[] strArray4 = GameData.cardImageList;
            int index4 = num7;
            int num8 = 1;
            int num9 = index4 + num8;
            string str4 = "+2b.png";
            strArray4[index4] = str4;
            string[] strArray5 = GameData.cardImageList;
            int index5 = num9;
            int num10 = 1;
            int num11 = index5 + num10;
            string str5 = "skipb.png";
            strArray5[index5] = str5;
            string[] strArray6 = GameData.cardImageList;
            int index6 = num11;
            int num12 = 1;
            int num13 = index6 + num12;
            string str6 = "revb.png";
            strArray6[index6] = str6;
            string[] strArray7 = GameData.cardImageList;
            int index7 = num13;
            int num14 = 1;
            int num15 = index7 + num14;
            string str7 = "0b.png";
            strArray7[index7] = str7;
            string[] strArray8 = GameData.cardImageList;
            int index8 = num15;
            int num16 = 1;
            int num17 = index8 + num16;
            string str8 = "1b.png";
            strArray8[index8] = str8;
            string[] strArray9 = GameData.cardImageList;
            int index9 = num17;
            int num18 = 1;
            int num19 = index9 + num18;
            string str9 = "2b.png";
            strArray9[index9] = str9;
            string[] strArray10 = GameData.cardImageList;
            int index10 = num19;
            int num20 = 1;
            int num21 = index10 + num20;
            string str10 = "3b.png";
            strArray10[index10] = str10;
            string[] strArray11 = GameData.cardImageList;
            int index11 = num21;
            int num22 = 1;
            int num23 = index11 + num22;
            string str11 = "4b.png";
            strArray11[index11] = str11;
            string[] strArray12 = GameData.cardImageList;
            int index12 = num23;
            int num24 = 1;
            int num25 = index12 + num24;
            string str12 = "5b.png";
            strArray12[index12] = str12;
            string[] strArray13 = GameData.cardImageList;
            int index13 = num25;
            int num26 = 1;
            int num27 = index13 + num26;
            string str13 = "6b.png";
            strArray13[index13] = str13;
            string[] strArray14 = GameData.cardImageList;
            int index14 = num27;
            int num28 = 1;
            int num29 = index14 + num28;
            string str14 = "7b.png";
            strArray14[index14] = str14;
            string[] strArray15 = GameData.cardImageList;
            int index15 = num29;
            int num30 = 1;
            int num31 = index15 + num30;
            string str15 = "8b.png";
            strArray15[index15] = str15;
            string[] strArray16 = GameData.cardImageList;
            int index16 = num31;
            int num32 = 1;
            int num33 = index16 + num32;
            string str16 = "9b.png";
            strArray16[index16] = str16;
            string[] strArray17 = GameData.cardImageList;
            int index17 = num33;
            int num34 = 1;
            int num35 = index17 + num34;
            string str17 = "+2g.png";
            strArray17[index17] = str17;
            string[] strArray18 = GameData.cardImageList;
            int index18 = num35;
            int num36 = 1;
            int num37 = index18 + num36;
            string str18 = "skipg.png";
            strArray18[index18] = str18;
            string[] strArray19 = GameData.cardImageList;
            int index19 = num37;
            int num38 = 1;
            int num39 = index19 + num38;
            string str19 = "revg.png";
            strArray19[index19] = str19;
            string[] strArray20 = GameData.cardImageList;
            int index20 = num39;
            int num40 = 1;
            int num41 = index20 + num40;
            string str20 = "0g.png";
            strArray20[index20] = str20;
            string[] strArray21 = GameData.cardImageList;
            int index21 = num41;
            int num42 = 1;
            int num43 = index21 + num42;
            string str21 = "1g.png";
            strArray21[index21] = str21;
            string[] strArray22 = GameData.cardImageList;
            int index22 = num43;
            int num44 = 1;
            int num45 = index22 + num44;
            string str22 = "2g.png";
            strArray22[index22] = str22;
            string[] strArray23 = GameData.cardImageList;
            int index23 = num45;
            int num46 = 1;
            int num47 = index23 + num46;
            string str23 = "3g.png";
            strArray23[index23] = str23;
            string[] strArray24 = GameData.cardImageList;
            int index24 = num47;
            int num48 = 1;
            int num49 = index24 + num48;
            string str24 = "4g.png";
            strArray24[index24] = str24;
            string[] strArray25 = GameData.cardImageList;
            int index25 = num49;
            int num50 = 1;
            int num51 = index25 + num50;
            string str25 = "5g.png";
            strArray25[index25] = str25;
            string[] strArray26 = GameData.cardImageList;
            int index26 = num51;
            int num52 = 1;
            int num53 = index26 + num52;
            string str26 = "6g.png";
            strArray26[index26] = str26;
            string[] strArray27 = GameData.cardImageList;
            int index27 = num53;
            int num54 = 1;
            int num55 = index27 + num54;
            string str27 = "7g.png";
            strArray27[index27] = str27;
            string[] strArray28 = GameData.cardImageList;
            int index28 = num55;
            int num56 = 1;
            int num57 = index28 + num56;
            string str28 = "8g.png";
            strArray28[index28] = str28;
            string[] strArray29 = GameData.cardImageList;
            int index29 = num57;
            int num58 = 1;
            int num59 = index29 + num58;
            string str29 = "9g.png";
            strArray29[index29] = str29;
            string[] strArray30 = GameData.cardImageList;
            int index30 = num59;
            int num60 = 1;
            int num61 = index30 + num60;
            string str30 = "+2r.png";
            strArray30[index30] = str30;
            string[] strArray31 = GameData.cardImageList;
            int index31 = num61;
            int num62 = 1;
            int num63 = index31 + num62;
            string str31 = "skipr.png";
            strArray31[index31] = str31;
            string[] strArray32 = GameData.cardImageList;
            int index32 = num63;
            int num64 = 1;
            int num65 = index32 + num64;
            string str32 = "revr.png";
            strArray32[index32] = str32;
            string[] strArray33 = GameData.cardImageList;
            int index33 = num65;
            int num66 = 1;
            int num67 = index33 + num66;
            string str33 = "0r.png";
            strArray33[index33] = str33;
            string[] strArray34 = GameData.cardImageList;
            int index34 = num67;
            int num68 = 1;
            int num69 = index34 + num68;
            string str34 = "1r.png";
            strArray34[index34] = str34;
            string[] strArray35 = GameData.cardImageList;
            int index35 = num69;
            int num70 = 1;
            int num71 = index35 + num70;
            string str35 = "2r.png";
            strArray35[index35] = str35;
            string[] strArray36 = GameData.cardImageList;
            int index36 = num71;
            int num72 = 1;
            int num73 = index36 + num72;
            string str36 = "3r.png";
            strArray36[index36] = str36;
            string[] strArray37 = GameData.cardImageList;
            int index37 = num73;
            int num74 = 1;
            int num75 = index37 + num74;
            string str37 = "4r.png";
            strArray37[index37] = str37;
            string[] strArray38 = GameData.cardImageList;
            int index38 = num75;
            int num76 = 1;
            int num77 = index38 + num76;
            string str38 = "5r.png";
            strArray38[index38] = str38;
            string[] strArray39 = GameData.cardImageList;
            int index39 = num77;
            int num78 = 1;
            int num79 = index39 + num78;
            string str39 = "6r.png";
            strArray39[index39] = str39;
            string[] strArray40 = GameData.cardImageList;
            int index40 = num79;
            int num80 = 1;
            int num81 = index40 + num80;
            string str40 = "7r.png";
            strArray40[index40] = str40;
            string[] strArray41 = GameData.cardImageList;
            int index41 = num81;
            int num82 = 1;
            int num83 = index41 + num82;
            string str41 = "8r.png";
            strArray41[index41] = str41;
            string[] strArray42 = GameData.cardImageList;
            int index42 = num83;
            int num84 = 1;
            int num85 = index42 + num84;
            string str42 = "9r.png";
            strArray42[index42] = str42;
            string[] strArray43 = GameData.cardImageList;
            int index43 = num85;
            int num86 = 1;
            int num87 = index43 + num86;
            string str43 = "+2y.png";
            strArray43[index43] = str43;
            string[] strArray44 = GameData.cardImageList;
            int index44 = num87;
            int num88 = 1;
            int num89 = index44 + num88;
            string str44 = "skipy.png";
            strArray44[index44] = str44;
            string[] strArray45 = GameData.cardImageList;
            int index45 = num89;
            int num90 = 1;
            int num91 = index45 + num90;
            string str45 = "revy.png";
            strArray45[index45] = str45;
            string[] strArray46 = GameData.cardImageList;
            int index46 = num91;
            int num92 = 1;
            int num93 = index46 + num92;
            string str46 = "0y.png";
            strArray46[index46] = str46;
            string[] strArray47 = GameData.cardImageList;
            int index47 = num93;
            int num94 = 1;
            int num95 = index47 + num94;
            string str47 = "1y.png";
            strArray47[index47] = str47;
            string[] strArray48 = GameData.cardImageList;
            int index48 = num95;
            int num96 = 1;
            int num97 = index48 + num96;
            string str48 = "2y.png";
            strArray48[index48] = str48;
            string[] strArray49 = GameData.cardImageList;
            int index49 = num97;
            int num98 = 1;
            int num99 = index49 + num98;
            string str49 = "3y.png";
            strArray49[index49] = str49;
            string[] strArray50 = GameData.cardImageList;
            int index50 = num99;
            int num100 = 1;
            int num101 = index50 + num100;
            string str50 = "4y.png";
            strArray50[index50] = str50;
            string[] strArray51 = GameData.cardImageList;
            int index51 = num101;
            int num102 = 1;
            int num103 = index51 + num102;
            string str51 = "5y.png";
            strArray51[index51] = str51;
            string[] strArray52 = GameData.cardImageList;
            int index52 = num103;
            int num104 = 1;
            int num105 = index52 + num104;
            string str52 = "6y.png";
            strArray52[index52] = str52;
            string[] strArray53 = GameData.cardImageList;
            int index53 = num105;
            int num106 = 1;
            int num107 = index53 + num106;
            string str53 = "7y.png";
            strArray53[index53] = str53;
            string[] strArray54 = GameData.cardImageList;
            int index54 = num107;
            int num108 = 1;
            int index55 = index54 + num108;
            string str54 = "8y.png";
            strArray54[index54] = str54;
            GameData.cardImageList[index55] = "9y.png";
        }
    }
}
