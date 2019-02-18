using Ext.Net;
using QLHS_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class NghiepVu_QuyTrinh_CapNhatQuyTrinhXuLy : System.Web.UI.Page
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
        if (!this.IsPostBack)
        {
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            Initialization();
            int id = 0;
            try
            {
                id = int.Parse(Request.QueryString["id"].ToString());
                SetData(id);
            }
            catch { }
        }
    }
    private void Initialization()
    {
        txtNguoiTao.Text = Session["G_Ten_Nguoi_Dung"].ToString();
        dtNgayBatDau.Text = DateTime.Now.ToString("d/M/yyyy");
        stQuyTrinhDN.DataSource = Sys_Common.NV_LoaiQuyTrinh.GetAll();
        stTrangthai.DataSource = Sys_Common.NV_TrangThaiXuLy.GetAll();
        DataBind();
        cbTrangThai.Value = 2;
    }
    private void SetData(int id)
    {
        NV_QuyTrinhXuLy_ChiTiet model = Sys_Common.NV_QuyTrinhXuLy.GetById(id);
        try
        {
            hdID.Value = model.ID;
            txtTen.Text = model.Ten;
            cbQuyTrinhDN.Value = Sys_Common.NV_QuyTrinhDinhNghia.GetById(model.IDQuyTrinh).LoaiQuyTrinh;
            txtNguoiTao.Text = Sys_Common.HT_NGUOI_DUNG.Lay(model.NguoiTao).Ten_Dang_Nhap;
            txtNguoiTao.Disabled = true;
            dtNgayBatDau.SelectedDate = model.NgayBatDau;
            dtNgayBatDau.Disabled = true;
            txtNguoiYeuCau.Text = model.NguoiYeuCau;
            txtEmail.Text = model.Email;
            txtSoDienThoai.Text = model.SoDienThoai;
            txtDiaChi.Text = model.DiaChi;
            txtThongTin.Text = model.ThongTin;
            Document.DocumentID = model.FileDauVao.ToString();
            cbTrangThai.Value = model.TrangThai;
            txtGhiChu.Text = model.GhiChu;
        }
        catch
        {
            X.Msg.AddScript("parent.hdMsg.setValue('error');");
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValid())
        {
            NV_QuyTrinhXuLy_ChiTiet model = new NV_QuyTrinhXuLy_ChiTiet();
            int loai = int.Parse(cbQuyTrinhDN.Value.ToString());
            NV_QuyTrinhDinhNghia_ChiTiet dn = Sys_Common.NV_QuyTrinhDinhNghia.GetByLoaiActive(loai);
            if (dn.ID == 0)
            {
                X.Msg.Alert("Thông báo", "Thủ tục " + dn.Ten + " chưa được tạo quy trình xử lý. Liên hệ với người quản trị để tạo quy trình trước khi thiết lập hồ sơ !!!", new JFunction { Fn = "" }).Show();
                return;
            }
            model.IDQuyTrinh = dn.ID;
            List<NV_LuongDinhNghia_ChiTiet> lst = Sys_Common.NV_LuongDinhNghia.GetByQT(model.IDQuyTrinh);
            if (lst.Count <= 0)
            {
                X.Msg.Alert("Thông báo", "Thủ tục "+dn.Ten+" chưa được tạo quy trình xử lý. Liên hệ với người quản trị để tạo quy trình trước khi thiết lập hồ sơ !!!", new JFunction { Fn = "" }).Show();
                return;
            }
            model.Ten = txtTen.Text;
            model.NguoiTao = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
            model.NgayBatDau = dtNgayBatDau.SelectedDate;
            model.NguoiYeuCau = txtNguoiYeuCau.Text;
            model.Email = txtEmail.Text;
            model.SoDienThoai = txtSoDienThoai.Text;
            model.DiaChi = txtDiaChi.Text;
            model.ThongTin = txtThongTin.Text;
            model.FileDauVao = Document.DocumentID;
            model.TrangThai = int.Parse(cbTrangThai.Value.ToString());
            model.GhiChu = txtGhiChu.Text;
            bool check = false;
            try
            {
                int id = int.Parse(hdID.Value.ToString());
                model.ID = id;
                check = Sys_Common.NV_QuyTrinhXuLy.update(model);
            }
            catch
            {
                check = Sys_Common.NV_QuyTrinhXuLy.them(model);
            }
            if (check == true)
            {
                X.Msg.AddScript("parent.hdMsg.setValue('ok');");
                X.Msg.AddScript("parentAutoLoadControl.hide();");
            }
            else
            {
                X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
            }
        }
        else
        {
            X.Msg.Alert("Thông báo", "Bạn chưa nhập đủ thông tin", new JFunction { Fn = "" }).Show();
        }
    }
    private bool FormValid()
    {
        if (string.IsNullOrEmpty(txtTen.Text.Trim()) || string.IsNullOrEmpty(txtNguoiYeuCau.Text.Trim()) || cbQuyTrinhDN.Value == null)
        {
            return false;
        }
        return true;
    }
}