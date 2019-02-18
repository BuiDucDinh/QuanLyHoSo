<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="FrmLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CÔNG TY TNHH TM VÀ PHÁT TRIỂN CÔNG NGHỆ PHẦN MỀM TCSOFT</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body style="background: url(/images/161020_background.jpg); background-size: 100% 100%">
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <div id="wrapper">
            <div id="bg_login">
                <p>
                    <label>Tên đăng nhập:</label>
                    <input class="user" type="text" id="txtTen_Dang_Nhap" runat="server" />
                </p>
                <p>
                    <label>Mật khẩu:</label>
                    <input class="pass" type="password" id="txtMat_Khau" runat="server" />
                </p>
                <p>
                    <asp:Button ID="btnLogin" runat="server" class="submit" OnClick="btnLogin_Click"
                        Text="Đăng nhập" />

                    <asp:Button ID="btnCancel" runat="server" class="cancel" OnClick="btnCancel_Click"
                        Text="Hủy" />

                </p>
            </div>
            <div class="banquyen">
                <p align="center">
                    © Bản quyền thuộc : TCSOFT</br>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
