<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="DanhSachAnPham.aspx.cs" Inherits="Template_DanhSachAnPham" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>

    <a href="#"><%=dm.TenDanhMuc %></a>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="left-main">
                <div class="module">
                    <div class="module-title">
                        <a href="#" class="TitleCate" title="<%=dm.TenDanhMuc %>">
                            <span><%=dm.TenDanhMuc %></span>
                        </a>
                    </div>
                    <div class="module-content">
                        <%--                        <div class="search-box welcome">
                            <div class="haft search-item">
                                <label for="txtSearch">Từ khóa : </label>
                                <asp:TextBox runat="server" ID="txtTen" ClientIDMode="Static" MaxLength="100" OnTextChanged="btnSubmit_Click" AutoPostBack="true" />
                            </div>

                            <div class="haft search-item">
                                <label for="ddlType">Loại di sản : </label>
                                <div class="styled-select slate">
                                    <asp:DropDownList runat="server" ID="ddlLoai" DataValueField="LoaiID" DataTextField="TenLoai" OnSelectedIndexChanged="btnSubmit_Click" AutoPostBack="true" />
                                </div>
                            </div>

                            <div class="haft search-item">
                                <label for="dtFrom">Từ ngày : </label>
                                <asp:TextBox runat="server" ID="txtTuNgay" ClientIDMode="Static" MaxLength="70" OnTextChanged="btnSubmit_Click" AutoPostBack="true" />
                            </div>
                            <div class="haft search-item">
                                <label for="dtTo">Đến ngày : </label>
                                <asp:TextBox runat="server" ID="txtDenNgay" ClientIDMode="Static" MaxLength="70" OnTextChanged="btnSubmit_Click" AutoPostBack="true" />
                            </div>
                            <div class="clearfix"></div>
                            <div class="sumbit-btn">
                                <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn-default btn-search" Text="Bỏ điều kiện" />
                    </div>
                </div>--%>
                        <div class="clearfix"></div>
                        <div class="result" id="divs">
                            <asp:Repeater runat="server" ID="rptAnPham">
                                <ItemTemplate>
                                    <div class="new-item-search">
                                        <div class="left-new">
                                            <a href="#">
                                                <img src="/FileUpload/Images/<%#Eval("HinhAnh") %>" />
                                            </a>
                                        </div>
                                        <div class="right-new">
                                            <a href="<%#Eval("url") %>" class="new-title">
                                                <h3><%#Eval("TenSach") %></h3>
                                            </a>
                                            <p class="new-description"><%#Eval("GioiThieu") %></p>
                                            <div class="sumbit-btn">
                                                <a class="btn-default" href="/FileUpload/Document/<%#Eval("FileDinhKem") %>"><span class="fa fa-cloud-download" style="color: #fff"></span><%=Resources.labels.download %></a>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <div id="pagination"></div>
                        <script type="text/javascript">
                            $(document).ready(function () {
                                var totalrow = $("#divs .new-item-search").length;
                                var size = 7;
                                if (size > 10) size = 10;
                                $('#pagination').smartpaginator({ totalrecords: totalrow, recordsperpage: size, lenght: 4, datacontainer: 'divs', dataelement: '.new-item-search', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'black' });
                            });
                        </script>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
