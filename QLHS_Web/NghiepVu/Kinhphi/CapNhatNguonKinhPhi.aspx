<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatNguonKinhPhi.aspx.cs" Inherits="NghiepVu_KinhPhi_CapNhatNguonKinhPhi" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>
<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/css/MapStyles.css" rel="stylesheet" />
    <link href="/css/other.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout">
            <Content>
                <ext:Panel runat="server" Padding="10" Border="false">
                    <Content>
                        <ext:Hidden runat="server" ID="hdID" />
                        <table>
                            <tr>
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Loại nguồn kinh phí:</span><span style="color: red">*</span></p>
                                    <ext:ComboBox ID="cbLoainguon" runat="server" EmptyText="--Chọn loại kinh phí--" DisplayField="TenLoai" ValueField="ID"
                                        Editable="false" Width="300">
                                        <Store>
                                            <ext:Store runat="server" ID="stLoainguon">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="ID">
                                                        <Fields>
                                                            <ext:RecordField Name="ID" />
                                                            <ext:RecordField Name="TenLoai" />
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
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Nhà đầu tư:</span></p>
                                    <ext:ComboBox ID="cbNguoidautu" runat="server" EmptyText="--Chọn nhà đầu tư--" DisplayField="Ten" ValueField="ID"
                                        Editable="false" Width="300">
                                        <Store>
                                            <ext:Store runat="server" ID="stNguoidautu">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="ID">
                                                        <Fields>
                                                            <ext:RecordField Name="ID" />
                                                            <ext:RecordField Name="Ten" />
                                                            <ext:RecordField Name="MoTa" />
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
                                <td style="width: 50%;">
                                    <p><span class="x-label-text">Số tiền:</span></p>
                                    <ext:TextField ID="txtSoTien" runat="server" Margins="2" IndicatorText="*" Style="margin-top: 5px;" Width="300" />
                                </td>
                                <td style="width: 50%;">
                                    <ext:Panel runat="server" ID="pnUpdate" Hidden="true" Border="false">
                                        <Content>
                                            <table>
                                                <tr>
                                                    <td style="width: 50%;">
                                                        <p><span class="x-label-text">Số tiền còn lại:</span></p>
                                                        <ext:TextField ID="txtTienconlai" Disabled="true" runat="server" Margins="2" IndicatorText="*" Style="margin-top: 5px;" Width="140" />
                                                    </td>
                                                    <td style="width: 50%;">
                                                        <p><span class="x-label-text">Ngày đầu tư:</span></p>
                                                        <ext:DateField runat="server" ID="txtNgaydautu" Margins="2" Width="140" Disabled="true" />

                                                    </td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ext:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <p><span class="x-label-text">Mô tả:</span></p>
                                    <ext:HtmlEditor runat="server" ID="txtMota" Margins="2" Width="600" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <ext:Panel ID="Panel1" runat="server" Border="false" Cls="css1">
                                        <Content>
                                            <uc1:Document runat="server" ID="Document" LabelWidth="150" />
                                        </Content>
                                    </ext:Panel>
                                </td>
                            </tr>
                        </table>
                    </Content>
                </ext:Panel>
            </Content>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
    </form>
</body>
</html>
