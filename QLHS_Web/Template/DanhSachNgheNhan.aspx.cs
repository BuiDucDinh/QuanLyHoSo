using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Data;
using System.Globalization;
public partial class Template_DanhSachNgheNhan : BasePage
{
    public NV_Menu_ChiTiet menu = new NV_Menu_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string url = RouteData.Values["menu"] != null ? RouteData.Values["menu"].ToString() : "";
            loadData(url);
        }
    }
    private void loadData(string url)
    {
        menu = Sys_Common.NV_Menu.GetByUrl(url);
        DataTable dt = Sys_Common.NV_NgheNhan.GetAll();
        rptTintuc.DataSource = dt;
        rptTintuc.DataBind();
    }
}