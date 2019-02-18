<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Template_Controls_Header" %>


<script type="text/javascript">
    $(document).ready(function () {

        setInterval(function () {
            // lay gia tri giay trong doi tuong Date()
            var seconds = new Date().getSeconds();
            // Chen so 0 vao dang truoc gia tri giay
            $("#sec").html((seconds < 10 ? "0" : "") + seconds);
        }, 1000);

        setInterval(function () {
            // Tuong tu lay gia tri phut
            var minutes = new Date().getMinutes();
            // Chen so 0 vao dang truoc gia tri phut neu gia tri hien tai nho hon 10
            $("#min").html((minutes < 10 ? "0" : "") + minutes);
        }, 1000);

        setInterval(function () {
            // Lay gia tri gio hien tai
            var hours = new Date().getHours();
            // Chen so 0 vao truoc gia tri gio neu gia tri nho hon 10
            $("#hours").html((hours < 10 ? "0" : "") + hours);
        }, 1000);
    });
</script>

<header class="header">

    <div class="header-content-top content">
        <div class="content-banner">
            <asp:Panel runat="server" ID="pnBanber" CssClass="header-content">
                <div class="row" style="position: relative">
                    <div class="col-xs-2 logo">
                        <div class="box-logo">
                            <%=logo %>
                        </div>
                    </div>
                    <div class="col-xs-10 slogan">
                        <div class="top_info_header box-logo">
                            <%--<p>Sở văn hóa, thể thao và du lịch Thanh Hóa</p>--%>
                            <%=Resources.labels.header %>
                          <%--  QUẢN LÝ DI SẢN VĂN HÓA THANH HÓA
                            <p>Management of Cultural Heritage</p>--%>
                        </div>
                    </div>
                    <div class="lang">
                        <asp:ImageButton runat="server" ID="btnViet" ImageUrl="/Images/flag-vn.png" OnClick="btnViet_Click" />
                        <asp:ImageButton runat="server" ID="btnEng" ImageUrl="/Images/flag-eng.gif" OnClick="btnEng_Click" />
                    <%--<a href="<%= HttpContext.Current.Request.Url.AbsoluteUri+"l=vi" %> ">
                            <img src="/Images/flag-vn.png" alt="" title="Vietnam" />
                        </a>
                        <a href="<%= HttpContext.Current.Request.Url.AbsoluteUri+"l=en" %> ">
                            <img src="Images/flag-Eng.gif" alt="English" title="English" />
                        </a>--%>
                    </div>
                    <div class="col-xs-5 hidden-lg hidden-md menu-center">
                        <!-- mobile-menu -->
                        <div class="hidden-desktop" id="mobile-menu">
                            <ul class="navmenu">

                                <li>
                                    <div class="menutop">
                                        <div class="toggle">
                                            <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                                        </div>
                                        <h2>Menu</h2>
                                    </div>
                                    <ul style="display: none;" class="submenu topnav">
                                        <li class="level0 level-top parent"><a class="level-top" href="/"><span><i class="fa fa-home fa-lg" aria-hidden="true"></i>Trang chủ</span></a></li>
                                        <asp:Repeater runat="server" ID="rptMenu" OnItemDataBound="rptMenu_ItemDataBound">
                                            <ItemTemplate>
                                                <li class="level0 level-top parent">
                                                    <a class="level-top" href="<%#Eval("url") %>"><span><%#Eval("TenMenu") %></span> </a>
                                                    <asp:Repeater runat="server" ID="rptMenuCon" OnItemDataBound="rptMenu_ItemDataBound">
                                                        <HeaderTemplate>
                                                            <em>+</em>
                                                            <ul class="level0">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <li class="level1">
                                                                <a href="<%#Eval("url") %>"><span><%#Eval("TenMenu") %></span> </a><em>+</em>
                                                                <asp:Repeater runat="server" ID="rptMenuCon" OnItemDataBound="rptMenu_ItemDataBound">
                                                                    <HeaderTemplate>
                                                                        <em>+</em>
                                                                        <ul class="level0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <li class="level2"><a href="<%#Eval("url") %>"><span><%#Eval("TenMenu") %></span></a>
                                                                            <asp:Repeater runat="server" ID="rptMenuCon">
                                                                                <HeaderTemplate>
                                                                                    <em>+</em>
                                                                                    <ul class="level0">
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <li class="level3"><a href="<%#Eval("url") %>"><span><%#Eval("TenMenu") %></span></a></li>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    </ul>
                                                                                </FooterTemplate>
                                                                            </asp:Repeater>
                                                                        </li>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </ul>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </li>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </ul>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <!--End mobile-menu -->
                    </div>

                </div>
            </asp:Panel>
            <%--<ul class="mytopmenu">
                <li><a href="#">Liên kết</a></li>
                <li><a href="#">RSS</a></li>
                <li><a href="#">Sơ đồ</a></li>
            </ul>--%>
        </div>
    </div>



    <nav class="content">
        <div class="nav-inner">
            <ul id="nav" class="hidden-xs">

                <li class="level0 active"><a href="/"><i class="fa fa-home fa-lg" style="padding: 0 10px;"></i></a></li>


                <asp:Repeater runat="server" ID="rptMenuDesktop" OnItemDataBound="rptMenu_ItemDataBound">
                    <ItemTemplate>

                        <li class="level0 parent drop-menu ">
                            <a href="<%#Eval("url") %>"><span><%#Eval("TenMenu") %></a>
                            <asp:Repeater runat="server" ID="rptMenuCon" OnItemDataBound="rptMenu_ItemDataBound">
                                <HeaderTemplate>

                                    <i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                <ul class="level1 cap1">
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <li class="level1"><a href="<%#Eval("url") %>"><span><%#Eval("TenMenu") %></span></a>
                                        <asp:Repeater runat="server" ID="rptMenuCon" OnItemDataBound="rptMenu_ItemDataBound">
                                            <HeaderTemplate>
                                                <ul class="level1" style="left: 190px">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li class="level2"><a href="<%#Eval("url") %>"><span><%#Eval("TenMenu") %></span></a>
                                                    <asp:Repeater runat="server" ID="rptMenuCon">
                                                        <HeaderTemplate>
                                                            <ul class="level2" style="width: 200px;">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <li class="level3" style="text-align: left;"><a href="<%#Eval("url") %>"><span><%#Eval("TenMenu") %></span></a> </li>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </ul>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>


                        </li>
                    </ItemTemplate>
                </asp:Repeater>

            </ul>
        </div>
    </nav>
    <div class="site-header content">
        <div class="content-body">
            <div class="row row-header-top ">
                <div class="header-topbar">
                    <div class="col-md-6 col-xs-6 date-topbar" style="color: #000;">
                        <div class="welcome">
                            <asp:Label runat="server" ID="lbTime" />
                            <span id="hours"></span>
                            <span class="point">:</span>
                            <span id="min"></span>
                            <span class="point">:</span>
                            <span id="sec"></span>
                        </div>
                        <%-- <div class="welcome">
                            <a href="#">English </a>|
                            <a href="#">Tiếng Việt </a>
                        </div>--%>
                    </div>
                    <div class="col-md-6 col-xs-6">

                        <div class="search-box pull-right welcome">
                            <form action="/search" method="get" id="search_mini_form">
                                <input placeholder="<%=Resources.labels.search %>" value="" maxlength="70" name="query" id="search" type="text">
                                <button class="btn btn-default  search-btn-bg"><span class="fa fa-search"></span></button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</header>
