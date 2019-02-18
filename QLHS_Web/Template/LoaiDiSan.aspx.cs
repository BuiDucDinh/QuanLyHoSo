using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Data;
public partial class Template_LoaiDiSan :BasePage
{
    public NV_DM_LoaiDiSan_ChiTiet loaids = new NV_DM_LoaiDiSan_ChiTiet();
    public string tenloaids = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string url = RouteData.Values["menu"].ToString();
            if (!string.IsNullOrEmpty(url))
            {
                loadData(url);
            }
        }
    }
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
}