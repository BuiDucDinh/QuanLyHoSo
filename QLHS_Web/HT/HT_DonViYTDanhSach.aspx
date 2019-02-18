<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_DonViYTDanhSach.aspx.cs"
    Inherits="HT_HT_DonViYTDanhSach" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <script type="text/javascript">
          var ren_LH = function (value) {
              if (value == 1) {
                  return 'Sở Nông nghiệp và PTNN'
              }
              else if (value == 2) {
                  return 'Các đơn vị thuộc sở Nông nghiệp và PTNT'
              }
              else if (value == 3) {
                  return 'Các đơn vị không thuộc sở Nông nghiệp và PTNT'
              }
              else {
                return 'Chi cục'
              }
          }

          
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <asp:ObjectDataSource ID="odsHT_Don_Vi_YT" runat="server" OnSelected="odsHT_Don_Vi_YT_Selected"
        SelectMethod="Page_By_Filter" TypeName="QLHS_Logic.Sys_Common">
        <SelectParameters>
            <asp:Parameter Name="Start" Type="Int32" />
            <asp:Parameter Name="Limit" Type="Int32" />
            <asp:Parameter Name="WhereString" />
            <asp:Parameter Name="SortString" />
            <asp:Parameter Name="Count" Direction="Output" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <ext:Panel ID="ViewPort1" runat="server" AutoScroll="true" AutoHeight="true">
        <Content>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tbody>
                    <tr>
                        <td width="300" align="left">
                            <ext:ComboBox ID="cboTuyen" runat="server" FieldLabel="Tuyến đơn vị trực thuộc" EmptyText="--Lựa chọn tuyến--" Hidden="true"
                                Editable="false" Width="300" LabelWidth="150">
                                <Items>
                                    <ext:ListItem Text="Huyện" Value="2" />
                                    <ext:ListItem Text="Tỉnh" Value="3" />
                                </Items>
                                <DirectEvents>
                                    <Select OnEvent="cboTuyen_Selected">
                                    </Select>
                                </DirectEvents>
                            </ext:ComboBox>
                        </td>
                        <td align="left" width="250">
                            <ext:ComboBox ID="cboMa_Huyen" runat="server" FieldLabel="&nbsp;&nbsp;Mã Huyện" Width="250" EmptyText="--Chọn Huyện--"
                                DisplayField="Ten_Huyen" ValueField="Ma_Huyen" Mode="Local" AllowBlank="true" Hidden="true"
                                Disabled="true">
                                <Store>
                                    <ext:Store ID="dsHuyen" runat="server">
                                        <Reader>
                                            <ext:JsonReader>
                                                <Fields>
                                                    <ext:RecordField Name="Ten_Huyen" SortDir="ASC" />
                                                    <ext:RecordField Name="Ma_Huyen" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                            </ext:ComboBox>
                        </td>
                        <td align="left" width="20">&nbsp;&nbsp;</td>
                        <td align="left">
                            <ext:Button ID="btnOK" runat="server" Text="Lọc" Icon="Find" Hidden="true">
                                <DirectEvents>
                                    <Click OnEvent="btnOK_Click">
                                        <EventMask ShowMask="true" MinDelay="100" Msg="Xin vui lòng chờ đợi !!!" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
            <ext:GridPanel ID="gridHT_Don_Vi_YT" runat="server" Title="" Margins="0 0 5 5" Header="false"
                Icon="UserSuit" AutoHeight="true">
                <Store>
                    <ext:Store ID="dsHT_Don_Vi_YT" runat="server" RemoteSort="true" DataSourceID="odsHT_Don_Vi_YT"
                        OnRefreshData="dsHT_Don_Vi_YT_RefreshData">
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
                            <ext:JsonReader IDProperty="Ma_Don_Vi">
                                <Fields>
                                    <ext:RecordField Name="Ma_Don_Vi" SortDir="ASC" />
                                    <ext:RecordField Name="Ten_Don_Vi" />
                                    <ext:RecordField Name="Tuyen" />
                                    <ext:RecordField Name="Ma_Tinh" />
                                    <ext:RecordField Name="Ma_Huyen" />
                                    <ext:RecordField Name="Ma_Xa" />
                                    <ext:RecordField Name="Loai_Hinh" />
                                    <ext:RecordField Name="Thanh_Phan" />
                                    <ext:RecordField Name="KB" />
                                    <ext:RecordField Name="DP" />
                                    <ext:RecordField Name="VT" />
                                    <ext:RecordField Name="BC" />
                                    <ext:RecordField Name="SK" />
                                    <ext:RecordField Name="DB" />
                                    <ext:RecordField Name="CP" />
                                    <ext:RecordField Name="NL" />
                                    <ext:RecordField Name="AT" />
                                    <ext:RecordField Name="DV" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                        <SortInfo Field="Ma_Don_Vi" Direction="ASC" />
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="Ma_Don_Vi" DataIndex="Ma_Don_Vi" Header="ID" Width="80" Hidden="true" />
                        <ext:Column ColumnID="Ten_Don_Vi" DataIndex="Ten_Don_Vi" Header="Tên đơn vị"
                            Width="350" />
                        <ext:Column ColumnID="Tuyen" DataIndex="Tuyen" Header="Tuyến đơn vị trực thuộc (1:Xã;2:Huyện;3:Tỉnh)"
                            Width="80" Hidden="true" />
                        <ext:Column ColumnID="Ma_Tinh" DataIndex="Ma_Tinh" Header="Mã tỉnh (mặc định là 22 - QN)"  Hidden="true"
                            Width="150" />
                        <ext:Column ColumnID="Ma_Huyen" DataIndex="Ma_Huyen" Header="Mã Huyện mà đơn vị trực thuộc (nếu ko có thì để trống)"  Hidden="true"
                            Width="150" />
                        <ext:Column ColumnID="Ma_Xa" DataIndex="Ma_Xa" Header="Mã xã mà đơn vị trực thuộc (nếu ko có thì để trống)"  Hidden="true"
                            Width="150" />
                        <ext:Column ColumnID="Loai_Hinh" DataIndex="Loai_Hinh" Header="Loại hình" Width="280">
                        <Renderer Fn="ren_LH" />
                        </ext:Column>
                        <ext:Column ColumnID="Thanh_Phan" DataIndex="Thanh_Phan" Header="Thành phần kinh tế (1: Công lập;2: Tư nhân)"  Hidden="true"
                            Width="80" />
                        <ext:CheckColumn ColumnID="KB" DataIndex="KB" Header="Module Khám bệnh"  Hidden="true" />
                        <ext:CheckColumn ColumnID="DP" DataIndex="DP" Header="Module Dược phẩm" Hidden="true" />
                        <ext:CheckColumn ColumnID="VT" DataIndex="VT" Header="Module Vật tư y tế" Hidden="true" />
                        <ext:CheckColumn ColumnID="BC" DataIndex="BC" Header="Module Báo cáo" Hidden="true" />
                        <ext:CheckColumn ColumnID="SK" DataIndex="SK" Header="Module Sức khỏe" Hidden="true" />
                        <ext:CheckColumn ColumnID="DB" DataIndex="DB" Header="Module Dịch bệnh"  Hidden="true"/>
                        <ext:CheckColumn ColumnID="CP" DataIndex="CP" Header="Module Cấp phép y dược" Hidden="true" />
                        <ext:CheckColumn ColumnID="NL" DataIndex="NL" Header="Module Quản lý nhân lực" Hidden="true" />
                        <ext:CheckColumn ColumnID="AT" DataIndex="AT" Header="Module An toàn vệ sinh thực phẩm" Hidden="true" />
                        <ext:CheckColumn ColumnID="DV" DataIndex="DV" Header="Module Dịch vụ công y tế dự phòng"  Hidden="true"/>
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="btnInsert" runat="server" Text="Thêm mới" Icon="Add">
                                <DirectEvents>
                                    <Click OnEvent="btnInsert_Click">
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button ID="btnUpdate" runat="server" Text="Cập nhật" Icon="ApplicationFormEdit">
                                <DirectEvents>
                                    <Click OnEvent="btnUpdate_Click">
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button ID="btnDelete" runat="server" Text="Xóa" Icon="Cross">
                                <DirectEvents>
                                    <Click OnEvent="btnDelete_Click">
                                        <Confirmation ConfirmRequest="true" Title="Thông báoo" Message="Bạn muốn xóa bản ghi này?" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Hidden ID="txtFilter" runat="server" AutoDataBind="true">
                                <Listeners>
                                    <Change Handler="#{pageHT_Don_Vi_YT}.changePage(1);" Delay="30" />
                                </Listeners>
                            </ext:Hidden>
                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                            <ext:TriggerField ID="txtSearch" runat="server" Width="200" EmptyText="Tìm kiếm"
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
                    <ext:PagingToolbar ID="pageHT_Don_Vi_YT" runat="server" PageSize="30" DisplayInfo="true"
                        DisplayMsg="Hiện thị bản ghi {0} - {1} của {2}" EmptyMsg="Không có thông tin để hiển thị" />
                </BottomBar>
                <LoadMask ShowMask="true" />
            </ext:GridPanel>
        </Content>
    </ext:Panel>
    <ext:Window ID="winHT_Don_Vi_YT" runat="server" Icon="Lightbulb" Title="Đơn vị"
        Height="800" Width="800" Modal="true" Hidden="true" Layout="Fit" CloseAction="Hide"
        Closable="true">
        <DirectEvents>
            <Hide OnEvent="winHT_Don_Vi_YT_Hide">
            </Hide>
        </DirectEvents>
    </ext:Window>
    </form>
</body>
</html>
