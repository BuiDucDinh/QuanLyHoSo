using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Data;
using Ext.Net;
public partial class BigMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["GIsLogin"] == null)
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Thông báo",
                Message = "Phiên làm việc đã kết thúc do bạn ngưng sử dụng máy quá lâu. <br>Hãy ấn F5 để bắt đầu phiên làm việc mới.",
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                Closable = false
            });
            return;
        }
    }
    [WebMethod]
    public static List<NV_Map_ChiTiet> loadMap()
    {
        List<NV_Map_ChiTiet> lst = new List<NV_Map_ChiTiet>();
        string value = "";
        value = HttpContext.Current.Request.QueryString["id"] != null ? HttpContext.Current.Request.QueryString["id"].ToString() : "";
        int id = 0;
        try
        {
            id = int.Parse(value);
        }
        catch { }
        DataTable dt;
        if (id == 0)
        {
            dt = Sys_Common.NV_Map.GetAll();
        }
        else
        {
            dt = Sys_Common.NV_Map.GetByDiSan(id);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow item in dt.Rows)
            {
                NV_Map_ChiTiet m = new NV_Map_ChiTiet();
                m.DiSanID = int.Parse(item["DiSanID"].ToString());
                m.ID = int.Parse(item["ID"].ToString());
                m.Ten = item["Ten"].ToString();
                m.DiaChi = item["DiaChi"].ToString();
                m.MoTa = item["MoTa"].ToString();
                m.Lat = float.Parse(item["Lat"].ToString());
                m.Lng = float.Parse(item["Lng"].ToString());
                m.Link = item["Link"].ToString();
                lst.Add(m);
            }
        }
        return lst;
    }
   
}