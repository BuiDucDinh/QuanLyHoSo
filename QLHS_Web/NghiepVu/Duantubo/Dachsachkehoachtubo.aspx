<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dachsachkehoachtubo.aspx.cs"
    Inherits="DSVH_Quanlykehoachtubo_Dachsachkehoachtubo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> <script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        var fnCommand = function (command, value) {
            if (command == "Delete") {
                Ext.Msg.confirm("Thông báo", "Bạn có chắc muốn xóa bản ghi này?", function (btn) {
                    if (btn == "yes") {
                        submitCommand(command, value);
                    }
                });
            }
            else {
                submitCommand(command, value);
            }
        };
        var submitCommand = function (command, value) {
            Ext.net.DirectMethods.Command(command, value, {
                success: function (result) {
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        var prepareToolbar = function (grid, toolbar, rowIndex, record) {
            var ma = Ext.getCmp('hdRole').getValue();
            var role = JSON.parse(ma);
            if (!role.Duoc_Sua) {
                toolbar.items.itemAt(2).hide();
            }
            if (!role.Duoc_Xoa) {
                toolbar.items.itemAt(0).hide();
                toolbar.items.itemAt(1).hide();
            }
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
                if (!role.Duoc_Xuat) {
                    Ext.getCmp('btnExport').hide();
                }
            });
        });
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
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="150">
            <Items>
                <ext:Panel runat="server" ID="pnLoc" Padding="10" Border="false">
                    <Content>
                        <ext:Hidden runat="server" ID="hdRole" />
                        <table>
                            <tr>
                                <td>
                                    <ext:TextField ID="txtTieuDe" runat="server" FieldLabel="Tên gọi" Width="400" />
                                </td>
                                <td>
                                    <ext:MultiCombo ID="mcbDanhmuc" runat="server" FieldLabel="Danh mục tin" ValueField="MenuID" DisplayField="Menu_Vitri" Width="400" EmptyText="Chọn danh mục tin">
                                        <Store>
                                            <ext:Store runat="server" ID="stTheLoai">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="MenuID">
                                                        <Fields>
                                                            <ext:RecordField Name="MenuID" />
                                                            <ext:RecordField Name="Menu_Vitri" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                    </ext:MultiCombo>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ext:DateField ID="txtTungay" runat="server" FieldLabel="Từ ngày" Width="400" />
                                </td>
                                <td>
                                    <ext:DateField ID="txtDenngay" runat="server" FieldLabel="Đến ngày" Width="400" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <ext:Button runat="server" ID="btnLoc" Icon="Find" Text="Lọc" ToggleGroup="Group1">
                                        <DirectEvents>
                                            <Click OnEvent="btnLoc_Click" />
                                        </DirectEvents>
                                    </ext:Button>
                                </td>
                                <td>
                                    <ext:Button runat="server" ID="btnCancel" Icon="Decline" Text="Bỏ điều kiện" ToggleGroup="Group1">
                                        <DirectEvents>
                                            <Click OnEvent="btnCancel_Click" />
                                        </DirectEvents>
                                    </ext:Button>
                                </td>
                            </tr>
                        </table>

                    </Content>
                </ext:Panel>
                <ext:Panel runat="server" Layout="FitLayout" Title="Danh sách dự án tu bổ" Margins="5">
                    <Content>
                        <ext:GridPanel ID="gvData" runat="server" Title="" Margins="0 0 5 5" Header="false"
                            Icon="UserSuit" AutoHeight="true" AutoExpandColumn="TenDuAn">
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
                                        <ext:JsonReader IDProperty="KeHoachID">
                                            <Fields>
                                                <ext:RecordField Name="KeHoachID" />
                                                <ext:RecordField Name="TenDuAn" />
                                                <ext:RecordField Name="DiaDiem" />
                                                <ext:RecordField Name="DiSan" SortDir="ASC" />
                                                <ext:RecordField Name="CapQD" />
                                                <ext:RecordField Name="ChuDauTu" />
                                                <ext:RecordField Name="TrangThai" />
                                                <ext:RecordField Name="ChiPhiDuKien" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="KeHoachID" Direction="ASC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="TenDuAn" DataIndex="TenDuAn" Header="Tên dự án" />
                                    <ext:Column ColumnID="DiaDiem" DataIndex="DiaDiem" Header="Khu vực" />
                                    <ext:Column ColumnID="DiSan" DataIndex="DiSan" Header="Tên di sản" />
                                    <ext:Column ColumnID="CapQD" DataIndex="CapQD" Width="200" Header="Cấp QĐ đầu tư" />
                                    <ext:Column ColumnID="ChuDauTu" DataIndex="ChuDauTu" Width="200" Header="Chủ đầu tư" />
                                    <ext:Column ColumnID="ChiPhiDuKien" DataIndex="ChiPhiDuKien" Header="Dự kiến chi phí">
                                        <Renderer Format="UsMoney" />
                                    </ext:Column>
                                    <ext:CheckColumn ColumnID="TrangThai" DataIndex="TrangThai" Header="Trạng thái duyệt" />
                                    <ext:CommandColumn Width="80" Align="Right">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Xóa" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                <ToolTip Text="Sửa" />
                                            </ext:GridCommand>
                                        </Commands>
                                    </ext:CommandColumn>
                                    <%--<ext:Column ColumnID="File" DataIndex="File" Header="File đính kèm"/>--%>
                                </Columns>
                            </ColumnModel>
                            <Listeners>
                                <Command Handler="fnCommand(command, record.data.KeHoachID);" />
                            </Listeners>
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
                </ext:Panel>
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
                    MinWidth="1000" MinHeight="600" Padding="3" Resizable="true" AutoScroll="true" Modal="true" Collapsible="true" Maximizable="true">
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
