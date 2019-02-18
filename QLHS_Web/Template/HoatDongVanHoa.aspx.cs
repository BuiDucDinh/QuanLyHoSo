using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Data;
using System.Globalization;
public partial class Template_DanhMucDiSan : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialization();
            loadData();
        }
    }
    private void Initialization()
    {
        ddlDisan.DataSource = Sys_Common.LoadCombo("DiSan", GetLang());
        ddlTinh.DataSource = Sys_Common.LoadComboDiaDiem("", "tinh", GetLang());
        ddlHuyen.DataSource = Sys_Common.LoadComboDiaDiem(ddlTinh.SelectedValue, "huyen", GetLang());
        DataBind();
    }
    private void loadData()
    {
        int disan = 0;
        DateTime? tuNgay = null;
        try
        {
            disan = int.Parse(ddlDisan.SelectedValue);
        }
        catch { }
        try
        {
            tuNgay = DateTime.ParseExact(txtNgay.Text, "d-M-yyyy", CultureInfo.InvariantCulture);
        }
        catch { }
        string maTinh = ddlTinh.SelectedValue;
        string maHuyen = ddlHuyen.SelectedValue;
        DataTable dt = Sys_Common.NV_HoatDongVanHoa.getByCondition(disan, tuNgay, maTinh, maHuyen, Session["langID"] != null ? Session["langID"].ToString() : "vi");

        rptTintuc.DataSource = dt;
        rptTintuc.DataBind();
    }
    private void ClearData()
    {
        ddlDisan.SelectedIndex = 0;
        txtNgay.Text = "";
        ddlTinh.SelectedIndex = 0;
    }
    protected void ddlTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlTinh = (DropDownList)sender;
        ddlHuyen.DataSource = Sys_Common.LoadComboDiaDiem(ddlTinh.SelectedValue, "huyen");
        ddlHuyen.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loadData();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearData();
        loadData();
    }
}