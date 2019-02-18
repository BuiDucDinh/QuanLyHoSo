<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongTinHoSo.aspx.cs" Inherits="NghiepVu_QuyTrinh_ThongTinNguoiYeuCau" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Panel ID="ViewPort1" Padding="10" runat="server" Layout="FormLayout" AutoScroll="true" LabelWidth="150" EnableTheming="true">
            <Content>
                <ext:Label runat="server" ID="txtTen" FieldLabel="Tên hồ sơ" Width="600" />
                <ext:Label runat="server" ID="txtNgayBatDau" FieldLabel="Ngày tiếp nhận" Width="600" />
                <ext:Label runat="server" ID="txtNgayHoanThanh" Hidden="true" FieldLabel="Ngày hoàn thành" Width="600" />
                <ext:Label runat="server" ID="txtNguoiTiepNhan" FieldLabel="Người tiếp nhận" Width="600" />
                <ext:Label runat="server" ID="txtTrangThai" FieldLabel="Trạng thái hồ sơ" Width="600" />
                <ext:Label runat="server" ID="txtGhichu" FieldLabel="Ghi chú" Width="600" />
                <ext:HyperLink runat="server" ID="hlFiledauvao" FieldLabel="File tiếp nhận" Width="600" />
                <ext:HyperLink runat="server" ID="hlFileketqua" Hidden="true" FieldLabel="File kết quả" Width="600" />
                <ext:Panel runat="server" ID="pnNguoiYeuCau" Title="Thông tin người yêu cầu" Padding="10">
                    <Items>
                        <ext:Label runat="server" ID="txtNguoiYeuCau" FieldLabel="Người yêu cầu" Width="600" />
                        <ext:Label runat="server" ID="txtEmail" FieldLabel="Email" Width="600" />
                        <ext:Label runat="server" ID="txtSodienthoai" FieldLabel="Số điện thoại liên hệ" Width="600" />
                        <ext:Label runat="server" ID="txtDiachi" FieldLabel="Địa chỉ" Width="600" />
                        <ext:Label runat="server" ID="txtThongtin" FieldLabel="Thông tin người yêu cầu" Width="600" />
                    </Items>
                </ext:Panel>

            </Content>
        </ext:Panel>
    </form>
</body>
</html>
