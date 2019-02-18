<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Congvieccanxuly.aspx.cs" Inherits="NghiepVu_QuyTrinh_Congvieccanxuly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap1 = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };
        var fnCommand = function (command, id, trangthai) {
            if (trangthai == 1) {
                if (command == "Cancel") {
                    Ext.Msg.confirm("Thông báo", "Bạn có chắc muốn hủy hồ sơ này?", function (btn) {
                        if (btn == "yes") {
                            submitCommand(command, id, trangthai);
                        }
                    });
                }
                else {
                    submitCommand(command, id, trangthai);
                }
            }
            else if (command == "ShowInfo") {
                submitCommand(command, id, trangthai);
            }
            else if (trangthai == 0) {
                Ext.Msg.alert('Thông báo', 'Hồ sơ này đã được chuyển lên cơ quan có thẩm quyền xử lý, bạn không thể thay đổi hồ sơ này.');
            }
            else if (trangthai == 4) {
                Ext.Msg.alert('Thông báo', 'Hồ sơ này đã hoàn thành, bạn không thể thay đổi hồ sơ này.');
            }
            else if (trangthai == 3) {
                Ext.Msg.alert('Thông báo', 'Hồ sơ này đã bị hủy, bạn không thể xóa hoặc chỉnh sửa hồ sơ này');
            }
        };
        var submitCommand = function (command, value, trangthai) {
            Ext.net.DirectMethods.Command(command, value, trangthai, {
                success: function (result) {
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        var RenderTrangThai = function (value) {
            var trangthai = '';
            if (value == 0) trangthai = 'Đã xử lý';
            else if (value == 1) trangthai = 'Đang xử lý';
            else if (value == 2) trangthai = 'Chưa xử lý';
            else if (value == 3) trangthai = 'Hủy';
            else if (value == 4) trangthai = 'Hoàn thành';
            return trangthai;
        };
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
                <ext:Panel ID="Panel1" runat="server" Border="false" Layout="FormLayout" LabelWidth="150" Title="Thông tin cập nhật" Padding="10">
                    <Content>
                        <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên hồ sơ" Width="600" IndicatorText="*" />
                        <ext:ComboBox ID="cbLoaiQuyTrinh" runat="server" FieldLabel="Loại quy trình, thủ tục" Width="600"
                            EmptyText="-- Chọn quy trình --" Mode="Local"
                            Editable="false"
                            DisplayField="TenLoai"
                            ValueField="ID"
                            TypeAhead="true"
                            ForceSelection="true"
                            Resizable="true"
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
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" Qtip="Remove selected" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="this.removeByValue(this.getValue());this.clearValue();" />
                            </Listeners>
                        </ext:ComboBox>
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

                        <ext:ComboBox ID="cbOrderBy" runat="server" FieldLabel="Sắp xếp theo" Width="200" Mode="Local"
                            Editable="false" SelectedIndex="0" SelectOnFocus="true">
                            <Items>
                                <ext:ListItem Text="Sắp hết hạn" Value="0" />
                                <ext:ListItem Text="Ngày tiếp nhận gần nhất" Value="NgayXuLy" />
                                <ext:ListItem Text="" Value="2" />
                            </Items>
                        </ext:ComboBox>
                        <ext:Button runat="server" ID="btnSearch" FieldLabel="" Text="Lọc" Icon="Find" Width="80">
                            <DirectEvents>
                                <Click OnEvent="btnSearch_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Content>
                </ext:Panel>
                <ext:Panel runat="server" Border="false">
                    <Items>
                        <ext:GridPanel ID="gvData" runat="server" Title="" Margins="0 0 5 5" Header="false"
                            Icon="UserSuit" AutoHeight="true" AutoExpandColumn="MoTa">
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
                                                <ext:RecordField Name="TenLoai" />
                                                <ext:RecordField Name="MoTa" />
                                                <ext:RecordField Name="ConLai" />
                                                <ext:RecordField Name="ThongBao" />
                                                <ext:RecordField Name="TrangThai" />
                                                <ext:RecordField Name="ThoiGianHT" />
                                                <ext:RecordField Name="NgayXuLy" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="Conlai" Direction="ASC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="50" />
                                    <ext:Column ColumnID="TenLoai" DataIndex="TenLoai" Header="Quy trình nghiệp vụ" Width="150" />
                                    <ext:Column ColumnID="Ten" DataIndex="Ten" Header="Công việc" Width="150" />
                                    <ext:Column ColumnID="MoTa" DataIndex="MoTa" Header="Mô tả" Width="150" />
                                    <ext:DateColumn ColumnID="NgayXuLy" DataIndex="NgayXuLy" Header="Ngày xử lý" Format="d/M/yyyy" />
                                    <ext:Column ColumnID="TrangThai" DataIndex="TrangThai" Header="Trạng thái">
                                        <Renderer Fn="RenderTrangThai" />
                                    </ext:Column>
                                    <ext:Column ColumnID="ThongBao" DataIndex="ThongBao" Header="Thời gian xử lý" Width="150" />
                                    <ext:CommandColumn Width="100" Header="Action">
                                        <Commands>
                                            <ext:GridCommand Icon="Cancel" CommandName="Cancel">
                                                <ToolTip Text="Hủy hồ sơ" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="NoteEdit" CommandName="Show">
                                                <ToolTip Text="Xử lý yêu cầu" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                            <ext:GridCommand Icon="ApplicationViewIcons" CommandName="ShowInfo">
                                                <ToolTip Text="Xem Thông tin hồ sơ" />
                                            </ext:GridCommand>
                                        </Commands>
                                    </ext:CommandColumn>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel SingleSelect="false" runat="server" />
                            </SelectionModel>
                            <Listeners>
                                <Command Handler="fnCommand(command, record.data.ID,record.data.TrangThai);" />
                            </Listeners>
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
                    MinWidth="800" Height="550" Modal="true" Padding="3" Resizable="false">
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
