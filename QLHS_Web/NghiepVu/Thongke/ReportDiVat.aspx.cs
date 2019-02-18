using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Report.ReportSource;
using DevExpress.XtraReports.UI;
using QLHS_Logic;
using System.Data;
public partial class NghiepVu_Thongke_ReportDiVat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
        string chucnang = Request.QueryString["cn"] != null ? Request.QueryString["cn"].ToString() : "";
        if (!string.IsNullOrEmpty(id))
        {
            loadData(int.Parse(id), chucnang);
        }
    }
    private void loadData(int id, string cn)
    {
        DataTable dt;
        string sql = "select TenBang from TableLog where MaForm='" + cn + "'";
        dt = Sys_Common.RunTableBySQL(sql);
        if (dt.Rows.Count > 0)
        {
            string tenbang = dt.Rows[0]["TenBang"].ToString();
            switch (tenbang)
            {
                case "DiVatCoVat":
                    dt = Sys_Common.NV_DiVatCoVat.GetByIdTable(id);
                    rpDiVat rpDivat = new rpDiVat();
                    rpDivat.DataSource = dt;
                    rpDivat.DataMember = dt.TableName;
                    ReportViewer.Report = rpDivat;
                    break;
                case "DiSanVanHoa":
                    dt = Sys_Common.NV_DiSanVanHoa.GetByIdTable(id);
                    rpDiSan rpDisan = new rpDiSan();
                    rpDisan.DataSource = dt;
                    rpDisan.DataMember = dt.TableName;
                    ReportViewer.Report = rpDisan;
                    break;
                case "NgheNhan":
                    dt = Sys_Common.NV_NgheNhan.GetByIdTable(id);
                    rpNgheNhan rpNghenhan = new rpNgheNhan();
                    rpNghenhan.DataSource = dt;
                    rpNghenhan.DataMember = dt.TableName;
                    ReportViewer.Report = rpNghenhan;
                    break;
            }
        }
    }
}