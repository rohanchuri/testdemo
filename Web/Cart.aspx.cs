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

public partial class Cart : System.Web.UI.Page
{
    User user;
    protected void Page_Load(object sender, EventArgs e)
    {
        user = Session["CurrentUser"] as User;        
        if (user == null)
        {
            Response.Write("<script>alert('您还未登录或登录超时,请重新登录');document.location='MemberShip/UserLogin.aspx';</script>");
            return;
        }
        
        if (!IsPostBack)
        {
            if (Session["Cart"] != null)
            {
                BindGridView();
            }
        }
    }

    /// <summary>
    /// 结算
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgb_Salary_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Cart"] == null || ((DataTable)Session["Cart"]).Rows.Count==0)
        {
            Response.Write("<script>alert('您的购物车为空,请先将图书放入购物车!');document.location='BookList.aspx';</script>");
            return;
        }
        Order order = new Order();
        order.OrderDate = DateTime.Now;
        if (this.ltrSalary.Text != String.Empty)
        {
            order.TotalPrice = Convert.ToDecimal(this.ltrSalary.Text);
        }
        order.User = user;
        order = OrderManager.AddOrder(order);        
        OrderBook orderbook=new OrderBook();
        Book book = new Book();
        Order orders = new Order();
        foreach (DataRow dr in ((DataTable)Session["Cart"]).Rows)
        {
            book.Id = Convert.ToInt32(dr["BookId"]);
            orders.Id = order.Id;
            orderbook.Book = book;
            orderbook.Order = orders;
            orderbook.Quantity = Convert.ToInt32(dr["Number"]);
            orderbook.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);

            OrderBookManager.AddOrderBook(orderbook);
        }
        Session.Remove("Cart");
        Response.Write("<script>alert('结算成功,请等待审批订单');window.location='BookList.aspx'</script>");
    }

    /// <summary>
    /// 绑定GridView方法
    /// </summary>
    private void BindGridView()
    {
        DataTable cart = Session["cart"] as DataTable;
        TotalPrice(cart);
        this.gvCart.DataSource=cart;
        this.gvCart.DataBind();
    }

    /// <summary>
    /// 为前台图片找到正确的路径
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public string GetUrl(string url)
    {
        return StringHandler.CoverUrl(url);
    }

    /// <summary>
    /// GridView编辑按钮处理事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCart_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCart.EditIndex=e.NewEditIndex;
        BindGridView();
    }

    /// <summary>
    /// GridView分页处理事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCart_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCart.PageIndex = e.NewPageIndex;
        BindGridView();
    }

    /// <summary>
    /// GridView删除按钮处理事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable cart = Session["cart"] as DataTable;
        cart.Rows[e.RowIndex].Delete();
        Session["cart"] = cart;
        BindGridView();
    }

    /// <summary>
    /// GridView取消按钮处理事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCart.EditIndex = -1;
        BindGridView();
    }

    /// <summary>
    /// GridView更新按钮处理事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataTable cart = Session["cart"] as DataTable;
        foreach (DataRow dr in cart.Rows)
        {
            if (dr["BookName"].ToString().Equals((gvCart.Rows[e.RowIndex].FindControl("lblBookName") as Label).Text))
            {
                dr["Number"] = (gvCart.Rows[e.RowIndex].FindControl("txtNumber") as TextBox).Text.Trim();
            }
        }
         
        Session["cart"] = cart;
        gvCart.EditIndex = -1;  
        BindGridView();
    }

    /// <summary>
    /// GridView数据绑定后激发的事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCart_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lb= e.Row.FindControl("lnkbtnDelete") as LinkButton;
            lb.Attributes.Add("onclick","return confirm('确定删除吗?')");
        }
    }

    /// <summary>
    /// 计算总价
    /// </summary>
    /// <param name="cart"></param>
    private void TotalPrice(DataTable cart)
    {
        foreach (DataRow dr in cart.Rows)
        {
            double Total = 0;
            Total += Convert.ToDouble(dr["UnitPrice"].ToString()) * Convert.ToDouble(dr["Number"].ToString());
            this.ltrSalary.Text = Total.ToString();
        }
    }
}
