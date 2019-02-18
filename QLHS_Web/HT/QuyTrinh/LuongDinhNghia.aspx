<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LuongDinhNghia.aspx.cs" Inherits="HT_QuyTrinh_LuongDinhNghia" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ExportYap1 = function () {
            Ext.net.Mask.show();
            Ext.net.Mask.hide.defer(500);
        };
    </script>
    <style>
        #lbTitle {
            font-weight: bold;
            text-transform: uppercase;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!----Goi ung dung ext------>


        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="ViewPort1" runat="server" Layout="FormLayout" LabelWidth="150" Padding="10">
            <Content>
                <asp:Label runat="server" ID="lbTitle" />
                <asp:Label runat="server" ID="lbMessage" />
                <asp:Repeater runat="server" ID="rptData">
                    <ItemTemplate>
                        <div class="item">
                            <h4><%#Eval("STT") %> : <%#Eval("Ten") %></h4>
                            <p>Cơ quan xử lý : <%#Eval("CoQuan") %></p>
                            <p>Người xử lý : <%#Eval("NguoiXuLy") %></p>
                            <p>Thời gian hoàn thành : <%#Eval("ThoiGianHT") %></p>
                            <p>Chi tiết công việc : <%#Eval("MoTa") %></p>
                            <br />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </Content>

        </ext:Panel>
    </form>
</body>
</html>
