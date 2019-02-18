using Ext.Net;
using QLHS_Logic;
using QLHS_Logic.NV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NghiepVu_Duantubo_CapNhatDonViTuBo : System.Web.UI.Page
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
            if (id != "")
            {
                SetData(Sys_Common.NV_DonViTuBo.GetById(int.Parse(id)));
            }
            else
            {
                ClearData();
            }
        }
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            NV_DonViTuBo_ChiTiet model = new NV_DonViTuBo_ChiTiet();
            model.TenDonVi = txtTenCongTy.Text;
            model.NguoiDaiDien = txtNguoiDaiDien.Text;
            model.DiaChi = txtDiaChi.Text;
            model.SoDienThoai = txtDienThoai.Text;
            model.GhiChu = txtGhichu.Text;
            model.CapDonVi = int.Parse(cbCapDonVi.Value.ToString());
            model.ChungChihanhNghe = txtChungChi.Text;
            model.File = Document.DocumentID;
            if (hdDonViID.Text != "")
            {
                model.DonViID = int.Parse(hdDonViID.Text);
                Sys_Common.NV_DonViTuBo.update(model);
            }
            else
            {
                int id = 0;
                Sys_Common.NV_DonViTuBo.them(model, out id);
            }
            ClearData();
            X.Msg.AddScript("parent.hdMsg.setValue('ok');");
            X.Msg.AddScript("parentAutoLoadControl.hide();");
        }
    }
    private bool FormValidate()
    {
        if (string.IsNullOrEmpty(txtTenCongTy.Text.Trim()))
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin ", new JFunction { Fn = "" }).Show();
            return false;
        }
        return true;
    }
    private void SetData(NV_DonViTuBo_ChiTiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;

        txtTenCongTy.Value = myDetail.TenDonVi;
        txtNguoiDaiDien.Value = myDetail.NguoiDaiDien;
        txtDiaChi.Value = myDetail.DiaChi;
        txtDienThoai.Value = myDetail.SoDienThoai;
        txtGhichu.Value = myDetail.GhiChu;
        hdDonViID.Value = myDetail.DonViID;
        cbCapDonVi.Value = myDetail.CapDonVi;
        txtChungChi.Value = myDetail.ChungChihanhNghe;
        Document.DocumentID = myDetail.File;
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;
        txtTenCongTy.Value = "";
        txtNguoiDaiDien.Value = "";
        txtDiaChi.Value = "";
        txtDienThoai.Value = "";
        txtGhichu.Value = "";
        hdDonViID.Value = "";
        cbCapDonVi.Value = "";
        txtChungChi.Value = "";
        Document.DocumentID = "0";
    }
}