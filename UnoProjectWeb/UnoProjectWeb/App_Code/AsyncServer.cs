using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace UnoProjectWeb.App_Code
{
    public class AsyncServer
    {
        public static Player p1, p2;
        public static String turn;
        public static int gameId;
        public static int moveNumber;
        public static ArrayList deck = new ArrayList();
        public static Card lastCard;
        private static Object _lock = new Object();

        private static List<AsyncResult> _clientStateList = new List<AsyncResult>();


        private static Fraction[] arrFraction = new Fraction[2];

        public static void Load(AsyncResult state,string guid,bool endGame)
        {
            lock (_lock)
            { 
                Random r = new Random();
                if ((arrFraction[0] == null && _clientStateList.Count >= 2) || endGame)
                {
                    deck = new ArrayList();

                    for (int i = 1; i <= 9; i++)
                    {
                        Card c1 = new Card("Green", i);
                        Card c2 = new Card("Red", i);
                        Card c3 = new Card("Blue", i);
                        Card c4 = new Card("Yellow", i);
                        deck.Add(c1);
                        deck.Add(c2);
                        deck.Add(c3);
                        deck.Add(c4);
                    }
                    int numOfCards = 36;
                    ArrayList p1Cards = new ArrayList();
                    ArrayList p2Cards = new ArrayList();

                    for (int i = 1; i <= 7; i++)
                    {
                        int random1 = r.Next(numOfCards);
                        Card c1 = (Card)deck[random1];
                        p1Cards.Add(c1);
                        deck.Remove(deck[random1]);

                        int random2 = r.Next(numOfCards - 1);
                        Card c2 = (Card)deck[random2];
                        p2Cards.Add(c2);
                        deck.Remove(deck[random2]);

                        numOfCards -= 2;
                    }
                    p1 = new Player(p1Cards);
                    p2 = new Player(p2Cards);

                    int random = r.Next(numOfCards);
                    lastCard = (Card)deck[random];
                    deck.Remove(deck[random]);

                    p1.guID = _clientStateList[0].ClientGuid;
                    p2.guID = _clientStateList[1].ClientGuid;

                    turn = p1.GUID;
                    arrFraction[0] = new Fraction(p1.Cards, turn, p2.NumberOfCards, lastCard, deck.Count);
                    arrFraction[1] = new Fraction(p2.Cards, turn, p1.NumberOfCards, lastCard, deck.Count);

                    gameId = r.Next(1000000000);
                    moveNumber = 1;

                    Update(state, guid);


                }


                JavaScriptSerializer myJavaScriptSerializer = new JavaScriptSerializer();
                string resultStr = myJavaScriptSerializer.Serialize(arrFraction);
                state._context.Response.Write(resultStr);
             



            }
            
        }

        public static void Update(AsyncResult state, String guid)
        {
            for (int i = 0; i < _clientStateList.Count; i++)
            {
                

                if (_clientStateList[i] != null)
                {
                    try
                    {
                        arrFraction[i].clientGuid = _clientStateList[i].ClientGuid;
                        JavaScriptSerializer myJavaScriptSerializer1 = new JavaScriptSerializer();
                        string resultStr1 = myJavaScriptSerializer1.Serialize(arrFraction);
                        _clientStateList[i]._context.Response.Write(resultStr1);
                        _clientStateList[i].CompleteRequest();
                    }
                    catch { }
                }
            }
        }

        public static void Move(AsyncResult state, string guid, string id, string user)
        {
            int number = Int32.Parse(id.Split(':')[0]);
            string color = id.Split(':')[1];
            string strSql = "";
            DataTable dt;
            int totalWins;
            if (guid == p1.guID)
            {
                p1.Remove(number, color);
                if (p1.NumberOfCards == 0)
                {
                    strSql = @"
                               SELECT * FROM Scoreboard U WHERE U.PlayerName = @PlayerName";
                    dt = DB.ExecuteSelect("SYSTEM_USERS", strSql, new SqlParameter[] { new SqlParameter("@PlayerName", user)});
                    totalWins = Int32.Parse(dt.Rows[0]["TotalWins"].ToString());

                    strSql = @"
                               Update Scoreboard set TotalWins=@TotalWins WHERE  PlayerName=@PlayerName ";
                    DB.ExecuteNonQuery(strSql, new SqlParameter[] { new SqlParameter("@PlayerName", user), new SqlParameter("@TotalWins", totalWins + 1) });


                }
            }
            else
            {
                p2.Remove(number, color);
                if (p2.NumberOfCards == 0)
                {
                    strSql = @"
                               SELECT * FROM Scoreboard U WHERE U.PlayerName = @PlayerName";
                    dt = DB.ExecuteSelect("SYSTEM_USERS", strSql, new SqlParameter[] { new SqlParameter("@PlayerName", user) });
                    totalWins = Int32.Parse(dt.Rows[0]["TotalWins"].ToString());

                    strSql = @"
                               Update Scoreboard set TotalWins=@TotalWins WHERE  PlayerName=@PlayerName ";
                    DB.ExecuteNonQuery(strSql, new SqlParameter[] { new SqlParameter("@PlayerName", user), new SqlParameter("@TotalWins", totalWins + 1) });
                }
            }

            string cmdText = @"
				        INSERT INTO PlayerMoves
					        (GAMEID,MOVENUMBER,PLAYERNAME,MOVETYPE,CARDCHOSEN,CARDONDECK)
				        VALUES (@GAMEID,@MOVENUMBER,@PLAYERNAME,@MOVETYPE,@CARDCHOSEN,@CARDONDECK) ";
            DB.ExecuteNonQuery(cmdText, new SqlParameter[] { new SqlParameter("@GAMEID", gameId), new SqlParameter("@MOVENUMBER", moveNumber), new SqlParameter("@PLAYERNAME", user), new SqlParameter("@MOVETYPE", "Move Card"), new SqlParameter("@CARDCHOSEN", number + " " + color), new SqlParameter("@CARDONDECK", lastCard.number+" "+lastCard.color) });
            moveNumber++;

            turn = turn == p1.guID ? p2.guID : p1.guID;

            lastCard = new Card(color,number);
            arrFraction[0] = new Fraction(p1.Cards, turn, p2.NumberOfCards, lastCard,deck.Count);
            arrFraction[1] = new Fraction(p2.Cards, turn, p1.NumberOfCards, lastCard, deck.Count);

            Update(state, guid);

        }

        public static void AddCard(AsyncResult state, string guid,string user)
        {
            int numOfCards = deck.Count;
            int number=-1;
            string color="";
            if (numOfCards > 0)
            {
                Random r = new Random();
                int random = r.Next(numOfCards);


                if (guid == p1.guID)
                {
                    p1.AddCard((Card)deck[random]);
                    number = ((Card)deck[random]).number;
                    color = ((Card)deck[random]).color;
                }
                else
                {
                    p2.AddCard((Card)deck[random]);
                    number = ((Card)deck[random]).number;
                    color = ((Card)deck[random]).color;
                }
                deck.Remove(deck[random]);
            }

            string cmdText = @"
				        INSERT INTO PlayerMoves
					        (GAMEID,MOVENUMBER,PLAYERNAME,MOVETYPE,CARDRECEIVED,CARDONDECK)
				        VALUES (@GAMEID,@MOVENUMBER,@PLAYERNAME,@MOVETYPE,@CARDRECEIVED,@CARDONDECK) ";
            DB.ExecuteNonQuery(cmdText, new SqlParameter[] { new SqlParameter("@GAMEID", gameId), new SqlParameter("@MOVENUMBER", moveNumber), new SqlParameter("@PLAYERNAME", user), new SqlParameter("@MOVETYPE", "Pick Card"), new SqlParameter("@CARDRECEIVED", number + " " + color), new SqlParameter("@CARDONDECK", lastCard.number + " " + lastCard.color) });
            moveNumber++;

            turn = turn == p1.guID ? p2.guID : p1.guID;

            arrFraction[0] = new Fraction(p1.Cards, turn, p2.NumberOfCards, lastCard, deck.Count);
            arrFraction[1] = new Fraction(p2.Cards, turn, p1.NumberOfCards, lastCard, deck.Count);

            Update(state, guid);

        }

        public static void GetMoveHistory(AsyncResult state)
        {
            string cmdText = @"
				        SELECT * FROM PlayerMoves WHERE GAMEID=@GAMEID";
            DataTable dt = DB.ExecuteSelect("SYSTEM_USERS", cmdText, new SqlParameter[] { new SqlParameter("@GAMEID", gameId) });
            int numOfMoves = dt.Rows.Count;
            HistoryMove[] arrMoves = new HistoryMove[numOfMoves];
            for (int i = 0; i < numOfMoves; i++)
            {
                arrMoves[i] = new HistoryMove(Int32.Parse(dt.Rows[i]["GameId"].ToString()), Int32.Parse(dt.Rows[i]["MoveNumber"].ToString()), dt.Rows[i]["PlayerName"].ToString(), dt.Rows[i]["MoveType"].ToString(), dt.Rows[i]["CardChosen"].ToString(), dt.Rows[i]["CardReceived"].ToString(), dt.Rows[i]["CardOnDeck"].ToString());
            }

            JavaScriptSerializer myJavaScriptSerializer = new JavaScriptSerializer();
            string resultStr = myJavaScriptSerializer.Serialize(arrMoves);
            state._context.Response.Write(resultStr);
            state.CompleteRequest();
        }

        public static void GetScoreboard(AsyncResult state)
        {
            string cmdText = @"
				        SELECT * FROM Scoreboard order by TotalWins desc";
            DataTable dt = DB.ExecuteSelect("SYSTEM_USERS", cmdText, new SqlParameter[] { });
            int numOfUsers = dt.Rows.Count;
            PlayerScore[] arrScores = new PlayerScore[numOfUsers];
            for (int i = 0; i < numOfUsers; i++)
            {
                arrScores[i] = new PlayerScore(dt.Rows[i]["PlayerName"].ToString(), Int32.Parse(dt.Rows[i]["TotalWins"].ToString()));
            }

            JavaScriptSerializer myJavaScriptSerializer = new JavaScriptSerializer();
            string resultStr = myJavaScriptSerializer.Serialize(arrScores);
            state._context.Response.Write(resultStr);
            state.CompleteRequest();
        }  


        public static void RegisterClient(AsyncResult state)
        {
            lock (_lock)
            {
                state.ClientGuid = Guid.NewGuid().ToString();
                _clientStateList.Add(state);
                state._context.Response.Write(state.ClientGuid.ToString());
            }
        }

        public static void UpdateClient(AsyncResult state, String guid)
        {
            lock (_lock)
            {
                AsyncResult clientState = _clientStateList.Find(
                    delegate(AsyncResult cs)
                    {
                        return cs.ClientGuid == guid;
                    }
                );
                if (clientState != state && clientState != null)
                {
                    clientState._context = state._context;
                    clientState._state = state._state;
                    clientState._callback = state._callback;
                }



            }
        }

        public static void UnregisterClient(AsyncResult state, string guid)
        {
            lock (_lock)
            {
                if (_clientStateList.Count > 0)
                    for (int i = 0; i < _clientStateList.Count; i++)
                    {
                        if (_clientStateList[i].ClientGuid == guid)
                            _clientStateList.Remove(_clientStateList[i]);
                    }
            }
        }



    }

}