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
    public NV_AnPham_ChiTiet ap = new NV_AnPham_ChiTiet();
    public NV_DanhMucAnPham_ChiTiet menu = new NV_DanhMucAnPham_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                string menu = RouteData.Values["menu"] != null ? RouteData.Values["menu"].ToString() : "";
                string anpham = RouteData.Values["anpham"].ToString();
                loadData(menu, anpham);            
        }
    }
    private void loadData(string menu, string anpham)
    {
        ap = Sys_Common.NV_AnPham.GetByUrl(anpham);

        if (!string.IsNullOrEmpty(menu))
        {
            this.menu = Sys_Common.NV_DanhMucAnPham.GetByUrl(menu);
            if (this.menu.DanhMucID != 0)
            {
                DataTable dt = Sys_Common.NV_AnPham.GetByDanhMuc(this.menu.DanhMucID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptOrther.DataSource = dt;
                    rptOrther.DataBind();
                }
            }
        }
    }
}