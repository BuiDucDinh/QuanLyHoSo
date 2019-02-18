<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatDiVat.aspx.cs" ValidateRequest="false" Inherits="NghiepVu_Disanvanhoa_CapNhatDiVat" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>
<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>
<%@ Register Src="~/Control/Images/ImageMutil.ascx" TagPrefix="uc1" TagName="ImageMutil" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/Control/Video/Video.ascx" TagPrefix="uc1" TagName="Video" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };
        var checkIsMusiem = function (el) {
            if (el.checked) {
                var a = Ext.getCmp('cbNoiLuuTru');
                Ext.getCmp('cbNoiLuuTru').Show();
                Ext.getCmp('pnDiSan').Hide();
            }
            else {
                Ext.getCmp('cbNoiLuuTru').Show();
                Ext.getCmp('pnDiSan').Hide();
            }
        }
    </script>

    <script src="/Template/js/jquery-2.0.3.min.js"></script>
    <link href="/css/MapStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <div style="margin: 10px">
            <asp:ImageButton ID="btnUpdate" Text="Lưu lại" ImageUrl="/images/btnAdd.png" runat="server" CssClass="btnsave" OnClick="btnUpdate_Click" />
            <ext:Panel runat="server" Border="false" Padding="5">

                <Content>
                    <div style="width: 100%; float: left">
                        <ext:Panel runat="server" Title="Chọn thông tin ngôn ngữ" Border="true" Width="1000" LabelWidth="150" FormGroup="true">
                            <Items>
                                <ext:ComboBox ID="cbNgonNgu" runat="server" LabelWidth="120" Width="250" FieldLabel="Ngôn ngữ" SelectOnFocus="true">
                                    <Items>
                                        <ext:ListItem Text="Tiếng việt" Value="vi" />
                                        <ext:ListItem Text="Tiếng Anh" Value="en" />
                                    </Items>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                    </div>
                    <div style="width: 50%; float: left">
                        <ext:Panel runat="server" Title="Thông tin chung" Border="true" Width="500" LabelWidth="150" FormGroup="true">
                            <Items>
                                <ext:Hidden runat="server" ID="hdID" Style="margin-bottom: 5px;" />
                                <ext:TextField runat="server" ID="txtTen" FieldLabel="Tên hiện vật" Width="450" />
                                <ext:TextField runat="server" ID="txtTenKhac" FieldLabel="Tên gọi khác" Width="450" />
                                <ext:TextField runat="server" ID="txtMaSo" FieldLabel="Mã số" LabelWidth="150" Width="450" />
                                <ext:TextField runat="server" ID="txtNguongoc" FieldLabel="Nguồn gốc" Width="450" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Title="Cơ quan/Hội đồng thẩm đinh" Margins="5" LabelWidth="150" FormGroup="true">
                            <Items>
                                <ext:ComboBox ID="cbHoidong" runat="server" DisplayField="TenHoiDong" ValueField="ID"
                                    Width="450" EmptyText="--Chọn hội đồng thẩm định" IndicatorText="*" FieldLabel="Hội đồng thẩm định" Mode="Local">
                                    <Store>
                                        <ext:Store runat="server" ID="stHoidong">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="TenHoiDong" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                </ext:ComboBox>
                                <ext:DateField ID="txtNgaygiamdinh" Format="dd/MM/yyyy" runat="server" FieldLabel="Ngày giám định" Width="450" Margins="2" />
                                <ext:TextArea ID="txtGhichugiamdinh" runat="server" Width="450" FieldLabel="Ghi chú giám định" Margins="2" />
                            </Items>
                        </ext:Panel>

                        <ext:Panel runat="server" Title="Thời kỳ/Niên đại" Margins="5" LabelWidth="100" FormGroup="true">
                            <Items>
                                <ext:ComboBox ID="cbThoiky" runat="server" DisplayField="TenThoiKy" ValueField="ID"
                                    Width="450" EmptyText="--Chọn thời kỳ lịch sử" FieldLabel="Thời kỳ" Mode="Local">
                                    <Store>
                                        <ext:Store runat="server" ID="stThoiky">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="TenThoiKy" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                </ext:ComboBox>
                                <ext:TextField runat="server" ID="txtNiendai" FieldLabel="Niên đại" Width="450" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Title="Thông tin chủ sở hữu/Lưu trữ" FormGroup="true">
                            <Content>
                                <ext:Checkbox runat="server" ID="ckbIsMusiem" FieldLabel="Lưu trữ tại khu di sản" Checked="true">
                                    <Listeners>
                                        <AfterRender Handler="this.el.on('change', function (e, el) { if(el.checked){#{pnDiSan}.show();#{pnNoiLuuTru}.hide();}else {#{pnDiSan}.hide();#{pnNoiLuuTru}.show();}});" />
                                    </Listeners>
                                </ext:Checkbox>
                                <div style="clear: both"></div>
                                <ext:Panel runat="server" Border="false" ID="pnDiSan">
                                    <Items>
                                        <ext:ComboBox ID="cbDiSan" runat="server" DisplayField="TenDiSan" ValueField="DiSanID"
                                            Width="450" EmptyText="--Chọn khu di sản" FieldLabel="Khu di sản" Mode="Local">
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
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Border="false" ID="pnNoiLuuTru" Hidden="true">
                                    <Items>
                                        <ext:ComboBox ID="cbNoiluutru" runat="server" DisplayField="Ten" ValueField="ID"
                                            Width="450" EmptyText="--Chọn nơi lưu trữ" FieldLabel="Nơi lưu trữ" Mode="Local">
                                            <Store>
                                                <ext:Store runat="server" ID="stNoiluutru">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="Ten" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                        </ext:ComboBox>

                                        <ext:TextArea runat="server" ID="txtChusohuu" FieldLabel="Chủ sở hữu" Width="450" />
                                    </Items>
                                </ext:Panel>
                                <ext:TextArea runat="server" ID="txtThaydoichu" FieldLabel="Thay đổi chủ sở hữu" Width="450" />
                            </Content>
                        </ext:Panel>
                    </div>
                    <div style="width: 50%; float: left">
                        <ext:Panel runat="server" Title="Thông tin khảo cổ" LabelWidth="150" Padding="5" Margins="5" FormGroup="true">
                            <Items>
                                <ext:ComboBox ID="cbPhanloai" runat="server" LabelWidth="150" Width="450" FieldLabel="Phân loại" SelectOnFocus="true">
                                    <Items>
                                        <ext:ListItem Text="Di vật" Value="1" />
                                        <ext:ListItem Text="Cổ vật" Value="2" />
                                        <ext:ListItem Text="Bảo vật quốc gia" Value="3" />
                                    </Items>
                                </ext:ComboBox>
                                <ext:TextField runat="server" ID="txtDiaDiem" FieldLabel="Địa điểm phát hiện di vật" Width="450" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Title="Thông tin hiện vật" LabelWidth="150" Padding="5" FormGroup="true">
                            <Items>
                                <ext:NumberField runat="server" ID="txtSoluong" FieldLabel="Số lượng" Width="450" MinValue="1" />
                                <ext:TextArea ID="txtThanhphan" runat="server" FieldLabel="Thành phần hợp thành" Width="450" Margins="2" />
                                <ext:TextArea runat="server" ID="txtKichthuoc" FieldLabel="Kích thước, trọng lượng" Width="450" />
                                <ext:TextArea runat="server" ID="txtChatlieu" FieldLabel="Chất liệu" Width="450" />
                                <ext:TextField runat="server" ID="txtTinhtrang" FieldLabel="Tình trạng" Width="450" />
                                <ext:TextArea runat="server" ID="txtMieuta" FieldLabel="Miêu tả hiện vật" Width="450" />
                                <ext:TextArea runat="server" ID="txtDautich" FieldLabel="Dấu tích đặc biệt" Width="450" />
                            </Items>
                        </ext:Panel>
                    </div>
                    <div style="clear: both"></div>
                    <ext:Panel runat="server" FormGroup="true" Title="Hình ảnh/Video">
                        <Items>
                            <ext:Panel runat="server" Border="false">
                                <Content>
                                    <uc1:ImageOnly runat="server" ID="ImageOnly" FieldLabel="Chọn ảnh" LabelWidth="100" />
                                </Content>
                            </ext:Panel>

                            <ext:Panel runat="server" Border="false">
                                <Content>
                                    <uc1:ImageMutil runat="server" ID="ImageMutil" FieldLabel="Album ảnh" LabelWidth="100" Width="270" />
                                </Content>
                            </ext:Panel>
                            <ext:Panel runat="server" Border="false">
                                <Content>
                                    <uc1:Video runat="server" ID="Video" LabelWidth="100" FieldLabel="Chọn video" Width="270" />
                                </Content>
                            </ext:Panel>
                            <ext:Panel runat="server" Border="false">
                                <Content>
                                    <uc1:Document runat="server" ID="Document" Width="270" FieldLabel="Chọn tài liệu" LabelWidth="100" />
                                </Content>
                            </ext:Panel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Border="false" FormGroup="true">
                        <Content>
                            <table>
                                <tr>
                                    <td style="width: 150px; font-family: Tahoma; font-size: 12px;">Giới thiệu về hiện vật
                                    </td>
                                    <td>
                                        <FCKeditorV2:FCKeditor ID="txtGioithieu" runat="server" BasePath="~/fckeditor/" Height="500" Width="850"></FCKeditorV2:FCKeditor>
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </ext:Panel>
                </Content>
            </ext:Panel>
        </div>
    </form>
</body>
</html>
