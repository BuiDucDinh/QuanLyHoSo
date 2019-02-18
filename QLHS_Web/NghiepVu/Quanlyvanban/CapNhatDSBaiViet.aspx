<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatDSBaiViet.aspx.cs" Inherits="NghiepVu_Quanlyvanban_CapNhatDSBaiViet" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>
<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/css/other.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <div style="margin: 10px">
            <table style="color: rgb(41, 84, 149); font: 13px arial,tahoma,sans-serif;">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnUpdate" ImageUrl="/images/btnAdd.png" runat="server" CssClass="btnsave" OnClick="btnUpdate_Click" />
                    </td>
                    <td>
                        <ext:Hidden runat="server" ID="hdBaiVietID" />
                    </td>
                </tr>
                 <tr>
                    <td>Ngôn ngữ: </td>
                    <td>
                        <ext:ComboBox runat="server" ID="cmbLang" SelectedIndex="0" Width="350">
                            <Items>
                                <ext:ListItem Text="Tiếng việt" Value="vi" />
                                <ext:ListItem Text="Tiếng anh" Value="en" />
                            </Items>
                            <DirectEvents>
                                <Change OnEvent="cmbLang_Change" />
                            </DirectEvents>
                        </ext:ComboBox>
                    </td>
                </tr>
                <tr>
                    <td>Tên ấn phẩm, bài viết: </td>
                    <td>
                        <ext:TextField ID="txtTieuDe" runat="server" IndicatorText="*" Style="margin-top: 5px;" Width="600" />

                    </td>
                </tr>
               

                <tr>
                    <td>Danh mục tin: </td>
                    <td>
                        <ext:MultiCombo ID="mcbDanhmuc" runat="server" ValueField="MenuID" DisplayField="Menu_Vitri" Width="600" EmptyText="Chọn danh mục tin">
                            <Store>
                                <ext:Store runat="server" ID="stTheLoai">
                                    <Reader>
                                        <ext:JsonReader IDProperty="MenuID">
                                            <Fields>
                                                <ext:RecordField Name="MenuID" />
                                                <ext:RecordField Name="Menu_Vitri" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:MultiCombo>
                    </td>
                </tr>
                <tr>
                    <td>Di sản: </td>
                    <td>
                        <ext:ComboBox ID="cbDiSan" runat="server" EmptyText="--Chọn di sản--" DisplayField="TenDiSan" ValueField="DiSanID" Width="350"
                            Editable="false">
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
                                <ext:FieldTrigger Icon="Clear" Qtip="Remove selected" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="this.removeByValue(this.getValue());this.clearValue();" />
                            </Listeners>
                        </ext:ComboBox>
                    </td>
                </tr>
                <tr>
                    <td>Hoạt động văn hóa: </td>
                    <td>
                        <ext:ComboBox ID="cbHoatDong" runat="server" EmptyText="-- Chọn hoạt động văn hóa --" DisplayField="TenGoi" Width="350" ValueField="HoatDongID"
                            Editable="false">
                            <Store>
                                <ext:Store runat="server" ID="stHoatdong">
                                    <Reader>
                                        <ext:JsonReader IDProperty="HoatDongID">
                                            <Fields>
                                                <ext:RecordField Name="HoatDongID" />
                                                <ext:RecordField Name="TenGoi" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" Qtip="Remove selected" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="this.removeByValue(this.getValue());this.clearValue();" />
                            </Listeners>
                        </ext:ComboBox>
                    </td>
                </tr>
                <tr>
                    <td>Chọn ảnh:
                    </td>
                    <td>
                        <ext:Panel runat="server" Border="false" Width="800" Layout="border" Region="Center" Height="100">
                            <Items>
                                <ext:Panel ID="Panel3" runat="server" Region="West" Border="false" Width="150">
                                    <Content>
                                        <uc1:ImageOnly runat="server" ID="ImageOnly" />
                                    </Content>
                                </ext:Panel>
                                <ext:Panel runat="server" Width="350" Border="false" Region="Center" LabelWidth="100">
                                    <Content>
                                        <%--                                <ext:Checkbox runat="server" ID="ckbDuyet" Checked="true" FieldLabel="Duyệt" />
                                <ext:Checkbox runat="server" ID="ckbNoiBat" Checked="true" FieldLabel="Nổi bật" />--%>
                                        <ext:SpinnerField ID="txtThuTu" runat="server" FieldLabel="Thứ tự" MinValue="1" MaxValue="1000" Width="150"/>
                                    </Content>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                    </td>
                </tr>
                <tr>
                    <td>Chọn tài liệu:</td>
                    <td>
                        <ext:Panel runat="server" Border="false">
                            <Content>
                                <uc1:Document runat="server" ID="Document" Width="120" />
                            </Content>
                        </ext:Panel>
                    </td>
                </tr>
                <tr>
                    <td>Ngày xuất bản: </td>
                    <td>
                        <ext:DateField ID="dtNgayxuatban" Disabled="true" runat="server" Width="150" />
                    </td>
                </tr>
                <tr>
                    <td>Giới thiệu ấn phẩm, bài viết: </td>
                    <td>
                        <ext:HtmlEditor ID="txtGioithieu" runat="server" Width="800" Height="150" />
                    </td>
                </tr>
                <tr>
                    <td>Nội dung bài viết: </td>
                    <td>
                        <FCKeditorV2:FCKeditor ID="txtNoidung" runat="server" BasePath="~/fckeditor/" Height="500" Width="800"></FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr>
                    <td>Url SEO: </td>
                    <td>
                        <ext:TextField runat="server" ID="txtUrl" Width="600" />
                    </td>
                </tr>
                <tr>
                    <td>Page Title:                      
                    </td>
                    <td>
                        <ext:TextField runat="server" ID="txtTitlePage" Width="600" />
                    </td>
                </tr>
                <tr>
                    <td>MetaKeyword:</td>
                    <td>
                        <ext:TextField runat="server" ID="txtMetaKeyword" Width="600" />
                    </td>
                </tr>
                <tr>
                    <td>MetaDescription:</td>
                    <td>
                        <ext:TextField runat="server" ID="txtMetaDescription" Width="600" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
