using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using System.Data;
using QLHS_Logic.NV;
public partial class Template_Default : BasePage
{
    public NV_DM_LoaiDiSan_ChiTiet vatthe = new NV_DM_LoaiDiSan_ChiTiet();
    public NV_DM_LoaiDiSan_ChiTiet phivatthe = new NV_DM_LoaiDiSan_ChiTiet();
    public string dsvatthe = "";
    public string dsphivatthe = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    private void loadData()
    {
        string sql = "select MenuID,TenMenu,ChucNangID,dbo.getUrl(MenuID,'Menu',null) as url from Menu where Duyet=1 and Vitri=2 and Level=1 and Lang='" + GetLang() + "' order by Stt";
        DataTable dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptMenu.DataSource = dt;
            rptMenu.DataBind();
        }
        sql = "select (select TenAnh from Image i where i.ImageID=q.ImageID) as Image,Link,Description,Target,IsImage from Quangcao q where Duyet=1 and Type=6";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToBoolean(dr["IsImage"].ToString()))
                {
                    dr["Description"] = @"<a href=""" + dr["Link"].ToString() + @""" class=""img-responsive"" target=""" + dr["Target"].ToString() + @"""><img src=""/FileUpload/Images/" + dr["Image"].ToString() + @"""></a>";
                }
            }
            rptSlider.DataSource = dt;
            rptSlider.DataBind();
        }
        sql = "select ID,TieuDe,dbo.getUrl(ID,'BaiViet_AnPham',DanhMucChinh) as url from BaiViet_AnPham bv where Duyet=1 and NoiBat=1 and Lang='" + GetLang() + "' order by Stt";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptTintuc.DataSource = dt;
            rptTintuc.DataBind();
        }

        vatthe = Sys_Common.NV_DM_LoaiDiSan.getByLoai_Parent(1);        //di sản văn hóa vật thể
        dsvatthe = GetLang() == "vi" ? vatthe.TenLoai : vatthe.EngName;
        dt = Sys_Common.NV_DiSanVanHoa.GetByLoaiDS(vatthe.LoaiID, true, GetLang());
        if (dt != null && dt.Rows.Count > 0)
        {
            rptDSVatThe.DataSource = dt;
            rptDSVatThe.DataBind();
        }
        phivatthe = Sys_Common.NV_DM_LoaiDiSan.getByLoai_Parent(0);     // di sản văn hóa phi vật thể
        dsphivatthe = GetLang() == "vi" ? phivatthe.TenLoai : phivatthe.EngName;
        dt = Sys_Common.NV_DiSanVanHoa.GetByLoaiDS(phivatthe.LoaiID, true, GetLang());
        if (dt != null && dt.Rows.Count > 0)
        {
            rptDSPhiVatThe.DataSource = dt;
            rptDSPhiVatThe.DataBind();
        }

        sql = "select (select TenAnh from Image i where i.ImageID=q.ImageID) as Image,Link,Description,Target,IsImage from Quangcao q where Duyet=1 and Type=3";
        dt = Sys_Common.getDataByQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToBoolean(dr["IsImage"].ToString()))
                {
                    dr["Description"] = @"<a href=""" + dr["Link"].ToString() + @""" target=""" + dr["Target"].ToString() + @"""><img src=""/FileUpload/Images/" + dr["Image"].ToString() + @"""></a>";
                }
            }
            rptAdv.DataSource = dt;
            rptAdv.DataBind();
        }
    }
    protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string id, chucnang;
            id = ((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString();
            chucnang = ((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString();
            string sql = "";
            DataTable dt = new DataTable();

            DataTable dtHot = new DataTable();
            dtHot.Columns.Add("TieuDe");
            dtHot.Columns.Add("NgayXuatBan");
            dtHot.Columns.Add("GioiThieu");
            dtHot.Columns.Add("HinhAnh");
            dtHot.Columns.Add("url");

            sql = "select top 4 ID,TieuDe,NgayXuatBan,GioiThieu,(select TenAnh from [Image] i where i.ImageID=bv.HinhAnh) as HinhAnh,dbo.getUrl(ID,'BaiViet_AnPham'," + id + ") as url from BaiViet_AnPham bv where Duyet=1 and DanhMuc like '%," + id + ",%' order by Stt,NgayXuatBan";
            dt = Sys_Common.getDataByQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                Panel pnDisan = e.Item.FindControl("pnDisan") as Panel;
                pnDisan.Visible = true;
                Repeater rpt2NewHot = e.Item.FindControl("rpt2HotNew") as Repeater;

                if (dt.Rows.Count > 1)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        DataRow drHot2 = dtHot.NewRow();
                        drHot2["TieuDe"] = dt.Rows[i]["TieuDe"].ToString();
                        drHot2["NgayXuatBan"] = dt.Rows[i]["NgayXuatBan"].ToString();
                        drHot2["GioiThieu"] = dt.Rows[i]["GioiThieu"].ToString();
                        drHot2["HinhAnh"] = dt.Rows[i]["HinhAnh"].ToString();
                        drHot2["url"] = dt.Rows[i]["url"].ToString();
                        dtHot.Rows.Add(drHot2);
                    }
                    rpt2NewHot.DataSource = dtHot;
                    for (int i = 0; i < 2; i++)
                    {
                        dt.Rows[i].Delete();
                    }
                    dt.AcceptChanges();
                    Repeater rptTinDisan = e.Item.FindControl("rptTinDisan") as Repeater;
                    rptTinDisan.DataSource = dt;
                    rptTinDisan.DataBind();
                }
                else
                {
                    rpt2NewHot.DataSource = dt;
                }
                rpt2NewHot.DataBind();
            }
        }
    }
}