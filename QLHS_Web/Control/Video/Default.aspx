<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Control_Video_Default" %>

<%@ Register Src="~/Control/Video/Video.ascx" TagPrefix="uc1" TagName="Video" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <uc1:Video runat="server" id="Video" />
    </form>
</body>
</html>
