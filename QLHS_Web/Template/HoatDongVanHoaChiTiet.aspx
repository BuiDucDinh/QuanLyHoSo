<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeFile="HoatDongVanHoaChiTiet.aspx.cs" Inherits="Template_ChiTietTin" %>

<%@ Register Src="~/Template/Controls/RightContent.ascx" TagPrefix="uc1" TagName="RightContent" %>


<asp:Content runat="server" ContentPlaceHolderID="Navigate">
    <a href="/"><%=Resources.labels.home %></a>
    <span>> </span>
    <a href="#"><%=Resources.labels.hoatdongvanhoa %></a>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div class="left-main">
        <div class="module">
            <div class="module-title">
                <a href="#" class="TitleCate" title="<%=hd.TenGoi %>">
                    <span><%=hd.TenGoi %></span>
                </a>
            </div>
            <div class="module-content">

               <%-- <div class="span12">
                    <div id="sync1" class="owl-carousel">
                        <asp:Repeater runat="server" ID="rptImage">
                            <ItemTemplate>
                                <div class="item" style="text-align: center;">
                                    <img src="/FileUpload/images/<%#Eval("TenAnh") %>" style="max-width: 90%" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                </div>--%>
                <div class="des">
                    <div class="info">
                        <p><%=Resources.labels.ngaykhiamac %> : <%=hd.NgayDienRa.ToString("dd/MM/yyyy")%></p>
                        <p><%=Resources.labels.thoigiandienra %> : <%=hd.ThoiGianDienRa %></p>
                    </div>
                </div>
                <div class="new-details">
                    <%=hd.NoiDung %>
                </div>
                <asp:Repeater runat="server" ID="rptImageLib">
                    <HeaderTemplate>
                        <div class="more-link">
                            <h4><%=Resources.labels.albumanh %> <%=hd.TenGoi %></h4>
                            <div id="owl-images" class="owl-carousel">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="item">
                            <img src="/FileUpload/Images/<%#Eval("HinhAnh") %>" />
                            <a href="<%#Eval("Url") %>"><%#Eval("TenMediaLib") %></a>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>

                <asp:Repeater runat="server" ID="rptOrther">
                    <HeaderTemplate>
                        <div class="more-link">
                            <h4><%=Resources.labels.tintuclienquan %></h4>
                            <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href="<%#Eval("url") %>"><%#Eval("TieuDe") %></a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div><div class="right-main">
        <uc1:RightContent runat="server" ID="RightContent" />
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ScriptContent">
    <style>
        #sync2 .item {
            padding: 10px 0px;
            margin: 5px;
            color: #FFF;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            text-align: center;
            cursor: pointer;
        }
    </style>

    <script>
        $(document).ready(function () {

            var owl = $("#owl-images");

            owl.owlCarousel({

                items: 4, //10 items above 1000px browser width
                itemsDesktop: [1000, 4], //5 items between 1000px and 901px
                itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
                itemsTablet: [600, 2], //2 items between 600 and 0;
                itemsMobile: false // itemsMobile disabled - inherit from itemsTablet option

            });

            var sync1 = $("#sync1");
            var sync2 = $("#sync2");

            sync1.owlCarousel({
                navigation: true,
                singleItem: true,
                slideSpeed: 1000,
                pagination: false,
                afterAction: syncPosition,
                responsiveRefreshRate: 200,
            });
            sync2.owlCarousel({
                navigation: true,
                items: 4,
                itemsDesktop: [1199, 4],
                itemsDesktopSmall: [979, 4],
                itemsTablet: [768, 3],
                itemsMobile: [479, 2],
                pagination: false,
                responsiveRefreshRate: 100,
                afterInit: function (el) {
                    el.find(".owl-item").eq(0).addClass("synced");
                }
            });

            function syncPosition(el) {
                var current = this.currentItem;
                $("#sync2")
                  .find(".owl-item")
                  .removeClass("synced")
                  .eq(current)
                  .addClass("synced")
                if ($("#sync2").data("owlCarousel") !== undefined) {
                    center(current)
                }

            }

            $("#sync2").on("click", ".owl-item", function (e) {
                e.preventDefault();
                var number = $(this).data("owlItem");
                sync1.trigger("owl.goTo", number);
            });

            function center(number) {
                var sync2visible = sync2.data("owlCarousel").owl.visibleItems;

                var num = number;
                var found = false;
                for (var i in sync2visible) {
                    if (num === sync2visible[i]) {
                        var found = true;
                    }
                }

                if (found === false) {
                    if (num > sync2visible[sync2visible.length - 1]) {
                        sync2.trigger("owl.goTo", num - sync2visible.length + 2)
                    } else {
                        if (num - 1 === -1) {
                            num = 0;
                        }
                        sync2.trigger("owl.goTo", num);
                    }
                } else if (num === sync2visible[sync2visible.length - 1]) {
                    sync2.trigger("owl.goTo", sync2visible[1])
                } else if (num === sync2visible[0]) {
                    sync2.trigger("owl.goTo", num - 1)
                }
            }

        });
    </script>
</asp:Content>
