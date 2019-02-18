<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThoiKy.aspx.cs" Inherits="NghiepVu_Danhmuc_ThoiKy" %>

<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Scripts/jquery-1.7.1.min.js"></script>
    <script src="/Scripts/jquery.shorten.1.0.js"></script>
<%--    <ext:XScript runat="server">
        <script type="text/javascript">
                         
            var applyFilter = function (field) {                
                var store = #{gvData}.getStore();
                store.suspendEvents();
                store.filterBy(getRecordFilter());                                
                store.resumeEvents();
                #{gvData}.getView().refresh(false);
            };
             
            var clearFilter = function () {
                #{txtSTen}.reset();
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
                        return filterString(#{txtSTen}.getValue(), "TenThoiKy", record);
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
    </ext:XScript>--%>
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
        <!----Goi ung dung ext------>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Viewport runat="server" LabelWidth="100" Padding="10" Layout="border">
            <Items> <ext:Hidden runat="server" ID="hdRole"/>
                <ext:Panel ID="Panel3" runat="server" Region="West" Split="true" Margins="0 0 0 0"
                    Frame="true" DefaultAnchor="100%" Width="300" Title="Thời kỳ lịch sử" Icon="House">
                    <Items>
                        <ext:GridPanel ID="gvData" runat="server" Frame="true"
                            Icon="UserSuit" AutoHeight="true" AutoExpandColumn="TenThoiKy" StripeRows="true" TrackMouseOver="true">
                            <Store>
                                <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stData_RefreshData">
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                        <ext:Parameter Name="limit" Value="10" Mode="Raw" />
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
                                                <ext:RecordField Name="TenThoiKy" SortDir="ASC" />
                                                <ext:RecordField Name="MoTa" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="ID" Direction="ASC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="30" />
                                    <ext:Column ColumnID="TenThoiKy" DataIndex="TenThoiKy" Header="Thời kỳ" />
                                    <ext:Column Width="28" DataIndex="ID" Sortable="false" Header="&nbsp;" Fixed="true">
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
                                <ext:PagingToolbar ID="pageData" runat="server" PageSize="10" DisplayInfo="true"
                                    DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                            </BottomBar>
                            <%--<View>
                                <ext:GridView runat="server">
                                    <HeaderRows>
                                        <ext:HeaderRow>
                                            <Columns>
                                                <ext:HeaderColumn Cls="x-small-editor"></ext:HeaderColumn>
                                                <ext:HeaderColumn Cls="x-small-editor">
                                                    <Component>
                                                        <ext:TextField ID="txtSTen" runat="server" Editable="false">
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
                            </View>--%>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>
                <ext:Panel runat="server" Region="Center" Split="true" Padding="5"
                    Frame="true" DefaultAnchor="100%" Width="300" Title="Thời kỳ lịch sử" Icon="House">
                    <Items>
                        <ext:Hidden runat="server" ID="hdID" />
                        <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên thời kỳ" Width="600" Margins="2" IndicatorText="*" />
                        <ext:TextField ID="txtEngName" runat="server" FieldLabel="Tên tiếng anh" Width="600" Margins="2" IndicatorText="*" />
                        <ext:HtmlEditor runat="server" ID="txtMoTa" FieldLabel="Ghi chú" Width="700" Height="500" />
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
                                <%--<ext:Button ID="btnExport" runat="server" Text="Xuất báo cáo" Icon="Report">
                                    <DirectEvents>
                                        <Click OnEvent="btnExport_Click" IsUpload="true" Before="ExportYap()">
                                            <ExtraParams>
                                                <ext:Parameter Name="data" Value="#{gvData}.getRowsValues()" Mode="Raw" Encode="true" />
                                            </ExtraParams>
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>--%>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                </ext:Panel>
            </Items>

        </ext:Viewport>
    </form>
</body>
</html>
