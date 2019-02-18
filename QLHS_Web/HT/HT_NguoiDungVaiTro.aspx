<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_NguoiDungVaiTro.aspx.cs" Inherits="HT_HT_NguoiDungVaiTro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />

    <ext:Panel ID="Panel4" runat="server" Title="Người dùng vai trò" Icon="UserKey" Padding="5"
        Layout="ColumnLayout" AutoHeight="true" AutoScroll="true">
        <Items>
            <ext:ColumnLayout ID="ColumnLayout2" runat="server">
                <Columns>
                    <ext:LayoutColumn ColumnWidth="0.5">
                        <ext:GridPanel ID="gridKhongVaiTro" runat="server" Title="" Margins="0 0 5 5" Icon="UserSuit"
                            EnableDragDrop="false" AutoExpandColumn="Ma_Vai_Tro" Height="400" AutoScroll="true">
                            <Store>
                                <ext:Store ID="dsKhongVaiTro" runat="server">
                                    <Reader>
                                        <ext:JsonReader IDProperty="Ma_Vai_Tro">
                                            <Fields>
                                                <ext:RecordField Name="Ma_Vai_Tro" SortDir="ASC" />
                                                <ext:RecordField Name="Ten_Vai_Tro" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel3" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="Ma_Vai_Tro" Header="Ma_Vai_Tro" Hidden="true" />
                                    <ext:Column ColumnID="Ten_Vai_Tro" DataIndex="Ten_Vai_Tro" Header="Vai trò không có quyền truy nhập"
                                        Width="250" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" />
                            </SelectionModel>
                        </ext:GridPanel>
                    </ext:LayoutColumn>
                    <ext:LayoutColumn>
                        <ext:Panel ID="Panel5" runat="server" Width="35" BodyStyle="background-color: transparent;"
                            Border="false" Layout="Anchor">
                            <Items>
                                <ext:Panel ID="Panel6" runat="server" Border="false" BodyStyle="background-color: transparent;"
                                    AnchorVertical="40%" />
                                <ext:Panel ID="Panel7" runat="server" Border="false" BodyStyle="background-color: transparent;"
                                    Padding="5">
                                    <Items>
                                        <ext:Button ID="btnVaiTroThem" runat="server" Icon="ResultsetNext" StyleSpec="margin-bottom:2px;">
                                            <DirectEvents>
                                                <Click OnEvent="btnVaiTroThem_Click">
                                                </Click>
                                            </DirectEvents>
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip4" runat="server" Title="Thêm" Html="Thêm vai trò truy nhập" />
                                            </ToolTips>
                                        </ext:Button>
                                        <ext:Button ID="btnVaiTroBo" runat="server" Icon="ResultsetPrevious" StyleSpec="margin-bottom:2px;">
                                            <DirectEvents>
                                                <Click OnEvent="btnVaiTroBo_Click">
                                                </Click>
                                            </DirectEvents>
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip5" runat="server" Title="Loại bỏ" Html="Loại bỏ vai trò truy nhập" />
                                            </ToolTips>
                                        </ext:Button>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                    </ext:LayoutColumn>
                    <ext:LayoutColumn ColumnWidth="0.5">
                        <ext:GridPanel ID="gridCoVaiTro" runat="server" Title="" Margins="0 0 5 5" Icon="UserSuit"
                            EnableDragDrop="false" AutoExpandColumn="Ten_Vai_Tro" Height="400" AutoScroll="true">
                            <Store>
                                <ext:Store ID="dsCoVaiTro" runat="server">
                                    <Reader>
                                        <ext:JsonReader IDProperty="Ma_Nguoi_Dung_Vai_Tro">
                                            <Fields>
                                                <ext:RecordField Name="Ma_Nguoi_Dung_Vai_Tro" SortDir="ASC" />                                                
                                                <ext:RecordField Name="Ma_Vai_Tro" />
                                                <ext:RecordField Name="Ten_Vai_Tro" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel4" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="Ma_Nguoi_Dung_Vai_Tro" Header="Ma_Nguoi_Dung_Vai_Tro" Hidden="true" />
                                    <ext:Column ColumnID="Ma_Vai_Tro" Header="Ma_Vai_Tro" Hidden="true" />
                                    <ext:Column ColumnID="Ten_Vai_Tro" DataIndex="Ten_Vai_Tro" Header="vai trò có quyền truy nhập"
                                        Width="250" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel4" runat="server" />
                            </SelectionModel>
                        </ext:GridPanel>
                    </ext:LayoutColumn>
                </Columns>
            </ext:ColumnLayout>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>

