<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoCao.aspx.cs" Inherits="NghiepVu_Thongke_BaoCao" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="plnTemplate" runat="server" Border="false" LabelWidth="70" MinHeight="1000">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:ComboBox ID="cbNam" runat="server" FieldLabel="Năm" Width="200" SelectedIndex="0" DisplayField="year" ValueField="year">
                            <Store>
                                <ext:Store runat="server" ID="stNam">
                                    <Reader>
                                        <ext:ArrayReader>
                                            <Fields>
                                                <ext:RecordField Name="year" />
                                            </Fields>
                                        </ext:ArrayReader>
                                    </Reader>
                                </ext:Store>
                            </Store>

                        </ext:ComboBox>
                        <ext:Button ID="btnExport" Text="Xem báo cáo" Icon="Report" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnTimkiem_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <%--<AutoLoad Url="http://phanmemquanlynhanghi.com/" Mode="Merge" NoCache="true" />--%>
            <Listeners>
                <Update Handler="var size = Ext.getBody().getViewSize(); #{plnTemplate}.setHeight(size.height+100);" Delay="100" />
            </Listeners>
        </ext:Panel>
    </form>
</body>
</html>
