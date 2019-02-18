<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NgheNhan.aspx.cs" Inherits="NghiepVu_DiSanVanHoa_NgheNhan" %>

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
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="100">
            <Content>
                <ext:Panel runat="server" ID="pnLoc" Padding="10" Border="false" Width="450">
                    <Content>
                        <ext:Hidden runat="server" ID="hdRole" />
                        <ext:TextField ID="txtHoTen" runat="server" FieldLabel="Tên nghệ nhân" Width="400" />
                        <ext:ComboBox runat="server" ID="cmbDiSan" FieldLabel="Chọn di sản văn hóa" Width="400" DisplayField="TenDiSan" ValueField="DiSanID">
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
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Select Handler="this.triggers[0].show();#{stData}.reload();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{stData}.reload(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:DateField ID="txtTungay" runat="server" FieldLabel="Từ ngày" Width="400" />
                        <ext:DateField ID="txtDenngay" runat="server" FieldLabel="Đến ngày" Width="400" />
                        <table style="margin-left:100px;">
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
                            Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoExpandColumn="HoTen">
                            <Store>
                                <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stData_RefreshData">
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                        <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="Filter" Value="#{txtHoTen}.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Proxy>
                                        <ext:PageProxy />
                                    </Proxy>
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="HoTen" />
                                                <ext:RecordField Name="TenKhac" />
                                                <ext:RecordField Name="DiSan" />
                                                <ext:RecordField Name="TenDiSan" />
                                                <ext:RecordField Name="TenLoaiDS" />
                                                <ext:RecordField Name="NgayCap" Type="Date" />
                                                <ext:RecordField Name="HoKhauThuongTru" />
                                                <ext:RecordField Name="TenDanhHieu" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="NgayCap" Direction="DESC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="50" />
                                    <ext:Column ColumnID="HoTen" DataIndex="HoTen" Header="Họ tên" />
                                    <ext:Column ColumnID="TenKhac" DataIndex="TenKhac" Header="Tên khác" Width="150" />
                                    <ext:Column ColumnID="TenDanhHieu" DataIndex="TenDanhHieu" Header="Danh hiệu" Width="100" />
                                    <ext:Column ColumnID="TenLoaiDS" DataIndex="TenLoaiDS" Header="Loại hình di sản" Width="100" />
                                    <ext:Column ColumnID="TenDiSan" DataIndex="TenDiSan" Width="100" Header="Di sản nắm giữ" />
                                    <ext:DateColumn ColumnID="NgayCap" DataIndex="NgayCap" Width="100" Header="Ngày cấp danh hiệu" Format="d/m/Y" />
                                    <ext:Column ColumnID="HoKhauThuongTru" DataIndex="HoKhauThuongTru" Header="Hộ khẩu thường trú" Width="150" />
                                    <ext:CommandColumn Width="130">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Delete" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                <ToolTip Text="Edit" />
                                            </ext:GridCommand>
                                        </Commands>
                                        <PrepareToolbar Fn="prepareToolbar" />
                                    </ext:CommandColumn>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel SingleSelect="false" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="#{btnDelete}.enable();#{btnExportDeTail}.enable();#{btnShow}.enable()" />
                                        <RowDeselect Handler="if (!#{gvData}.hasSelection()) {#{btnDelete}.disable();#{btnExportDeTail}.disable();#{btnShow}.disable();}" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <DirectEvents>
                                <DblClick OnEvent="gvData_DbClick" />
                            </DirectEvents>
                            <Listeners>
                                <Command Handler="fnCommand(command, record.data.ID);" />
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
                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click" />
                            </DirectEvents>
                        </ext:Button>
                         <ext:Button ID="btnShow" runat="server" Text="Xem" Icon="ApplicationGet" Disabled="true">
                            <DirectEvents>
                                <Click OnEvent="btnShow_Click">
                                    <ExtraParams>
                                        <ext:Parameter Name="ID" Value="Ext.encode(#{gvData}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                    </ExtraParams>
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
                        <ext:Button ID="btnExportDeTail" Text="In phiếu" runat="server" Disabled="true" Icon="Report">
                            <DirectEvents>
                                <Click OnEvent="btnExportDeTail_Click" />
                            </DirectEvents>
                        </ext:Button>
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
        <ext:Panel runat="server">
            <Items>
                <ext:Window runat="server" ID="wdDetail" Hidden="true" DefaultButton="0" Border="false" Title="Thông tin nhập liệu" Icon="Information"
                    MinWidth="1000" MinHeight="550" Padding="3" Resizable="false" AutoScroll="true" Modal="true" Collapsible="true" Maximizable="true">
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
