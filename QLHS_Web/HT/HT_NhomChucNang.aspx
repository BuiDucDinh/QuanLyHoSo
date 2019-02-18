<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_NhomChucNang.aspx.cs"
    Inherits="HT_HT_NhomChucNang" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<script type="text/javascript">
    var sexRenderer = function (value) {
        return (value == true ? 'Nam' : 'Nữ');
    };
</script>
<script type="text/javascript">
    var ExportYap = function () {
        Ext.net.Mask.show();
        Ext.net.Mask.hide.defer(500);
    };
</script>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <asp:ObjectDataSource ID="odsNhomChucNang" runat="server" OnSelected="odsNhomChucNang_Selected" SelectMethod="Page_By_Filter"
        TypeName="QLHS_Logic.Sys_Common">
        <SelectParameters>
            <asp:Parameter Name="Start" Type="Int32" />
            <asp:Parameter Name="Limit" Type="Int32" />
            <asp:Parameter Name="WhereString" />
            <asp:Parameter Name="SortString" />
            <asp:Parameter Name="Count" Direction="Output" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsChucNang" runat="server" OnSelected="odsChucNang_Selected" SelectMethod="Page_By_Filter"
        TypeName="QLHS_Logic.Sys_Common">
        <SelectParameters>
            <asp:Parameter Name="Start" Type="Int32" />
            <asp:Parameter Name="Limit" Type="Int32" />
            <asp:Parameter Name="WhereString" />
            <asp:Parameter Name="SortString" />
            <asp:Parameter Name="Count" Direction="Output" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="150">
        <Items>
            <ext:ComboBox ID="cboMa_Du_An" runat="server" FieldLabel="Dự án" Width="350" EmptyText="--Chọn dự án--"
                DisplayField="Ten_Du_An" ValueField="Ma_Du_An" Mode="Local">
                <Store>
                    <ext:Store ID="dsDu_An" runat="server">
                        <Reader>
                            <ext:JsonReader>
                                <Fields>
                                    <ext:RecordField Name="Ma_Du_An" />
                                    <ext:RecordField Name="Ten_Du_An" SortDir="ASC" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <DirectEvents>
                    <Select OnEvent="cboMa_Du_An_Click" />
                </DirectEvents>
            </ext:ComboBox>
            <ext:TextField ID="txtMa_Nhom_Chuc_Nang" FieldLabel="Mã nhóm chức năng" runat="server"
                Width="350" />
            <ext:TextField ID="txtTen_Nhom_Chuc_Nang" runat="server" FieldLabel="Tên nhóm chức năng"
                Width="350" Margins="2" IndicatorText="*" />
            <ext:TextField ID="txtSTT" runat="server" FieldLabel="Số thứ tự" Width="350" Margins="2" />
            <ext:Checkbox ID="chkDuoc_Hien_Thi" runat="server" FieldLabel="Được hiển thị" Width="350"
                Margins="2" IndicatorText="*" />
            <ext:GridPanel ID="gridNhomChucNang" runat="server" Title="Danh sách dữ liệu" Margins="0 0 5 5"
                Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoWidth="true">
                <Store>
                    <ext:Store ID="dsNhomChucNang" runat="server" RemoteSort="true" DataSourceID="odsNhomChucNang" OnRefreshData="dsNhomChucNang_RefreshData">
                        <AutoLoadParams>
                            <ext:Parameter Name="start" Value="0" Mode="Raw" />
                            <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                        </AutoLoadParams>
                        <BaseParams>
                            <ext:Parameter Name="Filters" Value="#{txtFilterNCN}.getValue()" Mode="Raw" />
                        </BaseParams>
                        <Proxy>
                            <ext:PageProxy />
                        </Proxy>
                        <Reader>
                            <ext:JsonReader IDProperty="Ma_Nhom_Chuc_Nang">
                                <Fields>
                                <ext:RecordField Name="Ma_Nhom_Chuc_Nang" />
                                    <ext:RecordField Name="Ten_Nhom_Chuc_Nang" />
                                    <ext:RecordField Name="STT" />
                                    <ext:RecordField Name="Duoc_Hien_Thi" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                        <SortInfo Field="Ma_Nhom_Chuc_Nang" Direction="ASC" />
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="Ma_Nhom_Chuc_Nang" DataIndex="Ma_Nhom_Chuc_Nang" Header="Mã nhóm" />
                        <ext:Column ColumnID="Ten_Nhom_Chuc_Nang" DataIndex="Ten_Nhom_Chuc_Nang" Header="Tên nhóm"
                            Width="200" />
                        <ext:Column ColumnID="STT" DataIndex="STT" Header="STT" Width="70" />
                        <ext:CheckColumn ColumnID="Duoc_Hien_Thi" DataIndex="Duoc_Hien_Thi" Header="Hiển thị"
                            Width="100" />
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
                <DirectEvents>
                    <DblClick OnEvent="gridNhomChucNang_DbClick">
                    </DblClick>
                </DirectEvents>
                <BottomBar>
                    <ext:PagingToolbar ID="pageDataNCN" runat="server" PageSize="30" DisplayInfo="true"
                        DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                </BottomBar>
                <LoadMask ShowMask="true" />
            </ext:GridPanel>
        </Items>
        <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnUpdateNCN" Text="Thêm mới" Icon="Add" runat="server">
                        <DirectEvents>
                            <Click OnEvent="btnUpdateNCN_Click">
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnDeleteNCN" Text="Xóa" Icon="BulletCross" runat="server">
                        <DirectEvents>
                            <Click OnEvent="btnDeleteNCN_Click">
                                <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnExportNCN" runat="server" Text="Xuất báo cáo" Icon="Report">
                        <DirectEvents>
                            <Click OnEvent="btnExportNCN_Click" IsUpload="true" Before="ExportYap()">
                                <ExtraParams>
                                    <ext:Parameter Name="data" Value="#{gridData}.getRowsValues()" Mode="Raw" Encode="true" />
                                    <ext:Parameter Name="format" Value="xls" Mode="Value" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Hidden ID="txtFilterNCN" runat="server" AutoDataBind="true">
                        <Listeners>
                            <Change Handler="#{pageDataNCN}.changePage(1);" Delay="30" />
                        </Listeners>
                    </ext:Hidden>
                    <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                    <ext:TriggerField ID="txtSearchNCN" runat="server" Width="250" EmptyText="Tìm kiếm">
                        <Triggers>
                            <ext:FieldTrigger Icon="Search" />
                        </Triggers>
                        <Listeners>
                            <TriggerClick Handler="#{txtFilterNCN}.setValue(this.getValue()); " />
                        </Listeners>
                    </ext:TriggerField>
                </Items>
            </ext:Toolbar>
        </TopBar>
    </ext:Panel>
    <br />
    

    <ext:Panel ID="Panel1" runat="server" Layout="FormLayout" LabelWidth="150" Title = "Danh sách chức năng">
        <Items>
            
            <ext:TextField ID="txtMa_Chuc_Nang" FieldLabel="Mã chức năng" runat="server"
                Width="350" />
            <ext:TextField ID="txtTen_Chuc_Nang" runat="server" FieldLabel="Tên chức năng"
                Width="350" Margins="2" IndicatorText="*" />
            <ext:TextField ID="txtSTTCN" runat="server" FieldLabel="Số thứ tự" Width="350" Margins="2" />
            <ext:Checkbox ID="chkDuoc_Hien_ThiCN" runat="server" FieldLabel="Được hiển thị" Width="350"
                Margins="2" IndicatorText="*" />
                <ext:TextField ID="txtIcon" runat="server" FieldLabel="Icon" Width="350" Margins="2" />
                <ext:TextField ID="txtDuong_Dan" runat="server" FieldLabel="Đường dẫn" Width="350" Margins="2" />
            <ext:GridPanel ID="gridChucNang" runat="server" Title="Danh sách chức năng" Margins="0 0 5 5"
                Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoWidth="true">
                <Store>
                    <ext:Store ID="dsChucNang" runat="server" RemoteSort="true" DataSourceID="odsChucNang" OnRefreshData="dsChucNang_RefreshData">
                        <AutoLoadParams>
                            <ext:Parameter Name="start" Value="0" Mode="Raw" />
                            <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                        </AutoLoadParams>
                        <BaseParams>
                            <ext:Parameter Name="Filter" Value="#{txtFilterCN}.getValue()" Mode="Raw" />
                        </BaseParams>
                        <Proxy>
                            <ext:PageProxy />
                        </Proxy>
                        <Reader>
                            <ext:JsonReader IDProperty="Ma_Chuc_Nang">
                                <Fields>
                                <ext:RecordField Name="Ma_Chuc_Nang" />
                                    <ext:RecordField Name="Ten_Chuc_Nang" />
                                    <ext:RecordField Name="STT" />
                                    <ext:RecordField Name="Duoc_Hien_Thi" />
                                    <ext:RecordField Name="Icon" />
                                    <ext:RecordField Name="Duong_Dan" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                        <SortInfo Field="Ma_Chuc_Nang" Direction="ASC" />
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel2" runat="server">
                    <Columns>
                        <ext:Column ColumnID="Ma_Chuc_Nang" DataIndex="Ma_Chuc_Nang" Header="Mã chức năng" />
                        <ext:Column ColumnID="Ten_Chuc_Nang" DataIndex="Ten_Chuc_Nang" Header="Tên chức năng"
                            Width="200" />
                        <ext:Column ColumnID="STT" DataIndex="STT" Header="STT" Width="70" />
                        <ext:CheckColumn ColumnID="Duoc_Hien_Thi" DataIndex="Duoc_Hien_Thi" Header="Hiển thị"
                            Width="100" />
                            <ext:Column ColumnID="Icon" DataIndex="Icon" Header="Icon" Width="100" />
                            <ext:Column ColumnID="Duong_Dan" DataIndex="Duong_Dan" Header="Đường dẫn" Width="250" />
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true" />
                </SelectionModel>
                <DirectEvents>
                    <DblClick OnEvent="gridChucNang_DbClick">
                    </DblClick>
                </DirectEvents>
                <BottomBar>
                    <ext:PagingToolbar ID="pageDataCN" runat="server" PageSize="30" DisplayInfo="true"
                        DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                </BottomBar>
                <LoadMask ShowMask="true" />
            </ext:GridPanel>
        </Items>
        <TopBar>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:Button ID="btnUpdateCN" Text="Thêm mới" Icon="Add" runat="server">
                        <DirectEvents>
                            <Click OnEvent="btnUpdateCN_Click">
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnDeleteCN" Text="Xóa" Icon="BulletCross" runat="server">
                        <DirectEvents>
                            <Click OnEvent="btnDeleteCN_Click">
                                <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    
                    <ext:Hidden ID="txtFilterCN" runat="server" AutoDataBind="true">
                        <Listeners>
                            <Change Handler="#{pageDataCN}.changePage(1);" Delay="30" />
                        </Listeners>
                    </ext:Hidden>
                    <ext:ToolbarFill ID="ToolbarFill2" runat="server" />
                    <ext:TriggerField ID="txtSearchCN" runat="server" Width="250" EmptyText="Tìm kiếm">
                        <Triggers>
                            <ext:FieldTrigger Icon="Search" />
                        </Triggers>
                        <Listeners>
                            <TriggerClick Handler="#{txtFilterCN}.setValue(this.getValue()); " />
                        </Listeners>
                    </ext:TriggerField>
                </Items>
            </ext:Toolbar>
        </TopBar>
    </ext:Panel>
    </form>
</body>
</html>
