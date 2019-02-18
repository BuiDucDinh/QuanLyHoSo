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
public partial class Template_LoaiDiSan : BasePage
{
    public NV_DM_LoaiDiSan_ChiTiet loaids = new NV_DM_LoaiDiSan_ChiTiet();
    public string tenloaids { get; set; }
    private void loadData(string url)
    {
        loaids = Sys_Common.NV_DM_LoaiDiSan.GetByUrl(url);
        tenloaids = GetLang() == "vi" ? loaids.TenLoai : loaids.EngName;
        DataTable dt = new DataTable();
        if (loaids.LoaiID != 0)
        {
            dt = Sys_Common.NV_DiSanVanHoa.GetByLoaiDS(loaids.LoaiID, null, GetLang());
        }
        else
        {
            dt = Sys_Common.NV_DiSanVanHoa.GetAll(true, GetLang());
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (string.IsNullOrEmpty(dr["Diadiem"].ToString()))
                {
                    string tinh = dr["ThuocTinh"].ToString();
                    string huyen = dr["ThuocHuyen"].ToString();
                    string xa = dr["ThuocXa"].ToString();
                    dr["DiaDiem"] = tinh + (!string.IsNullOrEmpty(huyen) ? ", " + huyen + (!string.IsNullOrEmpty(xa) ? ", " + xa : "") : "");
                }
            }
        }
        rptDiSan.DataSource = dt;
        rptDiSan.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialization();
            string url = RouteData.Values["menu"].ToString();
            if (!string.IsNullOrEmpty(url))
            {
                loaids = Sys_Common.NV_DM_LoaiDiSan.GetByUrl(url);
                tenloaids = GetLang() == "vi" ? loaids.TenLoai : loaids.EngName;
            }
            loadDiSan();
            ddlLoai.SelectedValue = loaids.LoaiID.ToString();
        }
    }
    private void Initialization()
    {
        DataTable dt = Sys_Common.NV_DM_LoaiDiSan.getDataCombo(GetLang());
        DataRow dr = dt.NewRow();
        dr["LoaiID"] = 0;
        dr["TenLoai"] = Resources.labels.chonloaids;
        dt.Rows.InsertAt(dr, 0);
        ddlLoai.DataSource = dt;
        ddlLoai.DataBind();

        dt = Sys_Common.NV_DM_CapDiSan.GetAll();
        if (GetLang() != "vi")
        {
            foreach (DataRow r in dt.Rows)
            {
                r["TenCap"] = r["EngName"].ToString();
            }
        }
        DataRow dr1 = dt.NewRow();
        dr1["ID"] = 0;
        dr1["TenCap"] = Resources.labels.choncapds;
        dt.Rows.InsertAt(dr1, 0);
        ddlCap.DataSource = dt;
        ddlCap.DataBind();


        ddlTinh.DataSource = Sys_Common.LoadComboDiaDiem("", "tinh", GetLang());
        ddlTinh.DataBind();
        ddlHuyen.DataSource = Sys_Common.LoadComboDiaDiem(ddlTinh.SelectedItem.Value, "huyen", GetLang());
        ddlHuyen.DataBind();
        ddlXa.DataSource = Sys_Common.LoadComboDiaDiem(ddlHuyen.SelectedItem.Value, "xa", GetLang());
        ddlXa.DataBind();
    }
    private void loadDiSan()
    {
        DateTime? tungay = null, denngay = null;
        int loai = 0; int cap = 0;
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
            cap = int.Parse(ddlCap.SelectedValue);
        }
        catch { }
        //try
        //{
        //    tungay = DateTime.ParseExact(txtTuNgay.Text, "d-M-yyyy", CultureInfo.InvariantCulture);
        //}
        //catch { }
        //try
        //{
        //    denngay = DateTime.ParseExact(txtDenNgay.Text, "d-M-yyyy", CultureInfo.InvariantCulture);
        //}
        //catch { }
        DataTable dt = Sys_Common.NV_DiSanVanHoa.GetResult(txtTen.Text, loai, cap, tungay, denngay, matinh, mahuyen, maxa, GetLang());
        if (dt.Rows.Count == 0)
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
        }
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
        ddlCap.SelectedIndex = -1;
        //txtTuNgay.Text = "";
        //txtDenNgay.Text = "";
        ddlTinh.SelectedIndex = 0;
        ddlHuyen.SelectedIndex = 0;
        ddlXa.SelectedIndex = 0;
        loadDiSan();
    }
    protected void ddlTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlHuyen.DataSource = Sys_Common.LoadComboDiaDiem(ddlTinh.SelectedItem.Value, "huyen",GetLang());
        ddlHuyen.DataBind();
        loadDiSan();
    }
    protected void ddlHuyen_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlXa.DataSource = Sys_Common.LoadComboDiaDiem(ddlHuyen.SelectedItem.Value, "xa",GetLang());
        ddlXa.DataBind();
        loadDiSan();
    }
}