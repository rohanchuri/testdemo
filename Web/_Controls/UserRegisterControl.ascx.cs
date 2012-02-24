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

public partial class _Controls_UserRegisterControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            snCode.Create();
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.txtLoginId.Text = String.Empty;
        this.txtLoginPwd.Text = String.Empty;
        this.txtName.Text = String.Empty;
        this.txtAddress.Text = String.Empty;
        this.txtTele.Text = String.Empty;
        this.txtEmail.Text = String.Empty;
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (!CeckCode())
        {
            this.ltMain.Text = "<script>alert('验证码错误！')</script>";
            return;
        }
        User user = new User();
        user.LoginId = this.txtLoginId.Text;
        user.LoginPwd = this.txtLoginPwd.Text;
        user.Name = this.txtName.Text;
        user.Address = this.txtAddress.Text;
        user.Phone = this.txtTele.Text;
        user.Mail = this.txtEmail.Text;

        if (!UserManager.Register(user))
        {
            this.ltMain.Text = "<script>alert('用户名已使用！请重新选择！')</script>";
        }
        else
        {
            this.ltMain.Text = "<script>alert('注册成功！请继续购物');window.location='../default.aspx'</script>";
        }
    }
    protected bool CeckCode()
    {
        if (snCode.CheckSN(txtCode.Text.Trim()))
        {
            return true;
        }
        else
        {
            snCode.Create();
            return false;
        }
    }
}
