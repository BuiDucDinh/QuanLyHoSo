<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatDonViTuBo.aspx.cs" Inherits="NghiepVu_Duantubo_CapNhatDonViTuBo" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="ViewPort2" runat="server" Layout="FormLayout" Padding="10" Height="">
            <Content>
                <ext:Hidden runat="server" ID="hdDonViID" />
                <ext:TextField ID="txtTenCongTy" runat="server" FieldLabel="Tên công ty"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtNguoiDaiDien" runat="server" FieldLabel="Người đại diện"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtDiaChi" runat="server" FieldLabel="Địa chỉ"
                    AnchorHorizontal="95%" />
                <ext:TextField ID="txtDienThoai" runat="server" FieldLabel="Điện thoại"
                    AnchorHorizontal="95%" />
                <ext:ComboBox ID="cbCapDonVi" runat="server" FieldLabel="Cấp đơn vị" AnchorHorizontal="95%"
                    EmptyText="--Cấp đơn vị--" AllowBlank="true" SelectedIndex="0">
                    <Items>
                        <ext:ListItem Value="0" Text="Cấp địa phương" />
                        <ext:ListItem Value="1" Text="Cấp tỉnh" />
                        <ext:ListItem Value="2" Text="Cấp nhà nước" />
                    </Items>
                </ext:ComboBox>

                <ext:TextField ID="txtChungChi" runat="server" FieldLabel="Chứng chỉ hành nghề"
                    AnchorHorizontal="95%" />
                <ext:TextArea ID="txtGhichu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="95%" />
                <ext:Panel runat="server" Border="false">
                    <Content>
                        <uc1:Document runat="server" ID="Document"/>
                    </Content>
                </ext:Panel>
            </Content>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click">
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
