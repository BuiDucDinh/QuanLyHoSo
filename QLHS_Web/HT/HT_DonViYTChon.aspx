<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_DonViYTChon.aspx.cs" Inherits="HT_HT_DonViYTChon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
    <ext:Viewport ID="ViewPort1" runat="server" Layout="fit">
        <Items>
            <ext:GridPanel ID="gridHT_Don_Vi_YT" runat="server" Title="" Margins="0 0 5 5" Header="false"
                Icon="UserSuit">
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
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                        <SortInfo Field="Ma_Don_Vi" Direction="ASC" />
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="Ma_Don_Vi" DataIndex="Ma_Don_Vi" Header="ID" Width="80" Hidden="true" />
                        <ext:Column ColumnID="Ten_Don_Vi" DataIndex="Ten_Don_Vi" Header="Tên đơn vị (Trạm y tế xã, huyện, phòng khám, bệnh viện huyện, tỉnh,...)"
                            Width="250" />
                        <ext:Column ColumnID="Tuyen" DataIndex="Tuyen" Header="Tuyến đơn vị trực thuộc (1:Xã;2:Huyện;3:Tỉnh)"
                            Width="80" />
                        <ext:Column ColumnID="Ma_Tinh" DataIndex="Ma_Tinh" Header="Mã tỉnh (mặc định là 22 - QN)"
                            Width="150" />
                        <ext:Column ColumnID="Ma_Huyen" DataIndex="Ma_Huyen" Header="Mã Huyện mà đơn vị trực thuộc (nếu ko có thì để trống)"
                            Width="150" />
                        <ext:Column ColumnID="Ma_Xa" DataIndex="Ma_Xa" Header="Mã xã mà đơn vị trực thuộc (nếu ko có thì để trống)"
                            Width="150" />
                        <ext:Column ColumnID="Loai_Hinh" DataIndex="Loai_Hinh" Header="Loại hình của đơn vị (1:Tuyến khám chữa bệnh;2:Tuyến điều trị)"
                            Width="80" />
                        <ext:Column ColumnID="Thanh_Phan" DataIndex="Thanh_Phan" Header="Thành phần kinh tế (1: Công lập;2: Tư nhân)"
                            Width="80" />
                        
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:CheckboxSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                </SelectionModel>
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            
                            <ext:Button ID="btnChoose" runat="server" Text="Đồng ý" Icon="Accept">
                                <DirectEvents>
                                    <Click OnEvent="btnChoose_Click">
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
        </Items>
    </ext:Viewport>
    
    </form>
</body>
</html>
