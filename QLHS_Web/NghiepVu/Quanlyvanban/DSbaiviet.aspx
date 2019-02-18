<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSbaiviet.aspx.cs" Inherits="DSVH_Quanlyvanban_Capnhatvanban" %>

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
        var GetImage = function (value) {
            return "<img src='/FileUpload/Images/" + value + "' style=\'width:60px; height:auto\'/>";
        }
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
            if (!role.Duoc_Duyet) {
                toolbar.items.itemAt(4).hide();
            }
            if (!role.Duoc_Sua) {
                toolbar.items.itemAt(2).hide();
                toolbar.items.itemAt(3).hide();
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
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="100">
            <Content>
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
                            <tr>
                                <td>
                                    <ext:Checkbox runat="server" ID="ckbNguoiTao" FieldLabel="Tin của bạn" />
                                </td>
                          
                                <td >
                                    <ext:ComboBox runat="server" ID="cmbLang" FieldLabel="Ngôn ngữ" SelectedIndex="0" Width="400">
                                        <Items>
                                            <ext:ListItem Text="Tiếng việt" Value="vi" />
                                            <ext:ListItem Text="Tiếng anh" Value="en" />
                                        </Items>

                                    </ext:ComboBox>
                                </td>
                            </tr>
                        </table>
                        <table style="margin-left: 100px">
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
                <ext:Panel runat="server" Layout="FitLayout" Title="Danh sách tin" Margins="5">
                    <Content>
                        <ext:GridPanel ID="gvData" runat="server"
                            Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoExpandColumn="TieuDe">
                            <Store>
                                <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stData_RefreshData">
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                        <ext:Parameter Name="limit" Value="10" Mode="Raw" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="Filter" Value="#{txtTieuDe}.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Proxy>
                                        <ext:PageProxy />
                                    </Proxy>
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="TieuDe" />
                                                <ext:RecordField Name="TenTheLoai" />
                                                <ext:RecordField Name="NgayXuatBan" Type="Date" />
                                                <ext:RecordField Name="TenDiSan" />
                                                <ext:RecordField Name="AnhDaiDien" />
                                                <ext:RecordField Name="Duyet" />
                                                <ext:RecordField Name="Stt" />
                                                <ext:RecordField Name="NguoiTao" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="NgayXuatBan" Direction="DESC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" />
                                    <ext:Column ColumnID="AnhDaiDien" DataIndex="AnhDaiDien" Header="Hình ảnh" Width="80" Align="Center">
                                        <Renderer Fn="GetImage" />
                                    </ext:Column>
                                    <ext:Column ColumnID="TieuDe" DataIndex="TieuDe" Header="Tiêu đề" />
                                    <ext:Column ColumnID="TenTheLoai" DataIndex="TenTheLoai" Header="Danh mục" Width="250" />
                                    <ext:DateColumn ColumnID="NgayXuatBan" DataIndex="NgayXuatBan" Width="100" Header="Ngày xuất bản" Format="d/m/Y" />
                                    <ext:Column ColumnID="TenDiSan" DataIndex="TenDiSan" Header="Tin di sản văn hóa" />
                                    <ext:CheckColumn DataIndex="Duyet" Header="Duyệt" Align="Center" />
                                    <ext:CommandColumn Width="150" Align="Right">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Xóa" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                <ToolTip Text="Sửa" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="Accept" CommandName="Active" Text="Duyệt">
                                                <ToolTip Text="Duyệt" />
                                            </ext:GridCommand>
                                        </Commands>
                                        <PrepareToolbar Fn="prepareToolbar" />
                                    </ext:CommandColumn>
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
                            <Listeners>
                                <Command Handler="fnCommand(command, record.data.ID);" />
                            </Listeners>
                            <DirectEvents>
                                <DblClick OnEvent="gvData_DbClick" />
                            </DirectEvents>
                            <BottomBar>
                                <ext:PagingToolbar ID="pageData" runat="server" PageSize="10" DisplayInfo="true"
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
                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click" />
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
                                    </ExtraParams>
                                </Click>
                            </DirectEvents>
                        </ext:Button>

                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
        <ext:Panel runat="server">
            <Items>
                <ext:Window runat="server" ID="wdDetail" Hidden="true" DefaultButton="0" Border="false" Title="Thông tin nhập liệu" Icon="Information"
                    MinWidth="1000" MinHeight="550" Padding="3" Resizable="false" AutoScroll="true" Modal="true" Maximizable="true">
                    <%--<Listeners>
                        <Hide Handler="if(hdMsg.getValue()=='ok'){hdMsg.setValue('');#{stData}.reload();Ext.Msg.alert('Thông báo','Đã cập nhật thành công');}" />
                    </Listeners>--%>
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg">
                    <Listeners>
                        <Change Handler="if(hdMsg.getValue()=='ok'){wdDetail.hide();hdMsg.setValue('');#{stData}.reload();Ext.Msg.alert('Thông báo','Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Hidden>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
