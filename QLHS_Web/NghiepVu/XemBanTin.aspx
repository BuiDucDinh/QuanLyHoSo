<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XemBanTin.aspx.cs" Inherits="NghiepVu_XemBanTin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:Panel runat="server" Border="true" FormGroup="true" Title="Nội dung bài viết">
                <Content>
                    <%=bv.NoiDung %>
                    <ext:Checkbox runat="server" ID="ckbDuyet" Checked="false" FieldLabel="Duyệt" />

                    <ext:Checkbox runat="server" ID="ckbNoiBat" Checked="true" FieldLabel="Nổi bật" />
                    <ext:Button runat="server" ID="btnUpdate" Text="Cập nhật" Icon="ApplicationAdd">
                        <DirectEvents>
                            <Click OnEvent="btnUpdate_Click" />
                        </DirectEvents>
                    </ext:Button>
                </Content>
            </ext:Panel>
            <ext:Window runat="server" ID="wdDetail" Hidden="true"
                DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
                MinWidth="1000" Height="550" Modal="true" Padding="3" Resizable="false">
                <Listeners>
                    <Hide Handler="if(hdMsg.getValue()=='true'){Ext.Msg.alert('Thông báo','Đã duyệt');}else{Ext.Msg.alert('Thông báo','Đã bỏ duyệt bài viết');}hdMsg.setValue('');" />
                </Listeners>
            </ext:Window>
            <ext:Hidden runat="server" ID="hdMsg" />
        </div>
    </form>
</body>
</html>
