using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Power.User
{
    /// <summary>
    /// UploadImageHandler 的摘要说明
    /// </summary>
    public class UploadImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string filePath1 = "";
            try
            {
                //不知道为什么获取不到
                //HttpPostedFile file = context.Request.Files[0];
                string filePath = context.Server.UrlDecode(context.Request["imgPath"]); ;
                string guid = context.Request["GUID"];
                string path = "images\\head\\"; filePath1 = filePath;
                Bitmap map = new Bitmap(filePath);
                string fileName = Path.GetFileName(filePath);
                string mapPath = context.Server.MapPath("~");
                string savePath = mapPath + path + guid;
                if (!System.IO.Directory.Exists(mapPath + path))
                {
                    System.IO.Directory.CreateDirectory(mapPath + path);
                }
                map.Save(savePath);
                //上传成功后显示IMG文件
                StringBuilder sb = new StringBuilder();
                sb.Append("<img id=\"imgUpload\" width=\"100px\" height=\"120px\" src=\"../" + path.Replace("\\", "/") + guid + "\" />");
                context.Response.Write(sb.ToString());
                context.Response.End();
            }
            catch (Exception)
            {
                throw;
                //context.Response.Write(filePath1 + "-----" + ex.ToString());
                //context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}