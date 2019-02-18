<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TiepNhanHoSo.aspx.cs" Inherits="NghiepVu_QuyTrinh_TiepNhanHoSo" %>

<%@ Register Src="~/Control/Document/Document.ascx" TagPrefix="uc1" TagName="Document" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(200);
        };
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Panel ID="ViewPort1" Padding="10" runat="server" Layout="FormLayout" AutoScroll="true" LabelWidth="150" EnableTheming="false">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnShowInfo" Text="Thông tin người làm hồ sơ" Icon="ApplicationViewIcons">
                            <DirectEvents>
                                <Click OnEvent="btnShowInfo_Click" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnShowProcess" Text="Xem luồng xử lý" Icon="ResultsetNext">
                            <DirectEvents>
                                <Click OnEvent="btnShowProcess_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Content>
                <ext:TextField runat="server" ID="hdID" Disabled="true" Hidden="true" ReadOnly="true" />
                <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên hồ sơ" Width="600" IndicatorText="*" />
                <ext:TextField runat="server" ID="lbMota" FieldLabel="Mô tả công việc" Width="600" Disabled="true" />
                <ext:DateField runat="server" ID="dtNgayBatDau" FieldLabel="Ngày tiếp nhận" Width="600" Format="d/M/yyyy" Disabled="true" />
                <ext:HyperLink runat="server" ID="hlFile" FieldLabel="File tiếp nhận" Width="600" Text="File tiếp nhận để xử lý" />
                <ext:Panel runat="server" Border="false">
                    <Content>
                        <uc1:Document runat="server" ID="Document" FieldLabel="File hồ sơ hoàn thành" Disabled="false" />
                    </Content>
                </ext:Panel>

                <ext:HtmlEditor ID="txtMota" runat="server" FieldLabel="Ghi chú" Width="600" />

            </Content>
            <Buttons>
                <ext:Button runat="server" ID="btnUpdate" Icon="TableSave" Text="Lưu tạm thời">
                    <DirectEvents>
                        <Click OnEvent="btnUpdate_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnSubmit" Icon="NextBlue" Text="Hoàn thành">
                    <DirectEvents>
                        <Click OnEvent="btnSubmit_Click" />
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Panel>
        <ext:Panel runat="server">
            <Items>
                <ext:Window runat="server" ID="wdDetail" Hidden="true"
                    DefaultButton="0" Border="false" AutoScroll="true" Maximizable="true" Collapsible="true"
                    MinWidth="700" Height="400" Modal="true" Padding="3" Resizable="false">
                </ext:Window>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>

