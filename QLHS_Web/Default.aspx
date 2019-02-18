<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%--<%@ Register Src="HelpWindow.ascx" TagName="HelpWindow" TagPrefix="uc2" %>
<%@ Register Src="System/SysUserConfig.ascx" TagName="UserConfigWindow" TagPrefix="uc3" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CÔNG TY TNHH TM VÀ PHÁT TRIỂN CÔNG NGHỆ PHẦN MỀM TCSOFT</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <ext:resourceplaceholder id="ResourcePlaceHolder1" runat="server" />

    <script type="text/javascript" src="Resources/js/site.js"></script>

    <script language="javascript" type="text/javascript" src="Resources/js/jquery-latest.js"></script>

    <script type="text/javascript">
        $(function () {
            setInterval(KeepSessionAlive, 30000);
        });

        function KeepSessionAlive() {
            $.post("KeepSessionAlive.ashx", null, function () {

            });
        }
        Ext.data.Connection.override({
            timeout: 120000
        });
        Ext.Ajax.timeout = 120000;
        Ext.net.DirectEvent.timeout = 120000;
        
    </script>

    <style type="text/css">
        .notify
        {
            font: normal 14px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            white-space: normal;
            color: Red;
            text-align: justify;
        }
        .pnlLoad
        {
            background-color: Aqua;
        }
        #ext-gen34
        {
            background: url( "/images/background_disan_chm.jpg" );
            background-size: 100% 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ext:resourcemanager id="ResourceManager1" runat="server" idmode="Explicit" />
    <ext:viewport id="ViewPort1" runat="server" layout="border">
        <Items>
            <ext:Toolbar ID="tbMain" runat="server" Region="North" Height="25" Margins="0 0 4 0">
                <Items>
                    <ext:Label ID="Label1" runat="server" Html="CÔNG TY TNHH TM VÀ PHÁT TRIỂN CÔNG NGHỆ PHẦN MỀM TCSOFT - PHẦN MỀM: "
                        Icon="FlagVi" AutoDataBind="true" />
                    <ext:ToolbarFill runat="server" />
                    <ext:Button ID="btnUserOnline" runat="server" Icon="StatusOnline" Text="Bích Thủy"
                        AutoDataBind="true">
                        <Menu runat="server">
                            <ext:Menu ID="Menu11" runat="server">
                                <Items>
                                    <ext:MenuItem Text="Cấu hình" Icon="Cog" runat="server" ID="mnuConfig">
                                        <DirectEvents>
                                            <Click OnEvent="UserConfigWindow_Show" />
                                        </DirectEvents>
                                    </ext:MenuItem>
                                    <ext:MenuItem Text="Lựa chọn Theme..." Icon="Wrench">
                                        <Menu runat="server">
                                            <ext:Menu ID="Menu21" runat="server">
                                                <Items>
                                                    <ext:MenuItem Text="Mặc định" runat="server" ID="mnuDefault">
                                                        <DirectEvents>
                                                            <Click OnEvent="btnDefault_Click">
                                                            </Click>
                                                        </DirectEvents>
                                                    </ext:MenuItem>
                                                    <ext:MenuItem Text="Xám sáng" runat="server" ID="mnuGray">
                                                        <DirectEvents>
                                                            <Click OnEvent="btnGray_Click">
                                                            </Click>
                                                        </DirectEvents>
                                                    </ext:MenuItem>
                                                    <ext:MenuItem Text="Xám đen" runat="server" ID="mnuSlate">
                                                        <DirectEvents>
                                                            <Click OnEvent="btnSlate_Click">
                                                            </Click>
                                                        </DirectEvents>
                                                    </ext:MenuItem>
                                                    <ext:MenuItem Text="Tím đen" runat="server" ID="mnuAccess">
                                                        <DirectEvents>
                                                            <Click OnEvent="btnAccess_Click">
                                                            </Click>
                                                        </DirectEvents>
                                                    </ext:MenuItem>
                                                </Items>
                                            </ext:Menu>
                                        </Menu>
                                    </ext:MenuItem>
                                </Items>
                            </ext:Menu>
                        </Menu>
                    </ext:Button>
                    <ext:Button ID="btnHelp" runat="server" Icon="Help" Text="Trợ giúp">
                        <Menu runat="server">
                            <ext:Menu ID="Menu4" runat="server">
                                <Items>
                                    <ext:MenuItem Text="Hướng dẫn sử dụng" Icon="Help">
                                        <Listeners>
                                            <Click Handler="DHM.addTab({ title : el.text, url : '/Home/Form/', icon : el.iconCls });" />
                                        </Listeners>
                                    </ext:MenuItem>
                                    <ext:MenuItem Text="Giới thiệu chương trình" Icon="Information">
                                        <Listeners>
                                            <Click Handler="#{winAbout}.show();" />
                                        </Listeners>
                                    </ext:MenuItem>
                                </Items>
                            </ext:Menu>
                        </Menu>
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                    <ext:Button ID="btnLogout" runat="server" Icon="LockGo" Text="Thoát">
                        <DirectEvents>
                            <Click OnEvent="btnLogout_Click" />
                        </DirectEvents>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
            <ext:Panel ID="pnlExplorer" runat="server" Title="Danh mục" Region="West" Width="225"
                CollapseMode="Mini" Margins="0 0 4 4" Split="true">
                <Content>
                    <ext:AccordionLayout ID="AccordionLayout1" runat="server" Animate="true">
                        <Items>
                        </Items>
                    </ext:AccordionLayout>
                </Content>
            </ext:Panel>
            <ext:TabPanel ID="tpMain" runat="server" Region="Center" Margins="0 0 4 0" EnableTabScroll="true">
                <Items>
                    <ext:Panel ID="Tab1" runat="server" Title="Trang chủ" Icon="ApplicationForm" Border="false">
                    </ext:Panel>
                </Items>
                <Plugins>
                    <ext:TabCloseMenu ID="TabCloseMenu1" runat="server" />
                </Plugins>
            </ext:TabPanel>
        </Items>
    </ext:viewport>
    <ext:window id="winHT_Don_Vi_YT" runat="server" icon="Lightbulb" title="Cập nhật thông tin người dùng"
        height="400" width="400" modal="true" hidden="true" layout="Fit" closeaction="Hide"
        closable="true">
    </ext:window>
    </form>
</body>
</html>
