<%@ WebHandler Language="C#" Class="UpVideo" %>

using System;
using System.Data;
using System.Web;

public class UpVideo : IHttpHandler{

    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.Files.Count > 0)
        {
            HttpFileCollection files = context.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string ets = System.IO.Path.GetExtension(file.FileName);
                if (file.ContentLength > 0 && (ets == ".mp4" || ets == ".svc" || ets == ".avi" || ets == ".mov"|| ets==".flv"))
                {
                    string fname = context.Server.MapPath("~/FileUpload/video/" + file.FileName);
                    file.SaveAs(fname);
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write("File Uploaded Successfully!");
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