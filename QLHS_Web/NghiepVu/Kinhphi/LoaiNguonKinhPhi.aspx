<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoaiNguonKinhPhi.aspx.cs" Inherits="NghiepVu_KinhPhi_LoaiNguonKinhPhi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                <ext:Hidden runat="server" ID="hdID" />
                <ext:TextField ID="txtTen" runat="server" FieldLabel="Nguồn kinh phí từ" Width="350" Margins="2" IndicatorText="*" />
                <ext:HtmlEditor ID="txtMota" runat="server" FieldLabel="Mô tả" Width="600" />
                
                <ext:GridPanel ID="gvData" runat="server" Title="" Margins="0 0 5 5" Header="false"
                    Icon="UserSuit" AutoHeight="true" AutoExpandColumn="MoTa">
                    <Store>
                        <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stData_RefreshData">
                            <AutoLoadParams>
                                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                <ext:Parameter Name="limit" Value="5" Mode="Raw" />
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
                                        <ext:RecordField Name="TenLoai" SortDir="ASC" />
                                        <ext:RecordField Name="MoTa" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                            <SortInfo Field="ID" Direction="ASC" />
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="60" />
                            <ext:Column ColumnID="TenLoai" DataIndex="TenLoai" Header="Nguồn kinh phí từ" Width="300" />
                            <ext:Column ColumnID="MoTa" DataIndex="MoTa" Header="Mô tả" />
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
                        <ext:PagingToolbar ID="pageData" runat="server" PageSize="5" DisplayInfo="true"
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
                                        <ext:Parameter Name="data" Value="#{gvData}.getRowsValues()" Mode="Raw" Encode="true" />
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
    </form>
</body>
</html>
