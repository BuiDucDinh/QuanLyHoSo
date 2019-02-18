<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_NguoiDung.aspx.cs" Inherits="HT_NguoiDung"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">
    var sexRenderer = function (value) {
        return (value == true ? 'Nam' : 'Nữ');
    };
</script>
<script type="text/javascript">
    var ExportYap = function () {
        Ext.net.Mask.show();
        Ext.net.Mask.hide.defer(500);
    };
</script>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <asp:ObjectDataSource ID="odsData" runat="server" OnSelected="odsData_Selected" SelectMethod="Page_By_Filter"
        TypeName="QLHS_Logic.Sys_Common">
        <SelectParameters>
            <asp:Parameter Name="Start" Type="Int32" />
            <asp:Parameter Name="Limit" Type="Int32" />
            <asp:Parameter Name="WhereString" />
            <asp:Parameter Name="SortString" />
            <asp:Parameter Name="Count" Direction="Output" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="150">
        <Items>
            <ext:TextField ID="txtMa_Nguoi_Dung" runat="server" Hidden="true" />
            <ext:TextField ID="txtTen_Dang_Nhap" runat="server" FieldLabel="Tên đăng nhập" Width="350"
                Margins="2" IndicatorText="*" />
            <ext:TextField ID="txtMat_Khau" runat="server" FieldLabel="Mật khẩu" Width="350"
                Margins="2" IndicatorText="*" InputType="Password" />
            <ext:TextField ID="txtHo_Ten" runat="server" FieldLabel="Họ và tên" Width="350" Margins="2"
                IndicatorText="*" />
            <ext:TextField ID="txtHom_Thu" runat="server" FieldLabel="Email" Width="350" Margins="2" />
            <ext:TextField ID="txtDien_Thoai" runat="server" FieldLabel="Số điện thoại" Width="350"
                Margins="2" />
            <ext:ComboBox ID="cboMa_Don_Vi" runat="server" FieldLabel="Đơn vị" Width="350" EmptyText="--Chọn đơn vị--"
                DisplayField="Ten_Don_Vi" ValueField="Ma_Don_Vi" Mode="Local" EnableKeyEvents="true"
                IndicatorText="Nhấn F2 để chọn đơn vị">
                <Store>
                    <ext:Store ID="dsDon_Vi" runat="server">
                        <Reader>
                            <ext:JsonReader>
                                <Fields>
                                    <ext:RecordField Name="Ten_Don_Vi" SortDir="ASC" />
                                    <ext:RecordField Name="Ma_Don_Vi" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <Listeners>
                    <KeyDown Handler=" if(e.getKey() == e.F2){Ext.net.DirectMethods.btnUrl_Click('All');}" />
                </Listeners>
            </ext:ComboBox>
            <%--<ext:DateField ID="dtpBirthDay" runat="server" FieldLabel="Ngày tháng năm sinh" Format="dd/MM/yyyy" />--%>
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
            <ext:GridPanel ID="gridData" runat="server" Title="Danh sách dữ liệu" Margins="0 0 5 5"
                Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoWidth="true">
                <Store>
                    <ext:Store ID="dsData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="dsData_RefreshData">
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
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="Ma_Nguoi_Dung" DataIndex="Ma_Nguoi_Dung" Header="ID" Hidden="true" />
                        <ext:Column ColumnID="Ten_Dang_Nhap" DataIndex="Ten_Dang_Nhap" Header="Tên đăng nhập"
                            Width="200" />
                        <ext:Column ColumnID="Ho_Ten" DataIndex="Ho_Ten" Header="Họ tên" Width="200" />
                        <ext:Column ColumnID="Hom_Thu" DataIndex="Hom_Thu" Header="Email" Width="200" />
                        <ext:Column ColumnID="Dien_Thoai" DataIndex="Dien_Thoai" Header="Số điện thoại" />
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
                <DirectEvents>
                    <DblClick OnEvent="grid_DbClick">
                    </DblClick>
                </DirectEvents>
                <BottomBar>
                    <ext:PagingToolbar ID="pageData" runat="server" PageSize="30" DisplayInfo="true"
                        DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                </BottomBar>
                <LoadMask ShowMask="true" />
            </ext:GridPanel>
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
                    <ext:Button ID="btnVaiTro" runat="server" Text="Quyền vai trò" Icon="UserAlert">
                        <DirectEvents>
                            <Click OnEvent="btnVaiTro_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="data" Value="#{gridData}.getRowsValues()" Mode="Raw"
                                        Encode="true" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnExport" runat="server" Text="Xuất báo cáo" Icon="Report">
                        <DirectEvents>
                            <Click OnEvent="btnExport_Click" IsUpload="true" Before="ExportYap()">
                                <ExtraParams>
                                    <ext:Parameter Name="data" Value="#{gridData}.getRowsValues()" Mode="Raw" Encode="true" />
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
    <ext:Window ID="winHT_Don_Vi_YTe" runat="server" Icon="NoteEdit" Title="Chọn đơn vị y tế"
        Height="400" Width="600" Modal="true" Hidden="true" Layout="FormLayout" CloseAction="Hide"
        Closable="true">
        <DirectEvents>
            <Hide OnEvent="winHT_Don_Vi_YTe_Hide">
            </Hide>
        </DirectEvents>
    </ext:Window>
    <ext:Window ID="winVaiTro" runat="server" Icon="NoteEdit" Title="Quyền vai trò" Height="400"
        Width="600" Modal="true" Hidden="true" Layout="FormLayout" CloseAction="Hide"
        Closable="true">
    </ext:Window>
    </form>
</body>
</html>
