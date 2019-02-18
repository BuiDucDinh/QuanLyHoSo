<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LichSuCaNhan.aspx.cs" Inherits="NghiepVu_LichSu_LichSuCaNhan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="100">
            <Content>
                <ext:Panel runat="server" ID="pnLoc" Padding="10" Border="false" Width="450">
                    <Items>
                        <ext:Hidden runat="server" ID="hdRole" />
                        <ext:ComboBox runat="server" ID="cmbChucNang" FieldLabel="Chọn chức năng thao tác" Width="400" DisplayField="TenChucNang" ValueField="MaChucNang">
                            <Store>
                                <ext:Store runat="server" ID="stChucnang">
                                    <Reader>
                                        <ext:JsonReader>
                                            <Fields>
                                                <ext:RecordField Name="TenChucNang" />
                                                <ext:RecordField Name="MaChucNang" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Select Handler="this.triggers[0].show();#{stData}.reload();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{stData}.reload(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:DateField ID="txtTungay" runat="server" FieldLabel="Từ ngày" Width="400">
                             <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Select Handler="this.triggers[0].show();#{stData}.reload();" />
                                <TriggerClick Handler="this.clearValue(); this.triggers[0].hide();#{stData}.reload();" />
                            </Listeners>
                        </ext:DateField>
                        <ext:DateField ID="txtDenngay" runat="server" FieldLabel="Đến ngày" Width="400" />
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" ID="btnCancel" Icon="Decline" Text="Bỏ điều kiện" ToggleGroup="Group1">
                            <DirectEvents>
                                <Click OnEvent="btnCancel_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Buttons>
                </ext:Panel>
                <ext:Panel runat="server" Layout="FitLayout" Title="Lịch sử hoạt động" Margins="5">
                    <Content>
                        <ext:GridPanel ID="gvData" runat="server"
                            Header="true" Icon="UserSuit" AutoHeight="true" AutoScroll="true" AutoExpandColumn="TenBanGhi">
                            <Store>
                                <ext:Store ID="stData" runat="server" RemoteSort="true" DataSourceID="odsData" OnRefreshData="stData_RefreshData">
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                        <ext:Parameter Name="limit" Value="30" Mode="Raw" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="Filter" Value="#{cmbChucNang}.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Proxy>
                                        <ext:PageProxy />
                                    </Proxy>
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="ChucNang" />
                                                <ext:RecordField Name="ThaoTac" />
                                                <ext:RecordField Name="NgayThaoTac" Type="Date" />
                                                <ext:RecordField Name="TenBanGhi" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="NgayThaoTac" Direction="DESC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" />
                                    <ext:Column ColumnID="ChucNang" DataIndex="ChucNang" Header="Chức năng" Width="200" />
                                    <ext:Column ColumnID="ThaoTac" DataIndex="ThaoTac" Header="Thao tác" Width="150" />
                                    <ext:Column ColumnID="TenBanGhi" DataIndex="TenBanGhi" Header="Bản ghi" />
                                    <ext:DateColumn ColumnID="NgayThaoTac" DataIndex="NgayThaoTac" Width="200" Header="Ngày thao tác" Format="d/m/Y h:m:s" />

                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel SingleSelect="false" runat="server"/>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="pageData" runat="server" PageSize="30" DisplayInfo="true"
                                    DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                            </BottomBar>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                    </Content>
                </ext:Panel>
            </Content>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
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

                    </Items>
                </ext:Toolbar>
            </TopBar>
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
