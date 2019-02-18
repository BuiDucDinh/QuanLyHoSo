using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
public partial class HT_HT_NguoiDungCapNhat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["G_Theme"] != null)
            {
                DHM_Common.SetTheme(this.Page, int.Parse(Session["G_Theme"].ToString()));
            }
            ClearData();
            if (Session["G_Ma_Nguoi_Dung"] != null)
            {
                HT_Nguoi_Dung_Chi_Tiet myDetail = Sys_Common.HT_NGUOI_DUNG.Lay(int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()));
                SetData(myDetail);
            }
        }
    }
    private void SetData(HT_Nguoi_Dung_Chi_Tiet myDetail)
    {
        btnUpdate.Text = "Cập nhật";
        btnUpdate.Icon = Icon.ApplicationEdit;
        
        txtMa_Don_Vi.Text = myDetail.Ma_Don_Vi.ToString();
        txtTen_Dang_Nhap.Text = myDetail.Ten_Dang_Nhap;
        txtMat_Khau.Text = Sys_Common.Decrypt(myDetail.Mat_Khau,Sys_Common.Key);
        txtHo_Ten.Text = myDetail.Ho_Ten;
        txtHom_Thu.Text = myDetail.Hom_Thu;
        txtDien_Thoai.Text = myDetail.Dien_Thoai;
        chkDuoc_Kich_Hoat.Checked = myDetail.Duoc_Kich_Hoat;
        cboHinh_Nen.Value = myDetail.Hinh_Nen.ToString();
    }
    private void ClearData()
    {
        btnUpdate.Text = "Thêm mới";
        btnUpdate.Icon = Icon.Add;
        
        txtMa_Don_Vi.Text = null;
        txtTen_Dang_Nhap.Text = "";
        txtMat_Khau.Text = "";
        txtHo_Ten.Text = null;
        txtHom_Thu.Text = null;
        txtDien_Thoai.Text = null;
        chkDuoc_Kich_Hoat.Checked = false;
        cboHinh_Nen.Value = "1";
    }
    protected void btnUpdate_Click(object sender, DirectEventArgs e)
    {
        if (FormValidate())
        {
            if (Session["G_Ma_Nguoi_Dung"] != null)
            {
                HT_Nguoi_Dung_Chi_Tiet myDetail = Sys_Common.HT_NGUOI_DUNG.Lay(int.Parse(Session["G_Ma_Nguoi_Dung"].ToString()));
                myDetail.Hinh_Nen = int.Parse(cboHinh_Nen.Value.ToString());
                myDetail.Dien_Thoai = txtDien_Thoai.Text;
                myDetail.Ho_Ten = txtHo_Ten.Text;
                myDetail.Hom_Thu = txtHom_Thu.Text;
                myDetail.Mat_Khau = Sys_Common.Encrypt(txtMat_Khau.Text.Trim(), Sys_Common.Key);
                Sys_Common.HT_NGUOI_DUNG.Cap_Nhat(myDetail);
            }
            
            X.Msg.Alert("Thông báo", "Đã cập nhật thành công !!!", new JFunction { Fn = "" }).Show();
            
        }
    }
    
    private bool FormValidate()
    {
        
        
       
        if (this.txtMat_Khau.Text.ToString() == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin Mật khẩu", "#{txtMat_Khau}.focus();").Show();
            return false;
        }
        if (this.txtHo_Ten.Text.ToString() == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin Họ và tên", "#{txtHo_Ten}.focus();").Show();
            return false;
        }
        if (this.txtHom_Thu.Text.ToString() == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin Hộp thư", "#{txtHom_Thu}.focus();").Show();
            return false;
        }
        if (this.txtDien_Thoai.Text.ToString() == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin Điện thoại", "#{txtDien_Thoai}.focus();").Show();
            return false;
        }

        if (this.cboHinh_Nen.Text.ToString() == "")
        {
            X.Msg.Alert("Thông báo", "Thiếu thông tin Hình nền", "#{txtHinh_Nen}.focus();").Show();
            return false;
        }
        return true;
    }
    
}