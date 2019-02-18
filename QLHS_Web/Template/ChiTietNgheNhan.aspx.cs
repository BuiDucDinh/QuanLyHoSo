using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TreeviewDropDown;
using QLHS_Logic.NV;
using QLHS_Logic;
using System.Data;
public partial class Template_ChiTietDiSan : BasePage
{
    public NV_Menu_ChiTiet menu = new NV_Menu_ChiTiet();
    public NV_NgheNhan_ChiTiet nghenhan = new NV_NgheNhan_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string menu = RouteData.Values["menu"] != null ? RouteData.Values["menu"].ToString() : "";
            string nghenhan = RouteData.Values["nghenhan"].ToString();
            loadData(menu, nghenhan);
        }
    }

    private void loadData(string menuUrl, string nghenhan)
    {
        menu = Sys_Common.NV_Menu.GetByUrl(menuUrl);
        string sql = "";
        DataTable dt;
        if (menu.MenuID == 0)
        {
            sql = "select top 1 MenuID from Menu where ChucNangID=16";
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                int menuID = int.Parse(dt.Rows[0]["MenuID"].ToString());
                menu = Sys_Common.NV_Menu.GetById(menuID);
            }
        }
        this.nghenhan = Sys_Common.NV_NgheNhan.GetByUrl(nghenhan);
        if (this.nghenhan.ID == 0)
        {
            Response.Redirect("/");
        }

        dt = Sys_Common.NV_NgheNhan.GetAll();
        rptOrther.DataSource = dt;
        rptOrther.DataBind();
    }
}