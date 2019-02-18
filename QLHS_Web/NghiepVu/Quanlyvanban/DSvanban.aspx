<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSvanban.aspx.cs" Inherits="DSVH_Quanlyvanban_Capnhatbaiviet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .cell_center {
            text-align: center;
            height: 30px;
            vertical-align: bottom;
        }

        .cell_right {
            text-align: right;
        }

        .cell_left {
            text-align: left;
            vertical-align: bottom;
        }
    </style>
    <script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(200);
        };
        var GetImage = function (value) {
            return "<img src='/FileUpload/Images/" + value + "' style=\'width:60px; height:auto\'/>";
        }
        var fnCommand = function (command, value, trangthai) {
            if (command == "Delete") {
                Ext.Msg.confirm("Thông báo", "Bạn có chắc muốn xóa bản ghi này?", function (btn) {
                    if (btn == "yes") {
                        submitCommand(command, value);
                    }
                });
            }
            else if (command == "Active") {
                var mes = trangthai ? "Bạn muốn bỏ bản ghi này ra khỏi kho thông tin tham khảo?" : "Bạn muốn thêm bản ghi này vào kho thông tin thao khảo?";
                Ext.Msg.confirm("Thông báo", mes, function (btn) {
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

        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" Padding="10">
            <Content>
                <ext:Panel runat="server" ID="pnLoc" Border="false">
                    <Content>
                        <table>
                            <tbody>
                                <tr>
                                    <td>Tên văn bản</td>
                                    <td>
                                        <ext:Hidden runat="server" ID="hdRole" />
                                        <ext:TextField ID="txtTenvanban" runat="server" Width="250">
                                            <Listeners>
                                                <Change Handler="#{stData}.reload();" />
                                            </Listeners>
                                        </ext:TextField>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Loại văn bản</td>
                                    <td>
                                        <ext:ComboBox ID="cboLoaiVB" runat="server" Width="250"
                                            EmptyText="--Chọn loại văn bản--" AllowBlank="true" DisplayField="TenLoaiVanBan" ValueField="LoaiVanBanID">
                                            <Store>
                                                <ext:Store runat="server" ID="stLoaiVB">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="LoaiVanBanID">
                                                            <Fields>
                                                                <ext:RecordField Name="LoaiVanBanID" />
                                                                <ext:RecordField Name="TenLoaiVanBan" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();#{stData}.reload();" />
                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{stData}.reload(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Cơ quan ban hành</td>
                                    <td>
                                        <ext:ComboBox ID="cmbCoquan" runat="server"
                                            Width="250" EmptyText="--Chọn cơ quan ban hành--" AllowBlank="true">
                                            <Items>
                                                <ext:ListItem Value="0" Text="Cơ quan" />
                                                <ext:ListItem Value="1" Text="Cơ quan 1" />
                                                <ext:ListItem Value="2" Text="Cơ quan 2" />
                                                <ext:ListItem Value="3" Text="Cơ quan 3" />
                                                <ext:ListItem Value="4" Text="Khác..." />
                                            </Items>
                                        </ext:ComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ban hành từ ngày</td>
                                    <td>
                                        <ext:DateField ID="dtTuNgay" runat="server" Format="d/M/yyyy" Width="230" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Đến ngày</td>
                                    <td>
                                        <ext:DateField ID="dtDenNgay" runat="server" Format="d/M/yyyy" Width="230" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table style="margin: 5px 0 10px 120px;">
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
                <ext:GridPanel ID="gvData" runat="server" Title="Danh sách dữ liệu" Margins="0 0 5 5" Width="1000"
                    Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoExpandColumn="TenVanBan">
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
                                <ext:JsonReader IDProperty="VanBanID">
                                    <Fields>
                                        <ext:RecordField Name="VanBanID" />
                                        <ext:RecordField Name="TenVanBan" />
                                        <ext:RecordField Name="TenLoaiVanBan" />
                                        <ext:RecordField Name="DonViBanHanh" />
                                        <ext:RecordField Name="NgayBanHanh" Type="Date" />
                                        <ext:RecordField Name="MoTa" />
                                        <ext:RecordField Name="Duyet" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                            <SortInfo Field="TenVanBan" Direction="ASC" />
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" />
                            <ext:Column ColumnID="TenVanBan" DataIndex="TenVanBan" Header="Tên văn bản" Width="200" />
                            <ext:Column ColumnID="TenLoaiVanBan" DataIndex="TenLoaiVanBan" Header="Loại văn bản" />
                            <ext:Column ColumnID="DonViBanHanh" DataIndex="DonViBanHanh" Width="150" Header="Đơn vị ban hành" />
                            <ext:DateColumn ColumnID="NgayBanHanh" DataIndex="NgayBanHanh" Width="150" Header="Ngày ban hành" Format="d/m/Y" />
                            <ext:CheckColumn DataIndex="Duyet" Width="50" Header="Duyệt" />
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
                    <Listeners>
                        <Command Handler="fnCommand(command, record.data.VanBanID, record.data.Duyet);" />
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
                        <DblClick OnEvent="gvData_DbClick" />
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
                    MinWidth="1000" MinHeight="550" Padding="3" Resizable="false" AutoScroll="true" Modal="true" Collapsible="true" Maximizable="true">
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg">
                    <Listeners>
                        <Change Handler="if(hdMsg.getValue()=='ok'){wdDetail.hide();#{stData}.reload();hdMsg.setValue('');Ext.Msg.alert('Thông báo','Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Hidden>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
