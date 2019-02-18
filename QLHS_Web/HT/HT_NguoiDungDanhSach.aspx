<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_NguoiDungDanhSach.aspx.cs"
    Inherits="HT_HT_NguoiDungDanhSach" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <asp:ObjectDataSource ID="odsDonVi" runat="server" OnSelected="odsDonVi_Selected"
            SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
            <SelectParameters>
                <asp:Parameter Name="Start" Type="Int32" />
                <asp:Parameter Name="Limit" Type="Int32" />
                <asp:Parameter Name="WhereString" />
                <asp:Parameter Name="SortString" />
                <asp:Parameter Name="Count" Direction="Output" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <ext:Store ID="stCanbo" runat="server" AutoLoad="true" OnRefreshData="stCanbo_RefreshData">
            <Reader>
                <ext:JsonReader IDProperty="CanBoID">
                    <Fields>
                        <ext:RecordField Name="CanBoID" />
                        <ext:RecordField Name="HoTen" />
                        <ext:RecordField Name="ChucVu" />
                        <ext:RecordField Name="Username" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                <ext:Parameter Name="limit" Value="10" Mode="Raw" />
            </AutoLoadParams>
        </ext:Store>

        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Layout="border" Border="false" Region="Center">
                    <Items>
                        <ext:Panel ID="FormPanel2" runat="server" Region="Center" Margins="0 0 0 0" Frame="true"
                            Title="Danh sách toàn bộ đơn vị" Icon="User" Layout="FitLayout">
                            <Items>
                                <ext:GridPanel ID="gridDonVi" runat="server" Layout="FitLayout" Height="300" AutoScroll="true" AutoExpandColumn="TenCoQuan">
                                    <Store>

                                        <ext:Store ID="dsDonVi" runat="server" RemoteSort="true" DataSourceID="odsDonVi"
                                            OnRefreshData="dsDonVi_RefreshData">
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
                                                <ext:JsonReader IDProperty="CoQuanID">
                                                    <Fields>
                                                        <ext:RecordField Name="CoQuanID" SortDir="ASC" />
                                                        <ext:RecordField Name="TenCoQuan" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                            <SortInfo Field="TenCoQuan" Direction="ASC" />
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel1" runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="CoQuanID" DataIndex="CoQuanID" Header="Mã đơn vị">
                                            </ext:Column>
                                            <ext:Column ColumnID="TenCoQuan" DataIndex="TenCoQuan" Header="Đơn vị" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                            <DirectEvents>
                                                <RowSelect OnEvent="RowSelect" Buffer="100">
                                                    <EventMask ShowMask="true" />
                                                    <ExtraParams>
                                                        <ext:Parameter Name="Ma_Don_Vi" Value="this.getSelected().id" Mode="Raw" />
                                                    </ExtraParams>
                                                </RowSelect>
                                            </DirectEvents>
                                            <Listeners>
                                                <RowSelect handler="#{txtMaDonVi}.setValue(this.getSelected().id);#{cbCanbo}.clearValue(); #{stCanbo}.reload()" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:Hidden ID="txtFilter" runat="server" AutoDataBind="true">
                                                    <Listeners>
                                                        <Change Handler="#{pageDonVi}.changePage(1);" Delay="30" />
                                                    </Listeners>
                                                </ext:Hidden>
                                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                                <ext:Hidden runat="server" ID="txtMaDonVi" />
                                                <ext:DisplayField ID="DisplayField1" runat="server" FieldLabel="Tên đơn vị" LabelAlign="Right" />
                                                <ext:TriggerField ID="txtSearch" runat="server" Width="200" EmptyText="Thông tin tìm kiếm"
                                                    EnableKeyEvents="true">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Search" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <TriggerClick Handler="#{txtFilter}.setValue(this.getValue()); " />
                                                        <KeyDown Handler=" if(e.getKey() == e.ENTER){#{txtFilter}.setValue(this.getValue());}" />
                                                    </Listeners>
                                                </ext:TriggerField>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="pageDonVi" runat="server" PageSize="30" DisplayInfo="true"
                                            DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                                    </BottomBar>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel3" runat="server" Region="East" Split="true" Margins="0 0 0 0"
                            Frame="true" Title="Danh sách người dùng thuộc đơn vị" Width="500" Icon="User"
                            DefaultAnchor="100%">
                            <Items>
                                <ext:GridPanel ID="gridData" runat="server" Layout="FitLayout" Height="300" AutoScroll="true">
                                    <Store>
                                        <ext:Store ID="dsData" runat="server">
                                            <Reader>
                                                <ext:JsonReader IDProperty="Ma_Nguoi_Dung">
                                                    <Fields>
                                                        <ext:RecordField Name="Ma_Nguoi_Dung" />
                                                        <ext:RecordField Name="Ten_Dang_Nhap" />
                                                        <ext:RecordField Name="Ho_Ten" />
                                                        <ext:RecordField Name="Hom_Thu" />
                                                        <ext:RecordField Name="Dien_Thoai" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                            <SortInfo Field="Ma_Nguoi_Dung" Direction="ASC" />
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel3" runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="Ma_Nguoi_Dung" DataIndex="Ma_Nguoi_Dung" Header="ID" Hidden="true" />
                                            <ext:Column ColumnID="Ten_Dang_Nhap" DataIndex="Ten_Dang_Nhap" Header="Tên đăng nhập"
                                                Width="100" />
                                            <ext:Column ColumnID="Ho_Ten" DataIndex="Ho_Ten" Header="Họ tên" Width="200" />
                                            <ext:Column ColumnID="Hom_Thu" DataIndex="Hom_Thu" Header="Email" Width="200" />
                                            <ext:Column ColumnID="Dien_Thoai" DataIndex="Dien_Thoai" Header="Số điện thoại" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true">
                                            <DirectEvents>
                                                <RowSelect OnEvent="RowSelectNguoiDung" Buffer="100">
                                                    <EventMask ShowMask="true" />
                                                    <ExtraParams>
                                                        <ext:Parameter Name="Ma_Nguoi_Dung" Value="this.getSelected().id" Mode="Raw" />
                                                    </ExtraParams>
                                                </RowSelect>
                                            </DirectEvents>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar2" runat="server">
                                            <Items>
                                                <ext:Button ID="btnDelete" Text="Xóa" Icon="BulletCross" runat="server">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnDelete_Click">
                                                            <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="pageData" runat="server" PageSize="30" DisplayInfo="true"
                                            DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                                    </BottomBar>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel2" runat="server" Layout="border" Border="false" Region="South"
                    Height="350">
                    <Items>
                        <ext:FormPanel ID="FormPanel1" runat="server" Region="Center" Margins="0 0 0 0" Frame="true" AutoScroll="true"
                            Title="Thông tin người dùng chi tiết" Icon="User">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar3" runat="server">
                                    <Items>
                                        <ext:Button ID="btnInsert" Text="Thêm mới" Icon="Add" runat="server">
                                            <DirectEvents>
                                                <Click OnEvent="btnUpdate_Click">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnUpdate" Text="Cập nhật" Icon="ApplicationEdit" runat="server">
                                            <DirectEvents>
                                                <Click OnEvent="btnUpdate_Click">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:TextField ID="txtMa_Nguoi_Dung" runat="server" Hidden="true" />
                                <ext:TextField ID="txtTen_Dang_Nhap" runat="server" FieldLabel="Tên đăng nhập" Width="350"
                                    Margins="2" IndicatorText="*" />
                                <ext:TextField ID="txtMat_Khau" runat="server" FieldLabel="Mật khẩu" Width="350"
                                    Margins="2" IndicatorText="*" InputType="Password" />

                                <ext:ComboBox
                                    ID="cbCanbo" FieldLabel="Cán bộ"
                                    runat="server"
                                    EmptyText="Chọn cán bộ"
                                    TypeAhead="true"
                                    ForceSelection="true"
                                    StoreID="stCanbo"
                                    Mode="Local"
                                    DisplayField="HoTen"
                                    ValueField="CanBoID"
                                    MinChars="1"
                                    ListWidth="300"
                                    PageSize="10"
                                    ItemSelector="tr.list-item">
                                    <Template ID="Template1" runat="server">
                                        <Html>
                                            <tpl for=".">
						<tpl if="[xindex] == 1">
							<table class="cbStates-list">
								<tr>
									<th>Tên</th>
									<th>Chức vụ</th>
									<th>Tài khoản</th>
								</tr>
						</tpl>
						<tr class="list-item">
							<td style="padding:3px 5px">{HoTen}</td>
							<td>{ChucVu}</td>
                            <td>{Username}</td>
						</tr>
						<tpl if="[xcount-xindex]==0">
							</table>
						</tpl>
					</tpl>
                                        </Html>
                                    </Template>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.focus().clearValue(); trigger.hide();}" />
                                        <Select Handler="this.triggers[0].show();" />
                                    </Listeners>
                                </ext:ComboBox>

                                <ext:TextField ID="txtHo_Ten" runat="server" FieldLabel="Họ và tên" Width="350" Margins="2" EmptyText="Bỏ qua nếu đã chọn cán bộ" />
                                <ext:TextField ID="txtHom_Thu" runat="server" FieldLabel="Email" Width="350" Margins="2" EmptyText="Bỏ qua nếu đã chọn cán bộ" />
                                <ext:TextField ID="txtDien_Thoai" runat="server" FieldLabel="Số điện thoại" Width="350" Margins="2" EmptyText="Bỏ qua nếu đã chọn cán bộ" />

                                <ext:Checkbox ID="chkDuoc_Kich_Hoat" runat="server" FieldLabel="Được kích hoạt" Margins="2" />
                                <ext:ComboBox ID="cboHinh_Nen" runat="server" FieldLabel="Giao diện" EmptyText="--Chọn giao diện--"
                                    Editable="false" Width="150">
                                    <Items>
                                        <ext:ListItem Text="Mặc định" Value="1" />
                                        <ext:ListItem Text="Xám trắng" Value="2" />
                                        <ext:ListItem Text="Xám đen" Value="3" />
                                        <ext:ListItem Text="Tím đen" Value="4" />
                                    </Items>
                                </ext:ComboBox>
                            </Items>
                        </ext:FormPanel>
                        <ext:Panel ID="Panel4" runat="server" Region="East" Split="true" Margins="0 0 0 0"
                            Frame="true" Title="Vai trò" Width="500" Icon="User" DefaultAnchor="100%">
                            <Items>
                                <ext:ColumnLayout ID="ColumnLayout2" runat="server">
                                    <Columns>
                                        <ext:LayoutColumn ColumnWidth="0.5">
                                            <ext:GridPanel ID="gridKhongVaiTro" runat="server" Title="" Margins="0 0 5 5" Icon="UserSuit"
                                                EnableDragDrop="false" AutoExpandColumn="Ma_Vai_Tro" Height="400" AutoScroll="true">
                                                <Store>
                                                    <ext:Store ID="dsKhongVaiTro" runat="server">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="Ma_Vai_Tro">
                                                                <Fields>
                                                                    <ext:RecordField Name="Ma_Vai_Tro" SortDir="ASC" />
                                                                    <ext:RecordField Name="Ten_Vai_Tro" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <ColumnModel ID="ColumnModel2" runat="server">
                                                    <Columns>
                                                        <ext:Column ColumnID="Ma_Vai_Tro" Header="Ma_Vai_Tro" Hidden="true" />
                                                        <ext:Column ColumnID="Ten_Vai_Tro" DataIndex="Ten_Vai_Tro" Header="Vai trò không có quyền truy nhập"
                                                            Width="250" />
                                                    </Columns>
                                                </ColumnModel>
                                                <SelectionModel>
                                                    <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" />
                                                </SelectionModel>
                                            </ext:GridPanel>
                                        </ext:LayoutColumn>
                                        <ext:LayoutColumn>
                                            <ext:Panel ID="Panel5" runat="server" Width="35" BodyStyle="background-color: transparent;"
                                                Border="false" Layout="Anchor">
                                                <Items>
                                                    <ext:Panel ID="Panel6" runat="server" Border="false" BodyStyle="background-color: transparent;"
                                                        AnchorVertical="40%" />
                                                    <ext:Panel ID="Panel7" runat="server" Border="false" BodyStyle="background-color: transparent;"
                                                        Padding="5">
                                                        <Items>
                                                            <ext:Button ID="btnVaiTroThem" runat="server" Icon="ResultsetNext" StyleSpec="margin-bottom:2px;">
                                                                <DirectEvents>
                                                                    <Click OnEvent="btnVaiTroThem_Click">
                                                                    </Click>
                                                                </DirectEvents>
                                                                <ToolTips>
                                                                    <ext:ToolTip ID="ToolTip4" runat="server" Title="Thêm" Html="Thêm vai trò truy nhập" />
                                                                </ToolTips>
                                                            </ext:Button>
                                                            <ext:Button ID="btnVaiTroBo" runat="server" Icon="ResultsetPrevious" StyleSpec="margin-bottom:2px;">
                                                                <DirectEvents>
                                                                    <Click OnEvent="btnVaiTroBo_Click">
                                                                    </Click>
                                                                </DirectEvents>
                                                                <ToolTips>
                                                                    <ext:ToolTip ID="ToolTip5" runat="server" Title="Loại bỏ" Html="Loại bỏ vai trò truy nhập" />
                                                                </ToolTips>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:Panel>
                                                </Items>
                                            </ext:Panel>
                                        </ext:LayoutColumn>
                                        <ext:LayoutColumn ColumnWidth="0.5">
                                            <ext:GridPanel ID="gridCoVaiTro" runat="server" Title="" Margins="0 0 5 5" Icon="UserSuit"
                                                EnableDragDrop="false" AutoExpandColumn="Ten_Vai_Tro" Height="400" AutoScroll="true">
                                                <Store>
                                                    <ext:Store ID="dsCoVaiTro" runat="server">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="Ma_Nguoi_Dung_Vai_Tro">
                                                                <Fields>
                                                                    <ext:RecordField Name="Ma_Nguoi_Dung_Vai_Tro" SortDir="ASC" />
                                                                    <ext:RecordField Name="Ma_Vai_Tro" />
                                                                    <ext:RecordField Name="Ten_Vai_Tro" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <ColumnModel ID="ColumnModel4" runat="server">
                                                    <Columns>
                                                        <ext:Column ColumnID="Ma_Nguoi_Dung_Vai_Tro" Header="Ma_Nguoi_Dung_Vai_Tro" Hidden="true" />
                                                        <ext:Column ColumnID="Ma_Vai_Tro" Header="Ma_Vai_Tro" Hidden="true" />
                                                        <ext:Column ColumnID="Ten_Vai_Tro" DataIndex="Ten_Vai_Tro" Header="vai trò có quyền truy nhập"
                                                            Width="350" />
                                                    </Columns>
                                                </ColumnModel>
                                                <SelectionModel>
                                                    <ext:RowSelectionModel ID="RowSelectionModel4" runat="server" />
                                                </SelectionModel>
                                            </ext:GridPanel>
                                        </ext:LayoutColumn>
                                    </Columns>
                                </ext:ColumnLayout>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
