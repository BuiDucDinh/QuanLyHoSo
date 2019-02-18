<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatDanhMucDuong.aspx.cs" Inherits="NghiepVu_Disanvanhoa_CapNhatDSPhiVatThe" %>

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
        <!----Goi ung dung ext------>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Panel ID="ViewPort1" Padding="10" runat="server" Layout="FormLayout" AutoScroll="true" LabelWidth="150" EnableTheming="false">
            <Content>
                <ext:Hidden runat="server" ID="hdID" Style="margin-bottom: 5px;" />
                <ext:TextField ID="txtTenDuong" runat="server" FieldLabel="Tên đường" Width="350" AllowBlank="false" Margins="2" IndicatorText="*" />
                <ext:TextField runat="server" ID="txtSoHieu" FieldLabel="Số hiệu đường bộ" Width="350" />
                <ext:ComboBox FieldLabel="Thuộc tỉnh" ID="cmbThuocTinh" runat="server" Width="300" SelectedIndex="0" IndicatorText="*" DisplayField="Ten_Tinh" ValueField="Ma_Tinh" SelectOnFocus="true">
                    <Store>
                        <ext:Store runat="server" ID="stTinh" AutoLoad="true">
                            <DirectEventConfig>
                                <EventMask ShowMask="false" />
                            </DirectEventConfig>
                            <Reader>
                                <ext:JsonReader IDProperty="Ma_Tinh">
                                    <Fields>
                                        <ext:RecordField Name="Ma_Tinh" />
                                        <ext:RecordField Name="Ten_Tinh" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Listeners>
                        <Select Handler="#{cmbThuocHuyen}.clearValue(); #{stHuyen}.reload()" />
                    </Listeners>
                </ext:ComboBox>

                <ext:ComboBox ID="cmbThuocHuyen" FieldLabel="Thuộc huyện" runat="server" Width="300" DisplayField="Ten_Huyen" ValueField="Ma_Huyen" SelectedIndex="0">
                    <Store>
                        <ext:Store runat="server" ID="stHuyen" AutoLoad="true" OnRefreshData="stHuyen_RefreshData">
                            <DirectEventConfig>
                                <EventMask ShowMask="false" />
                            </DirectEventConfig>
                            <Reader>
                                <ext:JsonReader IDProperty="Ma_Huyen">
                                    <Fields>
                                        <ext:RecordField Name="Ma_Huyen" />
                                        <ext:RecordField Name="Ten_Huyen" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:TextField runat="server" ID="txtChieuDai" FieldLabel="Chiều dài" Width="350" />
                <ext:TextField ID="txtDiemDau" runat="server" FieldLabel="Điểm đầu" Width="350" />
                <ext:TextField runat="server" ID="txtDiemCuoi" FieldLabel="Điểm cuối" Width="350" />
                <ext:TextArea runat="server" ID="txtMatDuong" FieldLabel="Mặt đường" Width="650" />
                <ext:HtmlEditor runat="server" ID="txtQuyetDinh" FieldLabel="Quyết định đặt tên đường" Width="650" />
                <ext:TextField runat="server" ID="txtDanhNhan" FieldLabel="Đặt tên theo danh nhân" Width="350"/>
                <ext:HtmlEditor runat="server" ID="txtTieuSu" FieldLabel="Tiểu sử của danh nhân" Width="650"/>
                <ext:HtmlEditor runat="server" ID="txtThayDoi" FieldLabel="Thay đổi về tên đường" Width="650" />
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
