<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatQuyTrinhDinhNghia.aspx.cs" Inherits="DT_QuyTrinh_CapNhatQuyTrinhDinhNghia" %>

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
                <ext:Hidden runat="server" ID="hdID" />
                <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên quy trình" Width="600" IndicatorText="*" AllowBlank="false" />
                <ext:ComboBox ID="cbLoaiQuyTrinh" runat="server" FieldLabel="Loại quy trình, thủ tục" Width="600" EmptyText="--Chọn quy trình" Mode="Local"
                    Editable="false"
                    DisplayField="TenLoai"
                    ValueField="ID"
                    TypeAhead="true"
                    ForceSelection="true"
                    Resizable="true" SelectedIndex="0"
                    SelectOnFocus="true">
                    <Store>
                        <ext:Store runat="server" ID="stLoaiQuyTrinh">
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
                <ext:Checkbox runat="server" ID="ckbTrangThai" FieldLabel="Trạng thái sử dụng">
                    <Listeners>
                        <Check Handler="if(this.getValue()==true){#{lbThongbao}.setText('Các hồ sơ đang được xử lý liên quan đến loại thủ tục này vẫn sẽ được sử lý theo quy trình được sử dụng trước đó');}else{#{lbThongbao}.setText('');}" />
                    </Listeners>
                </ext:Checkbox>
                <ext:Label runat="server" ID="lbThongbao" />
                <ext:TextField ID="txtNguoiTao" runat="server" FieldLabel="Người tạo" Width="600" IndicatorText="*" Disabled="true" />
                <ext:DateField runat="server" ID="dtNgayTao" FieldLabel="Ngày tạo" Width="600" Format="d/M/yyyy" Disabled="true" />
                <ext:DateField runat="server" ID="dtNgayHieuLuc" FieldLabel="Ngày hiệu lực" Width="600" Format="d/M/yyyy" Disabled="true" />
                <ext:HtmlEditor runat="server" ID="txtChuanBi" FieldLabel="Chuẩn bị hồ sơ" Width="600" />
                <ext:HtmlEditor runat="server" ID="txtTrinhtu" FieldLabel="Trình tự giải quyết" Width="600" />
                <ext:TextField ID="txtCachthuc" runat="server" FieldLabel="Cách thức thực hiện" Width="600" />
                <ext:TextField ID="txtThoiHan" runat="server" FieldLabel="Thời hạn giải quyết" Width="600" />
                <ext:ComboBox runat="server" ID="cbDoituong" FieldLabel="Đối tượng thực hiện" Width="600" SelectedIndex="0">
                    <Items>
                        <ext:ListItem Value="Tổ chức" Text="Tổ chức" />
                        <ext:ListItem Value="Cá nhân" Text="Cá nhân"/>
                    </Items>
                </ext:ComboBox>
                <ext:ComboBox ID="cbCoQuan" runat="server" FieldLabel="Cơ quan thực hiện" Width="600" EmptyText="--Chọn cơ quan thực hiện--"
                    Editable="false"
                    DisplayField="TenCoQuan"
                    ValueField="CoQuanID"
                    TypeAhead="true"
                    ForceSelection="true"
                    Resizable="true"
                    SelectOnFocus="true">
                    <Store>
                        <ext:Store runat="server" ID="stCoQuan">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="CoQuanID" />
                                        <ext:RecordField Name="TenCoQuan" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:TextField ID="txtKetQua" runat="server" FieldLabel="Kết quả thực hiện" Width="600" />
                <ext:TextArea runat="server" ID="txtYeucau" FieldLabel="Yêu cầu, điều kiện để thực hiện" Width="600" Height="150" />
                <ext:TextField ID="txtLePhi" runat="server" FieldLabel="Lệ phí (nếu có)" Width="600" />
                <ext:HtmlEditor runat="server" ID="txtMauDon" FieldLabel="Mẫu đơn, tờ khai (nếu có)" Width="600" />
                <ext:HtmlEditor runat="server" ID="txtPhapLy" FieldLabel="Căn cứ pháp lý" Width="600" />

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

