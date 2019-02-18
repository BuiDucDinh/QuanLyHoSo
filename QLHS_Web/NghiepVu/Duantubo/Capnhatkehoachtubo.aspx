<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Capnhatkehoachtubo.aspx.cs"
    Inherits="DSVH_Quanlykehoachtubo_Capnhatkehoachtubo" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Panel ID="ViewPort2" runat="server" Layout="FormLayout" Padding="10" LabelWidth="150">
            <Content>
                <ext:Hidden runat="server" ID="hdKeHoachID" />
                <ext:TextField ID="txtTenduan" runat="server" FieldLabel="Tên dự án" Width="600" />
                <ext:TextField ID="txtDiaDiem" runat="server" FieldLabel="Địa điểm" Width="600" />
                <ext:ComboBox FieldLabel="Thuộc tỉnh" ID="cmbThuocTinh" runat="server"
                    DisplayField="Ten_Tinh" ValueField="Ma_Tinh" EmptyText="Select a country">
                    <Store>
                        <ext:Store runat="server" ID="stTinh">
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
                        <Select Handler="#{cmbThuocHuyen}.clearValue(); #{stHuyen}.reload();" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbThuocHuyen" FieldLabel="Thuộc huyện" runat="server"
                    DisplayField="Ten_Huyen" ValueField="Ma_Huyen" EmptyText="Loading..." ValueNotFoundText="Loading...">
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
                        <Select Handler="#{cmbThuocXa}.clearValue(); #{stXa}.reload();" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbThuocXa" FieldLabel="Thuộc xã" runat="server" DisplayField="Ten_Xa" ValueField="Ma_Xa"
                    EmptyText="Loading...">
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

                <ext:ComboBox ID="cmbTendisan" runat="server" FieldLabel="Di sản cần tu bổ" EmptyText="--Chọn di sản--"
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
                <ext:TextArea ID="txtLydotubo" runat="server" FieldLabel="Lý do tu bổ" Width="600" />
                <ext:Panel runat="server" Border="false" Width="800">
                    <Content>
                        <table style="width: 800px">
                            <tr>
                                <td style="width: 50%">
                                    <ext:TextField ID="txtChiphidukien" runat="server" MaskRe="/[0-9\.]/" FieldLabel="Chi phí dự kiến" LabelWidth="150" Width="300" IndicatorText="VNĐ">
                                        <Listeners>
                                            <Change Handler="this.setValue(Ext.util.Format.number(newValue.replace(/[,]/g, ''), '0,0'));" />
                                        </Listeners>
                                    </ext:TextField>
                                </td>
                                <td style="width: 50%">
                                    <ext:TextField ID="txtChiPhiThucte" runat="server" MaskRe="/[0-9\.]/" FieldLabel="Chi phí thực tế" LabelWidth="150" Width="300" IndicatorText="VNĐ">
                                        <Listeners>
                                            <Change Handler="this.setValue(Ext.util.Format.number(newValue.replace(/[,]/g, ''), '0,0'));" />
                                        </Listeners>
                                    </ext:TextField>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%">
                                    <ext:DateField ID="dtNgaybatdau_dukien" runat="server" FieldLabel="Thời gian bắt đầu" LabelWidth="150" Width="300" />

                                </td>
                                <td style="width: 50%">
                                    <ext:DateField ID="dtNgayketthuc_dukien" runat="server" FieldLabel="Thời gian hoàn thành" LabelWidth="150" Width="300" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%">
                                    <ext:DateField ID="dtNgaybatdau_thucte" runat="server" FieldLabel="Ngày bắt đầu thực tê" LabelWidth="150" Width="300" />
                                </td>
                                <td style="width: 50%">
                                    <ext:DateField ID="dtNgayketthuc_thucte" runat="server" FieldLabel="Ngày hoàn thành thực tê" LabelWidth="150" Width="300" />
                                </td>
                            </tr>
                        </table>
                    </Content>
                </ext:Panel>
                <ext:HtmlEditor ID="txtMotaquatrinh" runat="server" FieldLabel="Mô tả quá trình" Width="600" />
                <ext:ComboBox ID="cmbChudautu" runat="server" FieldLabel="Chủ đầu tư" DisplayField="TenDonVi" ValueField="DonViID"
                    EmptyText="--Chọn đơn vị--" Editable="false" Width="400">
                    <Store>
                        <ext:Store runat="server" ID="stChudautu">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="DonViID" />
                                        <ext:RecordField Name="TenDonVi" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbThietke" runat="server" FieldLabel="Đơn vị cá nhân thiết kế" DisplayField="TenDonVi" ValueField="DonViID"
                    EmptyText="--Chọn đơn vị--" Editable="false" Width="400">
                    <Store>
                        <ext:Store runat="server" ID="stThietke">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="DonViID" />
                                        <ext:RecordField Name="TenDonVi" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbThicong" runat="server" FieldLabel="Đơn vị thi công" DisplayField="TenDonVi" ValueField="DonViID"
                    EmptyText="--Chọn đơn vị--" Editable="false" Width="400">
                    <Store>
                        <ext:Store runat="server" ID="stThiCong">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="DonViID" />
                                        <ext:RecordField Name="TenDonVi" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbGiamsat" runat="server" FieldLabel="Đơn vị giám sát" DisplayField="TenDonVi" ValueField="DonViID"
                    EmptyText="--Chọn đơn vị--" Editable="false" Width="400">
                    <Store>
                        <ext:Store runat="server" ID="stGiamsat">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="DonViID" />
                                        <ext:RecordField Name="TenDonVi" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:ComboBox ID="cmbCapquyetdinh" runat="server" FieldLabel="Cấp quyết định đầu tư" DisplayField="TenDonVi" ValueField="DonViID"
                    EmptyText="--Chọn đơn vị--" Editable="false" Width="400">
                    <Store>
                        <ext:Store runat="server" ID="stCapquyetdinh">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="DonViID" />
                                        <ext:RecordField Name="TenDonVi" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:HtmlEditor ID="txtMoTaCapquyetdinh" runat="server" FieldLabel="Quyết định đầu tư" Width="600" />
                <ext:HtmlEditor ID="txtNoidungcongviec" runat="server" FieldLabel="Nội dung công việc" Width="600" />

                <ext:Panel runat="server" Border="false">
                    <Content>
                        <uc1:Document runat="server" ID="Document" LabelWidth="150" FieldLabel="Tài liệu liên quan" Width="280" />
                    </Content>
                </ext:Panel>
                <ext:RadioGroup ID="radDuyet" runat="server" FieldLabel="Trạng thái" Width="400">
                    <Items>
                        <ext:Radio ID="radDaDuyet" runat="server" InputValue="1" BoxLabel="Đã duyệt" />
                        <ext:Radio ID="radChuaDuyet" runat="server" InputValue="0" BoxLabel="Chưa duyệt" />
                    </Items>
                </ext:RadioGroup>
            </Content>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Thêm mới" Icon="Add" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
    </form>
</body>
</html>
