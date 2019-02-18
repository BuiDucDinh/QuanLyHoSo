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
public partial class NghiepVu_Disanvanhoa_CapNhatDiVat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
        if (!IsPostBack)
        {
            Initialization();
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "")
            {
                SetData(Sys_Common.NV_DiVatCoVat.GetById(int.Parse(id)));
            }
            else
            {
                cbNgonNgu.Value = "vi";
            }
        }
    }
    private void Initialization()
    {
        stHoidong.DataSource = Sys_Common.NV_HoiDongThamDinh.GetAll();
        stNoiluutru.DataSource = Sys_Common.NV_NoiLuuTru.GetAll();
        stDiSan.DataSource = Sys_Common.NV_DiSanVanHoa.GetByLoai(1);
        stThoiky.DataSource = Sys_Common.NV_ThoiKy.GetAll();
        DataBind();
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTen.Text.Trim()) || string.IsNullOrEmpty(txtMaSo.Text.Trim()) || cbPhanloai.SelectedItem == null)
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_DiVatCoVat_ChiTiet model)
    {
        btnUpdate.ImageUrl = "/images/btnsave.png";
        //btnUpdate.Icon = Icon.ApplicationEdit;

        hdID.Text = model.ID.ToString();
        txtChatlieu.Text = model.ChatLieu;
        txtChusohuu.Text = model.ChuSoHuu;
        txtDautich.Text = model.DauTichDacBiet;
        txtDiaDiem.Text = model.DiaDiemPhatHien;
        txtGhichugiamdinh.Text = model.GhiChuGiamDinh;
        txtGioithieu.Value = model.GioiThieu;
        txtKichthuoc.Text = model.KichThuocTrongLuong;
        txtMaSo.Text = model.MaSo;
        txtMieuta.Text = model.MieuTaHienVat;
        try
        {
            txtNgaygiamdinh.SelectedDate = (DateTime)model.NgayGiamDinh;
        }
        catch { }
        txtNguongoc.Text = model.NguonGoc;
        txtNiendai.Text = model.NienDai;
        txtSoluong.Text = model.SoLuong.ToString();
        txtTen.Text = model.Ten;
        txtTenKhac.Text = model.TenKhac;
        txtThanhphan.Text = model.ThanhPhanHopThanh;
        txtThaydoichu.Text = model.ThayDoiChuSoHuu;
        txtTinhtrang.Text = model.TinhTrang;
        cbHoidong.Value = model.HoiDongGiamDinh;
        cbDiSan.Value = model.DiSanID;
        ckbIsMusiem.Checked = !model.IsMuseum;
        if (model.IsMuseum)
        {
            pnDiSan.Hidden = true;
            pnNoiLuuTru.Hidden = false;
        }
        else
        {
            pnNoiLuuTru.Hidden = true;
            pnDiSan.Hidden = false;
        }
        cbNoiluutru.Value = model.NoiLuuTru;
        cbPhanloai.Value = model.PhanLoai;
        cbThoiky.Value = model.Thoiky;
        ImageOnly.ImageID = model.AnhDaiDien.ToString();
        Document.DocumentID = model.FileDinhKem;
        Video.VideoID = model.Video;
        ImageMutil.ImageID = model.BoAnh;
        cbNgonNgu.Value = model.Lang;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (FormValidate())
        {
            NV_DiVatCoVat_ChiTiet model = new NV_DiVatCoVat_ChiTiet();
            model.AnhDaiDien = int.Parse(ImageOnly.ImageID);
            model.BoAnh = ImageMutil.ImageID;
            model.ChatLieu = txtChatlieu.Text;
            model.DauTichDacBiet = txtDautich.Text;
            model.DiaDiemPhatHien = txtDiaDiem.Text;
            model.FileDinhKem = Document.DocumentID;
            model.GhiChuGiamDinh = txtGhichugiamdinh.Text;
            model.GioiThieu = txtGioithieu.Value;
            try
            {
                model.HoiDongGiamDinh = int.Parse(cbHoidong.Value.ToString());
            }
            catch
            {
                model.HoiDongGiamDinh = 0;
            }
            model.KichThuocTrongLuong = txtKichthuoc.Text;
            model.MaSo = txtMaSo.Text;
            model.MieuTaHienVat = txtMieuta.Text;
            if (txtNgaygiamdinh.SelectedDate != txtNgaygiamdinh.MinDate)
            {
                model.NgayGiamDinh = txtNgaygiamdinh.SelectedDate;
            }
            model.NguonGoc = txtNguongoc.Text;
            model.NienDai = txtNiendai.Text;
            model.IsMuseum = !ckbIsMusiem.Checked;

            try
            {
                model.DiSanID = int.Parse(cbDiSan.Value.ToString());
            }
            catch { model.DiSanID = 0; }
            model.ChuSoHuu = txtChusohuu.Text;
            try
            {
                model.NoiLuuTru = int.Parse(cbNoiluutru.Value.ToString());
            }
            catch { }
            model.PhanLoai = int.Parse(cbPhanloai.Value.ToString());
            try
            {
                model.SoLuong = int.Parse(txtSoluong.Text);
            }
            catch { }
            model.Ten = txtTen.Text;
            model.TenKhac = txtTenKhac.Text;
            model.UrlName = StringUtil.RemoveSign4VietnameseString(model.Ten).Replace(" ", "-");
            model.ThanhPhanHopThanh = txtThanhphan.Text;
            model.ThayDoiChuSoHuu = txtThaydoichu.Text;
            try
            {
                model.Thoiky = int.Parse(cbThoiky.Value.ToString());
            }
            catch { }
            model.TinhTrang = txtTinhtrang.Text;
            model.Video = Video.VideoID;
            model.Lang = cbNgonNgu.Value.ToString();

            NV_Log_ChiTiet log;
            bool check;
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                check = Sys_Common.NV_DiVatCoVat.update(model);
                log = new NV_Log_ChiTiet(model.ID, "update");
            }
            else
            {
                int idBanGhi = 0;
                check = Sys_Common.NV_DiVatCoVat.them(model, out idBanGhi);
                log = new NV_Log_ChiTiet(idBanGhi, "insert");
            }
            if (check == true)
            {
                Sys_Common.NV_Log.them(log);
                X.Msg.AddScript("ExportYap();parent.hdMsg.setValue('ok');parentAutoLoadControl.hide();");
            }
            else
            {
                X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
            }
        }
    }
    private NV_Log_ChiTiet createLog(int id, string thaotac)
    {
        int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
        string maForm = Request.QueryString["cn"].ToString();
        NV_Log_ChiTiet log = new NV_Log_ChiTiet(maND, maForm);
        log.ThaoTac = thaotac;
        log.IDBanGhi = id;
        return log;
    }
}