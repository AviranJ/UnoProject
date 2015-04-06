using System;
using System.Collections.Generic;
using System.Collections;
using System.Web.Script.Serialization;

namespace UnoProjectWeb.App_Code
{
    public class AsyncServer
    {
        public static Player p1, p2;
        public static String turn;
        public static ArrayList deck;
        public static Card lastCard;
        private static Object _lock = new Object();

        private static List<AsyncResult> _clientStateList = new List<AsyncResult>();


        private static Fraction[] arrFraction = new Fraction[2];

        public static void Load(AsyncResult state,string guid)
        {
            lock (_lock)
            { 
                Random r = new Random();
                if (arrFraction[0] == null)
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
                        Card c2 = (Card)deck[r.Next(numOfCards - 1)];
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
                    arrFraction[0] = new Fraction(p1.Cards, turn, p2.NumberOfCards, lastCard);
                    arrFraction[1] = new Fraction(p2.Cards, turn, p1.NumberOfCards, lastCard);
                    
                }
                Update(state, guid);
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
                        JavaScriptSerializer myJavaScriptSerializer1 = new JavaScriptSerializer();
                        string resultStr1 = myJavaScriptSerializer1.Serialize(arrFraction);
                        _clientStateList[i]._context.Response.Write(resultStr1);
                        _clientStateList[i].CompleteRequest();
                        arrFraction[i].ClientGuid = _clientStateList[i].ClientGuid;
                    }
                    catch { }
                }
            }
        }

        public static void Move(AsyncResult state, string guid, string id)
        {
            JavaScriptSerializer myJavaScriptSerializer;
            string resultStr;
            int number = Int32.Parse(id.Split(':')[0]);
            string color = id.Split(':')[1];
            
            if (guid == p1.GUID)
            {
                p1.Remove(number, color);
            }
            else
            {
                p2.Remove(number, color);
            }
            lastCard = new Card(color,number);
            arrFraction[0] = new Fraction(p1.Cards, turn, p2.NumberOfCards, lastCard);
            arrFraction[1] = new Fraction(p2.Cards, turn, p1.NumberOfCards, lastCard);

            Update(state, guid);

            myJavaScriptSerializer = new JavaScriptSerializer();
            resultStr = myJavaScriptSerializer.Serialize(arrFraction);
            state._context.Response.Write(resultStr);

        }

        public static void AddCard(AsyncResult state, string guid)
        {
            int numOfCards = deck.Count;
            Random r = new Random();
            int random = r.Next(numOfCards);

            
            if (guid == p1.GUID)
            {
                p1.AddCard((Card)deck[random]);
            }
            else
            {
                p2.AddCard((Card)deck[random]);
            }
            deck.Remove(deck[random]);
            arrFraction[0] = new Fraction(p1.Cards, turn, p2.NumberOfCards, lastCard);
            arrFraction[1] = new Fraction(p2.Cards, turn, p1.NumberOfCards, lastCard);

            Update(state, guid);

            JavaScriptSerializer myJavaScriptSerializer = new JavaScriptSerializer();
            string resultStr = myJavaScriptSerializer.Serialize(arrFraction);
            state._context.Response.Write(resultStr);

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