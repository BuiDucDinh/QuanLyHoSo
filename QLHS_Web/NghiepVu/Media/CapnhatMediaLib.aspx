<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapnhatMediaLib.aspx.cs" Inherits="NghiepVu_Media_CapnhatMediaLib" %>

<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>
<%@ Register Src="~/Control/Images/ImageMutil.ascx" TagPrefix="uc1" TagName="ImageMutil" %>
<%@ Register Src="~/Control/Video/Video.ascx" TagPrefix="uc1" TagName="Video" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/css/MapStyles.css" rel="stylesheet" />
    <link href="/css/other.css" rel="stylesheet" />
    <%-- <script>
        function addDescripton() {
            var imgs = "<%=ImageMutil.ImageID%>";
            var arr = imgs.split(',');
            var arrImg=[];
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] != '') arrImg.push(arr[i]);
            }
            if (arrImg.length > 0) {

            }
        };
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="ViewPort2" runat="server" Layout="FormLayout" LabelWidth="100" Padding="10">
            <Content>
                <ext:Hidden runat="server" ID="hdMediaLibID" />
                <ext:TextField runat="server" ID="txtTenLib" Width="600" />
                <ext:ComboBox runat="server" ID="cmbHoatDong" FieldLabel="Chọn hoạt động văn hóa" EmptyText="Chọn hoạt động văn hóa" Width="350" DisplayField="TenGoi" ValueField="HoatDongID">
                    <Store>
                        <ext:Store runat="server" ID="stHoatDong">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="HoatDongID" />
                                        <ext:RecordField Name="TenGoi" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.triggers[0].show();" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox runat="server" ID="cmbDiSan" FieldLabel="Chọn di sản" EmptyText="Chọn di sản văn hóa" Width="350" DisplayField="TenDiSan" ValueField="DiSanID">
                    <Store>
                        <ext:Store runat="server" ID="stDiSan">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="DiSanID" />
                                        <ext:RecordField Name="TenDiSan" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.triggers[0].show();" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();}" />
                    </Listeners>
                </ext:ComboBox>

                <ext:MultiCombo ID="mcbDanhmuc" runat="server" FieldLabel="Danh mục tin" ValueField="MenuID" DisplayField="TenMenu" Width="350" EmptyText="Chọn danh mục tin">
                    <Store>
                        <ext:Store runat="server" ID="stDanhmuc">
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
                </ext:MultiCombo>
                <ext:HtmlEditor runat="server" ID="txtMota" Width="600" FieldLabel="Mô tả" Height="100" />
                <ext:Panel runat="server" ID="pnHinhAnh" Border="false">
                    <Content>
                        <uc1:ImageOnly runat="server" ID="ImageOnly" LabelWidth="100" FieldLabel="Chọn ảnh" Width="280" />
                    </Content>
                </ext:Panel>
                <ext:DateField runat="server" ID="dfNgaytao" Width="600" FieldLabel="Ngày tạo" ReadOnly="true" />
                <ext:DateField runat="server" ID="dfNgaysua" Width="600" FieldLabel="Ngày sửa" />
                <ext:Checkbox runat="server" ID="ckbDuyet" FieldLabel="Duyệt" Checked="false" />

                <ext:TextField runat="server" ID="txtPageTitle" Width="600" FieldLabel="PageTitle" />
                <ext:TextField runat="server" ID="txtUrl" Width="600" FieldLabel="Url SEO" />
                <ext:TextField runat="server" ID="txtMetaKeyword" Width="600" FieldLabel="Meta Keyword" />
                <ext:TextField runat="server" ID="txtMetaDescription" Width="600" FieldLabel="Meta Description" />
                <ext:Panel runat="server" ID="pnBoAnh" Border="false">
                    <Content>
                        <uc1:ImageMutil runat="server" ID="ImageMutil" LabelWidth="100" FieldLabel="Chọn ảnh" Width="280" />
                    </Content>
                </ext:Panel>
                <ext:Panel runat="server" ID="pnVideo" Border="false">
                    <Content>
                        <uc1:Video runat="server" ID="Video" LabelWidth="100" FieldLabel="Chọn ảnh" Width="280" />
                    </Content>
                </ext:Panel>
            </Content>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Lưu lại" Icon="DatabaseSave" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="btnCancel" Text="Hủy" Icon="Cross" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnCancel_Click">
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
