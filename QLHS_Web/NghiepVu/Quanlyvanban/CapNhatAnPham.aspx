<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatAnPham.aspx.cs" Inherits="NghiepVu_Quanlyvanban_CapNhatDSBaiViet" %>

<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>
<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/css/other.css" rel="stylesheet" />
    <link href="/css/MapStyles.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <div style="margin: 10px;">
            <asp:ImageButton ID="btnUpdate" Text="Lưu lại" ImageUrl="/images/btnAdd.png" runat="server" CssClass="btnsave" OnClick="btnUpdate_Click"/>
            <ext:Panel ID="ViewPort1" runat="server" Border="false" Layout="FormLayout" LabelWidth="150" Padding="10">
                <Content>
                    <ext:Hidden runat="server" ID="hdID" />
                      <ext:ComboBox runat="server" ID="cmbLang" FieldLabel="Ngôn ngữ" SelectedIndex="0" Width="350">
                            <Items>
                                <ext:ListItem Text="Tiếng việt" Value="vi" />
                                <ext:ListItem Text="Tiếng anh" Value="en" />
                            </Items>

                        </ext:ComboBox>

                    <ext:TextField runat="server" ID="txtMaanpham" FieldLabel="Mã ấn phẩm" Width="350" AllowBlank="false" Margins="2" IndicatorText="*" />

                    <ext:TextField runat="server" ID="txtTenanpham" FieldLabel="Tên ấn phẩm" Width="350" AllowBlank="false" Margins="2" IndicatorText="*" />

                    <ext:ComboBox ID="cbDanhMuc" runat="server" FieldLabel="Danh mục" EmptyText="--Chọn danh mục--" DisplayField="TenDanhMuc" ValueField="DanhMucID"
                        Editable="false" Width="350">
                        <Store>
                            <ext:Store runat="server" ID="stDanhMuc">
                                <Reader>
                                    <ext:JsonReader IDProperty="DanhMucID">
                                        <Fields>
                                            <ext:RecordField Name="DanhMucID" />
                                            <ext:RecordField Name="TenDanhMuc" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                    <ext:TextField runat="server" ID="txtTacgia" FieldLabel="Tác giả" Width="350" AllowBlank="false" Margins="2" />


                    <ext:ComboBox ID="cbDiSan" runat="server" FieldLabel="Di sản" EmptyText="--Chọn di sản--" DisplayField="TenDiSan" ValueField="DiSanID"
                        Editable="false" Width="350">
                        <Store>
                            <ext:Store runat="server" ID="stDiSan">
                                <Reader>
                                    <ext:JsonReader IDProperty="DiSanID">
                                        <Fields>
                                            <ext:RecordField Name="DiSanID" />
                                            <ext:RecordField Name="TenDiSan" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                    <ext:NumberField ID="txtSoTrang" runat="server" FieldLabel="Số trang" Margins="2" AllowDecimals="false" AllowNegative="false" />

                    <ext:ComboBox ID="cbNamXB" runat="server" FieldLabel="Năm xuất bản" DisplayField="Nam" ValueField="Nam"
                        Width="150" EmptyText="--Chọn năm xuất bản--" AllowBlank="true" SelectedIndex="0">
                        <Store>
                            <ext:Store runat="server" ID="stNamXB">
                                <Reader>
                                    <ext:ArrayReader>
                                        <Fields>
                                            <ext:RecordField Name="Nam" />
                                        </Fields>
                                    </ext:ArrayReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                    <ext:TextField runat="server" ID="txtNhaXuatBan" FieldLabel="Nhà xuất bản" Width="350" />

                    <ext:TextField runat="server" ID="txtKichco" FieldLabel="Kích cỡ" Width="350" />

                    <ext:Panel runat="server" Border="false">
                        <Content>
                            <uc1:ImageOnly runat="server" ID="ImageOnly" LabelWidth="150" FieldLabel="Chọn ảnh" Width="280" />
                        </Content>
                    </ext:Panel>
                    <ext:Panel runat="server" Border="false">
                        <Content>
                            <uc1:Document runat="server" ID="Document" LabelWidth="150" FieldLabel="Chọn tài liệu" Width="280" />
                        </Content>
                    </ext:Panel>
                    <FCKeditorV2:FCKeditor runat="server" ID="fckNoidung" BasePath="~/fckeditor/" Width="860" Height="400" />
                    <ext:HtmlEditor ID="txtGioithieu" runat="server" FieldLabel="Giới thiệu về ấn phẩm" Width="700" Height="100" />
                    <ext:HtmlEditor ID="txtTomtat" runat="server" FieldLabel="Tóm tắt nội dung" Width="700" Height="500" />

                </Content>
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
