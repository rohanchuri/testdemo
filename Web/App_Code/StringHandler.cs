using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// StringHandler 的摘要说明
/// 字符串通用类
/// </summary>
public static class StringHandler
{
    /// <summary>
    /// 截断字符串
    /// </summary>
    /// <param name="content"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string CutString(object content, int num)
    {
        if (content.ToString().Length > num - 2)
            return content.ToString().Substring(0, num - 2) + "...";
        else
            return content.ToString();
    }
    /// <summary>
    /// 货币
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ToMoney(object obj)
    {
        return String.Format("{0:C}", obj);
    }
    /// <summary>
    /// 短日期
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static String ToShortDate(object obj)
    {
        return Convert.ToDateTime(obj).ToShortDateString();
    }
    /// <summary>
    /// 封面路径
    /// </summary>
    /// <param name="isbn"></param>
    /// <returns></returns>
    public static string CoverUrl(object isbn)
    {
        //return "BookCover.ashx?isbn=" + isbn.ToString();
        return "Images/BookCovers/" + isbn.ToString() + ".jpg";
    }
}
