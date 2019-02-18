<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSAnpham.aspx.cs"
    Inherits="DSVH_Quanlyvanban_DSanpham" %>

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
        var myRenderer = function (value, metadata, record) {
            var tpl = "<img src='{0}' style='height:100px;width:100px'/>";
            return String.format(tpl, '/FileUpload/Images/' + value);
        };
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
        <ext:FormPanel ID="frmTKCapnhatbaiviet" runat="server" AutoWidth="true" LabelWidth="170"
            Layout="FormLayout" AutoHeight="true">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click">
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
            <Items>
                <ext:Panel ID="TableLayout1" runat="server" Columns="1" Padding="10">
                    <Content>
                        <ext:Hidden runat="server" ID="hdRole" />
                        <ext:TextField runat="server" ID="txtMaanpham" FieldLabel="Mã ấn phẩm" Width="400" Margins="2" IndicatorText="*" />

                        <ext:TextField runat="server" ID="txtTenanpham" FieldLabel="Tên ấn phẩm" Width="400" Margins="2" IndicatorText="*" />
                        <ext:ComboBox ID="cbDanhmuc" runat="server" FieldLabel="Danh mục ấn phẩm" Width="400" DisplayField="TenDanhMuc" ValueField="DanhMucID"
                            EmptyText="--Chọn danh mục ấn phẩm--" AllowBlank="true" SelectedIndex="0">
                            <Store>
                                <ext:Store runat="server" ID="stDanhmuc">
                                    <Reader>
                                        <ext:JsonReader IDProperty="DanhMucID">
                                            <Fields>
                                                <ext:RecordField Name="DanhMucID" />
                                                <ext:RecordField Name="TenDanhMuc" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbDiSan" runat="server" FieldLabel="Di sản văn hóa" Width="400" DisplayField="TenDiSan" ValueField="DiSanID"
                            EmptyText="--Chọn di sản văn hóa--" AllowBlank="true" SelectedIndex="0">
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
                        </ext:ComboBox>

                        <ext:ComboBox ID="cbNamXB" runat="server" FieldLabel="Năm xuất bản" ValueField="Nam" DisplayField="Nam"
                            Width="400" EmptyText="--Chọn năm xuất bản--" AllowBlank="true" SelectedIndex="0">
                            <Store>
                                <ext:Store runat="server" ID="stNamXB">
                                    <Reader>
                                        <ext:ArrayReader>
                                            <Fields>
                                                <ext:RecordField Name="Nam" />
                                            </Fields>
                                        </ext:ArrayReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ComboBox runat="server" ID="cmbLang" FieldLabel="Ngôn ngữ" SelectedIndex="0" Width="400">
                            <Items>
                                <ext:ListItem Text="Tiếng việt" Value="vi" />
                                <ext:ListItem Text="Tiếng anh" Value="en" />
                            </Items>

                        </ext:ComboBox>
                        <table style="margin-left: 100px">
                            <tr>
                                <td>
                                    <ext:Button runat="server" ID="btnSearch" Icon="Find" Text="Lọc" ToggleGroup="Group1">
                                        <DirectEvents>
                                            <Click OnEvent="btnSearch_Click" />
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

                        <ext:GridPanel ID="gvData" runat="server" Title="Danh sách dữ liệu" Margins="0 0 5 5"
                            Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoWidth="true" AutoExpandColumn="TenSach">
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
                                                <ext:RecordField Name="MaSach" />
                                                <ext:RecordField Name="TenSach" />
                                                <ext:RecordField Name="TacGia" />
                                                <ext:RecordField Name="DiSan" />
                                                <ext:RecordField Name="SoTrang" />
                                                <ext:RecordField Name="AnhDaiDien" />
                                                <ext:RecordField Name="HinhAnh" />
                                                <ext:RecordField Name="NhaXB" />
                                                <ext:RecordField Name="Duyet" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="ID" Direction="ASC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="HinhAnh" DataIndex="HinhAnh" Header="Ảnh">
                                        <Renderer Fn="myRenderer" />
                                    </ext:Column>
                                    <ext:Column ColumnID="MaSach" DataIndex="MaSach" Header="Mã sách" />
                                    <ext:Column ColumnID="TenSach" DataIndex="TenSach" Header="Tên sách" Width="400" />
                                    <ext:Column ColumnID="TacGia" DataIndex="TacGia" Header="Tác giả" Width="150" />
                                    <ext:Column ColumnID="NhaXB" DataIndex="NhaXB" Header="Nhà xuất bản" Width="150" />
                                    <ext:Column ColumnID="SoTrang" DataIndex="SoTrang" Header="Số trang" Width="60" />
                                    <ext:Column ColumnID="DiSan" DataIndex="DiSan" Header="Di sản" Width="200" />
                                    <ext:CheckColumn DataIndex="Duyet" Header="Duyệt" Width="50" />
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
                                <Command Handler="fnCommand(command, record.data.ID, record.data.Duyet);" />
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
                <ext:Panel runat="server">
                    <Items>
                        <ext:Window runat="server" ID="wdDetail" Hidden="true"
                            DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
                            MinWidth="900" Height="550" Modal="true" Padding="3" Resizable="false">
                            <%-- <Listeners>
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
            </Items>
        </ext:FormPanel>
    </form>
</body>
</html>
