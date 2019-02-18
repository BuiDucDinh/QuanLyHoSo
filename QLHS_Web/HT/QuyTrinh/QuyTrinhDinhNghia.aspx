<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuyTrinhDinhNghia.aspx.cs" Inherits="HT_QuyTrinhDinhNghia" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap1 = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!----Goi ung dung ext------>

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
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="150" Title="Thông tin cập nhật">
            <Content>

                <ext:Panel ID="Panel1" runat="server" Layout="FormLayout"  LabelWidth="150" Width="780" Padding="10">
                    <Content>
                        <ext:Hidden runat="server" ID="hdID" />
                        <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên quy trình" Width="600" />
                        <ext:ComboBox ID="cbLoaiQuyTrinh" runat="server" FieldLabel="Loại quy trình, thủ tục" Width="600" EmptyText="--Chọn quy trình" Mode="Local"
                            Editable="false"
                            DisplayField="TenLoai"
                            ValueField="ID"
                            TypeAhead="true"
                            ForceSelection="true"
                            Resizable="true" SelectedIndex="0"
                            SelectOnFocus="true">
                            <Store>
                                <ext:Store runat="server" ID="stLoaiQuyTrinh">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="TenLoai" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:Checkbox runat="server" ID="ckbTrangThai" FieldLabel="Trạng thái sử dụng" />
                        <ext:DateField runat="server" ID="dtNgayHieuLuc" FieldLabel="Ngày hiệu lực" Width="600" Format="d/M/yyyy" Disabled="true" />
                        <ext:ComboBox runat="server" ID="cbDoituong" FieldLabel="Đối tượng thực hiện" Width="600">
                            <Items>
                                <ext:ListItem Value="Tổ chức" Text="Tổ chức" />
                                <ext:ListItem Value="Cá nhân" Text="Cá nhân" />
                            </Items>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbCoQuan" runat="server" FieldLabel="Cơ quan thực hiện" Width="400" EmptyText="--Chọn cơ quan thực hiện--"
                            Editable="false"
                            DisplayField="TenCoQuan"
                            ValueField="CoQuanID"
                            TypeAhead="true"
                            ForceSelection="true"
                            Resizable="true"
                            SelectOnFocus="true">
                            <Store>
                                <ext:Store runat="server" ID="stCoQuan">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="CoQuanID" />
                                                <ext:RecordField Name="TenCoQuan" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                    </Content>
                    <Buttons>
                        <ext:Button runat="server" ID="btnLoc" Icon="Find" Text="Lọc">
                            <Listeners>
                                <Click Handler="#{stData}.reload()" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Panel>
                <ext:Panel runat="server" Border="false">
                    <Items>
                        <ext:GridPanel ID="gvData" runat="server" Title="" Margins="0 0 5 5" Header="false"
                            Icon="UserSuit" AutoHeight="true" AutoExpandColumn="Ten">
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
                                                <ext:RecordField Name="Ten" SortDir="ASC" />
                                                <ext:RecordField Name="TrangThai" />
                                                <ext:RecordField Name="LoaiQuyTrinh" />
                                                <ext:RecordField Name="NgayHieuLuc" />
                                                <ext:RecordField Name="NgayTao" />
                                                <ext:RecordField Name="NguoiTao" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="NgayHieuLuc" Direction="ASC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" />
                                    <ext:Column ColumnID="Ten" DataIndex="Ten" Header="Tên thủ tục" Width="150" />
                                    <ext:Column ColumnID="LoaiQuyTrinh" DataIndex="LoaiQuyTrinh" Header="Loại" Width="150" />
                                    <ext:CheckColumn ColumnID="TrangThai" DataIndex="TrangThai" Header="Trạng thái" Width="70" />

                                    <ext:CommandColumn Width="300" Header="Action">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Delete" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                <ToolTip Text="Edit" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="Find" CommandName="Show" Text="Xem">
                                                <ToolTip Text="Xem luồng xử lý" />
                                            </ext:GridCommand>
                                            <ext:GridCommand Icon="ApplicationAdd" CommandName="CreateTheard" Text="Tạo luồng xử lý">
                                                <ToolTip Text="Tạo luồng xử lý" />
                                            </ext:GridCommand>
                                        </Commands>
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
                                <DblClick OnEvent="gvData_DbClick">
                                </DblClick>
                            </DirectEvents>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="30" DisplayInfo="true"
                                    DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                            </BottomBar>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>

            </Content>
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
                                <Click OnEvent="btnExport_Click" IsUpload="true" Before="ExportYap1()">
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
                    DefaultButton="0" Border="false" AutoScroll="true" Maximizable="true" Collapsible="true"
                    MinWidth="900" Height="550" Modal="true" Padding="3" Resizable="false">
                    <Listeners>
                        <Hide Handler="if(hdMsg.getValue()=='ok'){hdMsg.setValue('');stData.reload();Ext.Msg.alert('Thông báo','Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg" />
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
