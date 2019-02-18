<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatDSVanHoa1.aspx.cs" ValidateRequest="false" Inherits="NghiepVu_Disanvanhoa_CapNhatDSVanHoa" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>
<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>
<%@ Register Src="~/Control/Images/ImageMutil.ascx" TagPrefix="uc1" TagName="ImageMutil" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/Control/Video/Video.ascx" TagPrefix="uc1" TagName="Video" %>


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
    <link href="/css/MapStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <div style="margin: 10px">

            <ext:Panel runat="server" Border="false" Padding="5">
                <Content>
                    <div style="width: 50%; float: left">
                    </div>
                </Content>
            </ext:Panel>
            <table style="color: rgb(41, 84, 149); font: 13px arial,tahoma,sans-serif;">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnUpdate" Text="Lưu lại" ImageUrl="/images/btnAdd.png" runat="server" CssClass="btnsave" OnClick="btnUpdate_Click" />
                    </td>
                    <td>
                        <ext:Hidden runat="server" ID="hdDiSanID" Style="margin-bottom: 5px;" />
                    </td>
                </tr>
                <tr>
                    <td>Mã di sản: </td>
                    <td>
                        <ext:TextField runat="server" ID="txtMaDiSan" Width="350" Margins="2" IndicatorText="*" />

                    </td>
                </tr>
                <tr>
                    <td>Tên di sản: </td>
                    <td>
                        <ext:TextField ID="txtTenDiSan" runat="server" Width="350" Margins="2" IndicatorText="*" />
                    </td>
                </tr>
                <tr style="display: none">
                    <td>Url Seo: </td>
                    <td>
                        <ext:TextField ID="txtUrl" runat="server" Width="350" Margins="2" />
                    </td>
                </tr>
                <tr>
                    <td>Tên khác (nếu có): </td>
                    <td>
                        <ext:TextField ID="txtTenKhac" runat="server" Width="350" Margins="2" />
                    </td>
                </tr>
                <tr>
                    <td>Số quyết định: </td>
                    <td>
                        <ext:TextField runat="server" ID="txtSodangky" Width="300" />
                    </td>
                </tr>

                <tr>
                    <td>Ngày quyết định: </td>
                    <td>
                        <ext:DateField ID="dtNgaychungnhan" runat="server" Width="350" Format="d/M/yyyy" />
                    </td>
                </tr>
                <tr>
                    <td>Cấp di sản: </td>
                    <td>
                        <ext:ComboBox ID="cbCapdisan" runat="server" DisplayField="TenCap" ValueField="ID"
                            Width="350" EmptyText="--Chọn cấp di sản" IndicatorText="*"
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
                    </td>
                </tr>
                <tr>
                    <td>Loại di sản: </td>
                    <td colspan="2">
                        <ext:Hidden runat="server" ID="hdPhivatthe" />
                        <ext:ComboBox ID="cbLoaiDiSan" runat="server" DisplayField="TenLoai" ValueField="LoaiID" IndicatorText="*"
                            Width="350" EmptyText="--Chọn loại di sản" SelectedIndex="0" Mode="Local">
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
                                <Select Handler="if(#{hdPhivatthe}.getValue().indexOf(this.getValue())==-1){#{cbDiSan}.show();}else{#{cbDiSan}.hide()}" />
                            </Listeners>
                        </ext:ComboBox>
                    </td>

                </tr>
                <tr>
                    <td>Di sản phi vật thể liên quan: </td>
                    <td>
                        <ext:ComboBox ID="cbDiSan" runat="server" Hidden="true" DisplayField="TenDiSan" ValueField="DiSanID"
                            Width="350" EmptyText="--Chọn di sản phi vật thể liên quan" Mode="Local">
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
                    </td>
                </tr>
                <tr>
                    <td>Danh mục di sản: </td>
                    <td colspan="2">
                        <ext:MultiCombo ID="mcbDanhmuc" runat="server" ValueField="DanhMucID" DisplayField="TenDanhMuc" Width="350" EmptyText="Chọn danh mục di sản">
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
                    </td>
                </tr>

                <tr>
                    <td>Cơ quan quản lý: </td>
                    <td>
                        <ext:ComboBox ID="cbCoQuanHC" runat="server" DisplayField="TenCoQuan" ValueField="CoQuanID"
                            Width="350" EmptyText="--Chọn cơ quan quản lý" SelectedIndex="0" Mode="Local">
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
                    </td>
                </tr>
                <tr>
                    <td>Thuộc tỉnh: </td>
                    <td>
                        <ext:ComboBox ID="cmbThuocTinh" runat="server" Width="350" SelectedIndex="1" DisplayField="Ten_Tinh" ValueField="Ma_Tinh" SelectOnFocus="true">
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
                            </Listeners>
                        </ext:ComboBox>
                    </td>
                </tr>
                <tr>
                    <td>Thuộc huyện: </td>
                    <td>
                        <ext:ComboBox ID="cmbThuocHuyen" runat="server" Width="350" DisplayField="Ten_Huyen" ValueField="Ma_Huyen" SelectedIndex="0">
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
                    </td>
                </tr>
                <tr>
                    <td>Thuộc xã:</td>
                    <td>
                        <ext:ComboBox ID="cmbThuocXa" runat="server" Width="350" DisplayField="Ten_Xa" ValueField="Ma_Xa" SelectedIndex="0">
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
                    </td>
                </tr>
                <tr>
                    <td>Ảnh đại diện: </td>
                    <td colspan="2">
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:ImageOnly runat="server" ID="ImageOnly" />
                            </Content>
                        </ext:Panel>
                    </td>
                </tr>
                <tr>
                    <td>Album ảnh: </td>
                    <td colspan="2">
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:ImageMutil runat="server" ID="ImageMutil" />
                            </Content>
                        </ext:Panel>
                    </td>
                </tr>
                <tr>
                    <td>Video:</td>
                    <td colspan="2">
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:Video runat="server" ID="Video" />
                            </Content>
                        </ext:Panel>
                    </td>
                </tr>
                <tr>
                    <td>Chọn tài liệu: </td>
                    <td colspan="2">
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:Document runat="server" ID="Document" Width="120" />
                            </Content>
                        </ext:Panel>
                    </td>
                </tr>
                <tr>
                    <td>Lí lịch di sản:</td>
                    <td colspan="2">
                        <ext:HtmlEditor runat="server" ID="txtLilich" Width="800" />
                    </td>
                </tr>
                <tr>
                    <td>Bản đồ khoanh vùng:</td>
                    <td colspan="2">
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:Document runat="server" ID="dBando" Width="120" />
                            </Content>
                        </ext:Panel>
                    </td>
                </tr>
                <tr>
                    <td>Mặt bằng tổng thể (bản vẽ kỹ thuật):</td>
                    <td colspan="2">
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:Document runat="server" ID="dMabang" Width="120" />
                            </Content>
                        </ext:Panel>
                    </td>
                </tr>

                <tr>
                    <td>Niên đại khởi dựng, tu bổ:</td>
                    <td colspan="2">
                        <ext:HtmlEditor runat="server" ID="txtNiendai" Width="800" />
                    </td>
                </tr>

                <tr>
                    <td>Quy hoạch di tích:</td>
                    <td colspan="2">
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:Document runat="server" ID="dQuyhoach" Width="120" />
                            </Content>
                        </ext:Panel>
                    </td>
                </tr>
                <tr>
                    <td>Số lượt khách:</td>
                    <td colspan="2">
                        <ext:TextField runat="server" ID="txtSoluotkhach" Width="300" />
                    </td>
                </tr>

                <tr>
                    <td>Kinh phí tu bổ, bảo quản:</td>
                    <td colspan="2">
                        <ext:TextArea runat="server" ID="txtChiphiduytri" Width="800" />
                    </td>
                </tr>

                <tr>
                    <td>Đề xuất bảo vệ:</td>
                    <td colspan="2">
                        <ext:HtmlEditor runat="server" ID="txtDexuat" Width="800" />
                    </td>
                </tr>

                <tr>
                    <td>Giá trị đánh giá:</td>
                    <td colspan="2">
                        <ext:TextArea runat="server" ID="txtGiatridanhgia" Width="800" />
                    </td>
                </tr>

                <tr>
                    <td>Hiện trạng: </td>
                    <td colspan="2">
                        <ext:TextArea runat="server" ID="txtHientrang" Width="800" />
                    </td>
                </tr>
                <%--<tr>
                    <td>Đưa vào kho tham khảo:</td>
                    <td>
                        <ext:Checkbox runat="server" ID="ckbTrangthai" />
                    </td>
                </tr>--%>
                <%--<tr>
                    <td>Chủ thể văn hóa: </td>
                    <td>
                        <ext:TextArea runat="server" ID="txtChuthevanhoa" Width="650" />
                    </td>
                </tr>--%>
                <tr>
                    <td>Giới thiệu về di sản: </td>
                    <td colspan="2">
                        <FCKeditorV2:FCKeditor ID="txtMoTa" runat="server" BasePath="~/fckeditor/" Height="500" Width="800"></FCKeditorV2:FCKeditor>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
