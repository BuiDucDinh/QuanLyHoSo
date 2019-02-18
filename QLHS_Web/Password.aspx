<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Password.aspx.cs" Inherits="Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Window ID="Window1" runat="server" Closable="false" Resizable="false" Height="350"
        Icon="Lock" Title="Xem mật khẩu" Draggable="false" Width="550" Modal="true"
        Padding="5" Layout="Form">
        <Items>
            <ext:TextField ID="txtUsername" runat="server" FieldLabel="Tên đăng nhập" AllowBlank="false"
                BlankText="Yêu cầu nhập tên đăng nhập." Text="" AnchorHorizontal="100%">                
                
                </ext:TextField>                
            <ext:TextField ID="txtPassword" runat="server" FieldLabel="Mật khẩu bạn được cấp"
                AllowBlank="false" BlankText="Yêu cầu nhập mật khẩu." Text="" AnchorHorizontal="100%" />            
                <ext:DisplayField ID="txtPass" runat="server" FieldLabel="Mật khẩu sau mã hóa"
                AllowBlank="false" AnchorHorizontal="100%" />
        </Items>
        <Buttons>
            <ext:Button ID="btnLogin" runat="server" Text="Kiểm tra" Icon="Accept">
                <Listeners>
                    <Click Handler="
                            if (!#{txtUsername}.validate()) {
                                Ext.Msg.alert('Thông báo','Mật khẩu mã hóa phải nhập thông tin');                                
                                return false; 
                            }" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnLogin_Click">
                        <EventMask ShowMask="true" Msg="Đang kiểm tra..." MinDelay="500" />
                    </Click>
                </DirectEvents>
            </ext:Button>            
        </Buttons>
    </ext:Window>
    <ext:KeyMap ID="KeyMap1" runat="server" Target="={Ext.isGecko ? Ext.getDoc() : Ext.getBody()}">
        <ext:KeyBinding>
            <Keys>
                <ext:Key Code="ENTER" />
            </Keys>
            <Listeners>
                <Event Fn="specialKeyHandler" />
            </Listeners>
        </ext:KeyBinding>
    </ext:KeyMap>
    <ext:Window ID="ReportWindow" runat="server" Icon="Report" Title="" Height="800"
    Width="800" AutoShow="false" Modal="true" Hidden="true" Layout="Fit">    
</ext:Window>
    </form>
</body>
</html>

