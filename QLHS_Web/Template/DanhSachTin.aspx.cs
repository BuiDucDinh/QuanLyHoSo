using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Data;
public partial class Template_DanhSachTin : BasePage
{
    public NV_Menu_ChiTiet menu = new NV_Menu_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string menu = RouteData.Values["menu"].ToString();
            loadData(menu);
        }
    }
    private void loadData(string url)
    {
        menu = Sys_Common.NV_Menu.GetByUrl(url);
        if (menu.MenuID != 0)
        {
            string sql = "select ID,TieuDe,NgayXuatBan,GioiThieu,(select TenAnh from [Image] i where i.ImageID=bv.HinhAnh) as HinhAnh,dbo.getUrl(ID,'BaiViet_AnPham'," + menu.MenuID + ") as url from BaiViet_AnPham bv where Duyet=1 and DanhMuc like '%," + menu.MenuID + ",%' order by Stt";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            rptTintuc.DataSource = dt;
            rptTintuc.DataBind();
        }
        else
        {
            Response.Redirect("/page-not-found");
        }
    }
}