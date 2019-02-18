<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSNguonKinhPhi.aspx.cs" Inherits="NghiepVu_KinhPhi_DSNguonKinhPhi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
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
        <asp:ObjectDataSource ID="odsNhadautu" runat="server" OnSelected="odsNhadautu_Selected" SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
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
                <ext:Panel runat="server" ID="pnLoc" Padding="10" Border="false" Title="Danh sách nhà đầu tư" FormGroup="true">
                    <Content>
                        <table>
                            <tr>
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Tên nhà đầu tư:</span><span style="color: red">*</span></p>
                                    <ext:TextField runat="server" ID="txtTen" Width="300" />
                                </td>
                                <td colspan="2">
                                    <p><span class="x-label-text">Số điện thoại:</span></p>
                                    <ext:TextField runat="server" ID="txtDienthoai" Width="300" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Email:</span></p>
                                    <ext:TextField runat="server" ID="txtEmail" Width="300" />
                                </td>
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Địa chỉ:</span></p>
                                    <ext:TextField runat="server" ID="txtDiachi" Width="300" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <p><span class="x-label-text">Mô tả:</span></p>
                                    <ext:HtmlEditor runat="server" ID="txtMota" Width="600" />
                                </td>
                            </tr>
                        </table>
                        <ext:Hidden runat="server" ID="hdID" />
                        <ext:Panel ID="Panel1" runat="server" Border="false" Width="250">
                            <Buttons>
                                <ext:Button ID="btnUpdate1" Text="Thêm mới" Icon="Add" runat="server">
                                    <DirectEvents>
                                        <Click OnEvent="btnUpdate1_Click" />
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button ID="btnCanCel1" Text="Hủy" Icon="Cancel" runat="server">
                                    <DirectEvents>
                                        <Click OnEvent="btnCanCel1_Click" />
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button ID="btnDelete1" Text="Xóa" Icon="BulletCross" runat="server" Disabled="true">
                                    <DirectEvents>
                                        <Click OnEvent="btnDelete1_Click">
                                            <Confirmation ConfirmRequest="true" Title="Thông báo" Message="Bạn muốn xóa bản ghi này?" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                            </Buttons>
                        </ext:Panel>
                        <ext:GridPanel ID="gvNhadautu" runat="server"
                            Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoExpandColumn="MoTa">
                            <Store>
                                <ext:Store ID="stDSNhadautu" runat="server" RemoteSort="true" DataSourceID="odsNhadautu" OnRefreshData="stDSNhadautu_RefreshData">
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
                                                <ext:RecordField Name="Ten" />
                                                <ext:RecordField Name="DienThoai" />
                                                <ext:RecordField Name="Email" />
                                                <ext:RecordField Name="DiaChi" />
                                                <ext:RecordField Name="MoTa" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="ID" Direction="DESC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" />
                                    <ext:Column ColumnID="Ten" DataIndex="Ten" Header="Người đầu tư" Width="200" />
                                    <ext:Column ColumnID="DienThoai" DataIndex="DienThoai" Header="Điện thoại" Width="100" />
                                    <ext:Column ColumnID="Email" DataIndex="Email" Width="150" Header="Email" />
                                    <ext:Column ColumnID="DiaChi" DataIndex="DiaChi" Header="Địa chỉ" Width="250" />
                                    <ext:Column DataIndex="MoTa" Header="Mô tả" />
                                    <%--<ext:CommandColumn Width="150" Header="Action">
                                        <Commands>
                                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                                <ToolTip Text="Edit" />
                                            </ext:GridCommand>
                                            <ext:CommandSeparator />
                                        </Commands>
                                    </ext:CommandColumn>--%>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel2" SingleSelect="false" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="#{btnDelete1}.enable();" />
                                        <RowDeselect Handler="if (!#{gvNhadautu}.hasSelection()) {#{btnDelete1}.disable();}" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <DirectEvents>
                                <DblClick OnEvent="gvNhadautu_DbClick">
                                </DblClick>
                            </DirectEvents>
                            <%--                            <Listeners>
                                <Click Handler="#{hdID}.setValue(record.data.ID);#{stData}.reload();" />
                                <DblClick Handler="#{hdID}.setValue(record.data.ID);#{stData}.reload();" />
                                <Command Handler="submitCommand(command, record.data.ID);" />
                            </Listeners>--%>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10" DisplayInfo="true"
                                    DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                            </BottomBar>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                    </Content>
                </ext:Panel>
                <ext:Panel runat="server" Title="Danh sách nguồn kinh phí" Padding="5" FormGroup="true">
                    <Content>
                        <table>
                            <tr>
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Từ ngày:</span><span style="color: red">*</span></p>

                                    <ext:DateField ID="txtTungay" runat="server" Width="300" />
                                </td>
                                <td colspan="2">
                                    <p><span class="x-label-text">Đến ngày:</span></p>

                                    <ext:DateField ID="txtDenngay" runat="server" Width="300" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Nguồn ngân sách:</span></p>
                                    <ext:ComboBox ID="cbNguonKinhPhi" runat="server" Width="300" EmptyText="--Chọn kiểu đầu tư --"
                                        Mode="Local" AllowBlank="true" DisplayField="TenLoai" ValueField="ID"
                                        Disabled="false">
                                        <Store>
                                            <ext:Store runat="server" ID="stNguonKinhPhi">
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
                                            <ext:FieldTrigger Icon="Clear" Qtip="Remove selected" />
                                        </Triggers>
                                        <Listeners>
                                            <TriggerClick Handler="this.removeByValue(this.getValue());this.clearValue();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </td>
                                <td style="width: 50%">
                                    <p><span class="x-label-text">Nguồn ngân sách:</span></p>

                                    <ext:ComboBox
                                        ID="cbNhadautu"
                                        runat="server"
                                        EmptyText="-- Chọn nhà đầu tư --"
                                        TypeAhead="true"
                                        ForceSelection="true"
                                        Width="300"
                                        Mode="Local"
                                        DisplayField="Ten"
                                        ValueField="ID"
                                        MinChars="1"
                                        ListWidth="300"
                                        PageSize="10"
                                        ItemSelector="tr.list-item">
                                        <Store>
                                            <ext:Store runat="server" ID="stNhadautu">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="ID">
                                                        <Fields>
                                                            <ext:RecordField Name="ID" />
                                                            <ext:RecordField Name="Ten" />
                                                            <ext:RecordField Name="MoTa" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Template ID="Template1" runat="server">
                                            <Html>
                                                <tpl for=".">
						<tpl if="[xindex] == 1">
							<table class="cbStates-list">
								<tr>
									<th>Tên</th>
									<th>Mô tả</th>
								</tr>
						</tpl>
						<tr class="list-item">
							<td style="padding:3px 5px">{Ten}</td>
							<td>{MoTa}</td>
						</tr>
						<tpl if="[xcount-xindex]==0">
                        </table>
                        </tpl>
					</tpl>
                                </Html>
                            </Template>
                            <triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </triggers>
                        <listeners>
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="this.removeByValue(this.getValue());this.clearValue();" />
                                <Select Handler="this.triggers[0].show();" />
                            </listeners>
                        </ext:ComboBox>
                                </td>
                                
                        </tr>
                        <tr>
                            <td style="width: 50%;">
                                <ext:Panel ID="Panel2" runat="server" Border="false" Width="300">
                                    <Buttons>
                                        <ext:Button runat="server" ID="btnLoc" Icon="Find" Text="Lọc" ToggleGroup="Group1">
                                            <DirectEvents>
                                                <Click OnEvent="btnLoc_Click" />
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnCancel" Icon="Decline" Text="Bỏ điều kiện" ToggleGroup="Group1">
                                            <DirectEvents>
                                                <Click OnEvent="btnCancel_Click" />
                                            </DirectEvents>
                                        </ext:Button>
                                    </Buttons>
                                </ext:Panel>
                            </td>
                        </tr>
                        </table>

                        <ext:Panel runat="server" Border="false" Width="300">
                            <Buttons>
                                <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                                    <DirectEvents>
                                        <Click OnEvent="btnUpdate_Click" />
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
                                                <ext:Parameter Name="format" Value="xls" Mode="Value" />
                                            </ExtraParams>
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>

                            </Buttons>
                        </ext:Panel>
                        <ext:GridPanel ID="gvData" runat="server"
                            Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoExpandColumn="MoTa">
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
                                                <ext:RecordField Name="NguoiDauTu" />
                                                <ext:RecordField Name="NguonKinhPhi" />
                                                <ext:RecordField Name="NgayDauTu" Type="Date" />
                                                <ext:RecordField Name="TienConLai" />
                                                <ext:RecordField Name="SoTien" />
                                                <ext:RecordField Name="MoTa" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="ID" Direction="DESC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" />
                                    <ext:Column ColumnID="NguoiDauTu" DataIndex="NguoiDauTu" Header="Người đầu tư" />
                                    <ext:Column ColumnID="NguonKinhPhi" DataIndex="NguonKinhPhi" Header="Kiểu đầu tư" Width="250" />
                                    <ext:DateColumn ColumnID="NgayDauTu" DataIndex="NgayDauTu" Width="100" Header="Ngày đầu tư" Format="d/m/Y" />
                                    <ext:Column ColumnID="SoTien" DataIndex="SoTien" Header="Số tiền đầu tư" />
                                    <ext:Column ColumnID="TienConLai" DataIndex="TienConLai" Width="150" Header="Số tiền còn lại" />
                                    <ext:CheckColumn DataIndex="MoTa" Header="Mô tả" />

                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" SingleSelect="true" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="#{btnDelete}.enable();" />
                                        <RowDeselect Handler="if (!#{gvData}.hasSelection()) {#{btnDelete}.disable();}" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <DirectEvents>
                                <Click OnEvent="gvData_DbClick" />
                            </DirectEvents>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="10" DisplayInfo="true"
                                    DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                            </BottomBar>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                        <%--<ext:GridPanel ID="gvData" runat="server"
                            Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoExpandColumn="MoTa">
                            <Store>
                                <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stData_RefreshData">
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                        <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="Filter" Value="" Mode="Raw" />
                                    </BaseParams>
                                    <Proxy>
                                        <ext:PageProxy />
                                    </Proxy>
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="NguoiDauTu" />
                                                <ext:RecordField Name="NguonKinhPhi" />
                                                <ext:RecordField Name="NgayDauTu" Type="Date" />
                                                <ext:RecordField Name="TienConLai" />
                                                <ext:RecordField Name="SoTien" />
                                                <ext:RecordField Name="MoTa" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="NgayDauTu" Direction="DESC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" />
                                    <ext:Column ColumnID="NguoiDauTu" DataIndex="NguoiDauTu" Header="Người đầu tư" />
                                    <ext:Column ColumnID="NguonKinhPhi" DataIndex="NguonKinhPhi" Header="Kiểu đầu tư" Width="250" />
                                    <ext:DateColumn ColumnID="NgayDauTu" DataIndex="NgayDauTu" Width="100" Header="Ngày đầu tư" Format="d/m/Y" />
                                    <ext:Column ColumnID="SoTien" DataIndex="SoTien" Header="Số tiền đầu tư" />
                                    <ext:Column ColumnID="TienConLai" DataIndex="TienConLai" Width="150" Header="Số tiền còn lại" />
                                    <ext:CheckColumn DataIndex="MoTa" Header="Mô tả" />
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
                                <DblClick OnEvent="gvData_DbClick" />
                            </DirectEvents>
                            <BottomBar>
                                <ext:PagingToolbar ID="pageData" runat="server" PageSize="30" DisplayInfo="true"
                                    DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                            </BottomBar>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>--%>
                    </Content>
                </ext:Panel>
            </Content>
        </ext:Panel>
        <ext:Panel runat="server">
            <Items>
                <ext:Window runat="server" ID="wdDetail" Hidden="true" DefaultButton="0" Border="false" Title="Thông tin nhập liệu" Icon="Information"
                    MinWidth="1000" MinHeight="550" Padding="3" Resizable="false" AutoScroll="true" Modal="true" Collapsible="true" Maximizable="true">
                    <Listeners>
                        <Hide Handler="if(hdMsg.getValue()=='ok'){hdMsg.setValue('');#{stData}.reload();Ext.Msg.alert('Đã cập nhật thành công');}" />
                    </Listeners>
                </ext:Window>
                <ext:Hidden runat="server" ID="hdMsg" />
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
