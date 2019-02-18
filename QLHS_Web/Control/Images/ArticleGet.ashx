<%@ WebHandler Language="C#" Class="ArticleGet" %>

using System;
using System.Data;
using System.Web;

public class ArticleGet : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.Files.Count > 0)
        {
            HttpFileCollection files = context.Request.Files;
            string arrImg = "";
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string ets = System.IO.Path.GetExtension(file.FileName);
                if (file.ContentLength > 0 && (ets == ".jpg" || ets == ".png" || ets == ".jpeg" || ets == ".gif" || ets == ".bmp"))
                {
                    string filename = file.FileName.Substring(0, file.FileName.LastIndexOf(".")) + "_" + DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss") + ets;
                    string filepath = context.Server.MapPath("~/FileUpload/images/" + filename);
                    file.SaveAs(filepath);
                    arrImg += filename + ",";
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(arrImg);

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