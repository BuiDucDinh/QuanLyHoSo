<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="ThuTucHanhChinh.aspx.cs" Inherits="Template_ChiTietTin" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="<%=menu.TenUrl %>"><%=menu.TenMenu %></a>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div class="left-main">
        <div class="module">
            <div class="module-title">
                <a href="<%=menu.UrlFull %>" class="TitleCate" title="<%=menu.TenMenu %>">
                    <span><%=menu.TenMenu %></span>
                </a>
            </div>
            <div class="row module-content">
                    <table>
                        <tbody>
                            <tr>
                                <td><%=Resources.labels.tenthutuc %>:</td>
                                <td class="bold"><%=qt.Ten %></td>
                            </tr>
                            <tr>
                                <td class="left"><%=Resources.labels.coquanthuchien %> :</td>
                                <td class="bold"><%=qt.CoQuan %></td>
                            </tr>
                        </tbody>
                    </table>

                    <table class="cchc-content">
                        <tbody>
                            <tr>
                                <td style="width: 250px"><%=Resources.labels.trinhtu %></td>
                                <td><%=qt.TrinhTu %></td>
                            </tr>
                            <tr>
                                <td><%=Resources.labels.cachthuc %></td>
                                <td><%=qt.CachThuc %></td>
                            </tr>
                            <tr>
                                <td><%=Resources.labels.thanhphanhoso %></td>
                                <td><%=qt.ChuanBi %></td>
                            </tr>
                            <tr>
                                <td><%=Resources.labels.thoihangiaiquyet %></td>
                                <td><%=qt.ThoiHan %> ngày</td>
                            </tr>
                            <tr>
                                <td><%=Resources.labels.doituongthutuc %></td>
                                <td><%=qt.DoiTuong %></td>
                            </tr>
                            <tr>
                                <td><%=Resources.labels.coquanthutuc %></td>
                                <td><%=qt.CoQuan %></td>
                            </tr>
                            <tr>
                                <td><%=Resources.labels.ketquathutuc %></td>
                                <td><%=qt.KetQua %></td>
                            </tr>
                            <tr>
                                <td><%=Resources.labels.yeucauthuchienthutuc %></td>
                                <td><%=qt.YeuCau %></td>
                            </tr>
                            <tr>
                                <td><%=Resources.labels.lephi %></td>
                                <td><%=qt.LePhi %></td>
                            </tr>
                            <tr>
                                <td><%=Resources.labels.maudon %></td>
                                <td><%=qt.MauDon %></td>
                            </tr>
                            <tr>
                                <td><%=Resources.labels.phaplythutuc %></td>
                                <td><%=qt.PhapLy %></td>
                            </tr>
                        </tbody>
                    </table>
            </div>
        </div>
    </div><div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
