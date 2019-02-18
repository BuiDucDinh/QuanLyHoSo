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
public partial class AddMarkerMap : System.Web.UI.Page
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
                lst.Add(m);
            }
        }
        return lst;
    }
    [WebMethod]
    public static bool updateMarker(NV_Map_ChiTiet marker)
    {
        bool check;
        int maND = int.Parse(HttpContext.Current.Session["G_Ma_Nguoi_Dung"].ToString());
        NV_Log_ChiTiet log;
        if (marker.ID != 0) //update
        {
            check = Sys_Common.NV_Map.update(marker);
            log = createLog(marker.DiSanID, "updateMap");
        }
        else //add
        {
            check = Sys_Common.NV_Map.them(marker);
            log = createLog(marker.DiSanID, "insertMap");
        }
        if (check)
        {
            Sys_Common.NV_Log.them(log);
        }
        return check;
    }
    [WebMethod]
    public static bool deleteMarker(int id)
    {
        try
        {
            Sys_Common.NV_Map.Xoa(id);
            NV_Log_ChiTiet log = createLog(id, "deleteMap");
            Sys_Common.NV_Log.them(log);
            return true;
        }
        catch
        {
            return false;
        }
    }
    private static NV_Log_ChiTiet createLog(int id, string thaotac)
    {
        int maND = int.Parse(HttpContext.Current.Session["G_Ma_Nguoi_Dung"].ToString());
        string maForm = "QL_DS_01";
        NV_Log_ChiTiet log = new NV_Log_ChiTiet(maND, maForm);
        log.ThaoTac = thaotac;
        log.IDBanGhi = id;
        return log;
    }
}