<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiVatCoVat.aspx.cs" Inherits="NghiepVu_DiSanVanHoa_DiVatCoVat" %>

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
                    Ext.getCmp('btnExportDeTail').hide();
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
                <ext:Panel runat="server" ID="pnLoc" Padding="10" Border="false" Width="1024">
                    <Content>
                        <ext:Hidden runat="server" ID="hdRole" />
                        <table style="font: 13px arial,tahoma,sans-serif;">
                            <tr>
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Tên di vật:</span></p>
                                    <ext:TextField runat="server" ID="txtTen" Width="300">
                                        <Listeners>
                                            <Change Handler="#{stData}.reload();" />
                                        </Listeners>
                                    </ext:TextField>
                                </td>
                                <td colspan="2">
                                    <p><span class="x-label-text">Số đăng ký di vật:</span></p>
                                    <ext:TextField runat="server" ID="txtSodangky" Width="300">
                                        <Listeners>
                                            <Change Handler="#{stData}.reload();" />
                                        </Listeners>
                                    </ext:TextField>
                                </td>
                                <td colspan="2">
                                    <p><span class="x-label-text">Thời kỳ:</span></p>
                                    <ext:ComboBox ID="cbThoiKy" runat="server" Width="300" DisplayField="TenThoiKy" ValueField="ID" SelectOnFocus="true">
                                        <Store>
                                            <ext:Store runat="server" ID="stThoiky" AutoLoad="true">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="ID">
                                                        <Fields>
                                                            <ext:RecordField Name="ID" />
                                                            <ext:RecordField Name="TenThoiKy" />
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
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Cấp từ ngày:</span></p>
                                    <ext:DateField runat="server" ID="txtTungay" Width="300" Format="dd/MM/yyyy">
                                        <Listeners>
                                            <Select Handler="#{stData}.reload();" />
                                        </Listeners>
                                    </ext:DateField>
                                </td>
                                <td colspan="2">
                                    <p><span class="x-label-text">Đến ngày:</span></p>
                                    <ext:DateField runat="server" ID="txtDenngay" Width="300" Format="dd/MM/yyyy">
                                        <Listeners>
                                            <Select Handler="#{stData}.reload();" />
                                        </Listeners>
                                    </ext:DateField>
                                </td>
                                <td colspan="2">
                                    <p><span class="x-label-text">Bảo tàng:</span></p>
                                    <ext:ComboBox ID="cbNoiLuuTru" runat="server" Width="300" DisplayField="Ten" ValueField="ID">
                                        <Store>
                                            <ext:Store runat="server" ID="stNoiLuuTru" AutoLoad="true">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="ID">
                                                        <Fields>
                                                            <ext:RecordField Name="ID" />
                                                            <ext:RecordField Name="Ten" />
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
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{stData}.reload();}" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Khu di tích:</span></p>
                                    <ext:ComboBox ID="cbDisan" runat="server" Width="300" DisplayField="TenDiSan" ValueField="DiSanID">
                                        <Store>
                                            <ext:Store runat="server" ID="stDiSan">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="DiSanID">
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
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{stData}.reload();}" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </td>
                                <td colspan="2">
                                    <p><span class="x-label-text">Tên di tích:</span></p>
                                    <ext:TextField runat="server" ID="txtTenDiTich" Width="300">
                                        <Listeners>
                                            <Change Handler="#{stData}.reload();" />
                                        </Listeners>
                                    </ext:TextField>
                                </td>
                                <td colspan="2">
                                    <p><span class="x-label-text">Ngôn ngữ:</span></p>
                                    <ext:ComboBox ID="cbNgonNgu" runat="server" Width="150" SelectOnFocus="true">
                                        <Items>
                                            <ext:ListItem Text="Tiếng việt" Value="vi" />
                                            <ext:ListItem Text="Tiếng Anh" Value="en" />
                                        </Items>
                                        <Listeners>
                                            <Change Handler="#{stData}.reload();" />
                                        </Listeners>
                                    </ext:ComboBox>                                    
                                </td>
                                <td>
                                    <br />
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
                <ext:Panel runat="server" Layout="FitLayout" Title="Danh sách di vật, cổ vật, bảo vật quốc gia" Margins="5">
                    <Content>
                        <ext:GridPanel ID="gvData" runat="server"
                            Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoExpandColumn="Ten">
                            <Store>
                                <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stData_RefreshData">
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                        <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="Filter" Value="#{txtTen}.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Proxy>
                                        <ext:PageProxy />
                                    </Proxy>
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="Ten" />
                                                <ext:RecordField Name="TenKhac" />
                                                <ext:RecordField Name="MaSo" />
                                                <ext:RecordField Name="TenLoai" />
                                                <ext:RecordField Name="TenThoiky" />
                                                <ext:RecordField Name="NienDai" />
                                                <ext:RecordField Name="NgayGiamDinh" Type="Date" />
                                                <ext:RecordField Name="BaoTang" />
                                                <ext:RecordField Name="TenAnh" />
                                                <ext:RecordField Name="DiaDiemPhatHien" />
                                                <ext:RecordField Name="TrangThai" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="NgayGiamDinh" Direction="DESC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="30" />
                                    <ext:Column ColumnID="TenAnh" DataIndex="TenAnh" Header="Hình ảnh" Width="80" Align="Center">
                                        <Renderer Fn="GetImage" />
                                    </ext:Column>
                                    <ext:Column ColumnID="HoTen" DataIndex="Ten" Header="Tên di vật, cổ vật, bảo vật quốc gia" />
                                    <ext:Column ColumnID="MaSo" DataIndex="MaSo" Header="Mã số" Width="120" />
                                    <ext:Column ColumnID="TenLoai" DataIndex="TenLoai" Header="Phân loại" Width="150" />
                                    <ext:Column ColumnID="TenThoiky" DataIndex="TenThoiky" Width="100" Header="Thời kỳ" />
                                    <ext:Column ColumnID="BaoTang" DataIndex="BaoTang" Width="150" Header="Nơi lưu trữ" />
                                    <ext:Column ColumnID="DiaDiemPhatHien" DataIndex="DiaDiemPhatHien" Header="Địa điểm phát hiện" Width="150" />
                                    <ext:CheckColumn DataIndex="TrangThai" Header="Duyệt" Width="40" />
                                    <ext:CommandColumn Width="130">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Delete" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                <ToolTip Text="Edit" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="Accept" CommandName="Active">
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
                                        <RowSelect Handler="#{btnDelete}.enable();#{btnExportDeTail}.enable();#{btnShow}.enable();" />
                                        <RowDeselect Handler="if (!#{gvData}.hasSelection()) {#{btnDelete}.disable();#{btnExportDeTail}.disable();#{btnShow}.disable();}" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <DirectEvents>
                                <DblClick OnEvent="gvData_DbClick" />
                            </DirectEvents>
                            <Listeners>
                                <Command Handler="fnCommand(command, record.data.ID,record.data.TrangThai);" />
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
                            <%-- <Listeners>
                                <Click Fn="saveData" />
                            </Listeners>--%>
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
                        <Hide Handler="if(hdMsg.getValue()=='ok'){hdMsg.setValue('');#{stData}.reload();Ext.Msg.alert('Đã cập nhật thành công');}" />
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
