<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuyTrinhXuLy.aspx.cs" Inherits="NghiepVu_QuyTrinh_QuyTrinhXuLy" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>


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
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="150">
            <Content>
                <ext:Panel ID="Panel1" runat="server" Border="false" Width="780" Layout="FormLayout" LabelWidth="150" Title="Thông tin cập nhật" Padding="10">
                    <Content>
                        <ext:Hidden runat="server" ID="hdID" />
                        <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên hồ sơ" Width="600"/>
                        <ext:ComboBox ID="cbTrangThai" runat="server" FieldLabel="Trạng thái" Width="200" 
                            EmptyText="-- Chọn trạng thái --" Mode="Local"
                            Editable="false"
                            DisplayField="Ten"
                            ValueField="ID"
                            TypeAhead="true"
                            ForceSelection="true"
                            Resizable="true"
                            SelectOnFocus="true">
                            <Store>
                                <ext:Store runat="server" ID="stTrangthai">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="Ten" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" Qtip="Remove selected" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="this.removeByValue(this.getValue());this.clearValue();" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbQuyTrinhDN" runat="server" FieldLabel="Chọn thủ tục" Width="600" 
                            EmptyText="-- Chọn thủ tục --" Mode="Local"
                            Editable="false"
                            DisplayField="TenLoai"
                            ValueField="ID"
                            TypeAhead="true"
                            ForceSelection="true"
                            Resizable="true"
                            SelectOnFocus="true">
                            <Store>
                                <ext:Store runat="server" ID="stQuyTrinhDN">
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
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" Qtip="Remove selected" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="this.removeByValue(this.getValue());this.clearValue();" />
                            </Listeners>
                        </ext:ComboBox>
                    </Content>
                    <Buttons>
                        <ext:Button runat="server" ID="btnSearch" Text="Lọc" Icon="Find" Width="80">
                            <DirectEvents>
                                <Click OnEvent="btnSearch_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Buttons>
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button runat="server" ID="btnUpdate" Text="Thêm mới" Icon="Add">
                                    <DirectEvents>
                                        <Click OnEvent="btnUpdate_Click" />
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button runat="server" ID="btnDelete" Text="Xóa" Icon="Delete">
                                    <DirectEvents>
                                        <Click OnEvent="btnDelete_Click" />
                                    </DirectEvents>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
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
                                                <ext:RecordField Name="QuyTrinhDN" />
                                                <ext:RecordField Name="NgayBatDau" />
                                                <ext:RecordField Name="NguoiTao" />
                                                <ext:RecordField Name="NguoiYeuCau" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="NgayBatDau" Direction="ASC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" />
                                    <ext:Column ColumnID="Ten" DataIndex="Ten" Header="Công việc" Width="150" />
                                    <ext:Column ColumnID="QuyTrinhDN" DataIndex="QuyTrinhDN" Header="Loại" Width="150" />
                                    <ext:DateColumn ColumnID="NgayBatDau" DataIndex="NgayBatDau" Header="Ngày tạo" Format="d/M/yyyy" />
                                    <ext:Column ColumnID="NguoiTao" DataIndex="NguoiTao" Header="Người tạo" />
                                    <ext:Column ColumnID="NguoiYeuCau" DataIndex="NguoiYeuCau" Header="Đơn vị/Cá nhân yêu cầu" Width="200" />

                                    <ext:Column ColumnID="TrangThai" DataIndex="TrangThai" Header="Trạng thái" />

                                    <ext:CommandColumn Width="150" Header="Action">
                                        <Commands>
                                            <ext:GridCommand Icon="Delete" CommandName="Delete">
                                                <ToolTip Text="Delete" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                <ToolTip Text="Edit" />
                                            </ext:GridCommand>
                                            <%--<ext:CommandSeparator />
                                            <ext:GridCommand Icon="Find" CommandName="Show" Text="Xem">
                                                <ToolTip Text="Xem luồng xử lý" />
                                            </ext:GridCommand>--%>
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
                                <%--<Command OnEvent="gvData_Command">
                                    <Confirmation BeforeConfirm="if (command=='Delete') return false;" ConfirmRequest="true" Message="Bạn chắc chắn muốn xóa bản ghi này?" Title="Delete" />
                                    <ExtraParams>
                                        <ext:Parameter Name="command" Value="command" Mode="Raw" />
                                        <ext:Parameter Name="ID" Value="record.data.ID" Mode="Raw" />
                                    </ExtraParams>
                                </Command>--%>
                                <DblClick OnEvent="gvData_DbClick">
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
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Hidden ID="txtFilter" runat="server" AutoDataBind="true">
                                    <Listeners>
                                        <Change Handler="#{pageData}.changePage(1);" Delay="30" />
                                    </Listeners>
                                </ext:Hidden>
                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                </ext:Panel>

            </Content>

        </ext:Panel>
        <ext:Panel runat="server">
            <Items>
                <ext:Window runat="server" ID="wdDetail" Hidden="true"
                    DefaultButton="0" Border="false" AutoScroll="true" Maximizable="true" Collapsible="true"
                    MinWidth="900" Height="550" Modal="true" Padding="3" Resizable="false">
                    <Listeners>
                        <Hide Handler="if(hdMsg.getValue()=='ok'){hdMsg.setValue('');#{stData}.reload();Ext.Msg.alert('Thông báo','Đã cập nhật thành công');} else if(hdMsg.getValue()=='error'){Ext.Msg.alert('Thông báo','Đã có lỗi sảy ra... Xin thử lại!!!');}" />
                    </Listeners>
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg" />
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
