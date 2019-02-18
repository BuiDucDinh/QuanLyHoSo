<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SliderNew.ascx.cs" Inherits="Template_Controls_SliderNew" %>

<asp:Repeater runat="server" ID="rptSlider">
    <HeaderTemplate>
        <div class="slider">
            <h4><%=Resources.labels.hoatdongnoibat %></h4>
            <div class="border" style="padding: 10px; border-radius: 5px;">
                <div class="span12" style="padding: 0 10px;">
                    <div id="owl-demo" class="owl-carousel">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="item">
            <a href="<%#Eval("url") %>" title="<%#Eval("TenGoi") %>">
                <img src="/FileUpload/Images/<%#Eval("HinhAnh") %>" alt="<%#Eval("TenGoi") %>" class="slide-img" />
            </a>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
            <a class="btn prev">
                <img src="/Template/images/Slide/Back.png" />
            </a>
        <a class="btn next">
            <img src="/Template/images/Slide/Next.png" />
        </a>
        </div>
    </div>
    <script>
        $(document).ready(function () {

            var owl = $("#owl-demo");

            owl.owlCarousel({
                navigation: false,
                autoPlay: 7000,
                stopOnHover: true,
                pagination: false,
                items: 4, //10 items above 1000px browser width
                itemsDesktop: [1000, 4], //5 items between 1000px and 901px
                itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
                itemsTablet: [600, 1], //2 items between 600 and 0;
                itemsMobile: false // itemsMobile disabled - inherit from itemsTablet option

            });
            // Custom Navigation Events
            $(".next").click(function () {
                owl.trigger('owl.next');
            })
            $(".prev").click(function () {
                owl.trigger('owl.prev');
            })
            $(".play").click(function () {
                owl.trigger('owl.play', 1000);
            })
            $(".stop").click(function () {
                owl.trigger('owl.stop');
            })


        });
    </script>
        </div>
    </FooterTemplate>
</asp:Repeater>
