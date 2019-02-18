<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatVanBan.aspx.cs" Inherits="NghiepVu_Quanlyvanban_CapNhatVanBan" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>
<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/MapStyles.css" rel="stylesheet" />

    <link href="/css/other.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <div style="margin: 10px">
             <asp:ImageButton ID="btnUpdate" Text="Lưu lại" ImageUrl="/images/btnAdd.png" runat="server" CssClass="btnsave" OnClick="btnUpdate_Click"/>
            <ext:Panel ID="ViewPort1" Border="false" runat="server" Layout="FormLayout" LabelWidth="150" Padding="5">
                <Items>
                    <ext:Hidden runat="server" ID="hdID" />
                    <ext:TextField ID="txtTenVB" runat="server" FieldLabel="Tên văn bản" Margins="2" IndicatorText="*" Style="margin-top: 5px;" Width="750" />
                    <ext:ComboBox ID="cbLoaiVB" runat="server" FieldLabel="Loại văn bản" EmptyText="--Chọn loại văn bản--" DisplayField="TenLoaiVanBan" ValueField="LoaiVanBanID" IndicatorText="*"
                        Editable="false" Width="150">
                        <Store>
                            <ext:Store runat="server" ID="stLoaiVB">
                                <Reader>
                                    <ext:JsonReader IDProperty="LoaiVanBanID">
                                        <Fields>
                                            <ext:RecordField Name="LoaiVanBanID" />
                                            <ext:RecordField Name="TenLoaiVanBan" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                    <ext:TextField ID="txtDonViBanHanh" runat="server" FieldLabel="Đơn vị ban hành" Margins="2" IndicatorText="*" Style="margin-top: 5px;" Width="750" />

                    <ext:DateField ID="dtNgayBanHanh" runat="server" FieldLabel="Ngày ban hành" Width="150" />

                    <ext:Panel runat="server" Border="false" Cls="css1">
                        <Content>
                            <uc1:Document runat="server" ID="Document" LabelWidth="150" FieldLabel="Chọn file" Width="280" />
                        </Content>
                    </ext:Panel>
                    <ext:HtmlEditor ID="txtMoTa" runat="server" FieldLabel="Giới thiệu ấn phẩm, bài viết" Width="750" Height="100" />
                    <ext:HtmlEditor ID="txtNoidung" runat="server" FieldLabel="Nội dung" Width="750" Height="500" />
                </Items>
                <%--<TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>--%>
            </ext:Panel>

        </div>
    </form>
</body>
</html>
