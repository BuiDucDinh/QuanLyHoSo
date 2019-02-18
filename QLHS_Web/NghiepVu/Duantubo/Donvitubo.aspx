<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Donvitubo.aspx.cs" Inherits="DSVH_Quanlykehoachtubo_Donvitubo" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        var GetImage = function (value) {
            return "<img src='/FileUpload/Images/" + value + "' style=\'width:60px; height:auto\'/>";
        }

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

        <ext:ResourceManager ID="ResourceManager2" runat="server" />

        <ext:Viewport ID="ViewPort1" runat="server" Layout="border">
            <Items>
                <ext:Panel runat="server" ID="pnLoc" Region="West" Padding="5" Width="600" Title="Danh sách nhà đầu tư">
                    <Content>
                        <ext:Hidden runat="server" ID="hdRole" />
                        <table style="color: rgb(41, 84, 149); font: 13px arial,tahoma,sans-serif;">
                            <tr>
                                <td>
                                    <p><span class="x-label-text">Tên công ty:</span><span style="color: red">*</span></p>
                                    <ext:TextField runat="server" ID="txtTen" Width="350">
                                        <Listeners>
                                            <Change Handler="#{stData}.reload();" />
                                        </Listeners>
                                    </ext:TextField>
                                </td>
                                <td>
                                    <p><span class="x-label-text">Chức năng:</span><span style="color: red">*</span></p>
                                    <ext:ComboBox ID="cbChucnang" runat="server" DisplayField="TenChucNang" ValueField="ID"
                                        EmptyText="--Chọn chức năng" IndicatorText="*" Mode="Local">
                                        <Store>
                                            <ext:Store runat="server" ID="stChucnangLoc">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="ID">
                                                        <Fields>
                                                            <ext:RecordField Name="ID" />
                                                            <ext:RecordField Name="TenChucNang" />
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
                                </td>
                            </tr>
                        </table>
                        <ext:GridPanel ID="gvData" runat="server" Title="" Margins="0 0 5 5" Header="false"
                            Icon="UserSuit" AutoHeight="true" AutoExpandColumn="TenDonVi">
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
                                        <ext:JsonReader IDProperty="DonViID">
                                            <Fields>
                                                <ext:RecordField Name="DonViID" />
                                                <ext:RecordField Name="TenDonVi" Type="String" />
                                                <ext:RecordField Name="NguoiDaiDien" Type="String" />
                                                <ext:RecordField Name="DiaChi" Type="String" />
                                                <ext:RecordField Name="CapDonVi" Type="String" />
                                                <ext:RecordField Name="ChungChiHanhNghe" Type="String" />
                                                <ext:RecordField Name="SoDienThoai" Type="String" />
                                                <ext:RecordField Name="GhiChu" Type="String" />
                                                <ext:RecordField Name="ChucNangDs" Type="String" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <SortInfo Field="TenDonVi" Direction="ASC" />
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="TenDonVi" Header="Tên công ty" Width="100" DataIndex="TenDonVi" />
                                    <ext:Column Header="Dịch vụ" Width="200" DataIndex="ChucNangDs" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" SingleSelect="true">
                                    <Listeners>
                                        <RowSelect Handler="#{btnDelete}.enable();" />
                                        <RowDeselect Handler="if (!#{gvData}.hasSelection()) {#{btnDelete}.disable();}" />
                                    </Listeners>
                                    <DirectEvents>
                                        <RowSelect OnEvent="RowSelect" Buffer="100">
                                            <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="#{pnUpdate}" />
                                            <ExtraParams>
                                                <ext:Parameter Name="ID" Value="this.getSelected().id" Mode="Raw" />
                                            </ExtraParams>
                                        </RowSelect>
                                    </DirectEvents>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="pageData" runat="server" PageSize="30" DisplayInfo="true"
                                    DisplayMsg="Hiển thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                            </BottomBar>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                    </Content>
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
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
                                                <ext:Parameter Name="data" Value="#{gvData}.getRowsValues()" Mode="Raw" Encode="true" />
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
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                </ext:Panel>
                <ext:Panel runat="server" ID="pnUpdate" Region="Center" Padding="10">
                    <Content>
                        <ext:Panel runat="server" Layout="FitLayout" Border="false" Region="West" LabelWidth="100">
                            <Content>
                                <ext:Hidden runat="server" ID="hdDonViID" />
                                <ext:TextField ID="txtTenCongTy" runat="server" FieldLabel="Tên công ty" Width="450" />
                                <ext:MultiCombo ID="mcbChucnang" runat="server" FieldLabel="Chức năng" ValueField="ID" DisplayField="TenChucNang" Width="450" EmptyText="Chọn chức năng">
                                    <Store>
                                        <ext:Store runat="server" ID="stChucnang">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="TenChucNang" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                </ext:MultiCombo>
                                <ext:TextField ID="txtNguoiDaiDien" runat="server" FieldLabel="Người đại diện" Width="450" />

                                <ext:TextField ID="txtDienThoai" FieldLabel="Điện thoại" runat="server" Width="450" />
                                <ext:TextField ID="txtDiaChi" runat="server" FieldLabel="Địa chỉ" Width="450" />

                                <ext:ComboBox ID="cbCapDonVi" runat="server" FieldLabel="Cấp đơn vị" Width="450" Hidden="true"
                                    EmptyText="--Cấp đơn vị--" AllowBlank="true" SelectedIndex="0">
                                    <Items>
                                        <ext:ListItem Value="0" Text="Cấp địa phương" />
                                        <ext:ListItem Value="1" Text="Cấp tỉnh" />
                                        <ext:ListItem Value="2" Text="Cấp nhà nước" />
                                    </Items>
                                </ext:ComboBox>
                                <ext:TextField ID="txtChungChi" runat="server" FieldLabel="Chứng chỉ hành nghề" Width="450" Hidden="true" />
                                <ext:Panel runat="server" Border="false">
                                    <Content>
                                        <uc1:Document runat="server" ID="Document" FieldLabel="Chọn tài liệu" Width="270" LabelWidth="100" />
                                    </Content>
                                </ext:Panel>
                                <ext:TextArea ID="txtGhichu" runat="server" FieldLabel="Ghi chú" Width="450" Height="150" />
                            </Content>
                        </ext:Panel>
                    </Content>
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                                    <DirectEvents>
                                        <Click OnEvent="btnUpdate_Click">
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:Button ID="btnCancel" Text="Hủy" Icon="Cancel" runat="server">
                                    <DirectEvents>
                                        <Click OnEvent="btnCancel_Click">
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
