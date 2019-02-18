<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMediaInLib.aspx.cs" Inherits="NghiepVu_Media_AddMediaInLib" %>

<%@ Register Src="~/Control/Images/ImageMutil.ascx" TagPrefix="uc1" TagName="ImageMutil" %>
<%@ Register Src="~/Control/Video/Video.ascx" TagPrefix="uc1" TagName="Video" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/MapStyles.css" rel="stylesheet" />
    <link href="/css/other.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Panel ID="ViewPort2" runat="server" Layout="FormLayout" LabelWidth="100" Padding="10">
            <Content>
                <ext:Hidden runat="server" ID="hdMediaLibID" />
                <ext:Label runat="server" ID="lbTenLib" Width="600" />
                <ext:Panel runat="server" ID="pnHinhAnh" Border="false">
                    <Content>
                        <uc1:ImageMutil runat="server" ID="ImageMutil" LabelWidth="100" FieldLabel="Chọn ảnh" Width="280"/>
                    </Content>
                </ext:Panel>
                 <ext:Panel runat="server" ID="pnVideo" Border="false">
                    <Content>
                        <uc1:Video runat="server" ID="Video" LabelWidth="100" FieldLabel="Chọn ảnh" Width="280"/>
                    </Content>
                </ext:Panel>
            </Content>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button ID="btnUpdate" Text="Lưu lại" Icon="DatabaseSave" runat="server">
                            <DirectEvents>
                                <Click OnEvent="btnUpdate_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
    </form>
</body>
</html>
