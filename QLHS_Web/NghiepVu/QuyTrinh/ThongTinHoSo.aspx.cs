using Ext.Net;
using QLHS_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_QuyTrinh_ThongTinNguoiYeuCau : System.Web.UI.Page
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
            int id = 0;
            try
            {
                id = int.Parse(Request.QueryString["id"].ToString());
                SetData(id);
            }
            catch { }
        }
    }

    private void SetData(int id)
    {
        try
        {
            NV_QuyTrinhXuLy_ChiTiet model = Sys_Common.NV_QuyTrinhXuLy.GetById(id);
            txtTen.Text = model.Ten;
            hlFiledauvao.NavigateUrl = "/FileUpload/Document/" + model.TenFileDauVao;
            hlFiledauvao.Text = model.TenFileDauVao;
            txtNgayBatDau.Text = ((DateTime)model.NgayBatDau).ToString("d/M/yyyy");
            txtNguoiTiepNhan.Text = model.NguoiTiepNhan;
            txtTrangThai.Text = model.TrangThaiText;
            txtGhichu.Text = model.GhiChu;
            if (model.TrangThai == 4)
            {
                hlFileketqua.Hidden = false;
                txtNgayHoanThanh.Hidden = false;
                try
                {
                    txtNgayHoanThanh.Text = ((DateTime)model.NgayHoanThanh).ToString("d/M/yyyy");
                }
                catch { }
                hlFileketqua.NavigateUrl = "/FileUpload/Document/" + model.TenFileKQ;
                hlFileketqua.Text = model.TenFileKQ;
            }
            txtNguoiYeuCau.Text = model.NguoiYeuCau;
            txtEmail.Text = model.Email;
            txtSodienthoai.Text = model.SoDienThoai;
            txtDiachi.Text = model.DiaChi;
            txtThongtin.Text = model.ThongTin;
        }
        catch
        {
            X.Msg.AddScript("parent.hdMsg.setValue('error');");
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
    }
}