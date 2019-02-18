using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Data;
public partial class Template_DanhSachThuVienAnh : BasePage
{
    public NV_Menu_ChiTiet menu = new NV_Menu_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ds = Request.QueryString["ds"] != null ? Request.QueryString["ds"].ToString() : "";
            string video = RouteData.Values["menuvideo"] != null ? RouteData.Values["menuvideo"].ToString() : "";
            string image = RouteData.Values["menuanh"] != null ? RouteData.Values["menuanh"].ToString() : "";
            loadData(image, video, ds);
        }
    }
    private void loadData(string image, string video, string ds)
    {
        string sql = "";
        DataTable dt;
        if (!string.IsNullOrEmpty(ds))
        {
            int type = 0;
            NV_DiSanVanHoa_ChiTiet disan = Sys_Common.NV_DiSanVanHoa.GetById(int.Parse(ds));
            if (!string.IsNullOrEmpty(video))
            {
                menu.TenMenu = "Danh sách video về " + disan.TenDiSan;
                type = 2;
            }
            else if (!string.IsNullOrEmpty(image))
            {
                menu.TenMenu = "Danh sách thư viện ảnh về " + disan.TenDiSan;
                type = 1;
            }
            sql = @"select MediaLibID,TenMediaLib
	                    ,(select TenAnh from Image i where i.ImageID=m.HinhAnh) as HinhAnh
	                    ,dbo.getUrl(MediaLibID,'MediaLib',null) as url
                    from MediaLib m where Duyet=1 and TypeMedia=" + type + " and DiSanID=" + ds;
        }
        else
        {
            string url = "";
            if (!string.IsNullOrEmpty(video))
            {
                url = video;
            }
            else if (!string.IsNullOrEmpty(image))
            {
                url = image;
            }
            menu = Sys_Common.NV_Menu.GetByUrl(url);
            sql = @"select MediaLibID,TenMediaLib
	                    ,(select TenAnh from Image i where i.ImageID=m.HinhAnh) as HinhAnh
	                    ,dbo.getUrl(MediaLibID,'MediaLib',null) as url
                    from MediaLib m where Duyet=1 and DanhMuc like '%," + menu.MenuID + ",%'";
        }
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptMedia.DataSource = dt;
            rptMedia.DataBind();
        }
    }
}