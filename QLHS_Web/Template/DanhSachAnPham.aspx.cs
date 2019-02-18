using QLHS_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic.NV;
using QLHS_Logic;
using System.Data;

public partial class Template_DanhSachAnPham : BasePage
{
    public NV_DanhMucAnPham_ChiTiet dm = new NV_DanhMucAnPham_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string url = RouteData.Values["menu"] != null ? RouteData.Values["menu"].ToString() : "";
            if (!string.IsNullOrEmpty(url))
            {
                loadData(url);
            }
        }
    }

    private void loadData(string url)
    {
        dm = Sys_Common.NV_DanhMucAnPham.GetByUrl(url);
        if (dm.DanhMucID != 0)
        {
            DataTable dt = Sys_Common.NV_AnPham.GetByDanhMuc(dm.DanhMucID);
            if (dt.Rows.Count > 0)
            {
                rptAnPham.DataSource = dt;
                rptAnPham.DataBind();
            }
        }
    }
}