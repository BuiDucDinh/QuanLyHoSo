jQuery(document).ready(function() {
	"use strict";
	jQuery('.toggle').click(function() {
		if (jQuery('.submenu').is(":hidden"))
		{
			jQuery('.submenu').slideDown("fast");
		} else {
			jQuery('.submenu').slideUp("fast");
		}
		return false;
	});

	/*  Phone Menu  */

	jQuery(".topnav").accordion({
		accordion:false,
		speed: 300,
		closedSign: '+',
		openedSign: '-'
	});

	$("#nav > li").hover(function() {
		var el = $(this).find(".level0-wrapper");
		el.hide();
		el.css("left", "0");
		el.stop(true, true).delay(150).fadeIn(300, "easeOutCubic");
	}, function() {
		$(this).find(".level0-wrapper").stop(true, true).delay(300).fadeOut(300, "easeInCubic");
	});	
	var scrolled = false;

	jQuery("#nav li.level0.drop-menu").mouseover(function(){
		if(jQuery(window).width() >= 740){
			jQuery(this).children('ul.level1').fadeIn(100);
		}
		return false;
	}).mouseleave(function(){
		if(jQuery(window).width() >= 740){
			jQuery(this).children('ul.level1').fadeOut(100);
		}
		return false;
	});
	jQuery("#nav li.level0.drop-menu li").mouseover(function(){
		if(jQuery(window).width() >= 740){
			jQuery(this).children('ul').css({top:0,left:"165px"});
			var offset = jQuery(this).offset();
			if(offset && (jQuery(window).width() < offset.left+325)){
				jQuery(this).children('ul').removeClass("right-sub");
				jQuery(this).children('ul').addClass("left-sub");
				jQuery(this).children('ul').css({top:0,left:"-167px"});
			} else {
				jQuery(this).children('ul').removeClass("left-sub");
				jQuery(this).children('ul').addClass("right-sub");
			}
			jQuery(this).children('ul').fadeIn(100);
		}
	}).mouseleave(function(){
		if(jQuery(window).width() >= 740){
			jQuery(this).children('ul').fadeOut(100);
		}
	});				

	jQuery("ul.accordion li.parent, ul.accordion li.parents, ul#magicat li.open").each(function(){
		jQuery(this).append('<em class="open-close">&nbsp;</em>');
	});
	jQuery('ul.accordion, ul#magicat').accordionNew();
	jQuery("ul.accordion li.active, ul#magicat li.active").each(function(){
		jQuery(this).children().next("div").css('display','block');
	});


});

function deleteCartInCheckoutPage(){ 	
	$(".checkout-cart-index a.btn-remove2,.checkout-cart-index a.btn-remove").click(function(event) {
		event.preventDefault();
		if(!confirm(confirm_content)){
			return false;
		}	
	});	
	return false;
}
function slideEffectAjax() {
	$('.top-cart-contain').mouseenter(function() {
		$(this).find(".top-cart-content").stop(true, true).slideDown();
	});

	$('.top-cart-contain').mouseleave(function() {
		$(this).find(".top-cart-content").stop(true, true).slideUp();
	});
}
function deleteCartInSidebar() {
	if(is_checkout_page>0) return false;
	$('#cart-sidebar a.btn-remove, #mini_cart_block a.btn-remove').each(function(){});
}  

$(document).ready(function(){
	slideEffectAjax();
});



/* Mega Menu */

var isTouchDevice = ('ontouchstart' in window) || (navigator.msMaxTouchPoints > 0);
jQuery(window).on("load", function() {
	if (isTouchDevice)
	{
		jQuery('#nav a.level-top').click(function(e) {
			$t = jQuery(this);
			$parent = $t.parent();
			if ($parent.hasClass('parent'))
			{
				if ( !$t.hasClass('menu-ready'))
				{                    
					jQuery('#nav a.level-top').removeClass('menu-ready');
					$t.addClass('menu-ready');
					return false;
				}
				else
				{
					$t.removeClass('menu-ready');
				}
			}
		});
	}
	//on load
	jQuery().UItoTop();
}); 

$(window).scroll(function() {
	if ($(this).scrollTop() > 1){  
		$('nav').addClass("stickys");
	}
	else{
		$('nav').removeClass("stickys");
	}
});

/* UItoTop */

(function($){
	jQuery.fn.UItoTop = function(options) {
		var defaults = {
			text: '',
			min: 200,
			inDelay:600,
			outDelay:400,
			containerID: 'toTop',
			containerHoverID: 'toTopHover',
			scrollSpeed: 1200,
			easingType: 'linear'
		};

		var settings = $.extend(defaults, options);
		var containerIDhash = '#' + settings.containerID;
		var containerHoverIDHash = '#'+settings.containerHoverID;
		jQuery('body').append('<a href="#" id="'+settings.containerID+'">'+settings.text+'</a>');
		jQuery(containerIDhash).hide().click(function(){
			jQuery('html, body').animate({scrollTop:0}, settings.scrollSpeed, settings.easingType);
			jQuery('#'+settings.containerHoverID, this).stop().animate({'opacity': 0 }, settings.inDelay, settings.easingType);
			return false;
		})
			.prepend('<span id="'+settings.containerHoverID+'"></span>')
			.hover(function() {
			jQuery(containerHoverIDHash, this).stop().animate({
				'opacity': 1
			}, 600, 'linear');
		}, function() { 
			jQuery(containerHoverIDHash, this).stop().animate({
				'opacity': 0
			}, 700, 'linear');
		});

		jQuery(window).scroll(function() {
			var sd = $(window).scrollTop();
			if(typeof document.body.style.maxHeight === "undefined") {
				jQuery(containerIDhash).css({
					'position': 'absolute',
					'top': $(window).scrollTop() + $(window).height() - 50
				});
			}
			if ( sd > settings.min ) 
				jQuery(containerIDhash).fadeIn(settings.inDelay);
			else 
				jQuery(containerIDhash).fadeOut(settings.Outdelay);
		});

	};
})(jQuery);


