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
    public NV_DanhNhan_ChiTiet dn = new NV_DanhNhan_ChiTiet();
    public NV_Menu_ChiTiet menu = new NV_Menu_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                string menu = RouteData.Values["menu"] != null ? RouteData.Values["menu"].ToString() : "";
                string danhnhan = RouteData.Values["danhnhan"].ToString();
                loadData(menu, danhnhan);            
        }
    }
    private void loadData(string menu, string danhnhan)
    {
        dn = Sys_Common.NV_DanhNhan.GetByUrl(danhnhan);
        if (!string.IsNullOrEmpty(menu))
        {
            this.menu = Sys_Common.NV_Menu.GetByUrl(menu);
           // if (this.menu.MenuID != 0)
            {
                DataTable dt = Sys_Common.NV_DanhNhan.GetAll();// (this.menu.MenuID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptOrther.DataSource = dt;
                    rptOrther.DataBind();
                }
            }
        }
    }
}