<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimKiemDiSan.aspx.cs" Inherits="NghiepVu_Timkiem_Timkiemdisan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value);
        };

        var pctChange = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value + "%");
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:ArrayReader>
                    <Fields>
                        <ext:RecordField Name="company" />
                        <ext:RecordField Name="price" Type="String" />
                        <ext:RecordField Name="change" Type="String" />
                        <ext:RecordField Name="pctChange" Type="String" />
                        <ext:RecordField Name="lastChange" Type="Date" DateFormat="M/d hh:mmtt" />
                    </Fields>
                </ext:ArrayReader>
            </Reader>
        </ext:Store>
        <ext:Panel ID="Panel1" runat="server" AnchorHorizontal="100%" Height="570">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <East>
                        <ext:GridPanel ID="grResult" runat="server" StoreID="Store1" StripeRows="true"
                            TrackMouseOver="true" Width="700" AutoExpandColumn="Company" Icon="None">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column ColumnID="Company" Header="Tên công ty" Width="100" DataIndex="company" />
                                    <ext:Column Header="Tên di sản" Width="100" DataIndex="price">
                                        <Renderer Fn="change" />
                                    </ext:Column>
                                    <ext:Column Header="Địa danh" Width="100" DataIndex="change">
                                        <Renderer Fn="change" />
                                    </ext:Column>
                                    <ext:Column Header="Loại di sản" Width="100" DataIndex="pctChange">
                                        <Renderer Fn="change" />
                                    </ext:Column>
                                    <ext:Column Header="Cấp di sản" Width="100" DataIndex="pctChange">
                                        <Renderer Fn="change" />
                                    </ext:Column>
                                    <ext:Column Header="Đơn vị quản lý" Width="100" DataIndex="pctChange">
                                        <Renderer Fn="change" />
                                    </ext:Column>
                                    <ext:DateColumn Header="Ngày khảo sát" Width="100" DataIndex="lastChange" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                    <Listeners>
                                        <RowSelect Handler="#{FormPanel1}.getForm().loadRecord(record);" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                        </ext:GridPanel>
                    </East>
                    <Center>
                        <ext:FormPanel ID="FormPanel1" runat="server" Title="Thông tin tìm kiếm" Padding="5" ButtonAlign="Right" Icon="Information">
                            <Items>
                                <ext:ComboBox ID="cbLoaiDiSan" runat="server" FieldLabel="Loại di sản" AnchorHorizontal="95%"
                                    EmptyText="--Loại di sản-" AllowBlank="true">
                                    <Items>
                                        <ext:ListItem Value="0" Text="Di sản văn hóa phi vật thể đại diện của nhân loại" />
                                        <ext:ListItem Value="1" Text="Danh lam thắng cảnh" />
                                        <ext:ListItem Value="2" Text="Nghi thức truyền thống" />
                                    </Items>
                                </ext:ComboBox>
                                <ext:TextField ID="CompanyField" runat="server" FieldLabel="Tên di sản"
                                    AnchorHorizontal="95%" />
                                <ext:Panel runat="server" ID="pnCaNhan" Hidden="true">
                                    <Content>
                                        <ext:TextField ID="PriceField" runat="server" FieldLabel="Người đại diện"
                                            AnchorHorizontal="95%" />
                                        <ext:TextField ID="ChangeField" runat="server" FieldLabel="Địa chỉ"
                                            AnchorHorizontal="95%" />
                                        <ext:TextField ID="PctChangeField" runat="server" FieldLabel="Điện thoại"
                                            AnchorHorizontal="95%" />
                                    </Content>
                                </ext:Panel>
                                <ext:ComboBox ID="cbDVQuanLy" runat="server" FieldLabel="Đơn vị quản lý" AnchorHorizontal="95%"
                                    EmptyText="--Cấp đơn vị--" AllowBlank="true">
                                    <Items>
                                        <ext:ListItem Value="0" Text="Sở văn hóa, thể thao và du lịch" />
                                        <ext:ListItem Value="1" Text="Phòng di sản tỉnh" />
                                    </Items>
                                </ext:ComboBox>
                                <ext:ComboBox ID="cbDVToChuc" runat="server" FieldLabel="Đơn vị tổ chức" AnchorHorizontal="95%"
                                    EmptyText="--Chứng chỉ--" AllowBlank="true">
                                    <Items>
                                        <ext:ListItem Value="0" Text="Sở văn hóa, thể thao và du lịch" />
                                        <ext:ListItem Value="1" Text="Phòng di sản tỉnh" />
                                    </Items>
                                </ext:ComboBox>
                                <ext:ComboBox ID="cboCapDiSan" runat="server" FieldLabel="Cấp di sản" AnchorHorizontal="95%"
                                    EmptyText="--Cấp đơn vị--" AllowBlank="true">
                                    <Items>
                                        <ext:ListItem Value="0" Text="Cấp địa phương" />
                                        <ext:ListItem Value="1" Text="Cấp tỉnh" />
                                        <ext:ListItem Value="2" Text="Cấp nhà nước" />
                                    </Items>
                                </ext:ComboBox>
                                
                                <ext:DateField ID="dtNgaykhaosat" runat="server" FieldLabel="Ngày khảo sát" AnchorHorizontal="95%" />
                                <ext:TextArea ID="txtGhichu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="95%" />
                                <ext:FileUploadField ID="BasicField" runat="server" Icon="Attach" FieldLabel="File đính kèm" AnchorHorizontal="95%" />
                            </Items>
                            <Buttons>
                                <ext:Button ID="btnCapnhat" runat="server" Text="Tìm kiếm" Icon="Add">
                                    <Listeners>
                                        <Click Handler="#{FormPanel1}.getForm().updateRecord(#{GridPanel1}.getSelectionModel().getSelected());" />
                                    </Listeners>
                                </ext:Button>
                            </Buttons>
                        </ext:FormPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
