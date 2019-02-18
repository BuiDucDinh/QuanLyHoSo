iWish$(document).ready(function () {
	iWishCheck();

	// if change variant
	iWish$(".iWishAdd").parents('form').find("[name='id']").change(function () {
		iWishCheck();
	});
	iWish$(".iWishAdd").parents('form').find("[name='variantId']").change(function () {
		iWishCheck();
	});
	iWish$('.single-option-selector').change(function () {
		iWishCheck();
	});

	if (iWish$(".iWishView").length > 0) {
		iWish$(".iWishView").click(function () {
			if (iwish_cid == 0) {
				iWishGotoStoreLogin();
			} else {
				iWishSubmit(iWishLink, { cust: iwish_cid });
			}
			return false;
		});
	}

	iWish$(".iWishAdd").click(function () {
		var iWishvId = iWish$(this).parents('form').find("[name='id']").val();
		if (typeof iWishvId === 'undefined') {
			iWishvId = iWish$(this).parents('form').find("[name='variantId']").val();
		};
		var iWishpId = iWish$(this).attr('data-product');
		if (typeof iWishvId === 'undefined' || typeof iWishpId === 'undefined') {
			return false;
		}
		if (iwish_cid == 0) {
			iWishGotoStoreLogin();
		} else {
			var postObj = {
				actionx : 'add',
				cust: iwish_cid,
				pid: iWishpId,
				vid: iWishvId
			};
			iWish$.post(iWishLink, postObj, function (data) {
				var result = (iWishFindAndGetVal('#iwish_post_result', data).toString().toLowerCase() === 'true');
				var redirect = parseInt(iWishFindAndGetVal('#iwish_post_redirect', data), 10);
				if (result) {
					iWish$('.iWishAdd').addClass('iWishHidden'), iWish$('.iWishAdded').removeClass('iWishHidden');
					if (redirect == 2) {
						iWishSubmit(iWishLink, { cust: iwish_cid });
					}
				}
			}, 'html');
		}
		return false;
	});
});
$(document).ready(function () {
	$('.single-option-selector').change(function () {
		iWishCheck();
	});
});
