<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_DMXa.aspx.cs" Inherits="HT_HT_DMXa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <form id="form1" runat="server">
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
            <ext:TextField ID="txtMa_Xa" FieldLabel="Mã xã" runat="server" Hidden="false" />
            <ext:TextField ID="txtTen_Xa" runat="server" FieldLabel="Tên xã" Width="350"
                Margins="2" IndicatorText="*" />            
            <ext:ComboBox ID="cboMa_Huyen" runat="server" FieldLabel="Tên huyện" Width="150" EmptyText="--Chọn Huyện--"
                DisplayField="Ten_Huyen" ValueField="Ma_Huyen" Mode="Local">
                <Store>
                    <ext:Store ID="dsDM_Huyen" runat="server">
                        <Reader>
                            <ext:JsonReader>
                                <Fields>
                                    <ext:RecordField Name="Ten_Huyen" SortDir="ASC" />
                                    <ext:RecordField Name="Ma_Huyen" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <DirectEvents>
                    <Select OnEvent="CboMa_Huyen_Change" />
                </DirectEvents>
            </ext:ComboBox>           
            <ext:NumberField ID="txtSo_Thu_Tu" runat="server" FieldLabel="Số thứ tự" Margins="2" IndicatorText="*" />
            <ext:ComboBox ID="cboHinh_Nen" runat="server" FieldLabel="Giao diện" EmptyText="--Chọn giao diện--"
                Editable="false" Width="150" Hidden="true">
                <Items>
                    <ext:ListItem Text="Mặc định" Value="1" />
                    <ext:ListItem Text="Xám trắng" Value="2" />
                    <ext:ListItem Text="Xám đen" Value="3" />
                    <ext:ListItem Text="Tím đen" Value="4" />
                </Items>
            </ext:ComboBox>
            <ext:GridPanel ID="gridData" runat="server" Title="Danh sách dữ liệu" Margins="0 0 5 5"
                Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoWidth="true">
                <Store>
                    <ext:Store ID="dsData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="dsData_RefreshData">
                        <AutoLoadParams>
                            <ext:Parameter Name="start" Value="0" Mode="Raw" />
                            <ext:Parameter Name="limit" Value="15" Mode="Raw" />
                        </AutoLoadParams>
                        <BaseParams>
                            <ext:Parameter Name="Filter" Value="#{txtFilter}.getValue()" Mode="Raw" />
                        </BaseParams>
                        <Proxy>
                            <ext:PageProxy />
                        </Proxy>
                        <Reader>
                            <ext:JsonReader IDProperty="Ma_Xa">
                                <Fields>
                                    <ext:RecordField Name="Ma_Xa" />
                                    <ext:RecordField Name="Ten_Xa" />
                                    <ext:RecordField Name="STT" />                                      
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                        <SortInfo Field="Ma_Huyen,STT" Direction="ASC" />
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="Ma_Xa" DataIndex="Ma_Xa" Header="Mã xã" Hidden="false" />
                        <ext:Column ColumnID="Ten_Xa" DataIndex="Ten_Xa" Header="Tên xã"
                            Width="200" />
                         <ext:Column ColumnID="STT" DataIndex="STT" Header="Số thứ tự" Width="200" />  
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
                    <ext:PagingToolbar ID="pageData" runat="server" PageSize="15" DisplayInfo="true"
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
    <ext:Window ID="winVaiTro" runat="server" Icon="NoteEdit" Title="Quyền vai trò"
        Height="400" Width="600" Modal="true" Hidden="true" Layout="FormLayout" CloseAction="Hide"
        Closable="true">        
    </ext:Window>
    </form>
</body>
</html>
