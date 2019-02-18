using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Data;
public partial class NghiepVu_Disanvanhoa_CapNhatDSVanHoa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["GIsLogin"] == null)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Phiên làm việc đã kết thúc do bạn ngưng sử dụng máy quá lâu. <br>Hãy ấn F5 để bắt đầu phiên làm việc mới.",
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    Closable = false
                });
                return;
            }
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            Initialization();
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "")
            {
                //loadDiaDiem();
                SetData(Sys_Common.NV_DiSanVanHoa.GetById(int.Parse(id)));
            }
        }
    }

    private void Initialization()
    {

        stCapDiSan.DataSource = Sys_Common.NV_DM_CapDiSan.GetAll();
        //loại di sản
        stLoaidisan.DataSource = Sys_Common.NV_DM_LoaiDiSan.getDataCombo();
        stCoquanHC.DataSource = Sys_Common.NV_CoQuanHanhChinh.GetDataToCombo();
        stDanhmuc.DataSource = Sys_Common.NV_DM_DiSan.GetAll();
        stDiSan.DataSource = Sys_Common.NV_DiSanVanHoa.GetByLoai(0);
        DataTable dt = Sys_Common.NV_DM_LoaiDiSan.getByLoai(0);
        if (dt.Rows.Count > 0)
        {
            hdPhivatthe.Text = ",";
            foreach (DataRow dr in dt.Rows)
            {
                hdPhivatthe.Text += dr["LoaiID"].ToString() + ",";
            }
        }
        DataBind();
    }
    private void SetData(NV_DiSanVanHoa_ChiTiet model)
    {
        txtMaDiSan.Text = model.MaDiSan;
        txtTenDiSan.Text = model.TenDiSan;
        txtTenKhac.Text = model.TenGoiKhac;
        cbLoaiDiSan.Value = model.LoaiDiSan;
        cbDiSan.Value = model.DiSanID;
        //txtChuthevanhoa.Value = model.ChuTheVanHoa;
        txtDiadiem.Text = model.DiaDiem;
        try
        {
            dtNgaychungnhan.Value = ((DateTime)model.NgayChungNhan).ToString("dd/MM/yyyy");
        }
        catch { }
        txtMoTa.Value = model.MoTa;
        txtHientrang.Value = model.HienTrang;
        cbCoQuanHC.Value = model.DonViQuanLy;
        txtGiatridanhgia.Value = model.GiaTriDanhGia;
        txtDexuat.Value = model.DeXuat;
        txtChiphiduytri.Value = model.ChiPhiDuyTri;
        txtSoluotkhach.Value = model.SoLuotKhach;
        txtSodangky.Value = model.SoDangKy;
        cbCapdisan.Value = model.CapDiSan;
        txtAnhdaidien.ImageUrl = "/Uploads/images/" + Sys_Common.NV_Image.GetbyListID("," + model.AnhDaiDien + ",").Rows[0]["TenAnh"].ToString();

        //ImageMutil.ImageID = model.HinhAnh;
        //Document.DocumentID = model.TaiLieu;
        //dBando.DocumentID = model.BanDoKhoanhVung;
        //dQuyhoach.DocumentID = model.QuyHoach;
        //dMabang.DocumentID = model.MatBangTongThe;
        //Video.VideoID = model.Video;
        txtLilich.Text = model.LyLich;
        txtNiendai.Text = model.NienDai;
        //ckbTrangthai.Checked = model.TrangThai;

        if (!string.IsNullOrEmpty(model.DanhMucDS))
        {
            string[] danhmuc = model.DanhMucDS.Split(',');

            foreach (string item in danhmuc)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    mcbDanhmuc.SelectedItems.Add(new Ext.Net.SelectedListItem(item));
                }
            }
        }
    }


}