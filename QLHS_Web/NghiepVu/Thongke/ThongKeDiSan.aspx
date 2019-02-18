<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongKeDiSan.aspx.cs" Inherits="NghiepVu_Thongke_ThongKeDiSan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<script type="text/javascript">
    function nodeLoad(node) {
        Ext.net.DirectMethods.NodeLoad(node.id, {
            success: function (result) {
                var data = eval("(" + result + ")");
                node.loadNodes(data);
            },

            failure: function (errorMsg) {
                Ext.Msg.alert('Failure', errorMsg);
            }
        });
    }
</script>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
        </ext:ResourceManager>

        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel runat="server" ID="pnTop" Region="North" Height="100">
                    <Items>
                        <ext:Panel ID="Panel6" runat="server" Split="true" Margins="0 0 0 0"
                            Frame="true" DefaultAnchor="100%" Height="100" LabelWidth="200">
                            <Content>
                                <table>
                                    <tr>
                                        <td>
                                            <ext:TextField ID="txtTenDiSan" runat="server" FieldLabel="Tên di sản" Hidden="false" Width="350" />
                                        </td>
                                        <td>
                                            <ext:DateField ID="dfTuNgay" runat="server" FieldLabel="Từ ngày" Width="350" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ext:ComboBox ID="cbXepHang" runat="server" FieldLabel="Xếp hạng theo loại" Width="250"
                                                Mode="Local" AllowBlank="true" Hidden="false"
                                                Disabled="false" SelectedIndex="0">
                                                <Items>
                                                    <ext:ListItem Value="0" Text="Tất cả" />
                                                </Items>
                                            </ext:ComboBox>
                                        </td>
                                        
                                        <td>
                                            <ext:DateField ID="dfDenNgay" runat="server" FieldLabel="Đến ngày" Width="350" />

                                            <ext:Button runat="server" ID="btnXemBaoCao" Text="Xem báo cáo" Icon="ZoomIn">
                                            </ext:Button>
                                        </td>
                                    </tr>
                                </table>
                            </Content>                            
                        </ext:Panel>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel1" runat="server" Layout="border" Border="false" Region="Center">
                    <Items>
                        <ext:Panel ID="Panel3" runat="server" Region="West" Split="true" Margins="0 0 0 0"
                            Frame="true" DefaultAnchor="100%" Width="200">
                            <Items>
                                <ext:Panel ID="Panel2" runat="server" Region="North" Split="true" Margins="0 0 0 0"
                                    Frame="true" Title="Địa điểm" Icon="House"
                                    DefaultAnchor="100%">
                                    <Items>
                                        <ext:TreePanel
                                            ID="TreePanel1"
                                            runat="server"
                                            AutoHeight="true"
                                            Border="false">
                                            <Root>
                                                <ext:AsyncTreeNode NodeID="0" Text="Root" />
                                            </Root>
                                            <Listeners>
                                                <BeforeLoad Fn="nodeLoad" />
                                            </Listeners>
                                        </ext:TreePanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel4" runat="server" Region="South" Split="true" Margins="0 0 0 0"
                                    Frame="true" Title="Loại hình văn hóa" Icon="BookAddresses"
                                    DefaultAnchor="100%">
                                    <Items>
                                        <ext:TreePanel
                                            ID="TreePanel2"
                                            runat="server"
                                            AutoHeight="true"
                                            Border="false">
                                            <Root>
                                                <ext:AsyncTreeNode NodeID="0" Text="Root" />
                                            </Root>
                                            <Listeners>
                                                <BeforeLoad Fn="nodeLoad" />
                                            </Listeners>
                                        </ext:TreePanel>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>

                        <ext:Panel ID="pnlExplorer" runat="server" Region="Center" Margins="0 0 0 0" Frame="true"
                            Title="Danh sách di sản" Icon="LayoutHeader" Layout="FitLayout">
                            <Content>
                            </Content>
                        </ext:Panel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
        <ext:Window runat="server" ID="wdDetail" Hidden="true"
            DefaultButton="0" Border="false" AutoScroll="false"
            MinWidth="1000" MinHeight="500" Modal="true" Padding="3" Resizable="false">
        </ext:Window>
    </form>
</body>
</html>
