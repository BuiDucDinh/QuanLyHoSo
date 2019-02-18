<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatHDVH.aspx.cs" Inherits="NghiepVu_Hoatdongvanhoa_CapNhatHDVH" %>

<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>
        <div style="margin: 10px;">

            <div style="margin: 10px">
                <table style="color: rgb(41, 84, 149); font: 13px arial,tahoma,sans-serif;">
                    <tr>
                        <td>
                            <asp:ImageButton ID="btnUpdate" Text="Lưu lại" ImageUrl="/images/btnAdd.png" runat="server" CssClass="btnsave" OnClick="btnUpdate_Click" />
                        </td>
                        <td>
                            <ext:Hidden ID="txtID" runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <td>Ngôn ngữ</td>
                        <td>
                             <ext:ComboBox runat="server" ID="cmbLang" SelectedIndex="0" Width="350">
                                                  <Items>
                                                      <ext:ListItem Text="Tiếng việt" Value="vi" />
                                                      <ext:ListItem Text="Tiếng anh" Value="en" />
                                                  </Items>
                                                   
                                                </ext:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Tên gọi</td>
                        <td>
                            <ext:TextField ID="txtTengoi" runat="server" Width="350" Margins="2" IndicatorText="*" />
                        </td>
                    </tr>
                    <tr>
                        <td>Tên khác (nếu có)</td>
                        <td>
                            <ext:TextField ID="txtTenkhac" runat="server" Width="350" Margins="2" />
                        </td>
                    </tr>
                    <tr>
                        <td>Chọn ảnh</td>
                        <td>
                            <ext:Panel runat="server" Border="false">
                                <Content>
                                    <uc1:ImageOnly runat="server" ID="ImageOnly" Width="120" />
                                </Content>
                            </ext:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>Ngày diễn ra</td>
                        <td>
                            <ext:DateField ID="dtpNgay" runat="server" Width="350" />
                        </td>
                    </tr>
                    <tr>
                        <td>Thời gian diễn ra</td>
                        <td>
                            <ext:TextField ID="txtThoiGian" runat="server" Width="350" Margins="2" />
                        </td>
                    </tr>
                    <tr>
                        <td>Di sản</td>
                        <td>
                            <ext:ComboBox ID="cmbDiSan" runat="server" Width="350" DisplayField="TenDiSan" ValueField="DiSanID" SelectedIndex="0" Mode="Local">
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
                            </ext:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Địa điểm tổ chức</td>
                        <td>

                            <ext:TextField ID="txtDiadiem" runat="server" Width="350" />
                        </td>
                    </tr>
                    <tr>
                        <td>Thuộc tỉnh</td>
                        <td>
                            <ext:ComboBox ID="cmbTinh" runat="server" Width="350" SelectedIndex="0" DisplayField="Ten_Tinh" ValueField="Ma_Tinh" SelectOnFocus="true">
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
                                    <Select Handler="#{cmbHuyen}.clearValue(); #{stHuyen}.reload()" />
                                </Listeners>
                            </ext:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Thuộc huyện</td>
                        <td>
                            <ext:ComboBox ID="cmbHuyen" runat="server" Width="350" DisplayField="Ten_Huyen" ValueField="Ma_Huyen" SelectedIndex="0">
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
                                    <Select Handler="#{cmbXa}.clearValue(); #{stXa}.reload();" />
                                </Listeners>
                            </ext:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Thuộc xã</td>
                        <td>
                            <ext:ComboBox ID="cmbXa" runat="server" Width="350" DisplayField="Ten_Xa" ValueField="Ma_Xa" SelectedIndex="0">
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
                        <td>Đơn vị tổ chức</td>
                        <td>
                            <ext:ComboBox ID="cmbDonvitochuc" runat="server" Width="350" DisplayField="TenCoQuan" ValueField="CoQuanID" SelectedIndex="0" Mode="Local">
                                <Store>
                                    <ext:Store runat="server" ID="stCoQuanToChuc">
                                        <Reader>
                                            <ext:JsonReader>
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
                        <td>Đơn vị quản lý</td>
                        <td>
                            <ext:ComboBox ID="cmbDonviquanly" runat="server" Width="350" DisplayField="TenCoQuan" ValueField="CoQuanID" SelectedIndex="0" Mode="Local">
                                <Store>
                                    <ext:Store runat="server" ID="stCoQuanQuanLy">
                                        <Reader>
                                            <ext:JsonReader>
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
                        <td>Giới thiệu khái quát</td>
                        <td>
                            <ext:HtmlEditor ID="txtGioithieu" runat="server" Width="800" Margins="2" />
                        </td>
                    </tr>
                    <tr>
                        <td>Nội dung hoạt động</td>
                        <td>
                            <FCKeditorV2:FCKeditor ID="txtNoidung" runat="server" BasePath="~/fckeditor/" Height="500" Width="800"></FCKeditorV2:FCKeditor>
                        </td>
                    </tr>
                    <tr>
                        <td>Url SEO</td>
                        <td>
                            <ext:TextField ID="txtUrl" runat="server" Width="350" Margins="2" />

                        </td>

                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
