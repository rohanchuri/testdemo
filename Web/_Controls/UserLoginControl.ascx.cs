using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyBookShop.BLL;
using MyBookShop.Models;

public partial class _Controls_UserLoginControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CurrentUser"] != null)
            {
                Response.Redirect("~/default.aspx");
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        User user;
        if (UserManager.Login(this.txtLoginId.Text, this.txtLoginPwd.Text, out user))
        {
            Session["CurrentUser"] = user;
            Response.Redirect("~/default.aspx");
        }
        else
        {
            Response.Write("<script>alert('用户名或密码不正确，请重新填写')</script>");
        }
    }

    protected void btnRegister_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Membership/UserRegister.aspx");
    }
}