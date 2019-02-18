<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangKeHienVatDiTich.aspx.cs" Inherits="NghiepVu_DiSanVanHoa_BangKeHienVatDiTich" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(200);
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
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="100">
            <Content>
                <ext:Panel runat="server" ID="pnLoc" Padding="10" Border="false" Width="900">
                    <Content>
                        <ext:Hidden runat="server" ID="hdRole" />
                        <table style="font: 13px arial,tahoma,sans-serif;">
                            <tr>
                                <td> 
                                    <p><span class="x-label-text">Tên di tích:</span></p>
                                </td>
                                <td colspan="2">                                   
                                    <ext:TextField runat="server" ID="txtTenDiTich" Width="500">
                                        <Listeners>
                                            <Change Handler="#{stData}.reload();" />
                                        </Listeners>
                                    </ext:TextField>
                                </td>                               
                            </tr>
                        </table>
                    </Content>
                </ext:Panel>
                <ext:Panel runat="server" Layout="FitLayout" Title="Thống kê hiện vật di tích" Margins="5">
                    <Content>
                        <ext:GridPanel ID="gvData" runat="server"
                            Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoExpandColumn="TenDiSan">
                            <Store>
                                <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stData_RefreshData">
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                        <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="Filter" Value="#{txtTenDiTich}.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Proxy>
                                        <ext:PageProxy />
                                    </Proxy>
                                    <Reader>
                                        <ext:JsonReader IDProperty="TT">
                                            <Fields>
                                                <ext:RecordField Name="TT" />
                                                <ext:RecordField Name="TenDiSan" />
                                                <ext:RecordField Name="SoDangKy" />
                                                <ext:RecordField Name="SLDiVat" />
                                                <ext:RecordField Name="SLCoVat" />
                                                <ext:RecordField Name="SLBaoVat" />
                                                <ext:RecordField Name="TongSl" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="TongSl" Direction="Desc" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="30" />                                   
                                    <ext:Column ColumnID="TenDiSan" DataIndex="TenDiSan" Header="Tên di tích" />
                                    <ext:Column ColumnID="SoDangKy" DataIndex="SoDangKy" Header="Số đăng ký" Width="120" />
                                    <ext:Column ColumnID="SLDiVat" DataIndex="SLDiVat" Header="SL Di vật" Width="150" />
                                    <ext:Column ColumnID="SLCoVat" DataIndex="SLCoVat" Width="150" Header="SL Cổ vật" />
                                    <ext:Column ColumnID="SLBaoVat" DataIndex="SLBaoVat" Width="150" Header="SL Bảo vật" />
                                    <ext:Column ColumnID="TongSl" DataIndex="TongSl" Width="150" Header="Tổng số hiện vật" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel SingleSelect="false" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="" />
                                        <RowDeselect Handler="" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <DirectEvents>
                                <DblClick OnEvent="gvData_DbClick" />
                            </DirectEvents>
                            <Listeners>
                                <Command Handler="" />
                            </Listeners>
                            <BottomBar>
                                <ext:PagingToolbar ID="pageData" runat="server" PageSize="30" DisplayInfo="true"
                                    DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                            </BottomBar>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                    </Content>
                </ext:Panel>
            </Content>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnExport" runat="server" Text="Xuất báo cáo" Icon="PageExcel">
                            <DirectEvents>
                                <Click OnEvent="btnExport_Click" IsUpload="true" Before="ExportYap()">
                                    <ExtraParams>
                                        <ext:Parameter Name="data" Value="#{gvData}.getRowsValues()" Mode="Raw" Encode="true" />
                                    </ExtraParams>
                                </Click>
                            </DirectEvents>
                        </ext:Button>

                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
    </form>
</body>
</html>
