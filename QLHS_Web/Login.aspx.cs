using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLHS_Logic;
using Ext.Net;
using System.Data;
public partial class FrmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void CheckLogin()
    {
        HT_Nguoi_Dung_Chi_Tiet nguoi_Dung_Chi_Tiet;
        nguoi_Dung_Chi_Tiet = Sys_Common.HT_NGUOI_DUNG.Lay_Boi_Mat_Khau(txtTen_Dang_Nhap.Value, Sys_Common.Encrypt(txtMat_Khau.Value, Sys_Common.Key));
        if (nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung == 0)
        {
            X.Msg.Alert("Thông báo", "Tên đăng nhập và mật khẩu không đúng !!!", new JFunction { Fn = "" }).Show();
        }
        else
        {
            if (!nguoi_Dung_Chi_Tiet.Duoc_Kich_Hoat)
            {
                X.Msg.Alert("Thông báo", "Người dùng này không có hiệu lực !!!", new JFunction { Fn = "" }).Show();
                return;
            }
            Session["G_Ma_Nguoi_Dung"] = nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung.ToString();
            Session["G_Ten_Nguoi_Dung"] = nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap.ToString().ToUpper();
            Session["G_Theme"] = nguoi_Dung_Chi_Tiet.Hinh_Nen.ToString();
            //Session["G_Ma_Du_An"] = cboDu_An.Value.ToString();
            Session["G_Ma_Don_Vi"] = nguoi_Dung_Chi_Tiet.Ma_Don_Vi;

            //Lấy thông tin Tuyến, Loại hình,Tên đơn vị
            //HT_Don_Vi_YT_Chi_Tiet myDon_Vi = Sys_Common.HT_DON_VI_YT.Lay(nguoi_Dung_Chi_Tiet.Ma_Don_Vi);
            //Session["G_Ma_Tuyen"] = myDon_Vi.Tuyen;
            //Session["G_Tuyen"] = myDon_Vi.Tuyen;

            //Session["G_Ma_Tinh"] = myDon_Vi.Ma_Tinh;
            //Session["G_Ma_Huyen"] = myDon_Vi.Ma_Huyen;
            //Session["G_Ma_Xa"] = myDon_Vi.Ma_Xa;
            //Session["G_Ma_Loai_Hinh"] = myDon_Vi.Loai_Hinh;
            //Session["G_Loai_Hinh"] = myDon_Vi.Loai_Hinh;
            //Session["G_Thanh_Phan"] = myDon_Vi.Thanh_Phan;

            //nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap = nguoi_Dung_Chi_Tiet.Ten_Dang_Nhap.ToUpper();
            //Sys_Common.HT_NGUOI_DUNG.Cap_Nhat(nguoi_Dung_Chi_Tiet);

            Session["GIsLogin"] = "OK";
            Sys_Common.HT_NGUOI_DUNG_DANG_NHAP.Them(0, nguoi_Dung_Chi_Tiet.Ma_Nguoi_Dung, DateTime.Now, "LG");
            //Response.Redirect("Default.aspx");
            DataTable myTable = Sys_Common.RunTableBySQL("SELECT Ma_Du_An, Ten_Du_An, Icon FROM HT_Du_An WHERE Ma_Du_An IN (SELECT Ma_Du_An FROM HT_Vai_Tro_Du_An WHERE Ma_Vai_Tro IN (SELECT Ma_Vai_Tro FROM HT_Nguoi_Dung_Vai_Tro WHERE Ma_Nguoi_Dung = " + Session["G_Ma_Nguoi_Dung"].ToString() + ")) UNION SELECT 'XX',N'Thoát','./images/Thoat.png' ORDER BY Ma_Du_An");
            if (myTable.Rows.Count == 2)
            {
                Session["G_Ma_Du_An"] = myTable.Rows[0]["Ma_Du_An"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
                Response.Redirect("Module.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        CheckLogin();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtTen_Dang_Nhap.Value = "";
        txtMat_Khau.Value = "";
    }
}