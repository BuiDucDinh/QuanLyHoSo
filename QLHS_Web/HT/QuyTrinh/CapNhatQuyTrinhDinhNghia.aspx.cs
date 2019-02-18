using Ext.Net;
using QLHS_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DT_QuyTrinh_CapNhatQuyTrinhDinhNghia : System.Web.UI.Page
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
        dtNgayTao.Text = DateTime.Now.ToString("d/M/yyyy");
        stLoaiQuyTrinh.DataSource = Sys_Common.NV_LoaiQuyTrinh.GetAll();

        stCoQuan.DataSource = Sys_Common.NV_CoQuanHanhChinh.GetDataToCombo();
        DataBind();
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_QuyTrinhDinhNghia_ChiTiet model = new NV_QuyTrinhDinhNghia_ChiTiet();
            if (hdID.Text != "")
            {
                int id = int.Parse(hdID.Text);
                model = Sys_Common.NV_QuyTrinhDinhNghia.GetById(id);
                if (model.TrangThai && !ckbTrangThai.Checked)
                {
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = "Thông báo",
                        Message = "Không thể ngưng sử dụng quy trình này. Để ngưng, bạn cần tạo quy trình thay thế cho mục này",
                        Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                        Closable = false
                    });
                    return;
                }
                else if (!model.TrangThai && ckbTrangThai.Checked)
                {
                    model.NgayHieuLuc = DateTime.Now;
                }
            }
            else
            {
                if (ckbTrangThai.Checked)
                {
                    model.NgayHieuLuc = DateTime.Now;
                }
                try
                {
                    model.NgayTao = dtNgayTao.SelectedDate;
                }
                catch
                {
                    model.NgayTao = DateTime.Now;
                }
                try
                {
                    model.NguoiTao = int.Parse(Session["G_Ma_Nguoi_Dung"].ToString());
                }
                catch
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
            }
            model.Ten = txtTen.Text;
            model.LoaiQuyTrinh = int.Parse(cbLoaiQuyTrinh.Value.ToString());
            model.TrangThai = ckbTrangThai.Checked;
            model.ChuanBi = txtChuanBi.Text;
            model.CachThuc = txtCachthuc.Text;
            try
            {
                model.CoQuanID = int.Parse(cbCoQuan.Value.ToString());
            }
            catch { }
            model.DoiTuong = cbDoituong.Value.ToString();
            model.KetQua = txtKetQua.Text;
            model.LePhi = txtLePhi.Text;
            model.MauDon = txtMauDon.Text;
            model.PhapLy = txtPhapLy.Text;
            model.ThoiHan = txtThoiHan.Text;
            model.YeuCau = txtYeucau.Text;
            model.TrinhTu = txtTrinhtu.Text;
            bool check = true;
            if (hdID.Text != "")
            {
                model.ID = int.Parse(hdID.Text);
                check = Sys_Common.NV_QuyTrinhDinhNghia.update(model);
            }
            else
            {
                check = Sys_Common.NV_QuyTrinhDinhNghia.them(model);
            }
            //if (model.TrangThai)
            //{
            //    Sys_Common.NV_QuyTrinhDinhNghia.Active(idModel, model.LoaiQuyTrinh);
            //}
            if (check)
            {
                X.Msg.AddScript("parent.hdMsg.setValue('ok');");
                X.Msg.AddScript("parentAutoLoadControl.hide();");
            }
            else
            {
                X.Msg.Alert("Thông báo", "Đã có lỗi sảy ra...Xin thử lại", new JFunction { Fn = "" }).Show();
            }
        }
    }
    private void SetData(int id)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        NV_QuyTrinhDinhNghia_ChiTiet myDetail = Sys_Common.NV_QuyTrinhDinhNghia.GetById(id);
        hdID.Value = myDetail.ID;
        txtTen.Text = myDetail.Ten;
        cbLoaiQuyTrinh.Value = myDetail.LoaiQuyTrinh;
        ckbTrangThai.Checked = myDetail.TrangThai;
        txtNguoiTao.Text = Sys_Common.HT_NGUOI_DUNG.Lay(myDetail.NguoiTao).Ho_Ten;
        txtTrinhtu.Text = myDetail.TrinhTu;
        try
        {
            dtNgayHieuLuc.SelectedDate = (DateTime)myDetail.NgayHieuLuc;
        }
        catch { }
        try
        {
            dtNgayTao.SelectedDate = (DateTime)myDetail.NgayTao;
        }
        catch { }
        txtChuanBi.Text = myDetail.ChuanBi;
        txtCachthuc.Text = myDetail.CachThuc;
        cbCoQuan.Value = myDetail.CoQuanID.ToString();
        cbDoituong.Value = myDetail.DoiTuong.ToString();
        txtThoiHan.Text = myDetail.ThoiHan;
        txtLePhi.Text = myDetail.LePhi;
        txtMauDon.Text = myDetail.MauDon;
        txtPhapLy.Text = myDetail.PhapLy;
        txtYeucau.Text = myDetail.YeuCau;
        txtKetQua.Text = myDetail.KetQua;
    }

    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;

        hdID.Value = "";
        txtTen.Text = "";
        dtNgayHieuLuc.Value = "";
        txtNguoiTao.Text = Session["G_Ten_Nguoi_Dung"].ToString();
        dtNgayTao.Text = DateTime.Now.ToString("d/M/yyyy");
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTen.Text.Trim()) || cbLoaiQuyTrinh.Value == null)
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
}