<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DonViKinhDoanh.aspx.cs" Inherits="NghiepVu_Danhmuc_LinhVucKinhDoanh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="odsData" runat="server" OnSelected="odsData_Selected" SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="Start" Type="Int32" />
                <asp:Parameter Name="Limit" Type="Int32" />
                <asp:Parameter Name="WhereString" Type="String" />
                <asp:Parameter Name="SortString" Type="String" />
                <asp:Parameter Direction="Output" Name="Count" Type="Int32" />
            </SelectParameters>

        </asp:ObjectDataSource>
        <!----Goi ung dung ext------>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="150" Padding="10">
            <Items>
                <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên đơn vị" Width="200" Margins="2" IndicatorText="*" />
                <ext:TextField ID="txtSoGiayPhep" runat="server" FieldLabel="Số giấy phép" Width="200" Margins="2" IndicatorText="*" />

                <ext:ComboBox ID="cmbLinhVuc" runat="server" FieldLabel="Lĩnh vực kinh doanh" ValueField="ID" DisplayField="TenLinhVuc" Width="350" EmptyText="Chọn lĩnh vực kinh doanh">
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
                </ext:ComboBox>
<%--                <ext:ComboBox FieldLabel="Thuộc tỉnh" ID="cmbThuocTinh" runat="server" Width="350" SelectedIndex="0" DisplayField="Ten_Tinh" ValueField="Ma_Tinh" SelectOnFocus="true">
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

                <ext:ComboBox ID="cmbThuocHuyen" FieldLabel="Thuộc huyện" runat="server" Width="350" DisplayField="Ten_Huyen" ValueField="Ma_Huyen" SelectedIndex="0">
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

                <ext:ComboBox ID="cmbThuocXa" FieldLabel="Thuộc xã" runat="server" Width="350" DisplayField="Ten_Xa" ValueField="Ma_Xa" SelectedIndex="0">
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

                <ext:GridPanel ID="gvData" runat="server" Title="" Margins="0 0 5 5" Header="false"
                    Icon="UserSuit" AutoHeight="true" AutoExpandColumn="TenDonVi">
                    <Store>
                        <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stData_RefreshData">
                            <AutoLoadParams>
                                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="Filter" Value="#{txtFilter}.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Proxy>
                                <ext:PageProxy />
                            </Proxy>
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="TenDonVi" />
                                        <ext:RecordField Name="SoGiayPhep" />
                                        <ext:RecordField Name="DienThoai" />
                                        <ext:RecordField Name="ChuKinhDoanh" />
                                        <ext:RecordField Name="LinhVucKD" />
                                        <ext:RecordField Name="DiaChi" />
                                        <ext:RecordField Name="Stt" SortDir="ASC" />

                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                            <SortInfo Field="Stt" Direction="ASC" />
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ColumnID="TenDonVi" DataIndex="TenDonVi" Header="Đơn vị kinh doanh" />
                            <ext:Column ColumnID="SoGiayPhep" DataIndex="SoGiayPhep" Header="Số giấy phép kinh doanh" Width="150" />
                            <ext:Column ColumnID="ChuKinhDoanh" DataIndex="ChuKinhDoanh" Header="Chủ đơn vị" Width="150" />
                            <ext:Column ColumnID="DienThoai" DataIndex="DienThoai" Header="Điện thoại" Width="150" />
                            <ext:Column ColumnID="LinhVucKD" DataIndex="LinhVucKD" Header="Lĩnh vực kinh doanh" Width="150" />
                            <ext:Column ColumnID="DiaChi" DataIndex="DiaChi" Header="Địa chỉ" Width="150" />
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel SingleSelect="false" runat="server">
                            <Listeners>
                                <RowSelect Handler="#{btnDelete}.enable();" />
                                <RowDeselect Handler="if (!#{gvData}.hasSelection()) {#{btnDelete}.disable();}" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <DirectEvents>
                        <DblClick OnEvent="gvData_DbClick">
                        </DblClick>
                    </DirectEvents>
                    <BottomBar>
                        <ext:PagingToolbar ID="pageData" runat="server" PageSize="30" DisplayInfo="true"
                            DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                    </BottomBar>
                    <LoadMask ShowMask="true" />
                </ext:GridPanel>

            </Items>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="btnCancel" Text="Hủy" Icon="BulletMinus" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnCancel_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="btnDelete" Text="Xóa" Icon="BulletCross" runat="server" Disabled="true">
                            <DirectEvents>
                                <Click OnEvent="btnDelete_Click">
                                    <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="btnExport" runat="server" Text="Xuất báo cáo" Icon="Report">
                            <DirectEvents>
                                <Click OnEvent="btnExport_Click" IsUpload="true" Before="ExportYap()">
                                    <ExtraParams>
                                        <ext:Parameter Name="data" Value="#{gridData}.getRowsValues()" Mode="Raw" Encode="true" />
                                        <ext:Parameter Name="format" Value="xls" Mode="Value" />
                                    </ExtraParams>
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Hidden ID="txtFilter" runat="server" AutoDataBind="true">
                            <Listeners>
                                <Change Handler="#{pageData}.changePage(1);" Delay="30" />
                            </Listeners>
                        </ext:Hidden>
                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                        <ext:TriggerField ID="txtSearch" runat="server" Width="250" EmptyText="Tìm kiếm">
                            <Triggers>
                                <ext:FieldTrigger Icon="Search" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="#{txtFilter}.setValue(this.getValue()); " />
                            </Listeners>
                        </ext:TriggerField>
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
        <ext:Panel runat="server">
            <Items>
                <ext:Window runat="server" ID="wdDetail" Hidden="true"
                    DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
                    MinWidth="900" Height="550" Modal="true" Padding="3" Resizable="false">
                    <Listeners>
                        <Hide Handler="if(hdMsg.getValue()=='ok'){#{stData}.reload();hdMsg.setValue('');alert('Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg" />
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
