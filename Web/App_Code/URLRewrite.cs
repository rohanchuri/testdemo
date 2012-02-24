using System;
using System.Web;
using System.Text.RegularExpressions;

public class URLRewrite: IHttpHandler
{
    public URLRewrite()
    {
    }
    public void ProcessRequest(HttpContext context)
    {
        string Url = context.Request.Url.ToString();
        string id = Url.Substring(Url.LastIndexOf("/") + 1).Replace(".shtml", "");
        context.Server.Execute("~/BookDetail.aspx?bid=" + id);
    }
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}