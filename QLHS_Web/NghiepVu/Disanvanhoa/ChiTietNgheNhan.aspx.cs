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
    public NV_NgheNhan_ChiTiet nghenhan = new NV_NgheNhan_ChiTiet();
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

    private void loadData(int n)
    {
        nghenhan = Sys_Common.NV_NgheNhan.GetById(n);
        if (nghenhan.DiSanID != 0)
        {
            string sql = "select TenTaiLieu from Document where '" + nghenhan.File + "' like '%,'+cast(DocumentID as nvarchar(10))+',%'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptDoc.DataSource = dt;
                rptDoc.DataBind();
            }
           
        }
       
    }
}