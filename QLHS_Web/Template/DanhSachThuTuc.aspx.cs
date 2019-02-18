using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Template_DanhSachThuTuc : BasePage
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
            DataTable dt = Sys_Common.NV_LoaiQuyTrinh.GetAll();
            rptTintuc.DataSource = dt;
            rptTintuc.DataBind();
        }
        else
        {
            Response.Redirect("/page-not-found");
        }
    }
}