<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Threading;

using System.Web.Script.Serialization;

public class Handler : IHttpAsyncHandler {

    public IAsyncResult BeginProcessRequest(HttpContext ctx, AsyncCallback cb, Object obj)
    {
        AsyncResult currentAsyncState = new AsyncResult(ctx, cb, obj);

        ThreadPool.QueueUserWorkItem(new WaitCallback(RequestWorker), currentAsyncState);

        return currentAsyncState;
    }

    private void RequestWorker(Object obj)
    {
        // obj - second parametr in ThreadPool.QueueUserWorkItem()
        AsyncResult myAsyncResult = obj as AsyncResult;
        string command = myAsyncResult._context.Request.QueryString["cmd"];

        switch (command)
        {
            case "load":
                break;
            case "Move":
                break;
                
        }
        myAsyncResult.CompleteRequest();
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