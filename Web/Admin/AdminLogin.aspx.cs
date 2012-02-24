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

public partial class Admin_AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void imgb_Sure_Click(object sender, ImageClickEventArgs e)
    {
        /*
         * TODO
        */
    }

    protected void imgb_Cancel_Click(object sender, ImageClickEventArgs e)
    {
        this.txtLoginId.Text = String.Empty;
        this.txtLoginPwd.Text = String.Empty;
    }
}
