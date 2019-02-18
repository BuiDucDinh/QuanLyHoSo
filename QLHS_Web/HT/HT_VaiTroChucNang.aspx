<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HT_VaiTroChucNang.aspx.cs"
    Inherits="HT_HT_VaiTroChucNang"  ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Panel ID="TabPanel1" runat="server" ActiveTabIndex="0" Border="false" DeferredRender="false">
        <Items>
            <ext:Panel ID="Panel4" runat="server" Title="Phân quyền chức năng" Icon="UserKey"
                Padding="5" Layout="FitLayout" Height="450" AutoScroll="true">
                <Items>
                    <ext:ComboBox ID="cboMa_Du_An" runat="server" FieldLabel="Dự án" Width="350" EmptyText="--Chọn dự án--"
                        DisplayField="Ten_Du_An" ValueField="Ma_Du_An" Mode="Local">
                        <Store>
                            <ext:Store ID="dsDu_An" runat="server">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="Ma_Du_An" />
                                            <ext:RecordField Name="Ten_Du_An" SortDir="ASC" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <DirectEvents>
                            <Select OnEvent="cboMa_Du_An_Click" />
                        </DirectEvents>
                    </ext:ComboBox>
                    <ext:GridPanel ID="gridVaiTroChucNang" runat="server" Title="" Margins="0 0 5 5"
                        Icon="UserSuit" EnableDragDrop="false" AutoExpandColumn="Ten_Chuc_Nang" AutoScroll="true" AutoHeight="true">
                        <Store>
                            <ext:Store ID="dsVaiTroChucNang" runat="server">
                                <Reader>
                                    <ext:JsonReader IDProperty="Ma_Chuc_Nang">
                                        <Fields>
                                            <ext:RecordField Name="Ma_Chuc_Nang" SortDir="ASC" />
                                            <ext:RecordField Name="Ten_Chuc_Nang" />
                                            <ext:RecordField Name="Duoc_Truy_Cap" />
                                            <ext:RecordField Name="Duoc_Sua" />
                                            <ext:RecordField Name="Duoc_Xoa" />
                                            <ext:RecordField Name="Duoc_Xuat" />
                                            <ext:RecordField Name="Duoc_Nhap" />
                                            <ext:RecordField Name="Duoc_Duyet" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel3" runat="server">
                            <Columns>
                                <ext:Column ColumnID="Ma_Chuc_Nang" Header="Ma_Chuc_Nang" Hidden="true" />
                                <ext:Column ColumnID="Ten_Chuc_Nang" DataIndex="Ten_Chuc_Nang" Header="Tên chức năng"
                                    Width="350" />
                                <ext:CheckColumn ColumnID="Duoc_Truy_Cap" Editable="true" DataIndex="Duoc_Truy_Cap"
                                    Header="Truy cập" Width="60" />
                                <ext:CheckColumn ColumnID="Duoc_Sua" Editable="true" DataIndex="Duoc_Sua" Header="Sửa"
                                    Width="50" />
                                <ext:CheckColumn ColumnID="Duoc_Xoa" Editable="true" DataIndex="Duoc_Xoa" Header="Xóa"
                                    Width="50" />
                                <ext:CheckColumn ColumnID="Duoc_Xuat" Editable="true" DataIndex="Duoc_Xuat" Header="Xuất"
                                    Width="50" />
                                <ext:CheckColumn ColumnID="Duoc_Nhap" Editable="true" DataIndex="Duoc_Nhap" Header="Nhập"
                                    Width="50" />
                                <ext:CheckColumn ColumnID="Duoc_Duyet" Editable="true" DataIndex="Duoc_Duyet" Header="Duyệt"
                                    Width="50" />
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" />
                        </SelectionModel>
                    </ext:GridPanel>
                </Items>
            </ext:Panel>
        </Items>
        <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnUpdate" runat="server" Text="Cập nhật" Icon="ApplicationFormEdit">
                        <DirectEvents>
                            <Click OnEvent="btnUpdate_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="values" Value="#{gridVaiTroChucNang}.getRowsValues()" Mode="Raw"
                                        Encode="true" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>
    </ext:Panel>
    </form>
</body>
</html>
