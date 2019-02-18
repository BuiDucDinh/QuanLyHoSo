using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic.NV;
using QLHS_Logic;
using System.Data;
public partial class Template_ChiTietTin : BasePage
{
    public NV_HoatDongVanHoa_ChiTiet hd = new NV_HoatDongVanHoa_ChiTiet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string hoatdong = RouteData.Values["hoatdong"] != null ? RouteData.Values["hoatdong"].ToString() : "";
            loadData(hoatdong);
        }
    }
    private void loadData(string hoatdong)
    {
        hd = Sys_Common.NV_HoatDongVanHoa.GetByUrl(hoatdong);
        if (hd.HoatDongID != 0)
        {
            string sql = "select TenAnh from Image where ImageID=" + hd.HinhAnh;
            DataTable dt = Sys_Common.getDataByQuery(sql);
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    rptImage.DataSource = dt;
            //    rptImage.DataBind();
            //}
            sql = "select ID,TieuDe,NgayXuatBan,GioiThieu,(select TenAnh from [Image] i where i.ImageID=bv.HinhAnh) as HinhAnh,dbo.getUrl(ID,'BaiViet_AnPham',DanhMucChinh) as url from BaiViet_AnPham bv where Duyet=1 and HoatDongID=" + hd.HoatDongID + " order by Stt";
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptOrther.DataSource = dt;
                rptOrther.DataBind();
            }
            sql = @"select [MediaLibID],[TenMediaLib],[MoTa],(select TenAnh from Image i where i.ImageID=m.HinhAnh) as [HinhAnh],[NgayTao]
                      ,dbo.getUrl(MediaLibID,'MediaLib',null) as [Url]
                    from MediaLib m where TypeMedia=1 and Duyet=1 and HoatDongID=" + hd.HoatDongID;
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptImageLib.DataSource = dt;
                rptImageLib.DataBind();
            }
        }
    }
}