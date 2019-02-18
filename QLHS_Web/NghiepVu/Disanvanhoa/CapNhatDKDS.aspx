<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatDKDS.aspx.cs" Inherits="NghiepVu_Disanvanhoa_CapNhatDKDS" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };
    </script>
    <script src="/Template/js/jquery-2.0.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Panel ID="ViewPort2" runat="server" Layout="FormLayout" Padding="10">
            <Content>
                <ext:TextField ID="txtSodangky" runat="server" FieldLabel="Số đăng ký" AllowBlank="false" Width="400" IndicatorText="*" />
                <ext:DateField ID="dtNgaydangky" runat="server" FieldLabel="Ngày đăng ký" Width="200" Format="d/M/yyyy"/>
                <ext:ComboBox ID="cmbTendisan" runat="server" FieldLabel="Tên di sản" EmptyText="--Chọn di sản--" AllowBlank="false" IndicatorText="*"
                    Editable="false" Width="400" DisplayField="TenDiSan" ValueField="DiSanID">
                    <Store>
                        <ext:Store runat="server" ID="stDiSan">
                            <Reader>
                                <ext:JsonReader IDProperty="DiSanID">
                                    <Fields>
                                        <ext:RecordField Name="DiSanID" />
                                        <ext:RecordField Name="TenDiSan" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbCapdisan" runat="server" FieldLabel="Đăng ký cấp di sản" EmptyText="--Chọn cấp di sản--" AllowBlank="false" IndicatorText="*"
                    Editable="false" Width="400" DisplayField="TenCap" ValueField="ID">
                    <Store>
                        <ext:Store runat="server" ID="stCapDiSan">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="TenCap" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:HtmlEditor ID="txtMota" runat="server" FieldLabel="Mô tả"
                    Width="600" />

                <ext:TextField ID="txtTinhtrang" runat="server" FieldLabel="Tình trạng di sản" Width="400" />

                <ext:RadioGroup ID="radDuyet" runat="server" FieldLabel="Trạng thái" Width="400">
                    <Items>
                        <ext:Radio ID="radDaDuyet" runat="server" InputValue="1" BoxLabel="Đã duyệt" />
                        <ext:Radio ID="radChuaDuyet" runat="server" InputValue="0" BoxLabel="Chưa duyệt" Checked="true" />
                    </Items>
                </ext:RadioGroup>
                <ext:Panel runat="server" Border="false">
                    <Content>
                        <uc1:Document runat="server" ID="Document" labelwidth="100" />
                    </Content>
                </ext:Panel>
            </Content>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Lưu lại" Icon="DatabaseSave" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
    </form>
</body>
</html>
