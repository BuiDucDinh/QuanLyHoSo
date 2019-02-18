<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatQuangcao.aspx.cs" Inherits="NghiepVu_Quangcao_CapNhatQuangcao" %>

<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>

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
    <link href="/css/other.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <!----Goi ung dung ext------>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Panel ID="ViewPort1" Padding="10" runat="server" Layout="FormLayout" AutoScroll="true" LabelWidth="150" EnableTheming="false">
            <Content>
                <ext:Hidden runat="server" ID="hdID" Style="margin-bottom: 5px;" />
                <ext:Checkbox runat="server" ID="ckbIsImage" Checked="true" FieldLabel="Quảng cáo 1 ảnh">
                    <Listeners>
                        <AfterRender Handler="this.el.on('change', function (e, el) { if(el.checked){#{pnDes}.hide();#{pnImage}.show();}else{#{pnDes}.show();#{pnImage}.hide();} });" />
<%--                        <Change Handler="if(#{ckbIsImage}.checked){#{pnDes}.hide();#{pnImage}.show();}else{#{pnDes}.show();#{pnImage}.hide();}" />--%>
                    </Listeners>
                </ext:Checkbox>
                <ext:TextField ID="txtName" runat="server" FieldLabel="Tên" Width="350" AllowBlank="false" Margins="2" IndicatorText="*" />
                <ext:ComboBox runat="server" ID="cbType" FieldLabel="Chọn vị trí quảng cáo" SelectedIndex="0" Width="300" DisplayField="name" ValueField="key">
                    <Store>
                        <ext:Store runat="server" ID="stType">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="key" />
                                        <ext:RecordField Name="name" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>

                <ext:ComboBox runat="server"
                    ID="cbMenu" FieldLabel="Trong trang" Width="300"
                    Editable="true"
                    DisplayField="TenMenu"
                    ValueField="MenuID"
                    TypeAhead="true"
                    ForceSelection="true"
                    EmptyText="--- Menu ---"
                    Resizable="true"
                    SelectOnFocus="true">
                    <Store>
                        <ext:Store ID="stMenu" runat="server">
                            <Proxy>
                                <ext:PageProxy />
                            </Proxy>
                            <Reader>
                                <ext:JsonReader IDProperty="MenuID">
                                    <Fields>
                                        <ext:RecordField Name="MenuID" />
                                        <ext:RecordField Name="TenMenu" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>

                <ext:ComboBox runat="server" ID="cbTarget" FieldLabel="Target" SelectedIndex="1" Width="300">
                    <Items>
                        <ext:ListItem Text="New Window" Value="_blank" />
                        <ext:ListItem Text="Same Window" Value="_self" />
                    </Items>
                </ext:ComboBox>

                <ext:NumberField ID="txtThuTu" runat="server" FieldLabel="Thứ tự" Margins="2" AllowDecimals="false" AllowNegative="false" MaxValue="1000" />

                <ext:Panel runat="server" ID="pnImage" Border="false" LabelWidth="150">
                    <Items>
                        <ext:TextField ID="txtLink" runat="server" FieldLabel="Url" Width="500" AllowBlank="false" Margins="2" />
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:ImageOnly runat="server" ID="ImageOnly" LabelWidth="150" Width="280" FieldLabel="Chọn ảnh"/>
                            </Content>
                        </ext:Panel>
                    </Items>
                </ext:Panel>
                <ext:Panel runat="server" ID="pnDes" Hidden="true" Border="false" LabelWidth="150">
                    <Items>
                        <ext:HtmlEditor runat="server" ID="txtDescription" FieldLabel="Nội dung" Width="900" />
                    </Items>
                </ext:Panel>
                <ext:Checkbox runat="server" ID="ckbDuyet" Checked="true" FieldLabel="Duyệt" />
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
