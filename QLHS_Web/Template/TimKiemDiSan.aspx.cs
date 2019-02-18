using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using TreeviewDropDown;
using System.Web.Services;
using System.Globalization;
public partial class Template_TimKiemDiSan : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialization();
            loadDiSan();
        }
    }
    private void Initialization()
    {
        DataTable dt = Sys_Common.NV_DM_LoaiDiSan.getDataCombo();
        DataRow dr = dt.NewRow();
        dr["LoaiID"] = 0;
        dr["TenLoai"] = "--Chọn loại di sản--";
        dt.Rows.InsertAt(dr, 0);
        ddlLoai.DataSource = dt;
        ddlLoai.DataBind();

        ddlTinh.DataSource = Sys_Common.LoadComboDiaDiem("", "tinh");
        ddlTinh.DataBind();
        ddlHuyen.DataSource = Sys_Common.LoadComboDiaDiem(ddlTinh.SelectedItem.Value, "huyen");
        ddlHuyen.DataBind();
        ddlXa.DataSource = Sys_Common.LoadComboDiaDiem(ddlHuyen.SelectedItem.Value, "xa");
        ddlXa.DataBind();
    }
    private void loadDiSan()
    {
        int loai = 0;
        DateTime? tungay = null, denngay = null;
        string matinh = ddlTinh.SelectedItem.Value,
            mahuyen = ddlHuyen.SelectedItem.Value,
            maxa = ddlXa.SelectedItem.Value;
        try
        {
            loai = int.Parse(ddlLoai.SelectedValue);
        }
        catch { }
        try
        {
            tungay = DateTime.ParseExact(txtTuNgay.Text, "d-M-yyyy", CultureInfo.InvariantCulture);
        }
        catch { }
        try
        {
            denngay = DateTime.ParseExact(txtDenNgay.Text, "d-M-yyyy", CultureInfo.InvariantCulture);
        }
        catch { }
        DataTable dt = Sys_Common.NV_DiSanVanHoa.GetResult(txtTen.Text, loai,0, tungay, denngay, matinh, mahuyen, maxa,GetLang());
        rptDiSan.DataSource = dt;
        rptDiSan.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loadDiSan();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtTen.Text = "";
        ddlLoai.SelectedIndex = -1;
        txtTuNgay.Text = "";
        txtDenNgay.Text = "";
        ddlTinh.SelectedIndex = 0;
        ddlHuyen.SelectedIndex = 0;
        ddlXa.SelectedIndex = 0;
        loadDiSan();
    }
    protected void ddlTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlHuyen.DataSource = Sys_Common.LoadComboDiaDiem(ddlTinh.SelectedItem.Value, "huyen");
        ddlHuyen.DataBind();
        loadDiSan();
    }
    protected void ddlHuyen_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlXa.DataSource = Sys_Common.LoadComboDiaDiem(ddlHuyen.SelectedItem.Value, "xa");
        ddlXa.DataBind();
        loadDiSan();
    }
}