<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_NguoiDungCapNhat.aspx.cs" Inherits="HT_HT_NguoiDungCapNhat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager id="ResourceManager1" runat="server" />
	
    <ext:Panel id="pnlHT_Nguoi_Dung" runat="server" layout="FormLayout" labelwidth="120">
        <Items>            
			
			<ext:NumberField ID="txtMa_Don_Vi" runat="server" FieldLabel="Mã đơn vị" Width="100" AllowDecimals="false" Hidden="true" />		
			<ext:TextField ID="txtTen_Dang_Nhap" runat="server" FieldLabel="Tên đăng nhập" Width="250" Disabled="true" />		
			<ext:TextField ID="txtMat_Khau" runat="server" FieldLabel="Mật khẩu" Width="250" InputType="Password" />		
			<ext:TextField ID="txtHo_Ten" runat="server" FieldLabel="Họ và tên" Width="250" />		
			<ext:TextField ID="txtHom_Thu" runat="server" FieldLabel="Hộp thư" Width="250" />		
			<ext:TextField ID="txtDien_Thoai" runat="server" FieldLabel="Điện thoại" Width="250" />		
			<ext:Checkbox ID="chkDuoc_Kich_Hoat" runat="server" FieldLabel="Được kích hoạt" Hidden="true"/>		
			<ext:ComboBox ID="cboHinh_Nen" runat="server" FieldLabel="Giao diện" EmptyText="--Chọn giao diện--"
                Editable="false" Width="150">
                <Items>
                    <ext:ListItem Text="Mặc định" Value="1" />
                    <ext:ListItem Text="Xám trắng" Value="2" />
                    <ext:ListItem Text="Xám đen" Value="3" />
                    <ext:ListItem Text="Tím đen" Value="4" />
                </Items>
            </ext:ComboBox>	
			
        </Items>
        <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
            <Items>
                <ext:Button ID="btnUpdate" runat="server" Text="Cập nhật" Icon="ApplicationFormEdit">
                    <DirectEvents>
                        <Click OnEvent="btnUpdate_Click">
                        <EventMask ShowMask="true" MinDelay="100" Msg="Xin vui lòng chờ đợi !!!" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                
			</Items>
        	</ext:Toolbar>
        </TopBar>
	</ext:Panel>
	
	</form>
</body>
</html>
