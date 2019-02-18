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
            else
            {
                cbNgonNgu.Value = "vi";
            }
            string enable = Request.QueryString["enable"] != null ? Request.QueryString["enable"].ToString() : "";
            //if (string.IsNullOrEmpty(enable) || enable != "1")
            //{
            //    DisableControl();
            //}
        }
    }
    private void DisableControl()
    {
        btnUpdate.Visible = false;
        txtMaDiSan.Disabled = true;
        txtTenDiSan.Disabled = true;
        txtTenKhac.Disabled = true;
        cbLoaiDiSan.Disabled = true;
        //txtChuthevanhoa.Value = true.ChuTheVanHoa;
        cmbThuocTinh.Disabled = true;

        cmbThuocHuyen.Disabled = true;
        cmbThuocXa.Disabled = true;
        dtNgaychungnhan.Disabled = true;
        //txtMoTa = true;
        txtHientrang.Disabled = true;
        cbCoQuanHC.Disabled = true;
        txtGiatridanhgia.Disabled = true;
        txtDexuat.Disabled = true;
        txtChiphiduytri.Disabled = true;
        txtSoluotkhach.Disabled = true;
        txtSodangky.Disabled = true;
        cbCapdisan.Disabled = true;
        ImageOnly.Disabled = true;
        ImageMutil.Disabled = true;
        Document.Disabled = true;
        dBando.Disabled = true;
        dQuyhoach.Disabled = true;
        dMabang.Disabled = true;
        Video.Disabled = true;
        txtUrl.Hidden = true;
        txtLilich.Disabled = true;
        txtNiendai.Disabled = true;
        mcbDanhmuc.Disabled = true;
        dThongKeHienVat.Disabled = true;
        cbNgonNgu.Disabled = true;
    }
    private void Initialization()
    {
        stTinh.DataSource = Sys_Common.LoadComboDiaDiem("", "tinh");

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
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTenDiSan.Text.Trim()) || string.IsNullOrEmpty(txtMaDiSan.Text.Trim()) || cbLoaiDiSan.SelectedItem == null || cbCapdisan.SelectedItem == null)
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_DiSanVanHoa_ChiTiet model)
    {
        btnUpdate.ImageUrl = "/images/btnsave.png";
        //btnUpdate.Icon = Icon.ApplicationEdit;

        hdDiSanID.Text = model.DiSanID.ToString();
        txtMaDiSan.Text = model.MaDiSan;
        txtTenDiSan.Text = model.TenDiSan;
        txtTenKhac.Text = model.TenGoiKhac;
        cbLoaiDiSan.Value = model.LoaiDiSan;
        cbDiSan.Hidden = hdPhivatthe.Text.Contains("," + model.LoaiDiSan + ",");
        txtThoigiandienra.Hidden = !cbDiSan.Hidden;
        //txtChuthevanhoa.Value = model.ChuTheVanHoa;
        cmbThuocTinh.Value = model.ThuocTinh;

        stHuyen.DataSource = Sys_Common.LoadComboDiaDiem(model.ThuocTinh, "huyen");
        stHuyen.DataBind();
        cmbThuocHuyen.Value = model.ThuocHuyen;
        stXa.DataSource = Sys_Common.LoadComboDiaDiem(model.ThuocHuyen, "xa");
        stXa.DataBind();
        cmbThuocXa.Value = model.ThuocXa;
        dtNgaychungnhan.Value = model.NgayChungNhan;
        txtMoTa.Value = model.MoTa;
        txtHientrang.Value = model.HienTrang;
        cbCoQuanHC.Value = model.DonViQuanLy;
        txtGiatridanhgia.Value = model.GiaTriDanhGia;
        txtDexuat.Value = model.DeXuat;
        txtChiphiduytri.Value = model.ChiPhiDuyTri;
        txtSoluotkhach.Value = model.SoLuotKhach;
        txtSodangky.Value = model.SoDangKy;
        cbCapdisan.Value = model.CapDiSan;
        ImageOnly.ImageID = model.AnhDaiDien.ToString();
        //ImageBando.ImageID = model.AnhBanDo.ToString();
        ImageBando.DocumentID = model.AnhBanDo.ToString();
        ImageMutil.ImageID = model.HinhAnh;
        //ImageSoQuyetDinh.ImageID = model.FileQuyetDinh.ToString();
        ImageSoQuyetDinh.DocumentID = model.FileQuyetDinh.ToString();
        Document.DocumentID = model.TaiLieu;
        dBando.DocumentID = model.BanDoKhoanhVung;
        dQuyhoach.DocumentID = model.QuyHoach;
        dMabang.DocumentID = model.MatBangTongThe;
        Video.VideoID = model.Video;
        txtUrl.Text = model.Url;
        txtLilich.Text = model.LyLich;
        txtNiendai.Text = model.NienDai;
        txtStt.Text = model.STT.ToString();
        txtThoigiandienra.Text = model.ThoiGianDienRa;
        //ckbTrangthai.Checked = model.TrangThai;
        dThongKeHienVat.DocumentID = model.ThongKeHienVat;
        cbNgonNgu.Value = model.Lang;

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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string s = txtMoTa.Value;
        if (FormValidate())
        {
            NV_DiSanVanHoa_ChiTiet model = new NV_DiSanVanHoa_ChiTiet();
            model.MaDiSan = txtMaDiSan.Text;
            model.TenDiSan = txtTenDiSan.Text;
            model.TenGoiKhac = txtTenKhac.Text;
            model.LoaiDiSan = int.Parse(cbLoaiDiSan.Value.ToString());
            //model.ChuTheVanHoa = txtChuthevanhoa.Text;
            try
            {
                model.ThuocTinh = cmbThuocTinh.Value.ToString();
            }
            catch
            {
                model.ThuocTinh = "";
            }
            try
            {
                model.ThuocHuyen = cmbThuocHuyen.Value.ToString();
            }
            catch { model.ThuocHuyen = ""; }
            try
            {
                model.ThuocXa = cmbThuocXa.Value.ToString();
            }
            catch { model.ThuocXa = ""; }
            try
            {
                model.STT = int.Parse(txtStt.Text);
            }
            catch { model.STT = 1; }
            model.NgayChungNhan = (DateTime?)dtNgaychungnhan.SelectedValue;
            model.MoTa = txtMoTa.Value.ToString();
            model.HienTrang = txtHientrang.Text;
            model.DonViQuanLy = int.Parse(cbCoQuanHC.Value.ToString());
            model.GiaTriDanhGia = txtGiatridanhgia.Text;
            model.DeXuat = txtDexuat.Text;
            model.TaiLieu = Document.DocumentID;
            model.BanDoKhoanhVung = dBando.DocumentID;
            model.QuyHoach = dQuyhoach.DocumentID;
            model.MatBangTongThe = dMabang.DocumentID;
            model.Video = Video.VideoID;
            model.ChiPhiDuyTri = txtChiphiduytri.Text;
            model.SoLuotKhach = txtSoluotkhach.Text;
            model.SoDangKy = txtSodangky.Text;
            model.CapDiSan = int.Parse(cbCapdisan.Value.ToString());
            //model.FileQuyetDinh = int.Parse(ImageSoQuyetDinh.ImageID);
            model.FileQuyetDinh = ImageSoQuyetDinh.DocumentID;
            model.AnhDaiDien = int.Parse(ImageOnly.ImageID);
            //model.AnhBanDo = int.Parse(ImageBando.ImageID);
            model.AnhBanDo = ImageBando.DocumentID;
            model.DanhMucDS = ",";
            model.HinhAnh = ImageMutil.ImageID;
            model.Url = txtUrl.Text != "" ? StringUtil.RemoveSign4VietnameseString(txtUrl.Text).Replace(" ", "-") : StringUtil.RemoveSign4VietnameseString(txtTenDiSan.Text).Replace(" ", "-");
            //model.TrangThai = ckbTrangthai.Checked;
            model.LyLich = txtLilich.Text;
            model.NienDai = txtNiendai.Text;
            model.ChuTheVanHoa = "";
            model.ThoiGianDienRa = txtThoigiandienra.Text.Trim();
            model.ThongKeHienVat = dThongKeHienVat.DocumentID;
            model.Lang = cbNgonNgu.Value.ToString();

            try
            {
                model.DiSanLQ = int.Parse(cbDiSan.Value.ToString());
            }
            catch
            {
                model.DiSanLQ = 0;
            }
            foreach (var item in mcbDanhmuc.SelectedItems)
            {
                model.DanhMucDS += item.Value + ",";
            }
            NV_Log_ChiTiet log;

            bool check;
            if (hdDiSanID.Text != "")
            {
                model.DiSanID = int.Parse(hdDiSanID.Text);
                check = Sys_Common.NV_DiSanVanHoa.Update(model);
                log = createLog(model.DiSanID, "update");
            }
            else
            {
                //model.Duyet = false;
                model.NguoiTao = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
                int idBanGhi = 0;
                check = Sys_Common.NV_DiSanVanHoa.them(model, out idBanGhi);
                log = createLog(idBanGhi, "insert");
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
    protected void stHuyen_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (cmbThuocTinh.Value != null)
        {
            this.stHuyen.DataSource = Sys_Common.LoadComboDiaDiem(this.cmbThuocTinh.Value.ToString(), "huyen");

            this.stHuyen.DataBind();
        }
        else
        {
            X.Msg.AddScript("#{cmbHuyen}.clearValue();");
        }
    }
    protected void stXa_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (cmbThuocHuyen.Value != null)
        {
            this.stXa.DataSource = Sys_Common.LoadComboDiaDiem(this.cmbThuocHuyen.Value.ToString(), "xa");

            this.stXa.DataBind();
        }
        else
        {
            X.Msg.AddScript("#{cmbXa}.clearValue();");
        }
    }

}