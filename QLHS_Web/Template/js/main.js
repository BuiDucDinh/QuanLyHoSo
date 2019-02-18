$(document).ready(function () {
    $("#owl-demo").owlCarousel({
        // autoPlay: 3000, //Set AutoPlay to 3 seconds
        pagination: false,
        navigation: true,
        navigationText: true,
        singleItem: true
    });

    $("#owl-demo .owl-buttons").click(function () {
        new WOW().init();
    })


    $(".main-slider-content").owlCarousel({
        autoPlay: 3000, //Set AutoPlay to 3 seconds
        pagination: false,
        navigation: true,
        navigationText: false,
        singleItem: true
    });


    $(".brand-carousel").owlCarousel({
        autoPlay: 3000, //Set AutoPlay to 3 seconds
        pagination: false,
        navigation: true,
        navigationText: false,
        items: 6
    });
    /** click to expand main 
    $(".mc-list li a").on("click", function(){
        var mcsp = $(this);
        var mcl = $(this).parent().find(".mc-list-child");
        mcl.toggle();
        if(mcl.is(":visible")) {
            mcsp.find(".fa").removeClass("fa-angle-right").addClass("fa-angle-down");
        } else {
            mcsp.find(".fa").removeClass("fa-angle-down").addClass("fa-angle-right");
        }
    });
	**/
    $(".cc-list li a").on("click", function () {
        var ccsp = $(this);
        var ccl = $(this).parent().find(".cc-list-child");
        ccl.toggle();
        if (ccl.is(":visible")) {
            ccsp.find(".fa").removeClass("fa-caret-right").addClass("fa-caret-down");
        } else {
            ccsp.find(".fa").removeClass("fa-caret-down").addClass("fa-caret-right");
        }
    });

    $(".header-menu-btn span").on("click", function () {
        $(".header-nav-mobile").css("left", "0px");
    });
    $(".header-menu-btn-hidden").on("click", function () {
        $(".header-nav-mobile").css("left", "-300px");
    });

});