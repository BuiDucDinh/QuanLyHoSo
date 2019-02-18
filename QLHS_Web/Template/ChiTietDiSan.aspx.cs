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
public partial class Template_ChiTietDiSan : BasePage
{
    public NV_DiSanVanHoa_ChiTiet ds = new NV_DiSanVanHoa_ChiTiet();
    public NV_DM_LoaiDiSan_ChiTiet lds = new NV_DM_LoaiDiSan_ChiTiet();
    public string loaids = "";
    public string urlLoaids = "";
    public string filequyetdinh = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string menu = RouteData.Values["menu"] != null ? RouteData.Values["menu"].ToString() : "";
            string disan = RouteData.Values["disan"].ToString();
            loadData(menu, disan);
        }
    }

    private void loadData(string menu, string disan)
    {
        ds = Sys_Common.NV_DiSanVanHoa.GetByUrl(disan);
        if (ds.DiSanID != 0)
        {
            string sql = "select TenAnh from Image where '" + ds.HinhAnh + "' like '%,'+cast(ImageID as nvarchar(20))+',%'";
            DataTable dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptImage.DataSource = dt;
                rptImage.DataBind();
            }
            //sql = "select TenTaiLieu,[File] from Document where '" + ds.TaiLieu + "' like '%,'+cast(DocumentID as nvarchar(10))+',%'";
            //dt = Sys_Common.getDataByQuery(sql);
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    rptDoc.DataSource = dt;
            //    rptDoc.DataBind();
            //}
            sql = "select TenAnh from Image where ImageID=" + ds.FileQuyetDinh;
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                filequyetdinh = "<a style='padding-left:10px;' target='_blank' href='/FileUpload/Images/" + dt.Rows[0]["TenAnh"].ToString() + "'><i class='fa fa-sign-in'></i></a>";
            }

            sql = "select Ten_Tinh from HT_DM_Tinh where Ma_Tinh='" + ds.ThuocTinh + "'";
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                ds.ThuocTinh = dt.Rows[0]["Ten_Tinh"].ToString();
            }
            sql = "select TenLoai,EngName,dbo.getUrl(LoaiID,'DM_LoaiDiSan',null) as url from DM_LoaiDiSan where LoaiID=" + ds.LoaiDiSan;
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (GetLang()=="vi")
                {
                     loaids = dt.Rows[0]["TenLoai"].ToString();
                }
                else
                {
                     loaids = dt.Rows[0]["EngName"].ToString();
                }
               
                urlLoaids = dt.Rows[0]["url"].ToString();
            }
            sql = "select TenDanhMuc from DM_DiSan where '" + ds.DanhMucDS + "' like '%,'+cast(DanhMucID as nvarchar(20))+',%'";
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                ds.DanhMucDS = "";
                foreach (DataRow dr in dt.Rows)
                {
                    ds.DanhMucDS += dr["TenDanhMuc"].ToString() + ", ";
                }
                ds.DanhMucDS.Remove(ds.DanhMucDS.Length - 3);
            }
            else
            {
                danhmuc.Visible = false;
            }
            sql = "select ID,TieuDe,NgayXuatBan,GioiThieu,(select TenAnh from [Image] i where i.ImageID=bv.HinhAnh) as HinhAnh,dbo.getUrl(ID,'BaiViet_AnPham',DanhMucChinh) as url from BaiViet_AnPham bv where Duyet=1 and DiSanID=" + ds.DiSanID + " order by Stt";
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptOrther.DataSource = dt;
                rptOrther.DataBind();
            }
            sql = @"select [MediaLibID],[TenMediaLib],[MoTa],(select TenAnh from Image i where i.ImageID=m.HinhAnh) as [HinhAnh],[NgayTao]
                      ,dbo.getUrl(MediaLibID,'MediaLib',null) as [Url]
                    from MediaLib m where TypeMedia=1 and Duyet=1 and DiSanID=" + ds.DiSanID;
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptImageLib.DataSource = dt;
                rptImageLib.DataBind();
            }
            dt = Sys_Common.NV_DiVatCoVat.GetByDiSanID(ds.DiSanID);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptDiVat.DataSource = dt;
                rptDiVat.DataBind();
            }
            RightContent.DiSanID = ds.DiSanID.ToString();
        }
        if (!string.IsNullOrEmpty(menu))
        {
            lds = Sys_Common.NV_DM_LoaiDiSan.GetByUrl(menu);
            if (lds.LoaiID != 0)
            {

            }
        }
    }
}