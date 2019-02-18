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
    public NV_QuyTrinhDinhNghia_ChiTiet qt = new NV_QuyTrinhDinhNghia_ChiTiet();
    public NV_Menu_ChiTiet menu = new NV_Menu_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string menu = RouteData.Values["menu"] != null ? RouteData.Values["menu"].ToString() : "";
            string thutuc = RouteData.Values["thutuc"].ToString();
            loadData(menu, thutuc);

        }
    }
    private void loadData(string menu, string thutuc)
    {
        NV_LoaiQuyTrinh_ChiTiet loaiQT = Sys_Common.NV_LoaiQuyTrinh.GetByUrl(thutuc);
        qt = Sys_Common.NV_QuyTrinhDinhNghia.GetByLoaiActive(loaiQT.ID);
        if (!string.IsNullOrEmpty(menu))
        {
            this.menu = Sys_Common.NV_Menu.GetByUrl(menu);
            if (this.menu.MenuID != 0)
            {
                this.menu.TenUrl = "/" + this.menu.TenUrl + "hc";               
            }
        }
    }
}