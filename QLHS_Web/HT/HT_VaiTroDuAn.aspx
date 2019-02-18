<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_VaiTroDuAn.aspx.cs" Inherits="HT_HT_VaiTroDuAn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Panel ID="Panel4" runat="server" Title="Vai trò dự án" Icon="UserKey" Padding="5"
        Layout="ColumnLayout" AutoHeight="true" AutoScroll="true">
        <Items>
            <ext:ColumnLayout ID="ColumnLayout2" runat="server">
                <Columns>
                    <ext:LayoutColumn ColumnWidth="0.5">
                        <ext:GridPanel ID="gridKhongDuAn" runat="server" Title="" Margins="0 0 5 5" Icon="UserSuit"
                            EnableDragDrop="false" AutoExpandColumn="Ma_Du_An" Height="400" AutoScroll="true">
                            <Store>
                                <ext:Store ID="dsKhongDuAn" runat="server">
                                    <Reader>
                                        <ext:JsonReader IDProperty="Ma_Du_An">
                                            <Fields>
                                                <ext:RecordField Name="Ma_Du_An" SortDir="ASC" />
                                                <ext:RecordField Name="Ten_Du_An" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel3" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="Ma_Du_An" Header="Ma_Du_An" Hidden="true" />
                                    <ext:Column ColumnID="Ten_Du_An" DataIndex="Ten_Du_An" Header="Dự án không có quyền truy nhập"
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
                                        <ext:Button ID="btnDuAnThem" runat="server" Icon="ResultsetNext" StyleSpec="margin-bottom:2px;">
                                            <DirectEvents>
                                                <Click OnEvent="btnDuAnThem_Click">
                                                </Click>
                                            </DirectEvents>
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip4" runat="server" Title="Thêm" Html="Thêm dự án truy nhập" />
                                            </ToolTips>
                                        </ext:Button>
                                        <ext:Button ID="btnDuAnBo" runat="server" Icon="ResultsetPrevious" StyleSpec="margin-bottom:2px;">
                                            <DirectEvents>
                                                <Click OnEvent="btnDuAnBo_Click">
                                                </Click>
                                            </DirectEvents>
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip5" runat="server" Title="Loại bỏ" Html="Loại bỏ dự án truy nhập" />
                                            </ToolTips>
                                        </ext:Button>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                    </ext:LayoutColumn>
                    <ext:LayoutColumn ColumnWidth="0.5">
                        <ext:GridPanel ID="gridCoDuAn" runat="server" Title="" Margins="0 0 5 5" Icon="UserSuit"
                            EnableDragDrop="false" AutoExpandColumn="Ten_Du_An" Height="400" AutoScroll="true">
                            <Store>
                                <ext:Store ID="dsCoDuAn" runat="server">
                                    <Reader>
                                        <ext:JsonReader IDProperty="Ma_Vai_Tro_Du_An">
                                            <Fields>
                                                <ext:RecordField Name="Ma_Vai_Tro_Du_An" SortDir="ASC" />                                                
                                                <ext:RecordField Name="Ma_Du_An" />
                                                <ext:RecordField Name="Ten_Du_An" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel4" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="Ma_Vai_Tro_Du_An" Header="Ma_Vai_Tro_Du_An" Hidden="true" />
                                    <ext:Column ColumnID="Ma_Du_An" Header="Ma_Du_An" Hidden="true" />
                                    <ext:Column ColumnID="Ten_Du_An" DataIndex="Ten_Du_An" Header="dự án có quyền truy nhập"
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
