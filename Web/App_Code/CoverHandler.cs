using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

/// <summary>
/// 映射文件后缀名方式的数字水印
/// </summary>
public class CoverHandler : IHttpHandler
{
    private const string WATERMARK_URL = "~/Images/watermark.jpg";        //水印图片
    private const string DEFAULTIMAGE_URL = "~/Images/default.jpg";           //默认图片
    public CoverHandler()
    {
    }
    public void ProcessRequest(HttpContext context)
    {
        System.Drawing.Image Cover;
        //判断请求的物理路径中，是否存在文件
        if (File.Exists(context.Request.PhysicalPath))
        {
            //加载文件
            Cover = Image.FromFile(context.Request.PhysicalPath);
            //加载水印图片
            Image watermark = Image.FromFile(context.Request.MapPath(WATERMARK_URL));
            //实例化画布
            Graphics g = Graphics.FromImage(Cover);
            //在image上绘制水印
            g.DrawImage(watermark, new Rectangle(Cover.Width - watermark.Width, Cover.Height - watermark.Height, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel);
            //释放画布
            g.Dispose();
            //释放水印图片
            watermark.Dispose();
        }
        else
        {
            //加载默认图片
            Cover = Image.FromFile(context.Request.MapPath(DEFAULTIMAGE_URL));
        }
        //设置输出格式
        context.Response.ContentType = "image/jpeg";
        //将图片存入输出流
        Cover.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        Cover.Dispose();
        context.Response.End();
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
