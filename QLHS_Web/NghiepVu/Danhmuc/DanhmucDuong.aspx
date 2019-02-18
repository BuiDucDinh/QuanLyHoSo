<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhmucDuong.aspx.cs" Inherits="NghiepVu_Danhmuc_DanhmucDuong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };
        function NodeLoadAddress(node) {
            Ext.net.DirectMethods.NodeLoadAddress(node.id, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        var getTasksAddress = function () {
            var msg = ",",
                selNodes = TreePanel1.getChecked();
            Ext.each(selNodes, function (node) {
                //childCheck(selNodes, true);
                msg += this.id.substring(1,this.id.leght) + ",";
            });
            var myElement = document.getElementById("hdAddress");
            myElement.value = msg;
        };

        $(document).ready(function () {
            Ext.onReady(function () {
                var ma = Ext.getCmp('hdRole').getValue();
                var role = JSON.parse(ma);
                if (!role.Duoc_Xoa) {
                    Ext.getCmp('btnDelete').hide();
                }
                if (!role.Duoc_Nhap && !role.Duoc_Sua) {
                    Ext.getCmp('btnUpdate').hide();
                }
            });
        });
    </script>
    <link href="/css/other.css" rel="stylesheet" />
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

        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Layout="border" Border="false" Region="Center">
                    <Items>
                        <ext:Panel ID="Panel3" runat="server" Region="West" Split="true" Margins="0 0 0 0"
                            Frame="true" DefaultAnchor="100%" Width="250">
                            <Items>
                                <ext:Panel ID="Panel2" runat="server" Region="North" Split="true" Margins="0 0 0 0"
                                    Frame="true" Title="Địa điểm" Icon="House" Layout="FitLayout" Height="590" AutoScroll="true"
                                    DefaultAnchor="100%">
                                    <Items>
                                        <ext:TreePanel SingleExpand="true"
                                            ID="TreePanel1" Height="420" AutoScroll="true"
                                            runat="server"
                                            AutoHeight="true"
                                            Border="false">
                                            <Root>
                                                <ext:AsyncTreeNode NodeID="T36" Text="Địa điểm" Expanded="true" Leaf="false" />
                                            </Root>
                                            <Listeners>
                                                <BeforeLoad Fn="NodeLoadAddress" />
                                                <CheckChange Handler="getTasksAddress();#{stData}.reload();" />
                                                <%--Handler="getTasksAddress();#{stData}.reload();"--%>
                                            </Listeners>
                                        </ext:TreePanel>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="pnlExplorer" runat="server" Region="Center" Margins="0 0 0 0" Frame="true"
                            Title="Danh sách đường" Icon="LayoutHeader" Layout="FitLayout">
                            <Content>
                                <ext:Panel ID="Panel5" runat="server" AutoScroll="true" Padding="10" AutoHeight="true" LabelWidth="150">
                                    <Content>
                                        <ext:Hidden runat="server" ID="hdAddress" ClientIDMode="Static"/>
                                        <ext:Hidden runat="server" ID="hdRole"/>
                                        <ext:GridPanel ID="gvData" runat="server" Title="" Padding="5" Header="false"
                                            Icon="UserSuit" AutoHeight="true" AutoExpandColumn="TenDuong">
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
                                                                <ext:RecordField Name="TenDuong" />
                                                                <ext:RecordField Name="SoHieuDuongBo" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                    <SortInfo Field="TenDuong" Direction="ASC" />
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel1" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="30" />
                                                    <ext:Column ColumnID="SoHieuDuongBo" DataIndex="SoHieuDuongBo" Header="Số hiệu đường bộ" Width="100" />
                                                    <ext:Column ColumnID="TenDuong" DataIndex="TenDuong" Header="Tên đường" />
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
                                                <ext:Button ID="btnUpdate" runat="server" Text="Thêm mới" Icon="Add">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnUpdate_Click">
                                                            <ExtraParams>
                                                                <ext:Parameter Name="ID" Value="Ext.encode(#{gvData}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                                            </ExtraParams>
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button ID="btnDelete" runat="server" Text="Xóa" Icon="Cross" Disabled="true">
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
                            </Content>
                        </ext:Panel>
                    </Items>
                </ext:Panel>

            </Items>
        </ext:Viewport>
        <ext:Panel runat="server">
            <Items>
                <ext:Window runat="server" ID="wdDetail" Hidden="true"
                    DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
                    MinWidth="900" Height="550" Modal="true" Padding="3" Resizable="false">
                    <Listeners>
                        <Hide Handler="if(hdMsg.getValue()=='ok'){#{stData}.reload();hdMsg.setValue('');Ext.Msg.alert('Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg" />
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
