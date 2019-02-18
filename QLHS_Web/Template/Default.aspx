<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="Default.aspx.cs" Inherits="Template_Default" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<%--<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/">Trang chủ</a>
    <span>> </span>
    <a href="#">Di sản văn hóa</a>
</asp:Content>--%>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <div class="left-main">
        <div class="module">
            <div class="module-content home">
                <div class="slider leftFloat">
                    <div class="owl-carousel main-slider-content">
                        <asp:Repeater runat="server" ID="rptSlider">
                            <ItemTemplate>
                                <div class="item">
                                    <%#Eval("Description") %>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="right-slider leftFloat">
                    <div class="info">
                        <ul>
                            <asp:Repeater runat="server" ID="rptTintuc">
                                <ItemTemplate>
                                    <li><i class="fa fa-plus-square" aria-hidden="true"></i>
                                        <a href="<%#Eval("url") %>"><%#Eval("TieuDe") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
        <div class="displayadv">
            <asp:Repeater runat="server" ID="rptAdv">
                <ItemTemplate>
                    <%#Eval("Description") %>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div >
            <div class="module tab">
                <div class="module-title">
                    <a href="<%=vatthe.Url %>" class="TitleCate" title="<%=dsvatthe %>">
                        <span><%=dsvatthe %></span>
                    </a>
                </div>
                <div class="module-content">
                    <div class="block-cate">
                        <div class="module-content">
                            <asp:Repeater runat="server" ID="rptDSVatThe">
                                <ItemTemplate>
                                    <div style="padding: 5px 0;">
                                        <div class="img-left">
                                            <a href="<%#Eval("url") %>" class="img-ds">
                                                <img src="/FileUpload/images/<%#Eval("AnhDaiDienDS") %>" class="img-responsive home-img" />
                                            </a>
                                        </div>
                                        <div class="about">
                                            <div class="about-new-title">
                                                <a href="<%#Eval("url") %>" class="link-new"><%#Eval("TenDiSan") %> - <%#Eval("LoaiDiSan") %></a>
                                            </div>
                                            <p><%#Eval("DiaDiem") %></p>
                                            <p class="day"><%=Resources.labels.ngaychungnhan %>: <%# DataBinder.Eval(Container.DataItem, "NgayChungNhan", "{0:d/M/yyyy}") %></p>
                                            <%--<p class="about-new-content"><%#Eval("MoTa") %></p>
                                                <p class="right"><a href="<%#Eval("url") %>" class="more_link">Xem thêm</a></p>--%>
                                        </div>
                                        <div style="clear: both"></div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                    </div>
                    <div class="block-cate">
                        <iframe src="/Template/Controls/BigMap.aspx" style="margin: 10px auto; width: 100%; border: 2px solid; height: 100%; min-height: 300px;"></iframe>
                        <a href="/Template/Controls/BigMap.aspx" target="_blank"><%=Resources.labels.fullscreen %></a>
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>
            <div class="module tab">
                <div class="module-title">
                    <a href="<%=phivatthe.Url %>" class="TitleCate" title="<%=dsphivatthe %>">
                        <span><%=dsphivatthe %></span>
                    </a>
                </div>
                <div class="module-content">
                    <div class="module-content">
                        <asp:Repeater runat="server" ID="rptDSPhiVatThe">
                            <ItemTemplate>
                                <div class="block-cate" style="padding: 5px;">
                                    <div class="img-left">
                                        <a href="<%#Eval("url") %>" class="img-ds">
                                            <img src="/FileUpload/images/<%#Eval("AnhDaiDienDS") %>" class="img-responsive home-img" />
                                        </a>
                                    </div>
                                    <div class="about">
                                        <div class="about-new-title">
                                            <a href="<%#Eval("url") %>" class="link-new"><%#Eval("TenDiSan") %> - <%#Eval("LoaiDiSan") %></a>
                                        </div>
                                        <p><%#Eval("DiaDiem") %></p>
                                        <p class="day">Chứng nhận ngày: <%# DataBinder.Eval(Container.DataItem, "NgayChungNhan", "{0:d/M/yyyy}") %></p>
                                    </div>
                                    <div style="clear: both"></div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>

            <asp:Repeater runat="server" ID="rptMenu" OnItemDataBound="rptMenu_ItemDataBound">
                <ItemTemplate>
                    <asp:Panel runat="server" ID="pnDiSan" Visible="false" CssClass="block-cate">
                        <div class="module tab">
                            <div class="module-title">
                                <a href="<%#Eval("url") %>" class="TitleCate" title="<%#Eval("TenMenu") %>">
                                    <span><%#Eval("TenMenu") %></span>
                                </a>
                            </div>
                            <div class="tab-content">
                                <div class="tab-pane active">
                                    <div class="module-content">
                                        <asp:Repeater runat="server" ID="rpt2HotNew">
                                            <ItemTemplate>
                                                <div class="img-left">
                                                    <a href="<%#Eval("url") %>">
                                                        <img src="/FileUpload/images/<%#Eval("HinhAnh") %>" class="img-responsive home-img" />
                                                    </a>
                                                </div>
                                                <div class="about">
                                                    <div class="about-new-title">
                                                        <a href="<%#Eval("url") %>" class="link-new"><%#Eval("TieuDe") %></a>
                                                    </div>
                                                    <p class="day">Cập nhật: <%# DataBinder.Eval(Container.DataItem, "NgayXuatBan", "{0:d/M/yyyy}") %></p>
                                                    <p class="about-new-content"><%#Eval("GioiThieu") %></p>
                                                    <p class="right"><a href="<%#Eval("url") %>" class="more_link">Xem thêm</a></p>

                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <div style="clear: both"></div>
                                        <div class="more-new">
                                            <asp:Repeater runat="server" ID="rptTinDisan">
                                                <ItemTemplate>
                                                    <p><a href="<%#Eval("url") %>"><%#Eval("TieuDe") %></a></p>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="<%# (Container.ItemIndex+1)%2==0?"clearfix":""%>"></div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
    <script>
        $(".about-new-content").each(function () {
            if ($(this).text().length > 200) {
                $(this).text($(this).text().substring(0, 200) + "...");
            }
        });
    </script>
</asp:Content>
