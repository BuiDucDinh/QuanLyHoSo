<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DuyetBaiViet.aspx.cs" Inherits="DSVH_Quanlyvanban_Capnhatvanban" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel runat="server" Layout="FormLayout" LabelWidth="120" Padding="10">
            <Items>
                <ext:TextField ID="txtTieude" runat="server" FieldLabel="Tên đăng nhập" Width="350" Disabled="true" />
                <ext:Checkbox ID="ckbDuyet" runat="server" FieldLabel="Duyệt"/>
                <ext:Checkbox ID="ckbNoiBat" runat="server" FieldLabel="Nổi bật"/>
            </Items>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" runat="server" Text="Cập nhật" Icon="ApplicationFormEdit">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click">
                                    <EventMask ShowMask="true" MinDelay="100" Msg="Xin vui lòng chờ đợi !!!" />
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