jQuery.extend( jQuery.easing,
			  {	
	easeInCubic: function (x, t, b, c, d) {
		return c*(t/=d)*t*t + b;
	},
	easeOutCubic: function (x, t, b, c, d) {
		return c*((t=t/d-1)*t*t + 1) + b;
	},	
});

(function(jQuery){
	jQuery.fn.extend({
		accordion: function() {       
			return this.each(function() {

				function activate(el,effect){	
					jQuery(el).siblings( panelSelector )[(effect || activationEffect)](((effect == "show")?activationEffectSpeed:false),function(){
						jQuery(el).parents().show();	
					});	
				}	
			});
		}
	}); 
})
(jQuery);

jQuery(function($) {
	$('.accordion').accordion();	
	$('.accordion').each(function(index){
		var activeItems = $(this).find('li.active');
		activeItems.each(function(i){
			$(this).children('ul').css('display', 'block');
			if (i == activeItems.length - 1)
			{
				$(this).addClass("current");
			}
		});
	});

});

/*  Responsive Menu  */

(function($){
	$.fn.extend({	
		accordion: function(options) {	
			var defaults = {
				accordion: 'true',
				speed: 300,
				closedSign: '[+]',
				openedSign: '[-]'
			};	
			var opts = $.extend(defaults, options);	
			var $this = $(this);	
			$this.find("li").each(function() {
				if($(this).find("ul").size() != 0){
					$(this).find("a:first").after("<em>"+ opts.closedSign +"</em>");	
					if($(this).find("a:first").attr('href') == "#"){
						$(this).find("a:first").click(function(){return false;});
					}
				}
			});	
			$this.find("li em").click(function() {
				if($(this).parent().find("ul").size() != 0){
					if(opts.accordion){
						//Do nothing when the list is open
						if(!$(this).parent().find("ul").is(':visible')){
							parents = $(this).parent().parents("ul");
							visible = $this.find("ul:visible");
							visible.each(function(visibleIndex){
								var close = true;
								parents.each(function(parentIndex){
									if(parents[parentIndex] == visible[visibleIndex]){
										close = false;
										return false;
									}
								});
								if(close){
									if($(this).parent().find("ul") != visible[visibleIndex]){
										$(visible[visibleIndex]).slideUp(opts.speed, function(){
											$(this).parent("li").find("em:first").html(opts.closedSign);
										});		
									}
								}
							});
						}
					}
					if($(this).parent().find("ul:first").is(":visible")){
						$(this).parent().find("ul:first").slideUp(opts.speed, function(){
							$(this).parent("li").find("em:first").delay(opts.speed).html(opts.closedSign);
						});	
					}else{
						$(this).parent().find("ul:first").slideDown(opts.speed, function(){
							$(this).parent("li").find("em:first").delay(opts.speed).html(opts.openedSign);
						});
					}
				}
			});
		}
	});
})(jQuery);

/* Sidebar Dropdown */

(function(jQuery){
	jQuery.fn.extend({
		accordionNew: function() {       
			return this.each(function() {	
				var jQueryul			= jQuery(this),
					elementDataKey			= 'accordiated',
					activeClassName			= 'active',
					activationEffect 		= 'slideToggle',
					panelSelector			= 'ul, div',
					activationEffectSpeed 	= 'fast',
					itemSelector			= 'li';	
				if(jQueryul.data(elementDataKey))
					return false;							
				jQuery.each(jQueryul.find('ul, li>div'), function(){
					jQuery(this).data(elementDataKey, true);
					jQuery(this).hide();
				});	
				jQuery.each(jQueryul.find('em.open-close'), function(){
					jQuery(this).click(function(e){
						activate(this, activationEffect);
						return void(0);
					});	
					jQuery(this).bind('activate-node', function(){
						jQueryul.find( panelSelector ).not(jQuery(this).parents()).not(jQuery(this).siblings()).slideUp( activationEffectSpeed );
						activate(this,'slideDown');
					});
				});	
				var active = (location.hash)?jQueryul.find('a[href=' + location.hash + ']')[0]:jQueryul.find('li.current a')[0];	
				if(active){
					activate(active, false);
				}	
				function activate(el,effect){	
					jQuery(el).parent( itemSelector ).siblings().removeClass(activeClassName).children( panelSelector ).slideUp( activationEffectSpeed );	
					jQuery(el).siblings( panelSelector )[(effect || activationEffect)](((effect == "show")?activationEffectSpeed:false),function(){	
						if(jQuery(el).siblings( panelSelector ).is(':visible')){
							jQuery(el).parents( itemSelector ).not(jQueryul.parents()).addClass(activeClassName);
						} else {
							jQuery(el).parent( itemSelector ).removeClass(activeClassName);
						}	
						if(effect == 'show'){
							jQuery(el).parents( itemSelector ).not(jQueryul.parents()).addClass(activeClassName);
						}	
						jQuery(el).parents().show();	
					});	
				}	
			});
		}
	}); 
})(jQuery);


$(document).ready(function(){
	$('.colletion-topbar .btn-view-list').click(function(){
		$('.colletion-topbar .btn-view-grid .fa').removeClass('active');
		$('.colletion-topbar .btn-view-list .fa').addClass('active');
	});
	$('.colletion-topbar .btn-view-grid').click(function(){
		$('.colletion-topbar .btn-view-list .fa').removeClass('active');
		$('.colletion-topbar .btn-view-grid .fa').addClass('active');
	});
});