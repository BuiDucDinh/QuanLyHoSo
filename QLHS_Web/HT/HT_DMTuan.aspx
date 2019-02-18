<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_DMTuan.aspx.cs" Inherits="HT_HT_DMTuan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var onKeyUp = function (field) {
            var v = this.processValue(this.getRawValue()),
                field;

            if (this.startDateField) {
                field = Ext.getCmp(this.startDateField);
                field.setMaxValue();
                this.dateRangeMax = null;
            } else if (this.endDateField) {
                field = Ext.getCmp(this.endDateField);
                field.setMinValue();
                this.dateRangeMin = null;
            }

            field.validate();
        };
    </script>
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
    <form id="form1" runat="server">
    <!----Goi ung dung ext------>
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
            <ext:TextField ID="txtMa_Tuan" runat="server" Hidden="true"  />            
             <ext:NumberField ID="txtTuan_So" runat="server" FieldLabel="Tuần số" Margins="2" IndicatorText="*" />
              <ext:NumberField ID="txtNam_Tinh" runat="server" MaxValue="3000" FieldLabel="Năm tính" Width="150" Margins="2" IndicatorText="*" />
            <ext:DateField 
                    ID="dteTu_Ngay" 
                    runat="server"
                    Vtype="daterange"
                    FieldLabel="Từ ngày"
                    Width="150"
                    EnableKeyEvents="true">  
                    <CustomConfig>
                        <ext:ConfigItem Name="endDateField" Value="#{dteDen_Ngay}" Mode="Value" />
                    </CustomConfig>
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners>
                </ext:DateField>
                
                <%--
                // Alternative syntax using custom config property attributes. 

                <ext:DateField 
                    ID="DateField1" 
                    runat="server" 
                    FieldLabel="To"
                    Vtype="daterange"
                    AnchorHorizontal="100%"
                    EnableKeyEvents="true" 
                    EndDateField="DateField2">
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners>
                </ext:DateField>
                    --%>
                    
                <ext:DateField 
                    ID="dteDen_Ngay"
                    runat="server" 
                    Vtype="daterange"
                    FieldLabel="Đến ngày"
                    Width="150"
                    EnableKeyEvents="true">    
                    <CustomConfig>
                        <ext:ConfigItem Name="startDateField" Value="#{dteTu_Ngay}" Mode="Value" />
                    </CustomConfig>
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners>
                </ext:DateField>
                
                <%--
                // Alternative syntax using custom config property attributes. 
                
                <ext:DateField 
                    ID="DateField2" 
                    runat="server" 
                    Vtype="daterange"
                    FieldLabel="From"
                    AnchorHorizontal="100%"
                    EnableKeyEvents="true"    
                    StartDateField="DateField1">
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners>
                </ext:DateField>--%>  
            <ext:ComboBox ID="cboHinh_Nen" runat="server" FieldLabel="Giao diện" EmptyText="--Chọn giao diện--"
                Editable="false" Width="150" Hidden="true">
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
                            <ext:JsonReader IDProperty="Ma_Tuan">
                                <Fields>
                                    <ext:RecordField Name="Ma_Tuan" />
                                    <ext:RecordField Name="Tuan_So" />
                                    <ext:RecordField Name="Nam_Tinh" />  
                                    <ext:RecordField Name="Tu_Ngay" /> 
                                    <ext:RecordField Name="Den_Ngay" />                                   
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                        <SortInfo Field="Ma_Tuan" Direction="ASC" />
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="Ma_Tuan" DataIndex="Ma_Tuan" Header="ID" Hidden="true" />
                        <ext:Column ColumnID="Tuan_So" DataIndex="Tuan_So" Header="Tuần số"
                            Width="200" />
                        <ext:Column ColumnID="Nam_Tinh" DataIndex="Nam_Tinh" Header="Năm tính" Width="200" />         
                        <ext:DateColumn ColumnID="Tu_Ngay" DataIndex="Tu_Ngay" Header="Từ ngày" Format="dd/MM/yyyy" ></ext:DateColumn> 
                        <ext:DateColumn ColumnID="Den_Ngay" DataIndex="Den_Ngay" Header="Đến ngày"  Format="dd/MM/yyyy" ></ext:DateColumn>                                          
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
    <ext:Window ID="winVaiTro" runat="server" Icon="NoteEdit" Title="Quyền vai trò"
        Height="400" Width="600" Modal="true" Hidden="true" Layout="FormLayout" CloseAction="Hide"
        Closable="true">        
    </ext:Window>
    </form>
</body>
</html>
