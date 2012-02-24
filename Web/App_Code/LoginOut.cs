using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
/// <summary>
/// LoginOut 的摘要说明
/// </summary>
public class LoginOut : IHttpHandler,IReadOnlySessionState,IRequiresSessionState
{
    public LoginOut()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public void ProcessRequest(HttpContext context)
    {
        context.Session.Abandon();
        System.Web.Security.FormsAuthentication.SignOut();
        context.Response.Redirect("~/default.aspx");
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
