<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XemDSVanHoa.aspx.cs" ValidateRequest="false" Inherits="NghiepVu_Disanvanhoa_CapNhatDSVanHoa" %>

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
            <ext:Panel runat="server" Border="false" Padding="5">
                <Content>
                    <div style="width: 50%; float: left">
                        <ext:Panel runat="server" Title="Thông tin chung" Border="true" Width="500" LabelWidth="150" FormGroup="true">
                            <Items>
                                <ext:TextField runat="server" ID="txtMaDiSan" FieldLabel="Mã di sản" Width="450" Margins="2" />
                                <ext:TextField ID="txtTenDiSan" runat="server" FieldLabel="Tên di sản" Width="450" Margins="2" />
                                <ext:TextField ID="txtTenKhac" runat="server" FieldLabel="Tên khác (nếu có)" Width="450" Margins="2" />
                                <ext:TextField runat="server" ID="txtSodangky" FieldLabel="Số quyết định" Width="450" />
                                <ext:TextField ID="dtNgaychungnhan" runat="server" FieldLabel="Ngày quyết định" Width="450" />
                                <ext:ComboBox ID="cbCapdisan" runat="server" FieldLabel="Cấp di sản" DisplayField="TenCap" ValueField="ID"
                                    Width="450" EmptyText="--Chọn cấp di sản" IndicatorText="*"
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
                                <ext:ComboBox ID="cbLoaiDiSan" runat="server" FieldLabel="Loại di sản" DisplayField="TenLoai" ValueField="LoaiID" IndicatorText="*"
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
                                </ext:ComboBox>
                                <ext:ComboBox ID="cbDiSan" runat="server" Hidden="true" FieldLabel="Di sản phi vật thể liên quan" DisplayField="TenDiSan" ValueField="DiSanID"
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
                                <ext:MultiCombo ID="mcbDanhmuc" runat="server" FieldLabel="Danh mục di sản" ValueField="DanhMucID" DisplayField="TenDanhMuc" Width="450" EmptyText="Chọn danh mục di sản">
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
                    <div style="width: 50%; float: left">
                        <ext:Panel runat="server" Title="Thông tin quản lý" Border="true" Width="500" LabelWidth="150" FormGroup="true">
                            <Items>
                                <ext:ComboBox ID="cbCoQuanHC" FieldLabel="Cơ quan quản lý" runat="server" DisplayField="TenCoQuan" ValueField="CoQuanID"
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
                                <ext:TextField runat="server" ID="txtDiadiem" FieldLabel="Địa điểm" Width="450" Margins="2" />
                                <ext:TextField runat="server" FieldLabel="Số lượt khách" ID="txtSoluotkhach" Width="450" />

                                <ext:TextArea runat="server" ID="txtChiphiduytri" FieldLabel="Chi phí duy trì" Width="450" />

                            </Items>
                        </ext:Panel>
                    </div>
                    <div style="clear: both"></div>

                    <ext:Panel runat="server" FormGroup="true" Title="Hình ảnh/Video/Tài liệu">
                        <Items>
                            <ext:Image runat="server" ID="txtAnhdaidien" FieldLabel="Ảnh đại diện" />
                            <ext:Image runat="server" ID="txtVideo" FieldLabel="Video" />
                            <ext:Panel runat="server" ID="pnImage" Border="false">
                                <Items>
                                    <%--lí lịch di sản, bản đồ khoanh vùng,Mặt bằng tổng thể (bản vẽ kỹ thuật),Quy hoạch di tích--%>
                                    <ext:HyperLink runat="server" ID="txttailieu" FieldLabel="Tài liệu" />
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" FormGroup="true" Title="Thông tin di sản">
                        <Items>
                            <ext:HtmlEditor runat="server" ID="txtDexuat" FieldLabel="Đề xuất bảo vệ" Width="800" />
                            <ext:TextArea runat="server" ID="txtGiatridanhgia" FieldLabel="Giá trị đánh giá" Width="800" />

                            <ext:TextArea runat="server" ID="txtHientrang" FieldLabel="Hiện trạng" Width="800" />
                            <ext:HtmlEditor runat="server" FieldLabel="Lí lịch di sản" ID="txtLilich" Width="800" />
                            <ext:HtmlEditor runat="server" ID="txtNiendai" FieldLabel="Niên đại khởi dựng, tu bổ" Width="800" />
                        </Items>
                    </ext:Panel>
                    <table style="color: rgb(41, 84, 149); font: 13px arial,tahoma,sans-serif;">
                        <tr>
                            <td>Giới thiệu về di sản: </td>
                            <td colspan="2">
                                <FCKeditorV2:FCKeditor ID="txtMoTa" runat="server" BasePath="~/fckeditor/" Height="500" Width="800"></FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                    </table>
                </Content>
            </ext:Panel>

        </div>

    </form>
</body>
</html>
