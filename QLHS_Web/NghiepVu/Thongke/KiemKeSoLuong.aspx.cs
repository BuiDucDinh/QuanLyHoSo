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
        string type = Request.QueryString["type"] != null ? Request.QueryString["type"].ToString() : "";
        string nam = Request.QueryString["nam"] != null ? Request.QueryString["nam"].ToString() : "";
        if (!string.IsNullOrEmpty(type))
        {
            loadData(type, nam);
        }
    }
    private void loadData(string type, string nam)
    {
        int year = 0;
        try
        {
            year = int.Parse(nam);
        }
        catch { }
        if (year == DateTime.Now.Year) year = 0;
        DataTable dt = new DataTable();
        switch (type)
        {
            case "1":
                rpSoBaoTang rptSobaotang = new rpSoBaoTang();
                dt = Sys_Common.NV_KiemKeSoLuong.ThongKeSoBaoTang(year);
                rptSobaotang.DataSource = dt;
                rptSobaotang.DataMember = dt.TableName;
                ReportViewer.Report = rptSobaotang;
                break;
            case "2":
                rpSoDiTich rptSoditich = new rpSoDiTich();
                dt = Sys_Common.NV_KiemKeSoLuong.ThongKeSoDiTich(year);
                rptSoditich.DataSource = dt;
                rptSoditich.DataMember = dt.TableName;
                ReportViewer.Report = rptSoditich;
                break;
            case "3":
                rpSoDiSanPVT rptSodisanPVT = new rpSoDiSanPVT();
                dt = Sys_Common.NV_KiemKeSoLuong.ThongKeSoDiSanPVT(year);
                rptSodisanPVT.DataSource = dt;
                rptSodisanPVT.DataMember = dt.TableName;
                ReportViewer.Report = rptSodisanPVT;
                break;
        }

    }
}