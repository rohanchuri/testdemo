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


public partial class BookDetail : System.Web.UI.Page
{
    private bool _userCanEdit = false;
    protected bool UserCanEdit
    {
        get { return _userCanEdit; }
        set { _userCanEdit = value; }
    }

    private int _bookID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["bid"] != null)
            {
                _bookID = Convert.ToInt32(Request.QueryString["bid"]);
                initPage(_bookID);
                ViewState["BookId"] = Request.QueryString["bid"].ToString();
            }
        }
    }

    private void initPage(int bid)
    {
        Book book=BookManager.GetBookById(bid);
        book.Clicks++;
        BookManager.ModifyBook(book);
        this.lblAuthor.Text=book.Author;
        this.lblBookName.Text = book.Title;
        this.lblPublisher.Text = book.Publisher.Name;
        this.lblBooksName.Text = book.Category.Name;
        this.lblISBN.Text = book.ISBN;
        this.lblPublishDate.Text = book.PublishDate.ToShortDateString();
        this.lblFonts.Text = book.WordsCount.ToString();
        this.lblPrice.Text = book.UnitPrice.ToString()+"元";
        this.lblContent.Text = book.ContentDescription;
        this.lblAuthorIntroduce.Text = book.AurhorDescription;
        this.lblRecomment.Text = book.EditorComment;
        this.lblCatagory.Text = book.TOC;
        this.lblvotes.Text = book.Votes.ToString();
        this.lblrating.Text = GetRatingStars(book.AverageRating);
        this.imgBook.ImageUrl = StringHandler.CoverUrl(book.ISBN);
    }

    /// <summary>
    /// 购买
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgb_Buy_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["CurrentUser"] != null)
        {
            if (Session["Cart"] == null)
            {
                this.BuildCart();
            }
            else
            {
                DataTable cart = Session["Cart"] as DataTable;
                if (this.ExistBook(cart))
                {
                    this.BuildSession(cart);
                }                
            }
            Response.Redirect("Cart.aspx");
        }
        else
        {
            Response.Redirect(@"Membership\UserLogin.aspx");
        }
    }
    /// <summary>
    /// 已有图书
    /// </summary>
    /// <param name="cart"></param>
    /// <returns></returns>
    public bool ExistBook(DataTable cart)
    {
        foreach (DataRow dr in cart.Rows)
        {
            if (dr["BookName"].ToString().Equals(this.lblBookName.Text.Trim()))
            {
                dr["Number"] = Convert.ToInt32(dr["Number"]) + 1;
                Session["Cart"] = cart;
                Response.Redirect("Cart.aspx");
            }
        }
        return true;
    }
    /// <summary>
    /// 新建购物车表
    /// </summary>
    public void BuildCart()
    {
        DataTable cart = new DataTable();
        cart.Columns.Add("BookId");
        cart.Columns.Add("BookName");
        cart.Columns.Add("Number");
        cart.Columns.Add("UnitPrice");
        cart.Columns.Add("ImageUrl");

        this.BuildSession(cart);
    }
    /// <summary>
    /// 添加新书
    /// </summary>
    /// <param name="cart"></param>
    public void BuildSession(DataTable cart)
    {
        DataRow dr = cart.NewRow();
        dr["BookId"] = ViewState["BookId"].ToString();
        dr["BookName"] = this.lblBookName.Text.Trim();
        dr["Number"] = "1";
        dr["UnitPrice"] = this.lblPrice.Text.Substring(0, this.lblPrice.Text.Length - 1); ;
        dr["ImageUrl"] = this.lblISBN.Text.Trim();
        cart.Rows.Add(dr);

        Session["Cart"] = cart;
    }

    protected void btnRate_Click(object sender, EventArgs e)
    {
        // check whether the user has already rated this article
        int userRating = GetUserRating();
        if (userRating > 0)
        {
            ShowUserRating(userRating);
        }
        else
        {
            // rate the article, then create a cookie to remember this user's rating
            userRating = ddlRatings.SelectedIndex + 1;
            _bookID = Convert.ToInt32(Request.QueryString["bid"]);
            Book book = BookManager.GetBookById(_bookID);
            book.Votes ++;
            book.TotalRating += userRating;
            BookManager.ModifyBook(book);

            ShowUserRating(userRating);

            HttpCookie cookie = new HttpCookie(
               "Rating_Article" + _bookID.ToString(), userRating.ToString());
            cookie.Expires = DateTime.Now.AddDays(15);
            this.Response.Cookies.Add(cookie);
            Response.Redirect("BookDetail.aspx?bid=" + _bookID);
        }
    }

    protected void ShowUserRating(int rating)
    {
        lblUserRating.Text = string.Format(lblUserRating.Text, rating);
        ddlRatings.Visible = false;
        btnRate.Visible = false;
        lblUserRating.Visible = true;
    }

    protected int GetUserRating()
    {
        int rating = 0;
        HttpCookie cookie = this.Request.Cookies["Rating_Article" + _bookID.ToString()];
        if (cookie != null)
            rating = int.Parse(cookie.Value);
        return rating;
    }

    protected string GetRatingStars(double averageRating)
    {
        if (averageRating >= 1)
        {
            if (averageRating < 1.5)
                return "★☆☆☆☆";
            else if (averageRating >= 1.5 && averageRating < 2.5)
                return "★★☆☆☆";
            else if (averageRating >= 2.5 && averageRating < 3.5)
                return "★★★☆☆";
            else if (averageRating >= 3.5 && averageRating < 4.5)
                return "★★★★☆";
            else
                return "★★★★★";
        }
        else
        {
            return "还没用户打分！";
        }
    }

}
