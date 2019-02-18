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
public partial class Template_ChiTietDiVat : System.Web.UI.Page
{
    public NV_DiVatCoVat_ChiTiet dv = new NV_DiVatCoVat_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "")
            {
                loadData(int.Parse(id));
            }
        }
    }

    private void loadData(int divat)
    {
        dv = Sys_Common.NV_DiVatCoVat.GetById(divat);
        if (dv.DiSanID != 0)
        {
            string sql = "select TenAnh from Image where '" + dv.BoAnh + "' like '%,'+cast(ImageID as nvarchar(20))+',%'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptImage.DataSource = dt;
                rptImage.DataBind();
            }
            sql = "select TenTaiLieu from Document where '" + dv.FileDinhKem + "' like '%,'+cast(DocumentID as nvarchar(10))+',%'";
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptDoc.DataSource = dt;
                rptDoc.DataBind();
            }
           
        }
       
    }
}