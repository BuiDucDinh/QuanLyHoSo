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
    public NV_DiVatCoVat_ChiTiet dv = new NV_DiVatCoVat_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string divat = RouteData.Values["divat"] != null ? RouteData.Values["divat"].ToString() : "";
            loadData(divat);
        }
    }

    private void loadData(string divat)
    {
        dv = Sys_Common.NV_DiVatCoVat.GetByUrl(divat);
        if (dv.ID != 0)
        {
            string sql = "select TenAnh from Image where '" + dv.BoAnh + "' like '%,'+cast(ImageID as nvarchar(20))+',%' or ImageID=" + dv.AnhDaiDien;
            DataTable dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptImage.DataSource = dt;
                rptImage.DataBind();
            }

            dt = Sys_Common.NV_DiVatCoVat.GetByDiSanID(dv.DiSanID);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptDiVat.DataSource = dt;
                rptDiVat.DataBind();
            }
        }
    }
}