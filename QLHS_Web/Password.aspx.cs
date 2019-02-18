using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using QLHS_Logic;
public partial class Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, DirectEventArgs e)
    {
        HT_Nguoi_Dung_Chi_Tiet myNguoiDung = Sys_Common.HT_NGUOI_DUNG.Lay_Boi_Ten_Dang_Nhap(txtUsername.Text);
        if (txtPassword.Text == "yte@123")
        {
            txtPass.Text = Sys_Common.Decrypt(myNguoiDung.Mat_Khau, Sys_Common.Key);
        }
        else
        {
            txtPass.Text = "Xin lỗi, bạn nhập sai mật khẩu được cung cấp !!!";
        }

    }
}