<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatQuyTrinhXuLy.aspx.cs" Inherits="NghiepVu_QuyTrinh_CapNhatQuyTrinhXuLy" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(200);
        };
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Panel ID="ViewPort1" Padding="10" runat="server" Layout="FormLayout" AutoScroll="true" LabelWidth="150" EnableTheming="false">
            <Content>
                <ext:TextField runat="server" ID="hdID" Disabled="true" Hidden="true" ReadOnly="true" />
                <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên hồ sơ" Width="600" IndicatorText="*" AllowBlank="false" />
                <ext:ComboBox ID="cbQuyTrinhDN" runat="server" FieldLabel="Chọn thủ tục" Width="600" EmptyText="--Chọn thủ tục" Mode="Local"
                    Editable="false"
                    DisplayField="TenLoai"
                    ValueField="ID"
                    TypeAhead="true"
                    ForceSelection="true"
                    Resizable="true" SelectedIndex="0"
                    SelectOnFocus="true">
                    <Store>
                        <ext:Store runat="server" ID="stQuyTrinhDN">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="TenLoai" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:TextField ID="txtNguoiTao" runat="server" FieldLabel="Người tạo" Width="600" IndicatorText="*" Disabled="true" />
                <ext:DateField runat="server" ID="dtNgayBatDau" FieldLabel="Ngày tạo" Width="600" Format="d/M/yyyy" Disabled="true" />

                <ext:Panel runat="server" Border="false">
                    <Content>
                        <uc1:Document runat="server" ID="Document" FieldLabel="Hồ sơ liên quan" Disabled="false" />
                    </Content>
                </ext:Panel>

                <ext:ComboBox ID="cbTrangThai" runat="server" FieldLabel="Trạng thái" Width="600" EmptyText="--Chọn trạng thái" Mode="Local"
                    Editable="false" Disabled="true"
                    DisplayField="Ten"
                    ValueField="ID"
                    TypeAhead="true"
                    ForceSelection="true"
                    Resizable="true" SelectedIndex="0"
                    SelectOnFocus="true">
                    <Store>
                        <ext:Store runat="server" ID="stTrangthai">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="Ten" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:HtmlEditor ID="txtGhiChu" runat="server" FieldLabel="Ghi chú" Width="600" />
                <ext:Panel runat="server" ID="pnNguoiYeuCau" Title="Thông tin người yêu cầu" Padding="10">
                    <Items>
                        <ext:TextField ID="txtNguoiYeuCau" runat="server" FieldLabel="Tên" Width="600" AllowBlank="false" IndicatorText="*" />
                        <ext:TextField ID="txtEmail" runat="server" FieldLabel="Email" Width="600" />
                        <ext:TextField ID="txtSoDienThoai" runat="server" FieldLabel="Số điện thoại" Width="600" />
                        <ext:TextField ID="txtDiaChi" runat="server" FieldLabel="Địa chỉ" Width="600" />
                        <ext:HtmlEditor ID="txtThongTin" runat="server" FieldLabel="Thông tin khác" Width="600" />
                    </Items>
                </ext:Panel>
            </Content>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Lưu lại" Icon="DatabaseSave" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
    </form>
</body>
</html>

