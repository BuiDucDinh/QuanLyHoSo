<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MediaLib.aspx.cs" Inherits="NghiepVu_Media_MediaLib" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var GetImage = function (value) {
            return "<img src='/FileUpload/Images/" + value + "' style=\'width:60px; height:auto\'/>";
        }
    </script>
    <link href="/css/MapStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="odsMediaLib" runat="server" OnSelected="odsMediaLib_Selected" SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="Start" Type="Int32" />
                <asp:Parameter Name="Limit" Type="Int32" />
                <asp:Parameter Name="WhereString" Type="String" />
                <asp:Parameter Name="SortString" Type="String" />
                <asp:Parameter Direction="Output" Name="Count" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="150">
            <Items>
                <ext:Panel runat="server" ID="pnLoc" Padding="10" Border="false" Width="700">
                    <Items>
                        <ext:TextField runat="server" ID="txtTenLib" Width="600" FieldLabel="Tên thư viện" />
                        <ext:ComboBox runat="server" ID="cmbHoatDong" FieldLabel="Chọn hoạt động văn hóa" SelectedIndex="0" Width="600" DisplayField="TenGoi" ValueField="HoatDongID">
                            <Store>
                                <ext:Store runat="server" ID="stHoatDong">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="HoatDongID" />
                                                <ext:RecordField Name="TenGoi" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ComboBox runat="server" ID="cmbDiSan" FieldLabel="Chọn di sản văn hóa" SelectedIndex="0" Width="600" DisplayField="TenDiSan" ValueField="DiSanID">
                            <Store>
                                <ext:Store runat="server" ID="stDiSan">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="DiSanID" />
                                                <ext:RecordField Name="TenDiSan" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ComboBox runat="server" ID="cmbDanhmuc" SelectedIndex="0" Width="600" FieldLabel="Danh mục" DisplayField="TenMenu" ValueField="MenuID">
                            <Store>
                                <ext:Store runat="server" ID="stDanhmuc">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="MenuID" />
                                                <ext:RecordField Name="TenMenu" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>

                    </Items>
                    <Buttons>
                        <ext:Button runat="server" ID="btnLoc" ToggleGroup="Group1" Text="Lọc" Icon="Find">
                            <DirectEvents>
                                <Click OnEvent="btnLoc_Click" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnCancel" ToggleGroup="Group1" Text="Bỏ điều kiện" Icon="Cross">
                            <DirectEvents>
                                <Click OnEvent="btnCancel_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Buttons>
                </ext:Panel>

                <ext:GridPanel ID="gridMediaLib" runat="server" Title="" Margins="0 0 5 5" Header="false"
                    Icon="UserSuit" AutoHeight="true" AutoExpandColumn="TenMediaLib">
                    <Store>
                        <ext:Store ID="stMediaLib" runat="server" RemoteSort="true" DataSourceID="odsMediaLib" OnRefreshData="stMediaLib_RefreshData">
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
                                <ext:JsonReader IDProperty="MediaLibID">
                                    <Fields>
                                        <ext:RecordField Name="MediaLibID" />
                                        <ext:RecordField Name="TenMediaLib" />
                                        <ext:RecordField Name="DiSan" />
                                        <ext:RecordField Name="HoatDong" />
                                        <ext:RecordField Name="NgaySua" />
                                        <ext:RecordField Name="Duyet" />
                                        <ext:RecordField Name="HinhAnh" />
                                        <ext:RecordField Name="DanhMuc" />
                                        <ext:RecordField Name="TypeMedia" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                            <SortInfo Field="TenMediaLib" Direction="ASC" />
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:Column ColumnID="HinhAnh" DataIndex="HinhAnh">
                                <Renderer Fn="GetImage" />
                            </ext:Column>
                            <ext:Column ColumnID="TenMediaLib" DataIndex="TenMediaLib" Header="Tên thư viện ảnh/video" />
                            <ext:Column ColumnID="DiSan" DataIndex="DiSan" Header="Di sản văn hóa" Width="150" />
                            <ext:Column ColumnID="HoatDong" DataIndex="HoatDong" Width="150" Header="Hoạt động văn hóa" />
                            <ext:Column ColumnID="DanhMuc" DataIndex="DanhMuc" Header="Danh mục" />
                            <ext:DateColumn DataIndex="NgaySua" Width="100" Header="Ngày sửa cuối" Format="d/M/yyyy" />
                            <ext:CheckColumn ColumnID="Duyet" DataIndex="Duyet" Header="Trạng thái duyệt" Width="100" />
                            <ext:CommandColumn Width="70">
                                <Commands>
                                    <ext:GridCommand Icon="BulletGo" CommandName="Show">
                                        <ToolTip Text="Xem album" />
                                    </ext:GridCommand>
                                    <ext:CommandSeparator />
                                    <ext:GridCommand Icon="PhotoAdd" CommandName="Add">
                                        <ToolTip Text="Thêm ảnh vào thư viện" />
                                    </ext:GridCommand>
                                </Commands>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel SingleSelect="false" runat="server">
                            <Listeners>
                                <RowSelect Handler="#{btnDelete}.enable();" />
                                <RowDeselect Handler="if (!#{gridMediaLib}.hasSelection()) {#{btnDelete}.disable();}" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <DirectEvents>
                        <DblClick OnEvent="gridMediaLib_DbClick">
                        </DblClick>
                        <Command OnEvent="Command_Event">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="command" Value="command" Mode="Raw" />
                                <ext:Parameter Name="rowIndex" Value="record.data.MediaLibID" Mode="Raw" />
                                <ext:Parameter Name="type" Value="record.data.TypeMedia" Mode="Raw" />
                            </ExtraParams>
                        </Command>
                    </DirectEvents>
                    <BottomBar>
                        <ext:PagingToolbar ID="pageNL_DM_ChucVu" runat="server" PageSize="30" DisplayInfo="true"
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
                                        <ext:Parameter Name="data" Value="#{gridMediaLib}.getRowsValues()" Mode="Raw" Encode="true" />
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
                <ext:Window runat="server" ID="wdDetail" Hidden="true" DefaultButton="0" Border="false" Title="Thông tin nhập liệu" Icon="Information"
                    MinWidth="800" MinHeight="500" Padding="3" Resizable="false" AutoScroll="true" Modal="true" Collapsible="true" Maximizable="true">
                    <Listeners>
                        <Hide Handler="if(hdMsg.getValue()=='ok'){hdMsg.setValue('');#{stMediaLib}.reload();Ext.Msg.alert('Thông báo','Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg" />
            </Items>
        </ext:Panel>
        <ext:Panel runat="server" ID="pnMedia">
            <Items>
                <ext:Window runat="server" ID="wdMedia" Hidden="true" DefaultButton="0" Border="false" Title="Thông tin nhập liệu" Icon="Information"
                    MinWidth="700" MinHeight="600" Padding="3" Resizable="false" AutoScroll="true" Modal="true" Collapsible="true" Maximizable="true">
                    <DirectEvents>
                        <Hide OnEvent="wdMedia_Hide" />
                    </DirectEvents>
                </ext:Window>
                <ext:Hidden runat="server" ID="Image_txtTextField" />
                <ext:Hidden runat="server" ID="Video_hdVideo" />
                <ext:Hidden runat="server" ID="hdMedia" />
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
