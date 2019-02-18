<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Control_Document_Default" %>

<%@ Register Src="~/Control/Images/ImageOnly.ascx" TagPrefix="uc1" TagName="ImageOnly" %>
<%@ Register Src="~/Control/Images/ImageMutil.ascx" TagPrefix="uc1" TagName="ImageMutil" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <uc1:ImageOnly runat="server" ID="ImageOnly" />
        <uc1:ImageOnly runat="server" ID="ImageOnly1" />
        <uc1:ImageOnly runat="server" ID="ImageOnly2" />
        <uc1:ImageMutil runat="server" ID="ImageMutil" />
        <ext:Button runat="server" ID="btn" Text="submit">
            <DirectEvents>
                <Click OnEvent="Unnamed_Event" />
            </DirectEvents>
        </ext:Button>
    </form>
</body>
</html>
