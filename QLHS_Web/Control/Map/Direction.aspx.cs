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
public partial class AddMarkerMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    [WebMethod]
    public static List<NV_Map_ChiTiet> loadMap()
    {
        List<NV_Map_ChiTiet> lst = new List<NV_Map_ChiTiet>();
        string value = "";
        try
        {
            value = HttpContext.Current.Request.QueryString["id"].ToString();
            int id = int.Parse(value);
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
                    m.DiSanID = int.Parse(value);
                    m.ID = int.Parse(item["ID"].ToString());
                    m.Ten = item["Ten"].ToString();
                    m.DiaChi = item["DiaChi"].ToString();
                    m.MoTa = item["MoTa"].ToString();
                    m.Lat = float.Parse(item["Lat"].ToString());
                    m.Lng = float.Parse(item["Lng"].ToString());
                    lst.Add(m);
                }
            }
        }
        catch { }
        return lst;
    }
    [WebMethod]
    public static bool updateMarker(NV_Map_ChiTiet marker)
    {
        if (marker.ID != 0) //update
        {
            return Sys_Common.NV_Map.update(marker);
        }
        else //add
        {
            return Sys_Common.NV_Map.them(marker);
        }
    }
    [WebMethod]
    public static bool deleteMarker(int id)
    {
        try
        {
            Sys_Common.NV_Map.Xoa(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
}