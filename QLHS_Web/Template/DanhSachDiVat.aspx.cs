using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Data;
public partial class Template_LoaiDiSan : BasePage
{
    public NV_DM_LoaiDiSan_ChiTiet loaids = new NV_DM_LoaiDiSan_ChiTiet();
    public string tenloaids = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialization();
            string url = RouteData.Values["disan"].ToString();
            if (!string.IsNullOrEmpty(url))
            {
                loaids = Sys_Common.NV_DM_LoaiDiSan.GetByUrl(url);
                tenloaids = GetLang() == "vi" ? loaids.TenLoai : loaids.EngName;
            }
            loadData();
        }
    }

    private void Initialization()
    {
        DataTable dt = Sys_Common.NV_DiSanVanHoa.GetByLoai(1);
        DataRow dr = dt.NewRow();
        dr["DiSanID"] = 0;
        dr["TenDiSan"] = "-- Chọn di sản --";
        dt.Rows.InsertAt(dr, 0);
        ddlDiSan.DataSource = dt;
        ddlDiSan.DataBind();

        dt = Sys_Common.NV_NoiLuuTru.GetAll();
        DataRow dr1 = dt.NewRow();
        dr1["ID"] = 0;
        dr1["Ten"] = "-- Chọn bảo tàng lưu trữ --";
        dt.Rows.InsertAt(dr1, 0);
        ddlBaotang.DataSource = dt;
        ddlBaotang.DataBind();
    }
    private void loadData()
    {
        int loai = 0; int disanid = 0; int baotang = 0;
        try
        {
            loai = int.Parse(ddlLoai.SelectedValue);
        }
        catch { }
        try
        {
            disanid = int.Parse(ddlDiSan.SelectedValue);
        }
        catch { }
        try
        {
            baotang = int.Parse(ddlBaotang.SelectedValue);
        }
        catch { }

        DataTable dt = Sys_Common.NV_DiVatCoVat.GetSearch(txtTen.Text, loai, disanid, baotang);
        //if (dt != null && dt.Rows.Count > 0)
        {
            rptDiVat.DataSource = dt;
            rptDiVat.DataBind();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loadData();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtTen.Text = "";
        ddlLoai.SelectedIndex = -1;
        ddlDiSan.SelectedIndex = -1;
        ddlBaotang.SelectedIndex = 0;
        loadData();
    }
}