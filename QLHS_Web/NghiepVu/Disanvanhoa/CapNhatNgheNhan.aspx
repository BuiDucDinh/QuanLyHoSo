<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatNgheNhan.aspx.cs" Inherits="NghiepVu_Quanlyvanban_CapNhatNgheNhan" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>
<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
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
        <div style="margin: 10px">
            <asp:ImageButton ID="btnUpdate" Text="Lưu lại" ImageUrl="/images/btnAdd.png" runat="server" CssClass="btnsave" OnClick="btnUpdate_Click" />
            <ext:Hidden runat="server" ID="hdID" Style="margin-bottom: 5px;" />
            <ext:Panel runat="server" Border="false" Padding="5">
                <Content>
                    <div style="width: 50%; float: left">
                        <ext:Panel runat="server" Border="true" LabelWidth="150" FormGroup="true">
                            <Items>
                                <ext:TextField runat="server" ID="txtHoten" Width="400" Margins="2" FieldLabel="Họ tên nghệ nhân *" />
                                <ext:TextField ID="txtTenkhac" runat="server" Width="400" Margins="2" FieldLabel="Tên gọi khác (nếu có)" />
                                <ext:TextField runat="server" ID="txtNgaySinh" Width="400" Format="d/M/yyyy" FieldLabel="Ngày sinh " />
                                <ext:ComboBox ID="cbDantoc" runat="server" DisplayField="Ten_Dan_Toc" ValueField="Ma_Dan_Toc"
                                    Width="400" EmptyText="--Chọn dân tộc" FieldLabel="Dân tộc"
                                    SelectedIndex="0" Mode="Local">
                                    <Store>
                                        <ext:Store runat="server" ID="stDantoc">
                                            <Reader>
                                                <ext:JsonReader IDProperty="Ma_Dan_Toc">
                                                    <Fields>
                                                        <ext:RecordField Name="Ma_Dan_Toc" />
                                                        <ext:RecordField Name="Ten_Dan_Toc" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                </ext:ComboBox>
                                <ext:TextField ID="txtNguyenquan" runat="server" Width="400" Margins="2" FieldLabel="Nguyên quán" />
                                <ext:TextField ID="txtHokhau" runat="server" Width="400" Margins="2" FieldLabel="Hộ khẩu thường trú" />
                                <ext:TextField ID="txtDiachi" runat="server" Width="400" Margins="2" FieldLabel="Địa chỉ" />

                            </Items>
                        </ext:Panel>
                    </div>
                    <div style="width: 50%; float: left">
                        <ext:Panel runat="server" Border="true" LabelWidth="150" FormGroup="true">
                            <Items>
                                <ext:ComboBox ID="cbDanhhieu" runat="server" DisplayField="TenDanhHieu" ValueField="ID"
                                    Width="400" EmptyText="--Chọn danh hiệu nghệ nhân" IndicatorText="*" Mode="Local" FieldLabel="Danh hiệu nghệ nhân">
                                    <Store>
                                        <ext:Store runat="server" ID="stDanhHieu">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="TenDanhHieu" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                </ext:ComboBox>
                                <ext:DateField runat="server" ID="txtNgaycap" Width="400" Format="d/M/yyyy" FieldLabel="Ngày cấp danh hiệu" />
                                <ext:ComboBox runat="server" ID="cbLoaiDS" Width="400" DisplayField="TenLoai"
                                    ValueField="LoaiID" FieldLabel="Loại hình di sản">
                                    <Store>
                                        <ext:Store runat="server" ID="stLoaiDS">
                                            <Reader>
                                                <ext:JsonReader>
                                                    <Fields>
                                                        <ext:RecordField Name="LoaiID" />
                                                        <ext:RecordField Name="TenLoai" />
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
                                <ext:ComboBox runat="server" ID="cbDiSan" Width="400" DisplayField="TenDiSan"
                                    ValueField="DiSanID" FieldLabel="Di sản phi vật thể sở hữu">
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
                                <ext:TextField ID="txtTenDS" runat="server" Width="400" Margins="2" FieldLabel="Mô tả di sản" />

                                <ext:TextField ID="txtNambatdau" runat="server" Width="400" Margins="2" FieldLabel="Năm bắt đầu thực hiện di sản" />
                                <ext:TextField ID="txtDienthoai" runat="server" Width="400" Margins="2" FieldLabel="Điện thoại cố định" />

                                <ext:TextField ID="txtDidong" runat="server" Width="400" Margins="2" FieldLabel="Điện thoại di động" />
                            </Items>
                        </ext:Panel>
                    </div>
                </Content>
            </ext:Panel>
            <table style="color: rgb(41, 84, 149); font: 13px arial,tahoma,sans-serif;">
                <%--<tr>
                    <td>Thuộc tỉnh: </td>
                    <td>
                        <ext:ComboBox ID="cmbThuocTinh" runat="server" Width="350" SelectedIndex="0" DisplayField="Ten_Tinh" ValueField="Ma_Tinh" SelectOnFocus="true">
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
                </tr>--%>
                <tr>
                    <td>Ảnh : </td>
                    <td>
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:ImageOnly runat="server" ID="ImageOnly" />
                            </Content>
                        </ext:Panel>
                    </td>
                </tr>
                <tr>
                    <td>Quá trình thực hiện di sản:</td>
                    <td>
                        <ext:HtmlEditor runat="server" ID="txtQuatrinh" Width="800" />
                    </td>
                </tr>
                <tr>
                    <td>Tri thức và kỹ năng đang nắm giữ:</td>
                    <td>
                        <ext:HtmlEditor runat="server" ID="txtTrithuc" Width="800" />
                    </td>
                </tr>
                <tr>
                    <td>Thành tích khen thưởng:</td>
                    <td>
                        <ext:HtmlEditor runat="server" ID="txtKhenthuong" Width="800" />
                    </td>
                </tr>
                <tr>
                    <td>Kỷ luật:</td>
                    <td>
                        <ext:HtmlEditor runat="server" ID="txtKyluat" Width="800" />
                    </td>
                </tr>

                <tr>
                    <td>Tài liệu: </td>
                    <td>
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:Document runat="server" ID="Document" Width="120" />
                            </Content>
                        </ext:Panel>
                    </td>
                </tr>
                <tr>
                    <td>Giới thiệu về nghệ nhân: </td>
                    <td>
                        <FCKeditorV2:FCKeditor runat="server" ID="fckGioithieu" BasePath="~/fckeditor/" Width="800" Height="400" />
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>

