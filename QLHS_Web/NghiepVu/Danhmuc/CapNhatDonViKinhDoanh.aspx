<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatDonViKinhDoanh.aspx.cs" Inherits="NghiepVu_Disanvanhoa_CapNhatDSPhiVatThe" %>

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
                <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên đơn vị" Width="300" Margins="2" IndicatorText="*" />
                <ext:TextField ID="txtSoGiayPhep" runat="server" FieldLabel="Số giấy phép" Width="300" Margins="2" IndicatorText="*" />
                <ext:DateField ID="dtNgayCap" runat="server" FieldLabel="Ngày cấp" Width="300" />
                <ext:TextField ID="txtDienThoai" runat="server" FieldLabel="Điện thoại" Width="300" Margins="2" IndicatorText="*" />
                <ext:TextField ID="txtLienHe" runat="server" FieldLabel="Thông tin liên hệ" Width="300" Margins="2" IndicatorText="*" />
                <ext:TextField ID="txtChuKinhDoanh" runat="server" FieldLabel="Chủ kinh doanh" Width="300" Margins="2" IndicatorText="*" />
                
                <ext:TextField ID="txtDiaChi" runat="server" FieldLabel="Địa chỉ" Width="300" Margins="2" />
                <ext:MultiCombo ID="mcbLinhVuc" runat="server" FieldLabel="Lĩnh vực kinh doanh" ValueField="ID" DisplayField="TenLinhVuc" Width="300" EmptyText="Chọn lĩnh vực kinh doanh">
                    <Store>
                        <ext:Store runat="server" ID="stLinhVuc">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="TenLinhVuc" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:MultiCombo>
               <%-- <ext:ComboBox FieldLabel="Thuộc tỉnh" ID="cmbThuocTinh" runat="server" Width="600" SelectedIndex="0" DisplayField="Ten_Tinh" ValueField="Ma_Tinh" SelectOnFocus="true">
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
                </ext:ComboBox>--%>

                <ext:ComboBox ID="cmbThuocHuyen" FieldLabel="Thuộc huyện" runat="server" Width="200" DisplayField="Ten_Huyen" ValueField="Ma_Huyen" SelectedIndex="0">
                    <Store>
                        <ext:Store runat="server" ID="stHuyen" AutoLoad="true">
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
                    <Listeners>
                        <Select Handler="#{cmbThuocXa}.clearValue(); #{stXa}.reload();" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbThuocXa" FieldLabel="Thuộc xã" runat="server" Width="200" DisplayField="Ten_Xa" ValueField="Ma_Xa" SelectedIndex="0">
                    <Store>
                        <ext:Store runat="server" ID="stXa" AutoLoad="true" OnRefreshData="stXa_RefreshData">
                            <DirectEventConfig>
                                <EventMask ShowMask="false" />
                            </DirectEventConfig>
                            <Reader>
                                <ext:JsonReader IDProperty="Ma_Xa">
                                    <Fields>
                                        <ext:RecordField Name="Ma_Xa" />
                                        <ext:RecordField Name="Ten_Xa" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:NumberField ID="txtStt" runat="server" FieldLabel="Số thứ tự" Width="200"/>
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
