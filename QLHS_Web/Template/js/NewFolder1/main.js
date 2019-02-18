$(document).ready(function(){
	$("#owl-demo").owlCarousel({
		// autoPlay: 3000, //Set AutoPlay to 3 seconds
		pagination: false,
		navigation: true,
		navigationText: true,
		singleItem: true
	});

	$("#owl-demo .owl-buttons").click(function(){
		new WOW().init();
	})


	$(".main-slider-content").owlCarousel({
		autoPlay: 3000, //Set AutoPlay to 3 seconds
		pagination: false,
		navigation: true,
		navigationText: false,
		singleItem: true
	});

	$(".product-list-carousel").owlCarousel({
		autoPlay: false, //Set AutoPlay to 3 seconds
		pagination: false,
		navigation: true,
		navigationText: false,
		items: 2,
		itemsDesktop: [1024, 2],
		itemsDesktopSmall: [900, 2],
		itemsTablet: [600, 1],
		itemsMobile: [320, 1]
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
	$(".cc-list li a").on("click", function(){
		var ccsp = $(this);
		var ccl = $(this).parent().find(".cc-list-child");
		ccl.toggle();
		if(ccl.is(":visible")) {
			ccsp.find(".fa").removeClass("fa-caret-right").addClass("fa-caret-down");
		} else {
			ccsp.find(".fa").removeClass("fa-caret-down").addClass("fa-caret-right");
		}
	});

	$(".header-menu-btn span").on("click",function(){
		$(".header-nav-mobile").css("left","0px");
	});
	$(".header-menu-btn-hidden").on("click", function(){
		$(".header-nav-mobile").css("left","-300px");
	});

	$(".product-list-list").hide();

	$(".btn-view-grid").on("click", function(){
		$(".product-list-grid").show();
		$(".product-list-list").hide();
	});
	$(".btn-view-list").on("click", function(){
		$(".product-list-grid").hide();
		$(".product-list-list").show();
	});

	Bizweb.doNotTriggerClickOnThumb = false;

	var selectCallbackQuickview = function(variant, selector) {
		var productItem = jQuery('.quick-view .product-item');
		addToCart = productItem.find('.add-to-cart-btn'),
			productPrice = productItem.find('.price'),
			comparePrice = productItem.find('.compare-price'),
			totalPrice = productItem.find('.total-price span');

		if (variant) {
			if (variant.available) {
				// We have a valid product variant, so enable the submit button
				addToCart.removeClass('disabled').removeAttr('disabled').text('Thêm vào giỏ hàng');

			} else {
				// Variant is sold out, disable the submit button
				addToCart.val('Hết hàng').addClass('disabled').attr('disabled', 'disabled');
			}

			// Regardless of stock, update the product price
			productPrice.html(Bizweb.formatMoney(variant.price, "{{amount_no_decimals_with_comma_separator}}&#8363;"));

			// Also update and show the product's compare price if necessary
			if ( variant.compare_at_price > variant.price ) {
				comparePrice
					.html(Bizweb.formatMoney(variant.compare_at_price, "{{amount_no_decimals_with_comma_separator}}&#8363;"))
					.show();
				productPrice.addClass('on-sale');
			} else {
				comparePrice.hide();
				productPrice.removeClass('on-sale');
			}


			// BEGIN SWATCHES
			var form = jQuery('.quick-view form.variants');
			for (var i=0,length=variant.options.length; i<length; i++) {
				var radioButton = form.find('.swatch[data-option-index="' + i + '"] :radio[value="' + variant.options[i] +'"]');
				if (radioButton.size()) {
					radioButton.get(0).checked = true;
				}
			}
			// END SWATCHES

			/*recaculate total price*/
			var regex = /([0-9]+[.|,][0-9]+)/g;
			var unitPrice = jQuery('.quick-view .price').text().match(regex)[0];
			unitPrice = unitPrice.replace(/[.|,]/,'');
			var quantity = parseInt(jQuery('.quick-view input[name=quantity]').val());
			var totalPrice = unitPrice * quantity;
			jQuery('.quick-view .total-price span').html(Bizweb.formatMoney(totalPrice, window.money_format));
			/*end of price calculation*/

			/*begin variant image*/
			if (variant && variant.image) {
				var originalImage = jQuery(".quick-view .quickview-featured-image img");
				var newImage = variant.featured_image;
				var element = originalImage[0];
				Bizweb.Image.switchImage(newImage, element, function (newImageSizedSrc, newImage, element) {
					newImageSizedSrc = newImageSizedSrc.replace(/\?(.*)/,"");
					jQuery('.quick-view .more-view-wrapper img').each(function() {
						var grandSize = jQuery(this).attr('src');
						grandSize = grandSize.replace('compact','grande');               
						if (grandSize == newImageSizedSrc) {
							jQuery(this).parent().trigger('click');              
							return false;
						}
					});
				});        
			}      

			/*end of variant image*/ 
		} else {
			// The variant doesn't exist. Just a safegaurd for errors, but disable the submit button anyway
			addToCart.text('Ngừng bán').addClass('disabled').attr('disabled', 'disabled');
		}
	};
});