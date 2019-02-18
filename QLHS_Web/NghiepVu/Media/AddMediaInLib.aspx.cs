using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
public partial class NghiepVu_Media_AddMediaInLib : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string type = Request.QueryString["type"].ToString();
            if (type == "1") pnVideo.Hidden = true;
            else if (type == "2") pnHinhAnh.Hidden = true;
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        string type = Request.QueryString["type"].ToString();
        int id = int.Parse(Request.QueryString["id"].ToString());
        NV_MediaLib_ChiTiet media = Sys_Common.NV_MediaLib.GetById(id);
        if (type == "1")
            media.MediaArray = ImageMutil.ImageID;
        else
            media.MediaArray = Video.VideoID;
        bool check = Sys_Common.NV_MediaLib.update(media);

    }
}