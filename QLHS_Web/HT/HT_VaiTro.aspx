<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_VaiTro.aspx.cs" Inherits="HT_HT_VaiTro" %>

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
    <asp:ObjectDataSource ID="odsData" runat="server" OnSelected="odsData_Selected" SelectMethod="Page_By_Filter"
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
            <ext:TextField ID="txtMa_Vai_Tro" runat="server" Hidden="true" />
            <ext:TextField ID="txtTen_Vai_Tro" runat="server" FieldLabel="Tên vai trò" Width="350"
                Margins="2" IndicatorText="*" />
            
            <ext:TextField ID="txtSTT" runat="server" FieldLabel="STT" Width="150" Margins="2"
                IndicatorText="*" />
            
            <ext:GridPanel ID="gridData" runat="server" Title="Danh sách dữ liệu" Margins="0 0 5 5"
                Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoWidth="true">
                <Store>
                    <ext:Store ID="dsData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="dsData_RefreshData">
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
                            <ext:JsonReader IDProperty="Ma_Vai_Tro">
                                <Fields>
                                    <ext:RecordField Name="Ma_Vai_Tro" />
                                    <ext:RecordField Name="Ten_Vai_Tro" />
                                    <ext:RecordField Name="STT" />                                    
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                        <SortInfo Field="STT" Direction="ASC" />
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="Ma_Vai_Tro" DataIndex="Ma_Vai_Tro" Header="ID" Hidden="true" />
                        <ext:Column ColumnID="Ten_Vai_Tro" DataIndex="Ten_Vai_Tro" Header="Tên vai trò"
                            Width="350" />
                        <ext:Column ColumnID="STT" DataIndex="STT" Header="STT" Width="100" />                        
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
                <DirectEvents>
                    <DblClick OnEvent="grid_DbClick">
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
                    <ext:Button ID="btnDelete" Text="Xóa" Icon="BulletCross" runat="server">
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
                    <ext:Button ID="btnDuAn" runat="server" Text="Quyền dự án" Icon="UserAlert">
                        <DirectEvents>
                            <Click OnEvent="btnDuAn_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="data" Value="#{gridData}.getRowsValues()" Mode="Raw" Encode="true" />
                                    
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnChucNang" runat="server" Text="Quyền chức năng" Icon="UserAlert">
                        <DirectEvents>
                            <Click OnEvent="btnChucNang_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="data" Value="#{gridData}.getRowsValues()" Mode="Raw" Encode="true" />
                                    
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
    <ext:Window ID="winDuAn" runat="server" Icon="NoteEdit" Title="Quyền dự án"
        Height="400" Width="600" Modal="true" Hidden="true" Layout="FormLayout" CloseAction="Hide"
        Closable="true">        
    </ext:Window>
    <ext:Window ID="winChucNang" runat="server" Icon="NoteEdit" Title="Quyền chức năng"
        Height="600" Width="700" Modal="true" Hidden="true" Layout="FormLayout" CloseAction="Hide"
        Closable="true">        
    </ext:Window>
    </form>
</body>
</html>
