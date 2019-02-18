using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using Models;
public partial class NghiepVu_Quanlyvanban_CapNhatNgheNhan : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            Initialization();
            if (!string.IsNullOrEmpty(id))
            {
                SetData(Sys_Common.NV_NgheNhan.GetById(int.Parse(id)));
            }
        }
    }
    private void Initialization()
    {
        stDantoc.DataSource = Sys_Common.HT_DAN_TOC.Danh_Sach();
        stDiSan.DataSource = Sys_Common.NV_DiSanVanHoa.GetByLoai(0);
        stDanhHieu.DataSource = Sys_Common.NV_DanhHieuNgheNhan.GetAll();
        stLoaiDS.DataSource = Sys_Common.NV_DM_LoaiDiSan.getByLoai(0);
        DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (FormValidate())
        {
            NV_NgheNhan_ChiTiet model = new NV_NgheNhan_ChiTiet();
            model.HoTen = txtHoten.Text;
            model.TenKhac = txtTenkhac.Text;
            model.NgaySinh = txtNgaySinh.Text;
            if (txtNgaycap.SelectedDate != Convert.ToDateTime(txtNgaycap.EmptyValue))
            {
                model.NgayCap = Convert.ToDateTime(txtNgaycap.Text);
            }
            else { }
            model.MaDanToc = cbDantoc.Value.ToString();
            model.NguyenQuan = txtNguyenquan.Text;
            model.HoKhauThuongTru = txtHokhau.Text;
            try
            {
                model.DiSanID = int.Parse(cbDiSan.Value.ToString());
            }
            catch { model.DiSanID = 0; }
            model.NamBatDau = txtNambatdau.Text;
            model.Url = StringUtil.RemoveSign4VietnameseString(txtHoten.Text).Replace(" ", "-");

            model.HinhAnh = int.Parse(ImageOnly.ImageID);
            model.File = Document.DocumentID;
            model.DienThoai = txtDienthoai.Text;
            model.DiDong = txtDidong.Text;
            model.DiaChi = txtDiachi.Text;
            model.QuaTrinh = txtQuatrinh.Text;
            model.TriThucKyNang = txtTrithuc.Text;
            model.KhenThuong = txtKhenthuong.Text;
            model.KyLuat = txtKyluat.Text;
            model.GioiThieu = fckGioithieu.Value;
            model.DanhHieu = int.Parse(cbDanhhieu.Value.ToString());
            model.LoaiDiSan = int.Parse(cbLoaiDS.Value.ToString());
            model.TenDiSan = txtTenDS.Text.Trim();
            bool check;

            int maND = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
            NV_Log_ChiTiet log;

            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                check = Sys_Common.NV_NgheNhan.update(model);
                log = createLog(model.ID, "update");
            }
            else
            {
                int idBanghi = 0;
                check = Sys_Common.NV_NgheNhan.them(model, out idBanghi);
                log = createLog(idBanghi, "insert");
            }
            if (check == true)
            {
                Sys_Common.NV_Log.them(log);
                X.Msg.AddScript("parent.hdMsg.setValue('ok');");
                X.Msg.AddScript("parentAutoLoadControl.hide();");
            }
            else
            {
                X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
            }
        }

    }

    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtHoten.Text.Trim()) || cbDiSan.Value == null || cbDanhhieu.Value == null || cbLoaiDS.Value == null)
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_NgheNhan_ChiTiet model)
    {
        btnUpdate.ImageUrl = "/images/btnsave.png";

        hdID.Value = model.ID;
        txtTenkhac.Text = model.TenKhac;
        txtHokhau.Text = model.HoKhauThuongTru;
        txtHoten.Text = model.HoTen;
        try
        {
            txtNgaycap.SelectedDate = (DateTime)model.NgayCap;
        }
        catch { }
        txtNgaySinh.Text = model.NgaySinh;
        txtNguyenquan.Text = model.NguyenQuan;
        txtDiachi.Text = model.DiaChi;
        txtDienthoai.Text = model.DienThoai;
        txtDidong.Text = model.DiDong;
        cbDantoc.Value = model.MaDanToc;
        txtQuatrinh.Text = model.QuaTrinh;
        txtTrithuc.Text = model.TriThucKyNang;
        txtKhenthuong.Text = model.KhenThuong;
        txtKyluat.Text = model.KyLuat;
        txtNambatdau.Text = model.NamBatDau;
        cbDiSan.Value = model.DiSanID;
        ImageOnly.ImageID = model.HinhAnh.ToString();
        Document.DocumentID = model.File;
        cbDanhhieu.Value = model.DanhHieu;
        fckGioithieu.Value = model.GioiThieu;
        cbLoaiDS.Value = model.LoaiDiSan;
        txtTenDS.Text = model.TenDiSan;
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