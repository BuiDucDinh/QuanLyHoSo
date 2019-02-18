<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoiLuuTru.aspx.cs" Inherits="NghiepVu_Danhmuc_NoiLuuTru" %>

<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Scripts/jquery-1.7.1.min.js"></script>
    <script src="/Scripts/jquery.shorten.1.0.js"></script>
    <link href="/css/other.css" rel="stylesheet" />
    <script type="text/javascript">
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
    <ext:XScript runat="server">
        <script type="text/javascript">
            var ExportYap = function () {
                Ext.net.Mask.show();
                Ext.net.Mask.hide.defer(200);
            };
                         
            var applyFilter = function (field) {                
                var store = #{gvData}.getStore();
                store.suspendEvents();
                store.filterBy(getRecordFilter());                                
                store.resumeEvents();
                #{gvData}.getView().refresh(false);
            };
             
            var clearFilter = function () {
                #{cbSTen}.reset();
                #{cbSLoaiBaoTang}.reset();
                #{cbSTinh}.reset();
                #{cbSHuyen}.reset();
                #{txtSDienthoai}.reset();
                #{txtSEmail}.reset();        
                
                #{stData}.clearFilter();
            }
 
            var filterString = function (value, dataIndex, record) {
                var val = record.get(dataIndex);
                
                if (typeof val != "string") {
                    return value.length == 0;
                }
                
                return val.toLowerCase().indexOf(value.toLowerCase()) > -1;
            };

            var filterNumber = function (value, dataIndex, record) {
                var val = record.get(dataIndex);
 
                if (!Ext.isEmpty(value, false) && val != value) {
                    return false;
                }
                
                return true;
            };
            
            var getRecordFilter = function () {
                var f = [];
 
                f.push({
                    filter: function (record) {     
                        return filterString(#{cbSTen}.getValue(), "Ten", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {     
                        return filterString(#{cbSLoaiBaoTang}.getValue(), "TenLoaiBaoTang", record);
                    }
                });

                f.push({
                    filter: function (record) {                       
                        return filterString(#{cbSTinh}.getRawValue(), "ThuocTinh", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterString(#{cbSHuyen}.getRawValue(), "ThuocHuyen", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterString(#{txtSDienthoai}.getValue(), "DienThoai", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterString(#{txtsEmail}.getValue(), "Email", record);
                    }
                });
 
                var len = f.length;
                 
                return function (record) {
                    for (var i = 0; i < len; i++) {
                        if (!f[i].filter(record)) {
                            return false;
                        }
                    }
                    return true;
                };
            };
        </script>
    </ext:XScript>
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
        <!----Goi ung dung ext------>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel runat="server" LabelWidth="100" Padding="10">
            <Content>
                <ext:Hidden runat="server" ID="hdRole" />
                <ext:Hidden runat="server" ID="hdID" />
                <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên bảo tàng" Width="350" Margins="2" IndicatorText="*" />
                <ext:TextField ID="txtEngName" runat="server" FieldLabel="Tên tiếng anh" Width="350" Margins="2" IndicatorText="*" />

                <ext:ComboBox ID="cmbLoaibaotang" runat="server" Width="350" FieldLabel="Loại bảo tàng"
                    DisplayField="TenLoai" ValueField="ID" SelectOnFocus="true">
                    <Store>
                        <ext:Store runat="server" ID="stLoaiBaoTang" AutoLoad="true">
                            <DirectEventConfig>
                                <EventMask ShowMask="false" />
                            </DirectEventConfig>
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="TenLoai" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.triggers[0].show();" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();}" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextField ID="txtWebsite" runat="server" FieldLabel="Website" Width="350" />
                <ext:TextField ID="txtDiachi" runat="server" FieldLabel="Địa chỉ cụ thể" Width="660" />
                <table>
                    <tr>
                        <td style="width: 20%">
                            <ext:TextField ID="txtDienthoai" runat="server" FieldLabel="Điện thoại" Width="300" />
                        </td>
                        <td style="width: 20%">
                            <ext:TextField ID="txtFax" runat="server" FieldLabel="Fax" Width="300" />
                        </td>
                        <td style="width: 20%">
                            <ext:TextField ID="txtEmail" runat="server" FieldLabel="Email" Width="300" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%">
                            <ext:ComboBox ID="cmbThuocTinh" runat="server" Width="300" SelectedIndex="0" FieldLabel="Thuộc tỉnh"
                                DisplayField="Ten_Tinh" ValueField="Ma_Tinh" SelectOnFocus="true">
                                <Store>
                                    <ext:Store runat="server" ID="stTinh" AutoLoad="true">
                                        <DirectEventConfig>
                                            <EventMask ShowMask="false" />
                                        </DirectEventConfig>
                                        <Reader>
                                            <ext:JsonReader IDProperty="Ma_Tinh">
                                                <Fields>
                                                    <ext:RecordField Name="Ma_Tinh" />
                                                    <ext:RecordField Name="Ten_Tinh" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Listeners>
                                    <Select Handler="#{cmbThuocHuyen}.clearValue(); #{stHuyen}.reload();#{stData}.reload();" />
                                </Listeners>
                            </ext:ComboBox>
                        </td>
                        <td style="width: 20%">
                            <ext:ComboBox ID="cmbThuocHuyen" runat="server" Width="300" FieldLabel="Thuộc huyện"
                                DisplayField="Ten_Huyen" ValueField="Ma_Huyen" SelectedIndex="0">
                                <Store>
                                    <ext:Store runat="server" ID="stHuyen" AutoLoad="true" OnRefreshData="stHuyen_RefreshData">
                                        <DirectEventConfig>
                                            <EventMask ShowMask="false" />
                                        </DirectEventConfig>
                                        <Reader>
                                            <ext:JsonReader IDProperty="Ma_Huyen">
                                                <Fields>
                                                    <ext:RecordField Name="Ma_Huyen" />
                                                    <ext:RecordField Name="Ten_Huyen" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Listeners>
                                    <Select Handler="#{cmbThuocXa}.clearValue(); #{stXa}.reload();#{stData}.reload();" />
                                </Listeners>
                            </ext:ComboBox>
                        </td>
                        <td style="width: 20%">
                            <ext:ComboBox ID="cmbThuocXa" runat="server" Width="300" FieldLabel="Thuộc xã"
                                DisplayField="Ten_Xa" ValueField="Ma_Xa" SelectedIndex="0">
                                <Store>
                                    <ext:Store runat="server" ID="stXa" AutoLoad="true" OnRefreshData="stXa_RefreshData">
                                        <DirectEventConfig>
                                            <EventMask ShowMask="false" />
                                        </DirectEventConfig>
                                        <Reader>
                                            <ext:JsonReader IDProperty="Ma_Xa">
                                                <Fields>
                                                    <ext:RecordField Name="Ma_Xa" />
                                                    <ext:RecordField Name="Ten_Xa" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Listeners>
                                    <Select Handler="#{stData}.reload();" />
                                </Listeners>
                            </ext:ComboBox>
                        </td>
                    </tr>
                </table>

                <ext:Panel runat="server" Border="false">
                    <Content>
                        <uc1:ImageOnly runat="server" ID="ImageOnly" FieldLabel="Chọn ảnh" LabelWidth="100" />
                    </Content>
                </ext:Panel>
                <ext:HtmlEditor runat="server" ID="txtMoTa" FieldLabel="Ghi chú" Width="800" />
                <ext:GridPanel ID="gvData" runat="server" Title="Danh sách nơi lưu trữ" Header="false"
                    Icon="UserSuit" AutoHeight="true" AutoExpandColumn="Ten">
                    <Store>
                        <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stData_RefreshData">
                            <AutoLoadParams>
                                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                <ext:Parameter Name="limit" Value="5" Mode="Raw" />
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
                                        <ext:RecordField Name="Ten" SortDir="ASC" />
                                        <ext:RecordField Name="DienThoai" />
                                        <ext:RecordField Name="Email" />
                                        <ext:RecordField Name="DiaChiCuThe" />
                                        <ext:RecordField Name="ThuocTinh" />
                                        <ext:RecordField Name="TenLoaiBaoTang" />
                                        <ext:RecordField Name="ThuocHuyen" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                            <SortInfo Field="ID" Direction="ASC" />
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="30" />
                            <ext:Column ColumnID="Ten" DataIndex="Ten" Header="Tên bảo tàng"/>
                            <ext:Column ColumnID="TenLoaiBaoTang" DataIndex="TenLoaiBaoTang" Header="Loại bảo tàng" Width="200"/>
                            <ext:Column ColumnID="ThuocTinh" DataIndex="ThuocTinh" Header="Thuộc tỉnh" Width="120" />
                            <ext:Column ColumnID="ThuocHuyen" DataIndex="ThuocHuyen" Header="Thuộc huyện" Width="120" />
                            <ext:Column ColumnID="DienThoai" DataIndex="DienThoai" Header="Điện thoại" Width="150" />
                            <ext:Column ColumnID="Email" DataIndex="Email" Header="Email" Width="150" />
                            <ext:Column Width="28" DataIndex="ID" Sortable="false" MenuDisabled="true" Header="&nbsp;" Fixed="true">
                                <Renderer Handler="return '';" />
                            </ext:Column>
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
                        <ext:PagingToolbar ID="pageData" runat="server" PageSize="5" DisplayInfo="true"
                            DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                    </BottomBar>

                    <View>
                        <ext:GridView runat="server">
                            <HeaderRows>
                                <ext:HeaderRow>
                                    <Columns>
                                        <ext:HeaderColumn Cls="x-small-editor"></ext:HeaderColumn>
                                        <ext:HeaderColumn Cls="x-small-editor">
                                            <Component>
                                                <ext:ComboBox
                                                    ID="cbSTen"
                                                    runat="server"
                                                    TriggerAction="All"
                                                    Mode="Local" StoreID="stData"
                                                    DisplayField="Ten"
                                                    ValueField="Ten">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="applyFilter(this);this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();applyFilter(this); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Component>
                                        </ext:HeaderColumn>
                                         <ext:HeaderColumn Cls="x-small-editor">
                                            <Component>
                                                <ext:ComboBox
                                                    ID="cbSLoaiBaoTang"
                                                    runat="server"
                                                    TriggerAction="All"
                                                    Mode="Local" StoreID="stLoaiBaoTang"
                                                    DisplayField="TenLoai"
                                                    ValueField="TenLoai">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="applyFilter(this);this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();applyFilter(this); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Component>
                                        </ext:HeaderColumn>
                                        <ext:HeaderColumn Cls="x-small-editor">
                                            <Component>
                                                <ext:ComboBox
                                                    ID="cbSTinh"
                                                    runat="server"
                                                    TriggerAction="All"
                                                    Mode="Local"
                                                    DisplayField="Ten_Tinh"
                                                    ValueField="Ma_Tinh">
                                                    <Store>
                                                        <ext:Store runat="server">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="Ma_Tinh">
                                                                    <Fields>
                                                                        <ext:RecordField Name="Ten_Tinh" />
                                                                        <ext:RecordField Name="Ma_Tinh" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="applyFilter(this);this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();applyFilter(this); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Component>
                                        </ext:HeaderColumn>

                                        <ext:HeaderColumn Cls="x-small-editor">
                                            <Component>
                                                <ext:ComboBox
                                                    ID="cbSHuyen"
                                                    runat="server"
                                                    TriggerAction="All"
                                                    Mode="Local"
                                                    DisplayField="Ten_Huyen"
                                                    ValueField="Ten_Huyen">
                                                    <Store>
                                                        <ext:Store runat="server" ID="stSHuyen">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="Ten_Huyen">
                                                                    <Fields>
                                                                        <ext:RecordField Name="Ten_Huyen" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="applyFilter(this);this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();applyFilter(this); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Component>
                                        </ext:HeaderColumn>

                                        <ext:HeaderColumn Cls="x-small-editor">
                                            <Component>
                                                <ext:TextField ID="txtSDienthoai" runat="server" Editable="false">
                                                    <Listeners>
                                                        <Change Handler="applyFilter(this);" />
                                                    </Listeners>
                                                </ext:TextField>
                                            </Component>
                                        </ext:HeaderColumn>

                                        <ext:HeaderColumn Cls="x-small-editor">
                                            <Component>
                                                <ext:TextField ID="txtSEmail" runat="server" Editable="false">
                                                    <Listeners>
                                                        <Change Handler="applyFilter(this);" />
                                                    </Listeners>
                                                </ext:TextField>
                                            </Component>
                                        </ext:HeaderColumn>

                                        <ext:HeaderColumn AutoWidthElement="false">
                                            <Component>
                                                <ext:Button ID="ClearFilterButton" runat="server" Icon="Cancel">
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Html="Clear filter" />
                                                    </ToolTips>

                                                    <Listeners>
                                                        <Click Handler="clearFilter(null);" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Component>
                                        </ext:HeaderColumn>
                                    </Columns>
                                </ext:HeaderRow>
                            </HeaderRows>
                        </ext:GridView>
                    </View>
                    <LoadMask ShowMask="true" />
                </ext:GridPanel>

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
                        <ext:Button ID="btnCancel" Text="Hủy" Icon="BulletMinus" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnCancel_Click">
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
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
    </form>
</body>
</html>
