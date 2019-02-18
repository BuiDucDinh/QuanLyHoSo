<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatDSVanHoa.aspx.cs" ValidateRequest="false" Inherits="NghiepVu_Disanvanhoa_CapNhatDSVanHoa" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>
<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>
<%@ Register Src="~/Control/Images/ImageMutil.ascx" TagPrefix="uc1" TagName="ImageMutil" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/Control/Video/Video.ascx" TagPrefix="uc1" TagName="Video" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Template/js/jquery-2.0.3.min.js"></script>
    <link href="/css/MapStyles.css" rel="stylesheet" />
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };
        var disableControl = function () {
            $("input").prop('disabled', true);
        }
        var onInitialize = function (editor) {
            var styles = {
                color: "white"
            };
            Ext.DomHelper.applyStyles(editor.getEditorBody(), styles);
        };
    </script>
    <style>
        .font-ext {
            font-family: Tahoma;
            font-size: 12px;
        }

        .width-label-tb {
            width: 125px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Access" />
        <div style="margin: 10px">

            <asp:ImageButton ID="btnUpdate" Text="Lưu lại" ImageUrl="/images/btnAdd.png" runat="server" CssClass="btnsave" OnClick="btnUpdate_Click" />

            <ext:Hidden runat="server" ID="hdDiSanID" Style="margin-bottom: 5px;" />
            <ext:Panel runat="server" Border="false" Padding="5">
                <Content>
                    <div style="width: 50%; float: left">
                        <ext:Panel runat="server" Border="true" Width="500" LabelWidth="120" FormGroup="true">
                            <Items>

                                <ext:ComboBox ID="cbNgonNgu" runat="server" LabelWidth="120" Width="250" FieldLabel="Ngôn ngữ">
                                    <Items>
                                        <ext:ListItem Text="Tiếng việt" Value="vi" />
                                        <ext:ListItem Text="Tiếng Anh" Value="en" />
                                    </Items>
                                </ext:ComboBox>

                                <ext:TextField runat="server" ID="txtMaDiSan" Width="450" Margins="2" LabelWidth="120" FieldLabel="Mã di sản *" />
                                <ext:TextField ID="txtTenDiSan" runat="server" Width="450" Margins="2" LabelWidth="120" FieldLabel="Tên di sản *" />
                                <ext:TextField ID="txtUrl" runat="server" Width="450" Margins="2" FieldLabel="Url Hiện Thị" />
                                <ext:TextField ID="txtTenKhac" runat="server" Width="450" Margins="2" FieldLabel="Tên khác (nếu có)" />
                                <ext:TextField runat="server" ID="txtSodangky" Width="450" FieldLabel="Số quyết định" />

                                <ext:DateField ID="dtNgaychungnhan" runat="server" Width="450" Format="d/M/yyyy" FieldLabel="Ngày quyết định" />

                                <ext:ComboBox ID="cbCoQuanHC" runat="server" DisplayField="TenCoQuan" ValueField="CoQuanID" FieldLabel="Cơ quan quản lý"
                                    Width="450" EmptyText="--Chọn cơ quan quản lý" SelectedIndex="0" Mode="Local">
                                    <Store>
                                        <ext:Store runat="server" ID="stCoquanHC">
                                            <Reader>
                                                <ext:JsonReader IDProperty="CoQuanID">
                                                    <Fields>
                                                        <ext:RecordField Name="CoQuanID" />
                                                        <ext:RecordField Name="TenCoQuan" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                </ext:ComboBox>
                                <ext:TextField runat="server" ID="txtSoluotkhach" Width="450" FieldLabel="Số lượt khách" />
                            </Items>
                        </ext:Panel>
                    </div>
                    <div style="width: 50%; float: left">
                        <ext:Panel runat="server" Border="true" LabelWidth="150" FormGroup="true">
                            <Items>
                                <ext:ComboBox ID="cmbThuocTinh" runat="server" Width="450" FieldLabel="Thuộc tính" SelectedIndex="1" DisplayField="Ten_Tinh" ValueField="Ma_Tinh" SelectOnFocus="true">
                                    <Store>
                                        <ext:Store runat="server" ID="stTinh" AutoLoad="true">
                                            <DirectEventConfig>
                                                <EventMask ShowMask="false" />
                                            </DirectEventConfig>
                                            <Reader>
                                                <ext:JsonReader IDProperty="Ma_Tinh">
                                                    <Fields>
                                                        <ext:RecordField Name="Ma_Tinh" />
                                                        <ext:RecordField Name="Ten_Tinh" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Listeners>
                                        <Change Handler="#{cmbThuocHuyen}.clearValue(); #{stHuyen}.reload()" />
                                        <BeforeSelect Handler="#{cmbThuocHuyen}.clearValue(); #{stHuyen}.reload()" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ComboBox ID="cmbThuocHuyen" FieldLabel="Thuộc huyện" runat="server" Width="450" DisplayField="Ten_Huyen" ValueField="Ma_Huyen" SelectedIndex="0">
                                    <Store>
                                        <ext:Store runat="server" ID="stHuyen" AutoLoad="true" OnRefreshData="stHuyen_RefreshData">
                                            <DirectEventConfig>
                                                <EventMask ShowMask="false" />
                                            </DirectEventConfig>
                                            <Reader>
                                                <ext:JsonReader IDProperty="Ma_Huyen">
                                                    <Fields>
                                                        <ext:RecordField Name="Ma_Huyen" />
                                                        <ext:RecordField Name="Ten_Huyen" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Listeners>
                                        <Change Handler="#{cmbThuocXa}.clearValue(); #{stXa}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ComboBox ID="cmbThuocXa" runat="server" FieldLabel="Thuộc xã" Width="450" DisplayField="Ten_Xa" ValueField="Ma_Xa" SelectedIndex="0">
                                    <Store>
                                        <ext:Store runat="server" ID="stXa" AutoLoad="true" OnRefreshData="stXa_RefreshData">
                                            <DirectEventConfig>
                                                <EventMask ShowMask="false" />
                                            </DirectEventConfig>
                                            <Reader>
                                                <ext:JsonReader IDProperty="Ma_Xa">
                                                    <Fields>
                                                        <ext:RecordField Name="Ma_Xa" />
                                                        <ext:RecordField Name="Ten_Xa" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                </ext:ComboBox>
                                <ext:ComboBox ID="cbCapdisan" runat="server" DisplayField="TenCap" ValueField="ID" FieldLabel="Cấp di sản *"
                                    Width="450" EmptyText="--Chọn cấp di sản" AllowBlank="false"
                                    SelectedIndex="0" Mode="Local">
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
                                <ext:Hidden runat="server" ID="hdPhivatthe" />
                                <ext:ComboBox ID="cbLoaiDiSan" runat="server" DisplayField="TenLoai" ValueField="LoaiID" FieldLabel="Loại di sản *"
                                    Width="450" EmptyText="--Chọn loại di sản" SelectedIndex="0" Mode="Local">
                                    <Store>
                                        <ext:Store runat="server" ID="stLoaidisan">
                                            <Reader>
                                                <ext:JsonReader IDProperty="LoaiID">
                                                    <Fields>
                                                        <ext:RecordField Name="LoaiID" />
                                                        <ext:RecordField Name="TenLoai" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Listeners>
                                        <Select Handler="if(#{hdPhivatthe}.getValue().indexOf(this.getValue())==-1){#{cbDiSan}.show();#{txtThoigiandienra}.hide()}else{#{cbDiSan}.hide();#{txtThoigiandienra}.show()}" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ComboBox ID="cbDiSan" runat="server" Hidden="true" DisplayField="TenDiSan" ValueField="DiSanID" FieldLabel="Di sản liên quan"
                                    Width="450" EmptyText="--Chọn di sản phi vật thể liên quan" Mode="Local">
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
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();#{stDisan}.reload();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{stDisan}.reload(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:TextField runat="server" ID="txtThoigiandienra" HideLabel="true" Width="450" FieldLabel="Thời gian diễn ra" />

                                <ext:MultiCombo ID="mcbDanhmuc" runat="server" FieldLabel="Danh mục di sản" ValueField="DanhMucID"
                                    DisplayField="TenDanhMuc" Width="450" EmptyText="Chọn danh mục di sản">
                                    <Store>
                                        <ext:Store runat="server" ID="stDanhmuc">
                                            <Reader>
                                                <ext:JsonReader IDProperty="DanhMucID">
                                                    <Fields>
                                                        <ext:RecordField Name="DanhMucID" />
                                                        <ext:RecordField Name="TenDanhMuc" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                </ext:MultiCombo>
                            </Items>
                        </ext:Panel>

                    </div>

                    <div style="clear: both"></div>
                    <ext:Panel runat="server" Border="false">
                        <Content>
                            <table>
                                <tr>
                                    <td class="font-ext width-label-tb">Văn bản quyết định</td>
                                    <td>
                                        <ext:Panel runat="server" Border="false">
                                            <Content>
                                                <uc1:Document runat="server" ID="ImageSoQuyetDinh" />
                                                <%--<uc1:ImageOnly runat="server" ID="ImageSoQuyetDinh" />--%>
                                            </Content>
                                        </ext:Panel>
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </ext:Panel>
                </Content>
            </ext:Panel>
            <ext:Panel runat="server" Title="Hình ảnh - video -tài liệu" Border="true" LabelWidth="150" FormGroup="true" Padding="5">
                <Content>
                    <table>

                        <tr>
                            <td class="font-ext width-label-tb">Ảnh đại diện</td>
                            <td style="width: 150px;">
                                <ext:Panel runat="server" Border="false">
                                    <Content>
                                        <uc1:ImageOnly runat="server" ID="ImageOnly" />
                                    </Content>
                                </ext:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="font-ext width-label-tb">Tập ảnh khảo tả</td>
                            <td style="width: 350px;">
                                <ext:Panel runat="server" Border="false">
                                    <Content>
                                        <uc1:ImageMutil runat="server" ID="ImageMutil" />
                                    </Content>
                                </ext:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="font-ext width-label-tb">Video</td>
                            <td>
                                <ext:Panel runat="server" Border="false">
                                    <Content>
                                        <uc1:Video runat="server" ID="Video" />
                                    </Content>
                                </ext:Panel>
                            </td>
                        </tr>
                    </table>
                </Content>
            </ext:Panel>
            <ext:Panel runat="server" Border="true" FormGroup="true" Title="Tài liệu" Padding="5">
                <Content>

                    <table>
                        <tr>
                            <td class="font-ext width-label-tb">Lý lịch di tích</td>
                            <td>
                                <ext:Panel runat="server" Border="false">
                                    <Content>
                                        <uc1:Document runat="server" ID="Document" />
                                    </Content>
                                </ext:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="font-ext width-label-tb">Bản đồ khoanh vùng di tích</td>
                            <td>
                                <ext:Panel runat="server" Border="false">
                                    <Content>
                                        <uc1:Document runat="server" ID="dBando" />
                                    </Content>
                                </ext:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="font-ext width-label-tb">Biên bản khoanh vùng di tích</td>
                            <td>
                                <ext:Panel runat="server" Border="false">
                                    <Content>
                                        <uc1:Document runat="server" ID="ImageBando" />
                                        <%--<uc1:ImageOnly runat="server" ID="ImageBando" />--%>
                                    </Content>
                                </ext:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="font-ext width-label-tb">Bản vẽ kỹ thuật di tích</td>
                            <td>
                                <ext:Panel runat="server" Border="false">
                                    <Content>
                                        <uc1:Document runat="server" ID="dMabang" />
                                    </Content>
                                </ext:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="font-ext width-label-tb">Bảng thông kê hiện vật</td>
                            <td>
                                <ext:Panel runat="server" Border="false">
                                    <Content>
                                        <uc1:Document runat="server" ID="dThongKeHienVat" Width="120" />
                                    </Content>
                                </ext:Panel>
                            </td>
                        </tr>

                        <tr>
                            <td class="font-ext width-label-tb">Quy hoạch di tích (Mặt bằng tổng thể)</td>
                            <td>
                                <ext:Panel runat="server" Border="false">
                                    <Content>
                                        <uc1:Document runat="server" ID="dQuyhoach" Width="120" />
                                    </Content>
                                </ext:Panel>
                            </td>
                        </tr>
                    </table>
                </Content>
            </ext:Panel>
            <ext:Panel runat="server" Border="true" FormGroup="true" Padding="5" LabelWidth="120">
                <Content>
                    <ext:HtmlEditor runat="server" ID="txtLilich" Width="1050" AnchorHorizontal="100%" FieldLabel="Lí lịch di sản" Hidden="true" />
                    <ext:HtmlEditor runat="server" ID="txtNiendai" Width="1050" FieldLabel="Niên đại khởi dựng, tu bổ" />
                    <ext:HtmlEditor runat="server" ID="txtGiatridanhgia" Width="1050" FieldLabel="Giá trị đánh giá" Hidden="true" />
                    <ext:HtmlEditor runat="server" ID="txtChiphiduytri" Width="1050" FieldLabel="Kinh phí tu bổ, bảo quản" />
                    <ext:HtmlEditor runat="server" ID="txtHientrang" Width="1050" FieldLabel="Hiện trạng" />
                    <ext:HtmlEditor runat="server" ID="txtDexuat" Width="1050" FieldLabel="Đề xuất bảo vệ" Hidden="true" />
                    <ext:NumberField runat="server" ID="txtStt" FieldLabel="Thứ tự" MinValue="0" />
                </Content>
            </ext:Panel>
            <table>
                <tr>
                    <td class="font-ext width-label-tb">Giới thiệu về di sản</td>
                    <td>
                        <FCKeditorV2:FCKeditor ID="txtMoTa" runat="server" BasePath="~/fckeditor/" Height="500" Width="800"></FCKeditorV2:FCKeditor>
                    </td>
                </tr>
            </table>

        </div>

    </form>
</body>
</html>
