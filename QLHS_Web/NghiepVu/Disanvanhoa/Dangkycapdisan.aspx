<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dangkycapdisan.aspx.cs" Inherits="DSVH_Quanlydisan_Dangkycapdisan" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Panel ID="ViewPort2" runat="server" Layout="FormLayout" Padding="10">
            <Content>

                <ext:GridPanel ID="gvData" runat="server" Title="" Margins="0 0 5 5" Header="false"
                    Icon="UserSuit" AutoHeight="true" AutoExpandColumn="MoTa">
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
                                <ext:JsonReader IDProperty="DangKyID">
                                    <Fields>
                                        <ext:RecordField Name="DangKyID" />
                                        <ext:RecordField Name="DiSan" />
                                        <ext:RecordField Name="SoDangKy" />
                                        <ext:RecordField Name="NgayDangKy" Type="Date" />
                                        <ext:RecordField Name="TinhTrang" />
                                        <ext:RecordField Name="TenCapDiSan" />
                                        <ext:RecordField Name="MoTa" />
                                        <ext:RecordField Name="Duyet" />

                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                            <SortInfo Field="NgayDangKy" Direction="DESC" />
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="Stt" />
                            <ext:Column ColumnID="SoDangKy" DataIndex="SoDangKy" Header="Số đăng ký" Width="150" />
                            <ext:Column ColumnID="DiSan" DataIndex="DiSan" Header="Di sản" Width="200" />
                            <ext:DateColumn ColumnID="NgayDangKy" DataIndex="NgayDangKy" Header="Ngày đăng ký" Width="150" Format="d/M/yyyy" />
                            <ext:Column ColumnID="TinhTrang" DataIndex="TinhTrang" Header="Tình trạng" Width="150" />
                            <ext:Column ColumnID="TenCapDiSan" DataIndex="TenCapDiSan" Header="Cấp di sản" Width="150" />
                            <ext:Column ColumnID="MoTa" DataIndex="MoTa" Header="Mô tả" Width="150" />
                            <ext:CheckColumn ColumnID="Duyet" DataIndex="Duyet" Header="Duyệt" Width="50" />
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
            </Content>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click" />
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
                                <Click OnEvent="btnExport_Click" IsUpload="true" ><%--Before="ExportYap()"--%>
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
        <ext:Panel runat="server">
            <Items>
                <ext:Window runat="server" ID="wdDetail" Hidden="true"
                    DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
                    MinWidth="900" MinHeight="500" Modal="true" Padding="3" Resizable="false">
                    <Listeners>
                        <Hide Handler="if(hdMsg.getValue()=='ok'){#{stData}.reload();hdMsg.setValue('');Ext.Msg.alert('Thông báo','Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg" />
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
