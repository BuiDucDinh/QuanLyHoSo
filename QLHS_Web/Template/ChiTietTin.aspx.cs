using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic.NV;
using QLHS_Logic;
using System.Data;
public partial class Template_ChiTietTin : BasePage
{
    public NV_BaiViet_AnPham_ChiTiet bv = new NV_BaiViet_AnPham_ChiTiet();
    public NV_Menu_ChiTiet menu = new NV_Menu_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string dmtin = RouteData.Values["dmtin"] != null ? RouteData.Values["dmtin"].ToString() : "";
            if (string.IsNullOrEmpty(dmtin))
            {
                string menu = RouteData.Values["menu"] != null ? RouteData.Values["menu"].ToString() : "";
                string tin = RouteData.Values["baiviet"].ToString();
                loadData(menu, tin);
            }
            else
            {
                loadData(dmtin);
            }
        }
    }
    private void loadData(string urlmenu)
    {
        this.menu = Sys_Common.NV_Menu.GetByUrl(urlmenu);
        if (menu.MenuID != 0)
        {
            try
            {
                bv = new NV_BaiViet_AnPham_ChiTiet(Sys_Common.NV_BaiViet_AnPham.GetByCate(menu.MenuID,Session["langID"] != null ? Session["langID"].ToString() : "vi"));
            }
            catch { }
        }
    }
    private void loadData(string menu, string tin)
    {
        bv = Sys_Common.NV_BaiViet_AnPham.GetByUrl(tin);
        if (bv.ID != 0)
        {

        }
        if (!string.IsNullOrEmpty(menu))
        {
            this.menu = Sys_Common.NV_Menu.GetByUrl(menu);
            if (this.menu.MenuID != 0)
            {
                DataTable dt = Sys_Common.NV_BaiViet_AnPham.GetByCate(this.menu.MenuID,Session["langID"] != null ? Session["langID"].ToString() : "vi");
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptOrther.DataSource = dt;
                    rptOrther.DataBind();
                }
            }
        }
    }
}