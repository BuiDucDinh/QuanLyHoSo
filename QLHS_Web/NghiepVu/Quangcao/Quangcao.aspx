<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Quangcao.aspx.cs" Inherits="NghiepVu_Quangcao_Quangcao" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var GetImage = function (value) {
            return "<img src='/FileUpload/Images/" + value + "' style=\'width:60px; height:auto\'/>";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="odsAdv" runat="server" OnSelected="odsAdv_Selected" SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="Start" Type="Int32" />
                <asp:Parameter Name="Limit" Type="Int32" />
                <asp:Parameter Name="WhereString" Type="String" />
                <asp:Parameter Name="SortString" Type="String" />
                <asp:Parameter Direction="Output" Name="Count" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="150" Border="false">
            <Items>
                <ext:Panel runat="server" ID="pnLoc" Padding="10" Border="false" Width="700">
                    <Items>
                        <ext:ComboBox runat="server" ID="cmbType" FieldLabel="Chọn vị trí quảng cáo" SelectedIndex="0" Width="600" DisplayField="name" ValueField="key">
                            <Store>
                                <ext:Store runat="server" ID="stType">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="key" />
                                                <ext:RecordField Name="name" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <DirectEvents>
                                <Select OnEvent="btnLoc_Click" />
                            </DirectEvents>
                        </ext:ComboBox>
                    </Items>
                </ext:Panel>

                <ext:GridPanel ID="gvData" runat="server" Title="" Margins="0 0 5 5" Header="false"
                    Icon="UserSuit" AutoHeight="true" AutoExpandColumn="Name">
                    <Store>
                        <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsAdv" OnRefreshData="stData_RefreshData">
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
                                        <ext:RecordField Name="Name" />
                                        <ext:RecordField Name="Duyet" />
                                        <ext:RecordField Name="Link" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                            <SortInfo Field="Type" Direction="ASC" />
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:Column ColumnID="Name" DataIndex="Name" Header="Tên quảng cáo" />
                            <ext:DateColumn DataIndex="Link" Width="100" Header="Link" Format="d/M/yyyy" />
                            <ext:CheckColumn ColumnID="Duyet" DataIndex="Duyet" Header="Trạng thái duyệt" Width="100" />
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
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
        <ext:Panel runat="server">
            <Items>
                <ext:Window runat="server" ID="wdDetail" Hidden="true" DefaultButton="0" Border="false" Title="Thông tin nhập liệu" Icon="Information"
                    MinWidth="800" MinHeight="500" Padding="3" Resizable="false" AutoScroll="true" Modal="true" Collapsible="true" Maximizable="true">

                    <Listeners>
                        <Hide Handler="#{stData}.reload();if(hdMsg.getValue()=='ok'){hdMsg.setValue('');alert('Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg" />
            </Items>
        </ext:Panel>

    </form>
</body>
</html>
