<%@ WebHandler Language="C#" Class="Handler" %>

    using System;
    using System.Web;
    using System.Threading;

    using System.Web.Script.Serialization;
    using UnoProjectWeb.App_Code;

    public class Handler : IHttpAsyncHandler
    {

        public IAsyncResult BeginProcessRequest(HttpContext ctx, AsyncCallback cb, Object obj)
        {
            AsyncResult currentAsyncState = new AsyncResult(ctx, cb, obj);

            ThreadPool.QueueUserWorkItem(new WaitCallback(RequestWorker), currentAsyncState);

            return currentAsyncState;
        }

        private void RequestWorker(Object obj)
        {
            
            AsyncResult myAsyncResult = obj as AsyncResult;
            string command = myAsyncResult._context.Request.QueryString["cmd"];
            string guid = myAsyncResult._context.Request.QueryString["guid"];
            string user = "";

            switch (command)
            {
                case "load":
                    string endgame = myAsyncResult._context.Request.QueryString["endgame"];
                    bool end = endgame == "true" ? true : false;
                    AsyncServer.Load(myAsyncResult, guid, end);
                    myAsyncResult.CompleteRequest();
                    break;
                case "move":
                     string ID = myAsyncResult._context.Request.QueryString["ID"];
                    user = myAsyncResult._context.Request.QueryString["user"];
                    AsyncServer.Move(myAsyncResult, guid, ID, user);
                    myAsyncResult.CompleteRequest();
                    break;
                case "addCard":
                    user = myAsyncResult._context.Request.QueryString["user"];
                    AsyncServer.AddCard(myAsyncResult, guid,user);
                    myAsyncResult.CompleteRequest();
                    break;
                case "register":
                    AsyncServer.RegisterClient(myAsyncResult);
                    myAsyncResult.CompleteRequest();
                    break;
                case "unregister":
                    AsyncServer.UnregisterClient(myAsyncResult, guid);
                    myAsyncResult.CompleteRequest();
                    break;
                case "process":
                    if (guid != null)
                    {
                        AsyncServer.UpdateClient(myAsyncResult, guid);
                    }
                    break;
                case "History":
                    AsyncServer.GetMoveHistory(myAsyncResult);
                    break;
                case "Scoreboard":
                    AsyncServer.GetScoreboard(myAsyncResult);
                    break;
            }
        }



        public void EndProcessRequest(IAsyncResult ar)
        {
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
        }

    }