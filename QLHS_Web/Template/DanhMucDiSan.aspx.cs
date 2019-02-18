using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using QLHS_Logic.NV;
using System.Data;
public partial class Template_DanhMucDiSan : BasePage
{
    public NV_DM_DiSan_ChiTiet danhmuc = new NV_DM_DiSan_ChiTiet();
    public string tendanhmuc = "";
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
        danhmuc = Sys_Common.NV_DM_DiSan.GetByUrl(url);
        tendanhmuc = GetLang() == "vi" ? danhmuc.TenDanhMuc : danhmuc.EngName;
        DataTable dt = Sys_Common.NV_DiSanVanHoa.GetByDanhMuc(danhmuc.DanhMucID.ToString(), GetLang());
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string tinh = dr["ThuocTinh"].ToString();
                string huyen = dr["ThuocHuyen"].ToString();
                string xa = dr["ThuocXa"].ToString();
                dr["DiaDiem"] = tinh + (!string.IsNullOrEmpty(huyen) ? ", " + huyen + (!string.IsNullOrEmpty(xa) ? ", " + xa : "") : "");
            }
            rptDiSan.DataSource = dt;
            rptDiSan.DataBind();
        }
    }
}