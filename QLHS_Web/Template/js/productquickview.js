! function () {
    function floatToString(a, b) {
        var c = a.toFixed(b)
            .toString();
        return c.match(/^\.\d+/) ? "0" + c : c;
    }

    function attributeToString(a) {
        return "string" != typeof a && (a += "", "undefined" === a && (a = "")), jQuery.trim(a);
    }

    function loadProductFromCart(a) {
        a.ajax({
            dataType: "json",
            url: "/cart.js",
            success: function (b) {
                var c = [];
                a.each(b.items, function (a, b) {
                    c.push(b.variant_id);
                }), list_cart_variants = c;
            }
        });
    }

    function scaqvImageZoom(a, b, c) {
        "function" != typeof Object.create && (Object.create = function (a) {
            function b() { }

            return b.prototype = a, new b;
        }), function (a) {
            var e = {
                init: function (b, c) {
                    var d = this;
                    d.elem = c, d.$elem = a(c), d.imageSrc = d.$elem.data("zoom-image") ? d.$elem.data("zoom-image") : d.$elem.attr("src"), d.options = a.extend({}, a.fn.elevateZoom.options, b), d.options.tint && (d.options.lensColour = "none", d.options.lensOpacity = "1"), "inner" == d.options.zoomType && (d.options.showLens = false), d.$elem.parent()
                        .removeAttr("title")
                        .removeAttr("alt"), d.zoomImage = d.imageSrc, d.refresh(1), a("#" + d.options.gallery + " a")
                        .click(function (b) {
                            return d.options.galleryActiveClass && (a("#" + d.options.gallery + " a")
                                .removeClass(d.options.galleryActiveClass), a(this)
                                .addClass(d.options.galleryActiveClass)), b.preventDefault(), d.zoomImagePre = a(this)
                                .data("zoom-image") ? a(this)
                                .data("zoom-image") : a(this)
                                .data("image"), d.swaptheimage(a(this)
                                .data("image"), d.zoomImagePre), false;
                        });
                },
                refresh: function (a) {
                    var b = this;
                    setTimeout(function () {
                        b.fetch(b.imageSrc);
                    }, a || b.options.refresh);
                },
                fetch: function (a) {
                    var b = this, c = new Image;
                    c.onload = function () {
                        b.largeWidth = c.width, b.largeHeight = c.height, b.startZoom(), b.currentImage = b.imageSrc, b.options.onZoomedImageLoaded(b.$elem);
                    }, c.src = a;
                },
                startZoom: function () {
                    var b = this;
                    if (b.nzWidth = b.$elem.width(), b.nzHeight = b.$elem.height(), b.isWindowActive = false, b.isLensActive = false, b.isTintActive = false, b.overWindow = false, b.options.imageCrossfade && (b.zoomWrap = b.$elem.wrap('<div style="height:' + b.nzHeight + "px;width:" + b.nzWidth + 'px;" class="zoomWrapper" />')), b.zoomLock = 1, b.scrollingLock = false, b.changeBgSize = false, b.currentZoomLevel = b.options.zoomLevel, b.nzOffset = b.$elem.offset(), b.widthRatio = b.largeWidth / b.currentZoomLevel / b.nzWidth, b.heightRatio = b.largeHeight / b.currentZoomLevel / b.nzHeight, "window" == b.options.zoomType && (b.zoomWindowStyle = "overflow: hidden;background-position: 0px 0px;text-align:center;background-color: " + String(b.options.zoomWindowBgColour) + ";width: " + String(b.options.zoomWindowWidth) + "px;" + "height: " + String(b.options.zoomWindowHeight) + "px;float: left;" + "background-size: " + b.largeWidth / b.currentZoomLevel + "px " + b.largeHeight / b.currentZoomLevel + "px;" + "display: none;z-index:100;" + "border: " + String(b.options.borderSize) + "px solid " + b.options.borderColour + ";background-repeat: no-repeat;" + "position: absolute;"), "inner" == b.options.zoomType) {
                        var c = b.$elem.css("border-left-width");
                        b.zoomWindowStyle = "overflow: hidden;margin-left: " + String(c) + ";" + "margin-top: " + String(c) + ";" + "background-position: 0px 0px;" + "width: " + String(b.nzWidth) + "px;" + "height: " + String(b.nzHeight) + "px;float: left;" + "display: none;" + "cursor:" + b.options.cursor + ";" + "px solid " + b.options.borderColour + ";background-repeat: no-repeat;" + "position: absolute;";
                    }
                    "window" == b.options.zoomType && (lensHeight = b.nzHeight < b.options.zoomWindowWidth / b.widthRatio ? b.nzHeight : String(b.options.zoomWindowHeight / b.heightRatio), lensWidth = b.largeWidth < b.options.zoomWindowWidth ? b.nzWidth : b.options.zoomWindowWidth / b.widthRatio, b.lensStyle = "background-position: 0px 0px;width: " + String(b.options.zoomWindowWidth / b.widthRatio) + "px;height: " + String(b.options.zoomWindowHeight / b.heightRatio) + "px;float: right;display: none;" + "overflow: hidden;" + "z-index: 999;" + "-webkit-transform: translateZ(0);" + "opacity:" + b.options.lensOpacity + ";filter: alpha(opacity = " + 100 * b.options.lensOpacity + "); zoom:1;" + "width:" + lensWidth + "px;" + "height:" + lensHeight + "px;" + "background-color:" + b.options.lensColour + ";" + "cursor:" + b.options.cursor + ";" + "border: " + b.options.lensBorderSize + "px" + " solid " + b.options.lensBorderColour + ";background-repeat: no-repeat;position: absolute;"), b.tintStyle = "display: block;position: absolute;background-color: " + b.options.tintColour + ";" + "filter:alpha(opacity=0);" + "opacity: 0;" + "width: " + b.nzWidth + "px;" + "height: " + b.nzHeight + "px;", b.lensRound = "", "lens" == b.options.zoomType && (b.lensStyle = "background-position: 0px 0px;float: left;display: none;border: " + String(b.options.borderSize) + "px solid " + b.options.borderColour + ";" + "width:" + String(b.options.lensSize) + "px;" + "height:" + String(b.options.lensSize) + "px;" + "background-repeat: no-repeat;position: absolute;"), "round" == b.options.lensShape && (b.lensRound = "border-top-left-radius: " + String(b.options.lensSize / 2 + b.options.borderSize) + "px;" + "border-top-right-radius: " + String(b.options.lensSize / 2 + b.options.borderSize) + "px;" + "border-bottom-left-radius: " + String(b.options.lensSize / 2 + b.options.borderSize) + "px;" + "border-bottom-right-radius: " + String(b.options.lensSize / 2 + b.options.borderSize) + "px;"), b.zoomContainer = a('<div class="zoomContainer" style="-webkit-transform: translateZ(0);position:absolute;left:' + b.nzOffset.left + "px;top:" + b.nzOffset.top + "px;height:" + b.nzHeight + "px;width:" + b.nzWidth + 'px;"></div>'), a("body")
                        .append(b.zoomContainer), b.options.containLensZoom && "lens" == b.options.zoomType && b.zoomContainer.css("overflow", "hidden"), "inner" != b.options.zoomType && (b.zoomLens = a("<div class='zoomLens' style='" + b.lensStyle + b.lensRound + "'>&nbsp;</div>")
                        .appendTo(b.zoomContainer)
                        .click(function () {
                            b.$elem.trigger("click");
                        }), b.options.tint && (b.tintContainer = a("<div/>")
                        .addClass("tintContainer"), b.zoomTint = a("<div class='zoomTint' style='" + b.tintStyle + "'></div>"), b.zoomLens.wrap(b.tintContainer), b.zoomTintcss = b.zoomLens.after(b.zoomTint), b.zoomTintImage = a('<img style="position: absolute; left: 0px; top: 0px; max-width: none; width: ' + b.nzWidth + "px; height: " + b.nzHeight + 'px;" src="' + b.imageSrc + '">')
                        .appendTo(b.zoomLens)
                        .click(function () {
                            b.$elem.trigger("click");
                        }))), b.zoomWindow = isNaN(b.options.zoomWindowPosition) ? a("<div style='z-index:999;left:" + b.windowOffsetLeft + "px;top:" + b.windowOffsetTop + "px;" + b.zoomWindowStyle + "' class='zoomWindow'>&nbsp;</div>")
                        .appendTo("body")
                        .click(function () {
                            b.$elem.trigger("click");
                        }) : a("<div style='z-index:999;left:" + b.windowOffsetLeft + "px;top:" + b.windowOffsetTop + "px;" + b.zoomWindowStyle + "' class='zoomWindow'>&nbsp;</div>")
                        .appendTo(b.zoomContainer)
                        .click(function () {
                            b.$elem.trigger("click");
                        }), b.zoomWindowContainer = a("<div/>")
                        .addClass("zoomWindowContainer")
                        .css("width", b.options.zoomWindowWidth), b.zoomWindow.wrap(b.zoomWindowContainer), "lens" == b.options.zoomType && b.zoomLens.css({
                            backgroundImage: "url('" + b.imageSrc + "')"
                        }), "window" == b.options.zoomType && b.zoomWindow.css({
                            backgroundImage: "url('" + b.imageSrc + "')"
                        }), "inner" == b.options.zoomType && b.zoomWindow.css({
                            backgroundImage: "url('" + b.imageSrc + "')"
                        }), b.$elem.bind("touchmove", function (a) {
                            a.preventDefault();
                            var c = a.originalEvent.touches[0] || a.originalEvent.changedTouches[0];
                            b.setPosition(c);
                        }), b.zoomContainer.bind("touchmove", function (a) {
                            "inner" == b.options.zoomType && b.showHideWindow("show"), a.preventDefault();
                            var c = a.originalEvent.touches[0] || a.originalEvent.changedTouches[0];
                            b.setPosition(c);
                        }), b.zoomContainer.bind("touchend", function () {
                            b.showHideWindow("hide"), b.options.showLens && b.showHideLens("hide"), b.options.tint && "inner" != b.options.zoomType && b.showHideTint("hide");
                        }), b.$elem.bind("touchend", function () {
                            b.showHideWindow("hide"), b.options.showLens && b.showHideLens("hide"), b.options.tint && "inner" != b.options.zoomType && b.showHideTint("hide");
                        }), b.options.showLens && (b.zoomLens.bind("touchmove", function (a) {
                            a.preventDefault();
                            var c = a.originalEvent.touches[0] || a.originalEvent.changedTouches[0];
                            b.setPosition(c);
                        }), b.zoomLens.bind("touchend", function () {
                            b.showHideWindow("hide"), b.options.showLens && b.showHideLens("hide"), b.options.tint && "inner" != b.options.zoomType && b.showHideTint("hide");
                        })), b.$elem.bind("mousemove", function (a) {
                            0 == b.overWindow && b.setElements("show"), (b.lastX !== a.clientX || b.lastY !== a.clientY) && (b.setPosition(a), b.currentLoc = a), b.lastX = a.clientX, b.lastY = a.clientY;
                        }), b.zoomContainer.bind("mousemove", function (a) {
                            0 == b.overWindow && b.setElements("show"), (b.lastX !== a.clientX || b.lastY !== a.clientY) && (b.setPosition(a), b.currentLoc = a), b.lastX = a.clientX, b.lastY = a.clientY;
                        }), "inner" != b.options.zoomType && b.zoomLens.bind("mousemove", function (a) {
                            (b.lastX !== a.clientX || b.lastY !== a.clientY) && (b.setPosition(a), b.currentLoc = a), b.lastX = a.clientX, b.lastY = a.clientY;
                        }), b.options.tint && "inner" != b.options.zoomType && b.zoomTint.bind("mousemove", function (a) {
                            (b.lastX !== a.clientX || b.lastY !== a.clientY) && (b.setPosition(a), b.currentLoc = a), b.lastX = a.clientX, b.lastY = a.clientY;
                        }), "inner" == b.options.zoomType && b.zoomWindow.bind("mousemove", function (a) {
                            (b.lastX !== a.clientX || b.lastY !== a.clientY) && (b.setPosition(a), b.currentLoc = a), b.lastX = a.clientX, b.lastY = a.clientY;
                        }), b.zoomContainer.add(b.$elem)
                        .mouseenter(function () {
                            0 == b.overWindow && b.setElements("show");
                        })
                        .mouseleave(function () {
                            b.scrollLock || b.setElements("hide");
                        }), "inner" != b.options.zoomType && b.zoomWindow.mouseenter(function () {
                            b.overWindow = true, b.setElements("hide");
                        })
                        .mouseleave(function () {
                            b.overWindow = false;
                        }), 1 != b.options.zoomLevel, b.minZoomLevel = b.options.minZoomLevel ? b.options.minZoomLevel : 2 * b.options.scrollZoomIncrement, b.options.scrollZoom && b.zoomContainer.add(b.$elem)
                        .bind("mousewheel DOMMouseScroll MozMousePixelScroll", function (c) {
                            b.scrollLock = true, clearTimeout(a.data(this, "timer")), a.data(this, "timer", setTimeout(function () {
                                b.scrollLock = false;
                            }, 250));
                            var d = c.originalEvent.wheelDelta || -1 * c.originalEvent.detail;
                            return c.stopImmediatePropagation(), c.stopPropagation(), c.preventDefault(), d / 120 > 0 ? b.currentZoomLevel >= b.minZoomLevel && b.changeZoomLevel(b.currentZoomLevel - b.options.scrollZoomIncrement) : b.options.maxZoomLevel ? b.currentZoomLevel <= b.options.maxZoomLevel && b.changeZoomLevel(parseFloat(b.currentZoomLevel) + b.options.scrollZoomIncrement) : b.changeZoomLevel(parseFloat(b.currentZoomLevel) + b.options.scrollZoomIncrement), false;
                        });
                },
                setElements: function (a) {
                    var b = this;
                    return b.options.zoomEnabled ? ("show" == a && b.isWindowSet && ("inner" == b.options.zoomType && b.showHideWindow("show"), "window" == b.options.zoomType && b.showHideWindow("show"), b.options.showLens && b.showHideLens("show"), b.options.tint && "inner" != b.options.zoomType && b.showHideTint("show")), "hide" == a && ("window" == b.options.zoomType && b.showHideWindow("hide"), b.options.tint || b.showHideWindow("hide"), b.options.showLens && b.showHideLens("hide"), b.options.tint && b.showHideTint("hide")), void 0) : false;
                },
                setPosition: function (a) {
                    var b = this;
                    return b.options.zoomEnabled ? (b.nzHeight = b.$elem.height(), b.nzWidth = b.$elem.width(), b.nzOffset = b.$elem.offset(), b.options.tint && "inner" != b.options.zoomType && (b.zoomTint.css({
                        top: 0
                    }), b.zoomTint.css({
                        left: 0
                    })), b.options.responsive && !b.options.scrollZoom && b.options.showLens && (lensHeight = b.nzHeight < b.options.zoomWindowWidth / b.widthRatio ? b.nzHeight : String(b.options.zoomWindowHeight / b.heightRatio), lensWidth = b.largeWidth < b.options.zoomWindowWidth ? b.nzWidth : b.options.zoomWindowWidth / b.widthRatio, b.widthRatio = b.largeWidth / b.nzWidth, b.heightRatio = b.largeHeight / b.nzHeight, "lens" != b.options.zoomType && (lensHeight = b.nzHeight < b.options.zoomWindowWidth / b.widthRatio ? b.nzHeight : String(b.options.zoomWindowHeight / b.heightRatio), lensWidth = b.options.zoomWindowWidth < b.options.zoomWindowWidth ? b.nzWidth : b.options.zoomWindowWidth / b.widthRatio, b.zoomLens.css("width", lensWidth), b.zoomLens.css("height", lensHeight), b.options.tint && (b.zoomTintImage.css("width", b.nzWidth), b.zoomTintImage.css("height", b.nzHeight))), "lens" == b.options.zoomType && b.zoomLens.css({
                        width: String(b.options.lensSize) + "px",
                        height: String(b.options.lensSize) + "px"
                    })), b.zoomContainer.css({
                        top: b.nzOffset.top
                    }), b.zoomContainer.css({
                        left: b.nzOffset.left
                    }), b.mouseLeft = parseInt(a.pageX - b.nzOffset.left), b.mouseTop = parseInt(a.pageY - b.nzOffset.top), "window" == b.options.zoomType && (b.Etoppos = b.mouseTop < b.zoomLens.height() / 2, b.Eboppos = b.mouseTop > b.nzHeight - b.zoomLens.height() / 2 - 2 * b.options.lensBorderSize, b.Eloppos = b.mouseLeft < 0 + b.zoomLens.width() / 2, b.Eroppos = b.mouseLeft > b.nzWidth - b.zoomLens.width() / 2 - 2 * b.options.lensBorderSize), "inner" == b.options.zoomType && (b.Etoppos = b.mouseTop < b.nzHeight / 2 / b.heightRatio, b.Eboppos = b.mouseTop > b.nzHeight - b.nzHeight / 2 / b.heightRatio, b.Eloppos = b.mouseLeft < 0 + b.nzWidth / 2 / b.widthRatio, b.Eroppos = b.mouseLeft > b.nzWidth - b.nzWidth / 2 / b.widthRatio - 2 * b.options.lensBorderSize), b.mouseLeft <= 0 || b.mouseTop < 0 || b.mouseLeft > b.nzWidth || b.mouseTop > b.nzHeight ? (b.setElements("hide"), void 0) : (b.options.showLens && (b.lensLeftPos = String(b.mouseLeft - b.zoomLens.width() / 2), b.lensTopPos = String(b.mouseTop - b.zoomLens.height() / 2)), b.Etoppos && (b.lensTopPos = 0), b.Eloppos && (b.windowLeftPos = 0, b.lensLeftPos = 0, b.tintpos = 0), "window" == b.options.zoomType && (b.Eboppos && (b.lensTopPos = Math.max(b.nzHeight - b.zoomLens.height() - 2 * b.options.lensBorderSize, 0)), b.Eroppos && (b.lensLeftPos = b.nzWidth - b.zoomLens.width() - 2 * b.options.lensBorderSize)), "inner" == b.options.zoomType && (b.Eboppos && (b.lensTopPos = Math.max(b.nzHeight - 2 * b.options.lensBorderSize, 0)), b.Eroppos && (b.lensLeftPos = b.nzWidth - b.nzWidth - 2 * b.options.lensBorderSize)), "lens" == b.options.zoomType && (b.windowLeftPos = String(-1 * ((a.pageX - b.nzOffset.left) * b.widthRatio - b.zoomLens.width() / 2)), b.windowTopPos = String(-1 * ((a.pageY - b.nzOffset.top) * b.heightRatio - b.zoomLens.height() / 2)), b.zoomLens.css({
                        backgroundPosition: b.windowLeftPos + "px " + b.windowTopPos + "px"
                    }), b.changeBgSize && (b.nzHeight > b.nzWidth ? ("lens" == b.options.zoomType && b.zoomLens.css({
                        "background-size": b.largeWidth / b.newvalueheight + "px " + b.largeHeight / b.newvalueheight + "px"
                    }), b.zoomWindow.css({
                        "background-size": b.largeWidth / b.newvalueheight + "px " + b.largeHeight / b.newvalueheight + "px"
                    })) : ("lens" == b.options.zoomType && b.zoomLens.css({
                        "background-size": b.largeWidth / b.newvaluewidth + "px " + b.largeHeight / b.newvaluewidth + "px"
                    }), b.zoomWindow.css({
                        "background-size": b.largeWidth / b.newvaluewidth + "px " + b.largeHeight / b.newvaluewidth + "px"
                    })), b.changeBgSize = false), b.setWindowPostition(a)), b.options.tint && "inner" != b.options.zoomType && b.setTintPosition(a), "window" == b.options.zoomType && b.setWindowPostition(a), "inner" == b.options.zoomType && b.setWindowPostition(a), b.options.showLens && (b.fullwidth && "lens" != b.options.zoomType && (b.lensLeftPos = 0), b.zoomLens.css({
                        left: b.lensLeftPos + "px",
                        top: b.lensTopPos + "px"
                    })), void 0)) : false;
                },
                showHideWindow: function (a) {
                    var b = this;
                    "show" == a && (b.isWindowActive || (b.options.zoomWindowFadeIn ? b.zoomWindow.stop(true, true, false)
                        .fadeIn(b.options.zoomWindowFadeIn) : b.zoomWindow.show(), b.isWindowActive = true)), "hide" == a && b.isWindowActive && (b.options.zoomWindowFadeOut ? b.zoomWindow.stop(true, true)
                        .fadeOut(b.options.zoomWindowFadeOut) : b.zoomWindow.hide(), b.isWindowActive = false);
                },
                showHideLens: function (a) {
                    var b = this;
                    "show" == a && (b.isLensActive || (b.options.lensFadeIn ? b.zoomLens.stop(true, true, false)
                        .fadeIn(b.options.lensFadeIn) : b.zoomLens.show(), b.isLensActive = true)), "hide" == a && b.isLensActive && (b.options.lensFadeOut ? b.zoomLens.stop(true, true)
                        .fadeOut(b.options.lensFadeOut) : b.zoomLens.hide(), b.isLensActive = false);
                },
                showHideTint: function (a) {
                    var b = this;
                    "show" == a && (b.isTintActive || (b.options.zoomTintFadeIn ? b.zoomTint.css({
                        opacity: b.options.tintOpacity
                    })
                        .animate()
                        .stop(true, true)
                        .fadeIn("slow") : (b.zoomTint.css({
                            opacity: b.options.tintOpacity
                        })
                            .animate(), b.zoomTint.show()), b.isTintActive = true)), "hide" == a && b.isTintActive && (b.options.zoomTintFadeOut ? b.zoomTint.stop(true, true)
                        .fadeOut(b.options.zoomTintFadeOut) : b.zoomTint.hide(), b.isTintActive = false);
                },
                setLensPostition: function () { },
                setWindowPostition: function (b) {
                    var c = this;
                    if (isNaN(c.options.zoomWindowPosition)) c.externalContainer = a("#" + c.options.zoomWindowPosition), c.externalContainerWidth = c.externalContainer.width(), c.externalContainerHeight = c.externalContainer.height(), c.externalContainerOffset = c.externalContainer.offset(), c.windowOffsetTop = c.externalContainerOffset.top, c.windowOffsetLeft = c.externalContainerOffset.left;
                    else
                        switch (c.options.zoomWindowPosition) {
                            case 1:
                                c.windowOffsetTop = c.options.zoomWindowOffety, c.windowOffsetLeft = +c.nzWidth;
                                break;
                            case 2:
                                c.options.zoomWindowHeight > c.nzHeight && (c.windowOffsetTop = -1 * (c.options.zoomWindowHeight / 2 - c.nzHeight / 2), c.windowOffsetLeft = c.nzWidth);
                                break;
                            case 3:
                                c.windowOffsetTop = c.nzHeight - c.zoomWindow.height() - 2 * c.options.borderSize, c.windowOffsetLeft = c.nzWidth;
                                break;
                            case 4:
                                c.windowOffsetTop = c.nzHeight, c.windowOffsetLeft = c.nzWidth;
                                break;
                            case 5:
                                c.windowOffsetTop = c.nzHeight, c.windowOffsetLeft = c.nzWidth - c.zoomWindow.width() - 2 * c.options.borderSize;
                                break;
                            case 6:
                                c.options.zoomWindowHeight > c.nzHeight && (c.windowOffsetTop = c.nzHeight, c.windowOffsetLeft = -1 * (c.options.zoomWindowWidth / 2 - c.nzWidth / 2 + 2 * c.options.borderSize));
                                break;
                            case 7:
                                c.windowOffsetTop = c.nzHeight, c.windowOffsetLeft = 0;
                                break;
                            case 8:
                                c.windowOffsetTop = c.nzHeight, c.windowOffsetLeft = -1 * (c.zoomWindow.width() + 2 * c.options.borderSize);
                                break;
                            case 9:
                                c.windowOffsetTop = c.nzHeight - c.zoomWindow.height() - 2 * c.options.borderSize, c.windowOffsetLeft = -1 * (c.zoomWindow.width() + 2 * c.options.borderSize);
                                break;
                            case 10:
                                c.options.zoomWindowHeight > c.nzHeight && (c.windowOffsetTop = -1 * (c.options.zoomWindowHeight / 2 - c.nzHeight / 2), c.windowOffsetLeft = -1 * (c.zoomWindow.width() + 2 * c.options.borderSize));
                                break;
                            case 11:
                                c.windowOffsetTop = c.options.zoomWindowOffety, c.windowOffsetLeft = -1 * (c.zoomWindow.width() + 2 * c.options.borderSize);
                                break;
                            case 12:
                                c.windowOffsetTop = -1 * (c.zoomWindow.height() + 2 * c.options.borderSize), c.windowOffsetLeft = -1 * (c.zoomWindow.width() + 2 * c.options.borderSize);
                                break;
                            case 13:
                                c.windowOffsetTop = -1 * (c.zoomWindow.height() + 2 * c.options.borderSize), c.windowOffsetLeft = 0;
                                break;
                            case 14:
                                c.options.zoomWindowHeight > c.nzHeight && (c.windowOffsetTop = -1 * (c.zoomWindow.height() + 2 * c.options.borderSize), c.windowOffsetLeft = -1 * (c.options.zoomWindowWidth / 2 - c.nzWidth / 2 + 2 * c.options.borderSize));
                                break;
                            case 15:
                                c.windowOffsetTop = -1 * (c.zoomWindow.height() + 2 * c.options.borderSize), c.windowOffsetLeft = c.nzWidth - c.zoomWindow.width() - 2 * c.options.borderSize;
                                break;
                            case 16:
                                c.windowOffsetTop = -1 * (c.zoomWindow.height() + 2 * c.options.borderSize), c.windowOffsetLeft = c.nzWidth;
                                break;
                            default:
                                c.windowOffsetTop = c.options.zoomWindowOffety, c.windowOffsetLeft = c.nzWidth;
                        }
                    c.isWindowSet = true, c.windowOffsetTop = c.windowOffsetTop + c.options.zoomWindowOffety, c.windowOffsetLeft = c.windowOffsetLeft + c.options.zoomWindowOffetx, c.zoomWindow.css({
                        top: c.windowOffsetTop
                    }), c.zoomWindow.css({
                        left: c.windowOffsetLeft
                    }), "inner" == c.options.zoomType && (c.zoomWindow.css({
                        top: 0
                    }), c.zoomWindow.css({
                        left: 0
                    })), c.windowLeftPos = String(-1 * ((b.pageX - c.nzOffset.left) * c.widthRatio - c.zoomWindow.width() / 2)), c.windowTopPos = String(-1 * ((b.pageY - c.nzOffset.top) * c.heightRatio - c.zoomWindow.height() / 2)), c.Etoppos && (c.windowTopPos = 0), c.Eloppos && (c.windowLeftPos = 0), c.Eboppos && (c.windowTopPos = -1 * (c.largeHeight / c.currentZoomLevel - c.zoomWindow.height())), c.Eroppos && (c.windowLeftPos = -1 * (c.largeWidth / c.currentZoomLevel - c.zoomWindow.width())), c.fullheight && (c.windowTopPos = 0), c.fullwidth && (c.windowLeftPos = 0), ("window" == c.options.zoomType || "inner" == c.options.zoomType) && (1 == c.zoomLock && (c.widthRatio <= 1 && (c.windowLeftPos = 0), c.heightRatio <= 1 && (c.windowTopPos = 0)), c.largeHeight < c.options.zoomWindowHeight && (c.windowTopPos = 0), c.largeWidth < c.options.zoomWindowWidth && (c.windowLeftPos = 0), c.options.easing ? (c.xp || (c.xp = 0), c.yp || (c.yp = 0), c.loop || (c.loop = setInterval(function () {
                        c.xp += (c.windowLeftPos - c.xp) / c.options.easingAmount, c.yp += (c.windowTopPos - c.yp) / c.options.easingAmount, c.scrollingLock ? (clearInterval(c.loop), c.xp = c.windowLeftPos, c.yp = c.windowTopPos, c.xp = -1 * ((b.pageX - c.nzOffset.left) * c.widthRatio - c.zoomWindow.width() / 2), c.yp = -1 * ((b.pageY - c.nzOffset.top) * c.heightRatio - c.zoomWindow.height() / 2), c.changeBgSize && (c.nzHeight > c.nzWidth ? ("lens" == c.options.zoomType && c.zoomLens.css({
                            "background-size": c.largeWidth / c.newvalueheight + "px " + c.largeHeight / c.newvalueheight + "px"
                        }), c.zoomWindow.css({
                            "background-size": c.largeWidth / c.newvalueheight + "px " + c.largeHeight / c.newvalueheight + "px"
                        })) : ("lens" != c.options.zoomType && c.zoomLens.css({
                            "background-size": c.largeWidth / c.newvaluewidth + "px " + c.largeHeight / c.newvalueheight + "px"
                        }), c.zoomWindow.css({
                            "background-size": c.largeWidth / c.newvaluewidth + "px " + c.largeHeight / c.newvaluewidth + "px"
                        })), c.changeBgSize = false), c.zoomWindow.css({
                            backgroundPosition: c.windowLeftPos + "px " + c.windowTopPos + "px"
                        }), c.scrollingLock = false, c.loop = false) : (c.changeBgSize && (c.nzHeight > c.nzWidth ? ("lens" == c.options.zoomType && c.zoomLens.css({
                            "background-size": c.largeWidth / c.newvalueheight + "px " + c.largeHeight / c.newvalueheight + "px"
                        }), c.zoomWindow.css({
                            "background-size": c.largeWidth / c.newvalueheight + "px " + c.largeHeight / c.newvalueheight + "px"
                        })) : ("lens" != c.options.zoomType && c.zoomLens.css({
                            "background-size": c.largeWidth / c.newvaluewidth + "px " + c.largeHeight / c.newvaluewidth + "px"
                        }), c.zoomWindow.css({
                            "background-size": c.largeWidth / c.newvaluewidth + "px " + c.largeHeight / c.newvaluewidth + "px"
                        })), c.changeBgSize = false), c.zoomWindow.css({
                            backgroundPosition: c.xp + "px " + c.yp + "px"
                        }));
                    }, 16))) : (c.changeBgSize && (c.nzHeight > c.nzWidth ? ("lens" == c.options.zoomType && c.zoomLens.css({
                        "background-size": c.largeWidth / c.newvalueheight + "px " + c.largeHeight / c.newvalueheight + "px"
                    }), c.zoomWindow.css({
                        "background-size": c.largeWidth / c.newvalueheight + "px " + c.largeHeight / c.newvalueheight + "px"
                    })) : ("lens" == c.options.zoomType && c.zoomLens.css({
                        "background-size": c.largeWidth / c.newvaluewidth + "px " + c.largeHeight / c.newvaluewidth + "px"
                    }), c.largeHeight / c.newvaluewidth < c.options.zoomWindowHeight ? c.zoomWindow.css({
                        "background-size": c.largeWidth / c.newvaluewidth + "px " + c.largeHeight / c.newvaluewidth + "px"
                    }) : c.zoomWindow.css({
                        "background-size": c.largeWidth / c.newvalueheight + "px " + c.largeHeight / c.newvalueheight + "px"
                    })), c.changeBgSize = false), c.zoomWindow.css({
                        backgroundPosition: c.windowLeftPos + "px " + c.windowTopPos + "px"
                    })));
                },
                setTintPosition: function (a) {
                    var b = this;
                    b.nzOffset = b.$elem.offset(), b.tintpos = String(-1 * (a.pageX - b.nzOffset.left - b.zoomLens.width() / 2)), b.tintposy = String(-1 * (a.pageY - b.nzOffset.top - b.zoomLens.height() / 2)), b.Etoppos && (b.tintposy = 0), b.Eloppos && (b.tintpos = 0), b.Eboppos && (b.tintposy = -1 * (b.nzHeight - b.zoomLens.height() - 2 * b.options.lensBorderSize)), b.Eroppos && (b.tintpos = -1 * (b.nzWidth - b.zoomLens.width() - 2 * b.options.lensBorderSize)), b.options.tint && (b.fullheight && (b.tintposy = 0), b.fullwidth && (b.tintpos = 0), b.zoomTintImage.css({
                        left: b.tintpos + "px"
                    }), b.zoomTintImage.css({
                        top: b.tintposy + "px"
                    }));
                },
                swaptheimage: function (b, c) {
                    var d = this, e = new Image;
                    d.options.loadingIcon && a.scafancybox.showLoading(), d.options.onImageSwap(d.$elem), e.onload = function () {
                        d.largeWidth = e.width, d.largeHeight = e.height, d.zoomImage = c, d.zoomWindow.css({
                            "background-size": d.largeWidth + "px " + d.largeHeight + "px"
                        }), d.zoomWindow.css({
                            "background-size": d.largeWidth + "px " + d.largeHeight + "px"
                        }), d.swapAction(b, c);
                    }, e.src = c;
                },
                swapAction: function (b, c) {
                    var d = this, e = new Image;
                    if (e.onload = function () {
                        d.nzHeight = e.height, d.nzWidth = e.width, d.options.onImageSwapComplete(d.$elem), d.doneCallback();
                    }, e.src = b, d.currentZoomLevel = d.options.zoomLevel, d.options.maxZoomLevel = false, "lens" == d.options.zoomType && d.zoomLens.css({
                        backgroundImage: "url('" + c + "')"
                    }), "window" == d.options.zoomType && d.zoomWindow.css({
                        backgroundImage: "url('" + c + "')"
                    }), "inner" == d.options.zoomType && d.zoomWindow.css({
                        backgroundImage: "url('" + c + "')"
                    }), d.currentImage = c, d.options.imageCrossfade) {
                        var f = d.$elem, g = f.clone();
                        if (d.$elem.attr("src", b), d.$elem.after(g), g.stop(true)
                            .fadeOut(d.options.imageCrossfade, function () {
                                a(this)
                                    .remove();
                        }), d.$elem.width("auto")
                            .removeAttr("width"), d.$elem.height("auto")
                            .removeAttr("height"), f.fadeIn(d.options.imageCrossfade), d.options.tint && "inner" != d.options.zoomType) {
                            var h = d.zoomTintImage, i = h.clone();
                            d.zoomTintImage.attr("src", c), d.zoomTintImage.after(i), i.stop(true)
                                .fadeOut(d.options.imageCrossfade, function () {
                                    a(this)
                                        .remove();
                                }), h.fadeIn(d.options.imageCrossfade), d.zoomTint.css({
                                    height: d.$elem.height()
                                }), d.zoomTint.css({
                                    width: d.$elem.width()
                                });
                        }
                        d.zoomContainer.css("height", d.$elem.height()), d.zoomContainer.css("width", d.$elem.width()), "inner" == d.options.zoomType && (d.options.constrainType || (d.zoomWrap.parent()
                            .css("height", d.$elem.height()), d.zoomWrap.parent()
                            .css("width", d.$elem.width()), d.zoomWindow.css("height", d.$elem.height()), d.zoomWindow.css("width", d.$elem.width()))), d.options.imageCrossfade && (d.zoomWrap.css("height", d.$elem.height()), d.zoomWrap.css("width", d.$elem.width()));
                    } else
                        d.$elem.attr("src", b), d.options.tint && (d.zoomTintImage.attr("src", c), d.zoomTintImage.attr("height", d.$elem.height()), d.zoomTintImage.css({
                            height: d.$elem.height()
                        }), d.zoomTint.css({
                            height: d.$elem.height()
                        })), d.zoomContainer.css("height", d.$elem.height()), d.zoomContainer.css("width", d.$elem.width()), d.options.imageCrossfade && (d.zoomWrap.css("height", d.$elem.height()), d.zoomWrap.css("width", d.$elem.width()));
                    d.options.constrainType && ("height" == d.options.constrainType && (d.zoomContainer.css("height", d.options.constrainSize), d.zoomContainer.css("width", "auto"), d.options.imageCrossfade ? (d.zoomWrap.css("height", d.options.constrainSize), d.zoomWrap.css("width", "auto"), d.constwidth = d.zoomWrap.width()) : (d.$elem.css("height", d.options.constrainSize), d.$elem.css("width", "auto"), d.constwidth = d.$elem.width()), "inner" == d.options.zoomType && (d.zoomWrap.parent()
                        .css("height", d.options.constrainSize), d.zoomWrap.parent()
                        .css("width", d.constwidth), d.zoomWindow.css("height", d.options.constrainSize), d.zoomWindow.css("width", d.constwidth)), d.options.tint && (d.tintContainer.css("height", d.options.constrainSize), d.tintContainer.css("width", d.constwidth), d.zoomTint.css("height", d.options.constrainSize), d.zoomTint.css("width", d.constwidth), d.zoomTintImage.css("height", d.options.constrainSize), d.zoomTintImage.css("width", d.constwidth))), "width" == d.options.constrainType && (d.zoomContainer.css("height", "auto"), d.zoomContainer.css("width", d.options.constrainSize), d.options.imageCrossfade ? (d.zoomWrap.css("height", "auto"), d.zoomWrap.css("width", d.options.constrainSize), d.constheight = d.zoomWrap.height()) : (d.$elem.css("height", "auto"), d.$elem.css("width", d.options.constrainSize), d.constheight = d.$elem.height()), "inner" == d.options.zoomType && (d.zoomWrap.parent()
                        .css("height", d.constheight), d.zoomWrap.parent()
                        .css("width", d.options.constrainSize), d.zoomWindow.css("height", d.constheight), d.zoomWindow.css("width", d.options.constrainSize)), d.options.tint && (d.tintContainer.css("height", d.constheight), d.tintContainer.css("width", d.options.constrainSize), d.zoomTint.css("height", d.constheight), d.zoomTint.css("width", d.options.constrainSize), d.zoomTintImage.css("height", d.constheight), d.zoomTintImage.css("width", d.options.constrainSize))));
                },
                doneCallback: function () {
                    var b = this;
                    a.scafancybox.hideLoading(), b.nzOffset = b.$elem.offset(), b.nzWidth = b.$elem.width(), b.nzHeight = b.$elem.height(), a.scafancybox.scaupdate(), b.currentZoomLevel = b.options.zoomLevel, b.widthRatio = b.largeWidth / b.nzWidth, b.heightRatio = b.largeHeight / b.nzHeight, "window" == b.options.zoomType && (lensHeight = b.nzHeight < b.options.zoomWindowWidth / b.widthRatio ? b.nzHeight : String(b.options.zoomWindowHeight / b.heightRatio), lensWidth = b.options.zoomWindowWidth < b.options.zoomWindowWidth ? b.nzWidth : b.options.zoomWindowWidth / b.widthRatio, b.zoomLens && (b.zoomLens.css("width", lensWidth), b.zoomLens.css("height", lensHeight)));
                },
                getCurrentImage: function () {
                    var a = this;
                    return a.zoomImage;
                },
                getGalleryList: function () {
                    var b = this;
                    return b.gallerylist = [], b.options.gallery ? a("#" + b.options.gallery + " a")
                        .each(function () {
                            var c = "";
                            a(this)
                                .data("zoom-image") ? c = a(this)
                                .data("zoom-image") : a(this)
                                .data("image") && (c = a(this)
                                    .data("image")), c == b.zoomImage ? b.gallerylist.unshift({
                                        href: "" + c,
                                        title: a(this)
                                            .find("img")
                                            .attr("title")
                                    }) : b.gallerylist.push({
                                        href: "" + c,
                                        title: a(this)
                                            .find("img")
                                            .attr("title")
                                    });
                        }) : b.gallerylist.push({
                            href: "" + b.zoomImage,
                            title: a(this)
                                .find("img")
                                .attr("title")
                        }), b.gallerylist;
                },
                changeZoomLevel: function (a) {
                    var b = this;
                    b.scrollingLock = true, b.newvalue = parseFloat(a)
                        .toFixed(2), newvalue = parseFloat(a)
                        .toFixed(2), maxheightnewvalue = b.largeHeight / (b.options.zoomWindowHeight / b.nzHeight * b.nzHeight), maxwidthtnewvalue = b.largeWidth / (b.options.zoomWindowWidth / b.nzWidth * b.nzWidth), "inner" != b.options.zoomType && (newvalue >= maxheightnewvalue ? (b.heightRatio = b.largeHeight / maxheightnewvalue / b.nzHeight, b.newvalueheight = maxheightnewvalue, b.fullheight = true) : (b.heightRatio = b.largeHeight / newvalue / b.nzHeight, b.newvalueheight = newvalue, b.fullheight = false), newvalue >= maxwidthtnewvalue ? (b.widthRatio = b.largeWidth / maxwidthtnewvalue / b.nzWidth, b.newvaluewidth = maxwidthtnewvalue, b.fullwidth = true) : (b.widthRatio = b.largeWidth / newvalue / b.nzWidth, b.newvaluewidth = newvalue, b.fullwidth = false), "lens" == b.options.zoomType && (newvalue >= maxheightnewvalue ? (b.fullwidth = true, b.newvaluewidth = maxheightnewvalue) : (b.widthRatio = b.largeWidth / newvalue / b.nzWidth, b.newvaluewidth = newvalue, b.fullwidth = false))), "inner" == b.options.zoomType && (maxheightnewvalue = parseFloat(b.largeHeight / b.nzHeight)
                        .toFixed(2), maxwidthtnewvalue = parseFloat(b.largeWidth / b.nzWidth)
                        .toFixed(2), newvalue > maxheightnewvalue && (newvalue = maxheightnewvalue), newvalue > maxwidthtnewvalue && (newvalue = maxwidthtnewvalue), newvalue >= maxheightnewvalue ? (b.heightRatio = b.largeHeight / newvalue / b.nzHeight, b.newvalueheight = newvalue > maxheightnewvalue ? maxheightnewvalue : newvalue, b.fullheight = true) : (b.heightRatio = b.largeHeight / newvalue / b.nzHeight, b.newvalueheight = newvalue > maxheightnewvalue ? maxheightnewvalue : newvalue, b.fullheight = false), newvalue >= maxwidthtnewvalue ? (b.widthRatio = b.largeWidth / newvalue / b.nzWidth, b.newvaluewidth = newvalue > maxwidthtnewvalue ? maxwidthtnewvalue : newvalue, b.fullwidth = true) : (b.widthRatio = b.largeWidth / newvalue / b.nzWidth, b.newvaluewidth = newvalue, b.fullwidth = false)), scrcontinue = false, "inner" == b.options.zoomType && (b.nzWidth > b.nzHeight && (b.newvaluewidth <= maxwidthtnewvalue ? scrcontinue = true : (scrcontinue = false, b.fullheight = true, b.fullwidth = true)), b.nzHeight > b.nzWidth && (b.newvaluewidth <= maxwidthtnewvalue ? scrcontinue = true : (scrcontinue = false, b.fullheight = true, b.fullwidth = true))), "inner" != b.options.zoomType && (scrcontinue = true), scrcontinue && (b.zoomLock = 0, b.changeZoom = true, b.options.zoomWindowHeight / b.heightRatio <= b.nzHeight && (b.currentZoomLevel = b.newvalueheight, "lens" != b.options.zoomType && "inner" != b.options.zoomType && (b.changeBgSize = true, b.zoomLens.css({
                            height: String(b.options.zoomWindowHeight / b.heightRatio) + "px"
                        })), ("lens" == b.options.zoomType || "inner" == b.options.zoomType) && (b.changeBgSize = true)), b.options.zoomWindowWidth / b.widthRatio <= b.nzWidth && ("inner" != b.options.zoomType && b.newvaluewidth > b.newvalueheight && (b.currentZoomLevel = b.newvaluewidth), "lens" != b.options.zoomType && "inner" != b.options.zoomType && (b.changeBgSize = true, b.zoomLens.css({
                            width: String(b.options.zoomWindowWidth / b.widthRatio) + "px"
                        })), ("lens" == b.options.zoomType || "inner" == b.options.zoomType) && (b.changeBgSize = true)), "inner" == b.options.zoomType && (b.changeBgSize = true, b.nzWidth > b.nzHeight && (b.currentZoomLevel = b.newvaluewidth), b.nzHeight > b.nzWidth && (b.currentZoomLevel = b.newvaluewidth))), b.setPosition(b.currentLoc);
                },
                closeAll: function () {
                    self.zoomWindow && self.zoomWindow.hide(), self.zoomLens && self.zoomLens.hide(), self.zoomTint && self.zoomTint.hide();
                },
                changeState: function (a) {
                    var b = this;
                    "enable" == a && (b.options.zoomEnabled = true), "disable" == a && (b.options.zoomEnabled = false);
                }
            };
            a.fn.elevateZoom = function (b) {
                return this.each(function () {
                    var c = Object.create(e);
                    c.init(b, this), a.data(this, "elevateZoom", c);
                });
            }, a.fn.elevateZoom.options = {
                zoomActivation: "hover",
                zoomEnabled: true,
                preloading: 1,
                zoomLevel: 1,
                scrollZoom: false,
                scrollZoomIncrement: .1,
                minZoomLevel: false,
                maxZoomLevel: false,
                easing: false,
                easingAmount: 12,
                lensSize: 200,
                zoomWindowWidth: 400,
                zoomWindowHeight: 400,
                zoomWindowOffetx: 0,
                zoomWindowOffety: 0,
                zoomWindowPosition: 1,
                zoomWindowBgColour: "#fff",
                lensFadeIn: false,
                lensFadeOut: false,
                debug: false,
                zoomWindowFadeIn: false,
                zoomWindowFadeOut: false,
                zoomWindowAlwaysShow: false,
                zoomTintFadeIn: false,
                zoomTintFadeOut: false,
                borderSize: 4,
                showLens: true,
                borderColour: "#888",
                lensBorderSize: 1,
                lensBorderColour: "#000",
                lensShape: "square",
                zoomType: "window",
                containLensZoom: false,
                lensColour: "white",
                lensOpacity: .4,
                lenszoom: false,
                tint: false,
                tintColour: "#333",
                tintOpacity: .4,
                gallery: false,
                galleryActiveClass: "zoomGalleryActive",
                imageCrossfade: false,
                constrainType: false,
                constrainSize: false,
                loadingIcon: "data:image/gif;base64,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",
                cursor: "default",
                responsive: true,
                onComplete: a.noop,
                onZoomedImageLoaded: function () { },
                onImageSwap: a.noop,
                onImageSwapComplete: a.noop
            };
        }(a, b, c);
    }


    function scaqvFancybox(a, b, c, d) {
        "use strict";
        var e = c("html"),
            f = c(a),
            g = c(b),
            h = c.scafancybox = function () {
                h.open.apply(this, arguments);
            },
            i = navigator.userAgent.match(/msie/i),
            j = null,
            k = b.createTouch !== d,
            l = function (a) {
                return a && a.hasOwnProperty && a instanceof c;
            },
            m = function (a) {
                return a && "string" === c.type(a);
            },
            n = function (a) {
                return m(a) && a.indexOf("%") > 0;
            },
            o = function (a) {
                return a && !(a.style.overflow && "hidden" === a.style.overflow) && (a.clientWidth && a.scrollWidth > a.clientWidth || a.clientHeight && a.scrollHeight > a.clientHeight);
            },
            p = function (a, b) {
                var c = parseInt(a, 10) || 0;
                return b && n(a) && (c = h.getViewport()[b] / 100 * c), Math.ceil(c);
            },
            q = function (a, b) {
                return p(a, b) + "px";
            };
        c.extend(h, {
            version: "2.1.5",
            defaults: {
                padding: 15,
                margin: 20,
                width: 800,
                height: 600,
                minWidth: 100,
                minHeight: 100,
                maxWidth: 9999,
                maxHeight: 9999,
                pixelRatio: 2,
                autoSize: true,
                autoHeight: false,
                autoWidth: false,
                autoResize: true,
                autoCenter: !k,
                fitToView: true,
                aspectRatio: false,
                topRatio: .5,
                leftRatio: .5,
                scrolling: "auto",
                wrapCSS: "",
                arrows: true,
                closeBtn: true,
                closeClick: false,
                nextClick: false,
                mouseWheel: true,
                autoPlay: false,
                playSpeed: 3e3,
                preload: 3,
                modal: false,
                loop: true,
                ajax: {
                    dataType: "html",
                    headers: {
                        "X-biz-fancybox": true
                    }
                },
                iframe: {
                    scrolling: "auto",
                    preload: true
                },
                swf: {
                    wmode: "transparent",
                    allowfullscreen: "true",
                    allowscriptaccess: "always"
                },
                keys: {
                    next: {
                        13: "left",
                        34: "up",
                        39: "left",
                        40: "up"
                    },
                    prev: {
                        8: "right",
                        33: "down",
                        37: "right",
                        38: "down"
                    },
                    close: [27],
                    play: [32],
                    toggle: [70]
                },
                direction: {
                    next: "left",
                    prev: "right"
                },
                scrollOutside: true,
                index: 0,
                type: null,
                href: null,
                content: null,
                title: null,
                tpl: {
                    wrap: '<div class="biz-fancybox-wrap" tabIndex="-1"><div class="biz-fancybox-skin"><div class="biz-fancybox-outer"><div class="biz-fancybox-inner"></div></div></div></div>',
                    image: '<img class="biz-fancybox-image" src="{href}" alt="" />',
                    iframe: '<iframe id="biz-fancybox-frame{rnd}"name="biz-fancybox-frame{rnd}"class="biz-fancybox-iframe"frameborder="0"vspace="0"hspace="0"webkitAllowFullScreen mozallowfullscreen allowFullScreen' + (i ? 'allowtransparency="true"' : "") + "></iframe>",
                    error: '<p class="biz-fancybox-error">The requested content cannot be loaded.<br/>Please try again later.</p>',
                    closeBtn: '<a title="Close" class="biz-fancybox-item biz-fancybox-close" href="javascript:;"></a>',
                    next: '<a title="Next"class="biz-fancybox-nav biz-fancybox-next"href="javascript:;"><span></span></a>',
                    prev: '<a title="Previous"class="biz-fancybox-nav biz-fancybox-prev"href="javascript:;"><span></span></a>'
                },
                openEffect: "fade",
                openSpeed: 250,
                openEasing: "swing",
                openOpacity: true,
                openMethod: "zoomIn",
                closeEffect: "fade",
                closeSpeed: 250,
                closeEasing: "swing",
                closeOpacity: true,
                closeMethod: "zoomOut",
                nextEffect: "elastic",
                nextSpeed: 250,
                nextEasing: "swing",
                nextMethod: "changeIn",
                prevEffect: "elastic",
                prevSpeed: 250,
                prevEasing: "swing",
                prevMethod: "changeOut",
                helpers: {
                    overlay: true,
                    title: true
                },
                onCancel: c.noop,
                beforeLoad: c.noop,
                afterLoad: c.noop,
                beforeShow: c.noop,
                afterShow: c.noop,
                beforeChange: c.noop,
                beforeClose: c.noop,
                afterClose: c.noop
            },
            group: {},
            opts: {},
            previous: null,
            coming: null,
            current: null,
            isActive: false,
            isOpen: false,
            isOpened: false,
            wrap: null,
            skin: null,
            outer: null,
            inner: null,
            player: {
                timer: null,
                isActive: false
            },
            ajaxLoad: null,
            imgPreload: null,
            transitions: {},
            helpers: {},
            open: function (a, b) {
                return a && (c.isPlainObject(b) || (b = {}), false !== h.close(true)) ? (c.isArray(a) || (a = l(a) ? c(a)
                    .get() : [a]), c.each(a, function (e, f) {
                        var i, j, k, n, o, p, q, g = {};
                        "object" === c.type(f) && (f.nodeType && (f = c(f)), l(f) ? (g = {
                            href: f.data("biz-fancybox-href") || f.attr("href"),
                            title: f.data("biz-fancybox-title") || f.attr("title"),
                            isDom: true,
                            element: f
                        }, c.metadata && c.extend(true, g, f.metadata())) : g = f), i = b.href || g.href || (m(f) ? f : null), j = b.title !== d ? b.title : g.title || "", k = b.content || g.content, n = k ? "html" : b.type || g.type, !n && g.isDom && (n = f.data("biz-fancybox-type"), n || (o = f.prop("class")
                            .match(/biz-fancybox\.(\w+)/), n = o ? o[1] : null)), m(i) && (n || (h.isImage(i) ? n = "image" : h.isSWF(i) ? n = "swf" : "#" === i.charAt(0) ? n = "inline" : m(f) && (n = "html", k = f)), "ajax" === n && (p = i.split(/\s+/, 2), i = p.shift(), q = p.shift())), k || ("inline" === n ? i ? k = c(m(i) ? i.replace(/.*(?=#[^\s]+$)/, "") : i) : g.isDom && (k = f) : "html" === n ? k = i : n || i || !g.isDom || (n = "inline", k = f)), c.extend(g, {
                                href: i,
                                type: n,
                                content: k,
                                title: j,
                                selector: q
                            }), a[e] = g;
                    }), h.opts = c.extend(true, {}, h.defaults, b), b.keys !== d && (h.opts.keys = b.keys ? c.extend({}, h.defaults.keys, b.keys) : false), h.group = a, h._start(h.opts.index)) : void 0;
            },
            cancel: function () {
                var a = h.coming;
                a && false !== h.trigger("onCancel") && (h.hideLoading(), h.ajaxLoad && h.ajaxLoad.abort(), h.ajaxLoad = null, h.imgPreload && (h.imgPreload.onload = h.imgPreload.onerror = null), a.wrap && a.wrap.stop(true, true)
                    .trigger("onReset")
                    .remove(), h.coming = null, h.current || h._afterZoomOut(a));
            },
            close: function (a) {
                h.cancel(), false !== h.trigger("beforeClose") && (h.unbindEvents(), h.isActive && (h.isOpen && a !== true ? (h.isOpen = h.isOpened = false, h.isClosing = true, c(".biz-fancybox-item, .biz-fancybox-nav")
                    .remove(), h.wrap.stop(true, true)
                    .removeClass("biz-fancybox-opened"), h.transitions[h.current.closeMethod]()) : (c(".biz-fancybox-wrap")
                    .stop(true)
                    .trigger("onReset")
                    .remove(), h._afterZoomOut())));
            },
            play: function (a) {
                var b = function () {
                    clearTimeout(h.player.timer);
                },
                    c = function () {
                        b(), h.current && h.player.isActive && (h.player.timer = setTimeout(h.next, h.current.playSpeed));
                    },
                    d = function () {
                        b(), g.unbind(".player"), h.player.isActive = false, h.trigger("onPlayEnd");
                    },
                    e = function () {
                        h.current && (h.current.loop || h.current.index < h.group.length - 1) && (h.player.isActive = true, g.bind({
                            "onCancel.player beforeClose.player": d,
                            "onUpdate.player": c,
                            "beforeLoad.player": b
                        }), c(), h.trigger("onPlayStart"));
                    };
                a === true || !h.player.isActive && a !== false ? e() : d();
            },
            next: function (a) {
                var b = h.current;
                b && (m(a) || (a = b.direction.next), h.jumpto(b.index + 1, a, "next"));
            },
            prev: function (a) {
                var b = h.current;
                b && (m(a) || (a = b.direction.prev), h.jumpto(b.index - 1, a, "prev"));
            },
            jumpto: function (a, b, c) {
                var e = h.current;
                e && (a = p(a), h.direction = b || e.direction[a >= e.index ? "next" : "prev"], h.router = c || "jumpto", e.loop && (0 > a && (a = e.group.length + a % e.group.length), a %= e.group.length), e.group[a] !== d && (h.cancel(), h._start(a)));
            },
            reposition: function (a, b) {
                var f,
                    d = h.current,
                    e = d ? d.wrap : null;
                e && (f = h._getPosition(b), a && "scroll" === a.type ? (delete f.position, e.stop(true, true)
                    .animate(f, 200)) : (e.css(f), d.pos = c.extend({}, d.dim, f)));
            },
            update: function (a) {
                var b = a && a.type, c = !b || "orientationchange" === b;
                c && (clearTimeout(j), j = null), h.isOpen && !j && (j = setTimeout(function () {
                    var d = h.current;
                    d && !h.isClosing && (h.wrap.removeClass("biz-fancybox-tmp"), (c || "load" === b || "resize" === b && d.autoResize) && h._setDimension(), "scroll" === b && d.canShrink || h.reposition(a), h.trigger("onUpdate"), j = null);
                }, c && !k ? 0 : 300));
            },
            scaupdate: function (a) {
                var b = a && a.type, d = true;
                if (d && (clearTimeout(j), j = null), h.isOpen && !j) {
                    var e, e = 0;
                    e = c("#biz-qv-left")
                        .outerHeight() > c(".biz-fancybox-inner")
                        .outerHeight() ? 345 : 0, 0 == c("#biz-qv-zoomcontainer")
                        .outerHeight() && c("#biz-qv-left")
                        .outerHeight() !== c(".biz-fancybox-inner")
                        .outerHeight() && (0 == e && (e = 345), c("#biz-qv-zoomcontainer")
                            .height(c("#biz-qv-zoomImg")
                                .outerHeight())), j = setTimeout(function () {
                                    var c = h.current;
                                    c && !h.isClosing && (h.wrap.removeClass("biz-fancybox-tmp"), (d || "load" === b || "resize" === b && c.autoResize) && h._setDimension(), "scroll" === b && c.canShrink || h.reposition(a), h.trigger("onUpdate"), j = null, h.hideLoading());
                                }, e);
                }
            },
            toggle: function (a) {
                h.isOpen && (h.current.fitToView = "boolean" === c.type(a) ? a : !h.current.fitToView, k && (h.wrap.removeAttr("style")
                    .addClass("biz-fancybox-tmp"), h.trigger("onUpdate")), h.update());
            },
            hideLoading: function () {
                g.unbind(".loading"), c("#biz-fancybox-loading")
                    .remove();
            },
            showLoading: function () {
                var a, b;
                h.hideLoading(), a = c('<div id="biz-fancybox-loading"><div></div></div>')
                    .click(h.cancel)
                    .appendTo("body"), g.bind("keydown.loading", function (a) {
                        27 === (a.which || a.keyCode) && (a.preventDefault(), h.cancel());
                    }), h.defaults.fixed || (b = h.getViewport(), a.css({
                        position: "absolute",
                        top: .5 * b.h + b.y,
                        left: .5 * b.w + b.x
                    }));
            },
            getViewport: function () {
                var b = h.current && h.current.locked || false,
                    c = {
                        x: f.scrollLeft(),
                        y: f.scrollTop()
                    };
                return b ? (c.w = b[0].clientWidth, c.h = b[0].clientHeight) : (c.w = k && a.innerWidth ? a.innerWidth : f.width(), c.h = k || a.innerHeight ? a.innerHeight : f.height()), c;
            },
            unbindEvents: function () {
                h.wrap && l(h.wrap) && h.wrap.unbind(".fb"), g.unbind(".fb"), f.unbind(".fb");
            },
            bindEvents: function () {
                var b, a = h.current;
                a && (f.bind("orientationchange.fb" + (k ? "" : " resize.fb") + (a.autoCenter && !a.locked ? " scroll.fb" : ""), h.update), b = a.keys, b && g.bind("keydown.fb", function (e) {
                    var f = e.which || e.keyCode, g = e.target || e.srcElement;
                    return 27 === f && h.coming ? false : (e.ctrlKey || e.altKey || e.shiftKey || e.metaKey || g && (g.type || c(g)
                        .is("[contenteditable]")) || c.each(b, function (b, g) {
                            return a.group.length > 1 && g[f] !== d ? (h[b](g[f]), e.preventDefault(), false) : c.inArray(f, g) > -1 ? (h[b](), e.preventDefault(), false) : void 0;
                        }), void 0);
                }), c.fn.mousewheel && a.mouseWheel && h.wrap.bind("mousewheel.fb", function (b, d, e, f) {
                    for (var g = b.target || null, i = c(g), j = false; i.length && !(j || i.is(".biz-fancybox-skin") || i.is(".biz-fancybox-wrap")) ;)
                        j = o(i[0]), i = c(i)
                            .parent();
                    0 === d || j || h.group.length > 1 && !a.canShrink && (f > 0 || e > 0 ? h.prev(f > 0 ? "down" : "left") : (0 > f || 0 > e) && h.next(0 > f ? "up" : "right"), b.preventDefault());
                }));
            },
            trigger: function (a, b) {
                var d, e = b || h.coming || h.current;
                if (e) {
                    if (c.isFunction(e[a]) && (d = e[a].apply(e, Array.prototype.slice.call(arguments, 1))), d === false) return false;
                    e.helpers && c.each(e.helpers, function (b, d) {
                        d && h.helpers[b] && c.isFunction(h.helpers[b][a]) && h.helpers[b][a](c.extend(true, {}, h.helpers[b].defaults, d), e);
                    }), g.trigger(a);
                }
            },
            isImage: function (a) {
                return m(a) && a.match(/(^data:image\/.*,)|(\.(jp(e|g|eg)|gif|png|bmp|webp|svg)((\?|#).*)?$)/i);
            },
            isSWF: function (a) {
                return m(a) && a.match(/\.(swf)((\?|#).*)?$/i);
            },
            _start: function (a) {
                var d, e, f, g, i, b = {};
                if (a = p(a), d = h.group[a] || null, !d) return false;
                if (b = c.extend(true, {}, h.opts, d), g = b.margin, i = b.padding, "number" === c.type(g) && (b.margin = [g, g, g, g]), "number" === c.type(i) && (b.padding = [i, i, i, i]), b.modal && c.extend(true, b, {
                    closeBtn: false,
                    closeClick: false,
                    nextClick: false,
                    arrows: false,
                    mouseWheel: false,
                    keys: null,
                    helpers: {
                    overlay: {
                    closeClick: false
                }
                }
                }), b.autoSize && (b.autoWidth = b.autoHeight = true), "auto" === b.width && (b.autoWidth = true), "auto" === b.height && (b.autoHeight = true), b.group = h.group, b.index = a, h.coming = b, false === h.trigger("beforeLoad")) return h.coming = null, void 0;
                if (f = b.type, e = b.href, !f) return h.coming = null, h.current && h.router && "jumpto" !== h.router ? (h.current.index = a, h[h.router](h.direction)) : false;
                if (h.isActive = true, ("image" === f || "swf" === f) && (b.autoHeight = b.autoWidth = false, b.scrolling = "visible"), "image" === f && (b.aspectRatio = true), "iframe" === f && k && (b.scrolling = "scroll"), b.wrap = c(b.tpl.wrap)
                    .addClass("biz-fancybox-" + (k ? "mobile" : "desktop") + " biz-fancybox-type-" + f + " biz-fancybox-tmp " + b.wrapCSS)
                    .appendTo(b.parent || "body"), c.extend(b, {
                    skin: c(".biz-fancybox-skin", b.wrap),
                    outer: c(".biz-fancybox-outer", b.wrap),
                    inner: c(".biz-fancybox-inner", b.wrap)
                }), c.each(["Top", "Right", "Bottom", "Left"], function (a, c) {
                    b.skin.css("padding" + c, q(b.padding[a]));
                }), h.trigger("onReady"), "inline" === f || "html" === f) {
                    if (!b.content || !b.content.length) return h._error("content");
                } else if (!e) return h._error("href");
                "image" === f ? h._loadImage() : "ajax" === f ? h._loadAjax() : "iframe" === f ? h._loadIframe() : h._afterLoad();
            },
            _error: function (a) {
                c.extend(h.coming, {
                    type: "html",
                    autoWidth: true,
                    autoHeight: true,
                    minWidth: 0,
                    minHeight: 0,
                    scrolling: "no",
                    hasError: a,
                    content: h.coming.tpl.error
                }), h._afterLoad();
            },
            _loadImage: function () {
                var a = h.imgPreload = new Image;
                a.onload = function () {
                    this.onload = this.onerror = null, h.coming.width = this.width / h.opts.pixelRatio, h.coming.height = this.height / h.opts.pixelRatio, h._afterLoad();
                }, a.onerror = function () {
                    this.onload = this.onerror = null, h._error("image");
                }, a.src = h.coming.href, a.complete !== true && h.showLoading();
            },
            _loadAjax: function () {
                var a = h.coming;
                h.showLoading(), h.ajaxLoad = c.ajax(c.extend({}, a.ajax, {
                    url: a.href,
                    error: function (a, b) {
                        h.coming && "abort" !== b ? h._error("ajax", a) : h.hideLoading();
                    },
                    success: function (b, c) {
                        "success" === c && (a.content = b, h._afterLoad());
                    }
                }));
            },
            _loadIframe: function () {
                var a = h.coming,
                    b = c(a.tpl.iframe.replace(/\{rnd\}/g, (new Date)
                            .getTime()))
                        .attr("scrolling", k ? "auto" : a.iframe.scrolling)
                        .attr("src", a.href);
                c(a.wrap)
                    .bind("onReset", function () {
                        try {
                            c(this)
                                .find("iframe")
                                .hide()
                                .attr("src", "//about:blank")
                                .end()
                                .empty();
                        } catch (a) {
                        }
                    }), a.iframe.preload && (h.showLoading(), b.one("load", function () {
                        c(this)
                            .data("ready", 1), k || c(this)
                            .bind("load.fb", h.update), c(this)
                            .parents(".biz-fancybox-wrap")
                            .width("100%")
                            .removeClass("biz-fancybox-tmp")
                            .show(), h._afterLoad();
                    })), a.content = b.appendTo(a.inner), a.iframe.preload || h._afterLoad();
            },
            _preloadImages: function () {
                var e,
                    f,
                    a = h.group,
                    b = h.current,
                    c = a.length,
                    d = b.preload ? Math.min(b.preload, c - 1) : 0;
                for (f = 1; d >= f; f += 1)
                    e = a[(b.index + f) % c], "image" === e.type && e.href && ((new Image)
                        .src = e.href);
            },
            _afterLoad: function () {
                var e,
                    f,
                    g,
                    i,
                    j,
                    k,
                    a = h.coming,
                    b = h.current,
                    d = "biz-fancybox-placeholder";
                if (h.hideLoading(), a && h.isActive !== false) {
                    if (false === h.trigger("afterLoad", a, b))
                        return a.wrap.stop(true)
                            .trigger("onReset")
                            .remove(), h.coming = null, void 0;
                    switch (b && (h.trigger("beforeChange", b), b.wrap.stop(true)
                        .removeClass("biz-fancybox-opened")
                        .find(".biz-fancybox-item, .biz-fancybox-nav")
                        .remove()), h.unbindEvents(), e = a, f = a.content, g = a.type, i = a.scrolling, c.extend(h, {
                        wrap: e.wrap,
                        skin: e.skin,
                        outer: e.outer,
                        inner: e.inner,
                        current: e,
                        previous: b
                    }), j = e.href, g) {
                        case "inline":
                        case "ajax":
                        case "html":
                            e.selector ? f = c("<div>")
                                .html(f)
                                .find(e.selector) : l(f) && (f.data(d) || f.data(d, c('<div class="' + d + '"></div>')
                                    .insertAfter(f)
                                    .hide()), f = f.show()
                                    .detach(), e.wrap.bind("onReset", function () {
                                        c(this)
                                            .find(f)
                                            .length && f.hide()
                                            .replaceAll(f.data(d))
                                            .data(d, false);
                                    }));
                            break;
                        case "image":
                            f = e.tpl.image.replace("{href}", j);
                            break;
                        case "swf":
                            f = '<object id="biz-fancybox-swf" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="100%" height="100%"><param name="movie" value="' + j + '"></param>', k = "", c.each(e.swf, function (a, b) {
                                f += '<param name="' + a + '"value="' + b + '"></param>', k += " " + a + '="' + b + '"';
                            }), f += '<embed src="' + j + '" type="application/x-shockwave-flash" width="100%" height="100%"' + k + "></embed></object>";
                    }
                    l(f) && f.parent()
                        .is(e.inner) || e.inner.append(f), h.trigger("beforeShow"), e.inner.css("overflow", "yes" === i ? "scroll" : "no" === i ? "hidden" : i), h._setDimension(), h.reposition(), h.isOpen = false, h.coming = null, h.bindEvents(), h.isOpened ? b.prevMethod && h.transitions[b.prevMethod]() : c(".biz-fancybox-wrap")
                        .not(e.wrap)
                        .stop(true)
                        .trigger("onReset")
                        .remove(), h.transitions[h.isOpened ? e.nextMethod : e.openMethod](), h._preloadImages();
                }
            },
            _setDimension: function () {
                var y,
                    z,
                    A,
                    B,
                    C,
                    D,
                    E,
                    F,
                    G,
                    H,
                    I,
                    J,
                    K,
                    L,
                    M,
                    a = h.getViewport(),
                    b = 0,
                    d = false,
                    e = false,
                    f = h.wrap,
                    g = h.skin,
                    i = h.inner,
                    j = h.current,
                    k = j.width,
                    l = j.height,
                    m = j.minWidth,
                    o = j.minHeight,
                    r = j.maxWidth,
                    s = j.maxHeight,
                    t = j.scrolling,
                    u = j.scrollOutside ? j.scrollbarWidth : 0,
                    v = j.margin,
                    w = p(v[1] + v[3]),
                    x = p(v[0] + v[2]);
                if (f.add(g)
                    .add(i)
                    .width("auto")
                    .height("auto")
                    .removeClass("biz-fancybox-tmp"), y = p(g.outerWidth(true) - g.width()), z = p(g.outerHeight(true) - g.height()), A = w + y, B = x + z, C = n(k) ? (a.w - A) * p(k) / 100 : k, D = n(l) ? (a.h - B) * p(l) / 100 : l, "iframe" === j.type) {
                    if (L = j.content, j.autoHeight && 1 === L.data("ready"))
                        try {
                            L[0].contentWindow.document.location && (i.width(C)
                                .height(9999), M = L.contents()
                                .find("body"), u && M.css("overflow-x", "hidden"), D = M.outerHeight(true));
                        } catch (N) {
                        }
                } else (j.autoWidth || j.autoHeight) && (i.addClass("biz-fancybox-tmp"), j.autoWidth || i.width(C), j.autoHeight || i.height(D), j.autoWidth && (C = i.width()), j.autoHeight && (D = i.height()), i.removeClass("biz-fancybox-tmp"));
                if (k = p(C), l = p(D), G = C / D, m = p(n(m) ? p(m, "w") - A : m), r = p(n(r) ? p(r, "w") - A : r), o = p(n(o) ? p(o, "h") - B : o), s = p(n(s) ? p(s, "h") - B : s), E = r, F = s, j.fitToView && (r = Math.min(a.w - A, r), s = Math.min(a.h - B, s)), J = a.w - w, K = a.h - x, j.aspectRatio ? (k > r && (k = r, l = p(k / G)), l > s && (l = s, k = p(l * G)), m > k && (k = m, l = p(k / G)), o > l && (l = o, k = p(l * G))) : (k = Math.max(m, Math.min(k, r)), j.autoHeight && "iframe" !== j.type && (i.width(k), l = i.height()), l = Math.max(o, Math.min(l, s))), j.fitToView)
                    if (i.width(k)
                        .height(l), f.width(k + y), H = f.width(), I = f.height(), j.aspectRatio)
                        for (;
                        (H > J || I > K) && k > m && l > o && !(b++ > 19) ;)
                            l = Math.max(o, Math.min(s, l - 10)), k = p(l * G), m > k && (k = m, l = p(k / G)), k > r && (k = r, l = p(k / G)), i.width(k)
                                .height(l), f.width(k + y), H = f.width(), I = f.height();
                    else k = Math.max(m, Math.min(k, k - (H - J))), l = Math.max(o, Math.min(l, l - (I - K)));
                u && "auto" === t && D > l && J > k + y + u && (k += u), i.width(k)
                    .height(l), f.width(k + y), H = f.width(), I = f.height(), d = (H > J || I > K) && k > m && l > o, e = j.aspectRatio ? E > k && F > l && C > k && D > l : (E > k || F > l) && (C > k || D > l), c.extend(j, {
                        dim: {
                            width: q(H),
                            height: q(I)
                        },
                        origWidth: C,
                        origHeight: D,
                        canShrink: d,
                        canExpand: e,
                        wPadding: y,
                        hPadding: z,
                        wrapSpace: I - g.outerHeight(true),
                        skinSpace: g.height() - l
                    }), !L && j.autoHeight && l > o && s > l && !e && i.height("auto");
            },
            _getPosition: function (a) {
                var b = h.current,
                    c = h.getViewport(),
                    d = b.margin,
                    e = h.wrap.width() + d[1] + d[3],
                    f = h.wrap.height() + d[0] + d[2],
                    g = {
                        position: "absolute",
                        top: d[0],
                        left: d[3]
                    };
                return b.autoCenter && b.fixed && !a && f <= c.h && e <= c.w ? g.position = "fixed" : b.locked || (g.top += c.y, g.left += c.x), g.top = q(Math.max(g.top, g.top + (c.h - f) * b.topRatio)), g.left = q(Math.max(g.left, g.left + (c.w - e) * b.leftRatio)), g;
            },
            _afterZoomIn: function () {
                var a = h.current;
                a && (h.isOpen = h.isOpened = true, h.wrap.css("overflow", "visible")
                    .addClass("biz-fancybox-opened"), h.update(), (a.closeClick || a.nextClick && h.group.length > 1) && h.inner.css("cursor", "pointer")
                    .bind("click.fb", function (b) {
                        c(b.target)
                            .is("a") || c(b.target)
                            .parent()
                            .is("a") || (b.preventDefault(), h[a.closeClick ? "close" : "next"]());
                    }), a.closeBtn && c(a.tpl.closeBtn)
                    .appendTo(h.skin)
                    .bind("click.fb", function (a) {
                        a.preventDefault(), h.close();
                    }), a.arrows && h.group.length > 1 && ((a.loop || a.index > 0) && c(a.tpl.prev)
                    .appendTo(h.outer)
                    .bind("click.fb", h.prev), (a.loop || a.index < h.group.length - 1) && c(a.tpl.next)
                    .appendTo(h.outer)
                    .bind("click.fb", h.next)), h.trigger("afterShow"), a.loop || a.index !== a.group.length - 1 ? h.opts.autoPlay && !h.player.isActive && (h.opts.autoPlay = false, h.play()) : h.play(false));
            },
            _afterZoomOut: function (a) {
                a = a || h.current, c(".biz-fancybox-wrap")
                    .trigger("onReset")
                    .remove(), c.extend(h, {
                        group: {},
                        opts: {},
                        router: false,
                        current: null,
                        isActive: false,
                        isOpened: false,
                        isOpen: false,
                        isClosing: false,
                        wrap: null,
                        skin: null,
                        outer: null,
                        inner: null
                    }), h.trigger("afterClose", a);
            }
        }), h.transitions = {
            getOrigPosition: function () {
                var a = h.current,
                    b = a.element,
                    c = a.orig,
                    d = {},
                    e = 50,
                    f = 50,
                    g = a.hPadding,
                    i = a.wPadding,
                    j = h.getViewport();
                return !c && a.isDom && b.is(":visible") && (c = b.find("img:first"), c.length || (c = b)), l(c) ? (d = c.offset(), c.is("img") && (e = c.outerWidth(), f = c.outerHeight())) : (d.top = j.y + (j.h - f) * a.topRatio, d.left = j.x + (j.w - e) * a.leftRatio), ("fixed" === h.wrap.css("position") || a.locked) && (d.top -= j.y, d.left -= j.x), d = {
                    top: q(d.top - g * a.topRatio),
                    left: q(d.left - i * a.leftRatio),
                    width: q(e + i),
                    height: q(f + g)
                };
            },
            step: function (a, b) {
                var c,
                    d,
                    e,
                    f = b.prop,
                    g = h.current,
                    i = g.wrapSpace,
                    j = g.skinSpace;
                ("width" === f || "height" === f) && (c = b.end === b.start ? 1 : (a - b.start) / (b.end - b.start), h.isClosing && (c = 1 - c), d = "width" === f ? g.wPadding : g.hPadding, e = a - d, h.skin[f](p("width" === f ? e : e - i * c)), h.inner[f](p("width" === f ? e : e - i * c - j * c)));
            },
            zoomIn: function () {
                var a = h.current,
                    b = a.pos,
                    d = a.openEffect,
                    e = "elastic" === d,
                    f = c.extend({
                        opacity: 1
                    }, b);
                delete f.position, e ? (b = this.getOrigPosition(), a.openOpacity && (b.opacity = .1)) : "fade" === d && (b.opacity = .1), h.wrap.css(b)
                    .animate(f, {
                        duration: "none" === d ? 0 : a.openSpeed,
                        easing: a.openEasing,
                        step: e ? this.step : null,
                        complete: h._afterZoomIn
                    });
            },
            zoomOut: function () {
                var a = h.current,
                    b = a.closeEffect,
                    c = "elastic" === b,
                    d = {
                        opacity: .1
                    };
                c && (d = this.getOrigPosition(), a.closeOpacity && (d.opacity = .1)), h.wrap.animate(d, {
                    duration: "none" === b ? 0 : a.closeSpeed,
                    easing: a.closeEasing,
                    step: c ? this.step : null,
                    complete: h._afterZoomOut
                });
            },
            changeIn: function () {
                var g,
                    a = h.current,
                    b = a.nextEffect,
                    c = a.pos,
                    d = {
                        opacity: 1
                    },
                    e = h.direction,
                    f = 200;
                c.opacity = .1, "elastic" === b && (g = "down" === e || "up" === e ? "top" : "left", "down" === e || "right" === e ? (c[g] = q(p(c[g]) - f), d[g] = "+=" + f + "px") : (c[g] = q(p(c[g]) + f), d[g] = "-=" + f + "px")), "none" === b ? h._afterZoomIn() : h.wrap.css(c)
                    .animate(d, {
                        duration: a.nextSpeed,
                        easing: a.nextEasing,
                        complete: h._afterZoomIn
                    });
            },
            changeOut: function () {
                var a = h.previous,
                    b = a.prevEffect,
                    d = {
                        opacity: .1
                    },
                    e = h.direction,
                    f = 200;
                "elastic" === b && (d["down" === e || "up" === e ? "top" : "left"] = ("up" === e || "left" === e ? "-" : "+") + "=" + f + "px"), a.wrap.animate(d, {
                    duration: "none" === b ? 0 : a.prevSpeed,
                    easing: a.prevEasing,
                    complete: function () {
                        c(this)
                            .trigger("onReset")
                            .remove();
                    }
                });
            }
        }, h.helpers.overlay = {
            defaults: {
                closeClick: true,
                speedOut: 200,
                showEarly: true,
                css: {},
                locked: !k,
                fixed: true
            },
            overlay: null,
            fixed: false,
            el: c("html"),
            create: function (a) {
                a = c.extend({}, this.defaults, a), this.overlay && this.close(), this.overlay = c('<div class="biz-fancybox-overlay"></div>')
                    .appendTo(h.coming ? h.coming.parent : a.parent), this.fixed = false, a.fixed && h.defaults.fixed && (this.overlay.addClass("biz-fancybox-overlay-fixed"), this.fixed = true);
            },
            open: function (a) {
                var b = this;
                a = c.extend({}, this.defaults, a), this.overlay ? this.overlay.unbind(".overlay")
                    .width("auto")
                    .height("auto") : this.create(a), this.fixed || (f.bind("resize.overlay", c.proxy(this.update, this)), this.update()), a.closeClick && this.overlay.bind("click.overlay", function (a) {
                        return c(a.target)
                            .hasClass("biz-fancybox-overlay") ? (h.isActive ? h.close() : b.close(), false) : void 0;
                    }), this.overlay.css(a.css)
                    .show();
            },
            close: function () {
                var a, b;
                f.unbind("resize.overlay"), this.el.hasClass("biz-fancybox-lock") && (c(".biz-fancybox-margin")
                    .removeClass("biz-fancybox-margin"), a = f.scrollTop(), b = f.scrollLeft(), this.el.removeClass("biz-fancybox-lock"), f.scrollTop(a)
                    .scrollLeft(b)), c(".biz-fancybox-overlay")
                    .remove()
                    .hide(), c.extend(this, {
                        overlay: null,
                        fixed: false
                    });
            },
            update: function () {
                var c, a = "100%";
                this.overlay.width(a)
                    .height("100%"), i ? (c = Math.max(b.documentElement.offsetWidth, b.body.offsetWidth), g.width() > c && (a = g.width())) : g.width() > f.width() && (a = g.width()), this.overlay.width(a)
                    .height(g.height());
            },
            onReady: function (a, b) {
                var d = this.overlay;
                c(".biz-fancybox-overlay")
                    .stop(true, true), d || this.create(a), a.locked && this.fixed && b.fixed && (d || (this.margin = g.height() > f.height() ? c("html")
                    .css("margin-right")
                    .replace("px", "") : false), b.locked = this.overlay.append(b.wrap), b.fixed = false), a.showEarly === true && this.beforeShow.apply(this, arguments);
            },
            beforeShow: function (a, b) {
                var d, e;
                b.locked && (this.margin !== false && (c("*")
                    .filter(function () {
                        return "fixed" === c(this)
                            .css("position") && !c(this)
                            .hasClass("biz-fancybox-overlay") && !c(this)
                            .hasClass("biz-fancybox-wrap");
                    })
                    .addClass("biz-fancybox-margin"), this.el.addClass("biz-fancybox-margin")), d = f.scrollTop(), e = f.scrollLeft(), this.el.addClass("biz-fancybox-lock"), f.scrollTop(d)
                    .scrollLeft(e)), this.open(a);
            },
            onUpdate: function () {
                this.fixed || this.update();
            },
            afterClose: function (a) {
                this.overlay && !h.coming && this.overlay.fadeOut(a.speedOut, c.proxy(this.close, this));
            }
        }, h.helpers.title = {
            defaults: {
                type: "float",
                position: "bottom"
            },
            beforeShow: function (a) {
                var f,
                    g,
                    b = h.current,
                    d = b.title,
                    e = a.type;
                if (c.isFunction(d) && (d = d.call(b.element, b)), m(d) && "" !== c.trim(d)) {
                    switch (f = c('<div class="biz-fancybox-title biz-fancybox-title-' + e + '-wrap">' + d + "</div>"), e) {
                        case "inside":
                            g = h.skin;
                            break;
                        case "outside":
                            g = h.wrap;
                            break;
                        case "over":
                            g = h.inner;
                            break;
                        default:
                            g = h.skin, f.appendTo("body"), i && f.width(f.width()), f.wrapInner('<span class="child"></span>'), h.current.margin[2] += Math.abs(p(f.css("margin-bottom")));
                    }
                    f["top" === a.position ? "prependTo" : "appendTo"](g);
                }
            }
        }, c.fn.scafancybox = function (a) {
            var b,
                d = c(this),
                e = this.selector || "",
                f = function (f) {
                    var j,
                        k,
                        g = c(this)
                            .blur(),
                        i = b;
                    f.ctrlKey || f.altKey || f.shiftKey || f.metaKey || g.is(".biz-fancybox-wrap") || (j = a.groupAttr || "data-biz-fancybox-group", k = g.attr(j), k || (j = "rel", k = g.get(0)[j]), k && "" !== k && "nofollow" !== k && (g = e.length ? c(e) : d, g = g.filter("[" + j + '="' + k + '"]'), i = g.index(this)), a.index = i, h.open(g, a) !== false && f.preventDefault());
                };
            return a = a || {}, b = a.index || 0, e && a.live !== false ? g.undelegate(e, "click.fb-start")
                .delegate(e + ":not('.biz-fancybox-item,.biz-fancybox-nav')", "click.fb-start", f) : d.unbind("click.fb-start")
                .bind("click.fb-start", f), this.filter("[data-biz-fancybox-start=1]")
                .trigger("click"), this;
        }, c.fn.scashowLoading = function () {
            h.showLoading();
        }, c.fn.scahideLoading = function () {
            h.hideLoading();
        }, g.ready(function () {
            var b, f;
            c.scrollbarWidth === d && (c.scrollbarWidth = function () {
                var a = c('<div style="width:50px;height:50px;overflow:auto"><div/></div>')
                        .appendTo("body"),
                    b = a.children(),
                    d = b.innerWidth() - b.height(99)
                        .innerWidth();
                return a.remove(), d;
            }), c.support.fixedPosition === d && (c.support.fixedPosition = function () {
                var a = c('<div style="position:fixed;top:20px;"></div>')
                        .appendTo("body"),
                    b = 20 === a[0].offsetTop || 15 === a[0].offsetTop;
                return a.remove(), b;
            }()), c.extend(h.defaults, {
                scrollbarWidth: c.scrollbarWidth(),
                fixed: c.support.fixedPosition,
                parent: c("body")
            }), b = c(a)
                .width(), e.addClass("biz-fancybox-lock-test"), f = c(a)
                .width(), e.removeClass("biz-fancybox-lock-test"), c("<style type='text/css'>.biz-fancybox-margin{margin-right:" + (f - b) + "px;}</style>")
                .appendTo("head");
        });
    }

    function preloadQV(a, b) {
        var c = b.attr("handle");
        return a.ajax({
            dataType: "json",
            url: "/products/" + c + ".js"
        })
            .done(function (a) {
                QVBizweb.preload(a.images, "large"), QVBizweb.preload(a.images);
            });
    }

    function findQVContainer(a, b) {
        return a('a[href*="/"]', b.parent())
            .has('img[src*="/products/"],img[src*="/no-image"],img[src*="/noimage"]')
            .length > 1 || b.parent()
            .width() - b.width() > 50 ? b : findQVContainer(a, b.parent());
    }

    function showIfProductAdd(a, b) {
        if (a.inArray(b, list_cart_variants) != -1) {
            a("#biz-qv-addcart-msg").html(product_in_cart);
            a("#biz-qv-addcart-msg").fadeIn(1e3);
            //alert("San pham da co san trong gio hang");
        }


    }

    window.loaded = false;
    //b.jsondata la chuoi settings duoc ma hoa
    function loadData(a, b) {
        if (!window.loaded) {
            window.loaded = true;
            
            collection_handle = b.collection_handle, "yes" == b.autoconfig && initQuickViewContent(a), scaqvFancybox(window, document, a, void 0), scaqvImageZoom(a, window, document, void 0);
            var c = b.jsondata;

            return moneyFormat = b.moneyFormat, noimage = b.noimage, add_to_cart_text = a(".biz-qv-cartbtn")
                    .val(), a("#biz-qv-unavailable").length && (unavailable_text = a("#biz-qv-unavailable").text()),
                settings = a.parseJSON(SCABase64.decode(c)), settings.bnt_possition = "center",
                //cp = c.replace(/'/gi,'"'),
                //settings = JSON.parse(cp),
                //console.log("Disable QV : " + settings.qv_disable),
                settings.qv_disable ? false : (SCASettings.loadSettings(a, settings), true);
        }

    }

    function createCartForm(a, b, c) {
        var d = a("#biz-qv-add-item-form", c);
        if (0 != d.length) {
            var e = a(".biz-qv-product-options", d), f = a("#biz-qv-variant-options", e);
            f.empty(),
            f.append('<div><select id="biz-qv-product-selected" name="variantid"class="biz-qv-hidden"></select> </div>');
            var g = a("#biz-qv-product-selected", f);
            g.empty();
            var h = b.variants;
            a.each(h, function (a, b) {
                g.append('<option value="' + b.id + '">' + b.title + " - " + QVBizweb.formatMoney(b.price, moneyFormat) + "</option>");
            }),
                a("#biz-qv-quantity", c)
                    .val("1"), a("#biz-qv-sold-out")
                    .addClass("biz-qv-hidden"),
                b.available ? (a(".biz-qv-cartbtn")
                    .removeClass("biz-qv-hidden"), a(".biz-qv-cartbtn")
                    .removeClass("disabled")
                    .removeAttr("disabled")
                    .val(add_to_cart_text)) : (a(".biz-qv-cartbtn")
                        .removeClass("biz-qv-hidden"),
                    a(".biz-qv-cartbtn").val(a("#biz-qv-sold-out").text()).addClass("disabled").attr("disabled", "disabled")),
            formatVariantOption(a, b);
        }
    }
    product_in_cart = 'Sản phẩm này đã có sẵn trong <a href="/cart" class="biz-qv-msg-cart-link">Giỏ hàng</a> !',
    product_added = 'Sản phẩm đã được thêm thành công vào <a href="/cart"  class="biz-qv-msg-cart-link">Giỏ hàng</a> !',

    function convert_currency() {
        try {
            "undefined" != typeof Currency && "undefined" != typeof Currency.convertAll && Currency.convertAll(Currency.shopCurrency, Currency.currentCurrency);
        } catch (a) {
            console.log(a);
        }
    }

    function formatVariantOption(a, b) {

        a("#biz-qv-addcart-msg").hide();
        var d = "";
        void 0 != settings.price_color && null != settings.price_color && (d = settings.price_color);
        var e = a("#biz-qv-showqv");
        if (b != null) {
            if (b.available) {
                if (b.options.length == 0) {
                    showIfProductAdd(a, b.variants[0].id),
                    a(".biz-qv-cartbtn").removeClass("disabled").removeAttr("disabled").val(add_to_cart_text);
                    //alert("varition id:" + b.variants[0].id);
                }

            } else {
                a(".biz-qv-cartbtn")
                    .val(a("#biz-qv-sold-out").text())
                    .addClass("disabled")
                    .attr("disabled", "disabled"), b.compare_at_price > b.price ? a(".biz-qv-price-container", e)
                    .html('<span class="biz-qv-product-price"style="color:' + d + ' !important;">' + QVBizweb.formatMoney(b.price, moneyFormat) + '&nbsp;<del class="biz-qv-product-compare-price">' + QVBizweb.formatMoney(b.compare_at_price, moneyFormat) + "</del>" + "</span>") : a(".biz-qv-price-container", e)
                    .html('<span class="biz-qv-product-price"style="color:' + d + ' !important;">' + QVBizweb.formatMoney(b.price, moneyFormat) + "</span>");
            }
        }
        else {
            a(".biz-qv-cartbtn")
            .val(unavailable_text)
            .addClass("disabled")
            .attr("disabled", "disabled");
        }


        //a("#biz-qv-addcart-msg").hide();
        //var d = "";
        //void 0 != settings.price_color && null != settings.price_color && (d = settings.price_color);
        //var e = a("#biz-qv-showqv");

        //if (b != null) {
        //    if (b.available) {
        //        if (a.inArray(b.id, list_cart_variants) != -1) {
        //            a("#biz-qv-addcart-msg").html(product_in_cart);
        //            a("#biz-qv-addcart-msg").fadeIn(1e3);
        //            alert("San pham da co san trong gio hang");
        //            a(".biz-qv-cartbtn").removeClass("disabled").removeAttr("disabled").val(add_to_cart_text);
        //        }

        //    } else {
        //        a(".biz-qv-cartbtn")
        //            .val(a("#biz-qv-sold-out").text())
        //            .addClass("disabled")
        //            .attr("disabled", "disabled"), b.compare_at_price > b.price ? a(".biz-qv-price-container", e)
        //            .html('<span class="biz-qv-product-price"style="color:' + d + ' !important;">' + QVBizweb.formatMoney(b.price, moneyFormat) + '&nbsp;<del class="biz-qv-product-compare-price">' + QVBizweb.formatMoney(b.compare_at_price, moneyFormat) + "</del>" + "</span>") : a(".biz-qv-price-container", e)
        //            .html('<span class="biz-qv-product-price"style="color:' + d + ' !important;">' + QVBizweb.formatMoney(b.price, moneyFormat) + "</span>");
        //    }
        //} else {
        //    a(".biz-qv-cartbtn")
        //           .val(unavailable_text)
        //           .addClass("disabled")
        //           .attr("disabled", "disabled");
        //}


        var c = function (b) {
            a("#biz-qv-addcart-msg").hide();
            var d = "";
            void 0 != settings.price_color && null != settings.price_color && (d = settings.price_color);
            var e = a("#biz-qv-showqv");
            b ? (b.available ? (showIfProductAdd(a, b.id),
            a(".biz-qv-cartbtn").removeClass("disabled").removeAttr("disabled").val(add_to_cart_text))

            : a(".biz-qv-cartbtn")
                    .val(a("#biz-qv-sold-out").text())
                    .addClass("disabled")
                    .attr("disabled", "disabled"), b.compare_at_price > b.price ? a(".biz-qv-price-container", e)
                    .html('<span class="biz-qv-product-price"style="color:' + d + ' !important;">' + QVBizweb.formatMoney(b.price, moneyFormat) + '&nbsp;<del class="biz-qv-product-compare-price">' + QVBizweb.formatMoney(b.compare_at_price, moneyFormat) + "</del>" + "</span>") : a(".biz-qv-price-container", e)
                    .html('<span class="biz-qv-product-price"style="color:' + d + ' !important;">' + QVBizweb.formatMoney(b.price, moneyFormat) + "</span>"))
            : a(".biz-qv-cartbtn")
                .val(unavailable_text)
                .addClass("disabled")
                .attr("disabled", "disabled");
        };

        a(function (d) {
            var e = a("#biz-qv-showqv");
            new Bizweb.OptionSelectors("biz-qv-product-selected", {
                product: b,
                onVariantSelected: c
            }), 1 == b.options.length && "Title" != b.options[0] && d(".selector-wrapper:eq(0)", e)
                .prepend("<label>" + b.options[0] + "</label>");
            var f = false, g = b.variants;
            a.each(g, function (c, g) {
                if (g.available && 0 == f) {
                    f = true;
                    var h = b.options;
                    a.each(h, function (a) {
                        d(".single-option-selector:eq(" + a + ")", e)
                            .val(g.options[a])
                            .trigger("change");
                    });
                }
            });
        }),
            a("#biz-qv-variant-options").removeClass("biz-qv-hidden"),
            1 == b.variants.length && b.variants[0].title.indexOf("Default") > -1 && a("#biz-qv-variant-options").addClass("biz-qv-hidden");
    }

    function truncate(a, b) {
        var c = a("<div/>")
            .html(b);
        b = c.text(), b = b.replace(/\r?\n/g, ". "), b = b.replace(/<!--\n?.*\n?-->/, "");
        var d = b.split(" "),
            e = 30,
            f = d.length > e,
            b = f ? d.splice(0, e)
                .join(" ") + "..." : b;
        return b;
    }

    function createDesc(a, b, c) {
        var d = a("#biz-qv-des", c);
        d.empty(), d.html(b.content), d.text(truncate(a, d.text())), d.append('<div class="clear-both"></div');
    }

    function createDetail(a, b, c, d) {
        var e = a("#biz-qv-detail", c);
        null != collection_handle ? e.attr("href", d.replace(".js", "")) : e.attr("href", "/" + b.alias);
    }

    function createPrice(a, b, c) {
        var d = a("#biz-qv-price-container", c);
        d.empty(), b.compare_at_price > b.price ? (a("#biz-qv-sale")
            .removeClass("biz-qv-hidden"), d.append('<span class="biz-qv-product-price">' + QVBizweb.formatMoney(b.price, moneyFormat) + '&nbsp;<del class="biz-qv-product-compare-price">' + QVBizweb.formatMoney(b.compare_at_price, moneyFormat) + "</del>  </span>")) : d.append('<span class="biz-qv-product-price">' + QVBizweb.formatMoney(b.price, moneyFormat) + "</span>");
    }

    function createTitle(a, b, c) {
        var d = a("#biz-qv-title", c);
        d.empty(), d.append("<strong>" + b.name + "</strong>");
    }

    function createGallery(a, b, c) {
        var d = a("#biz-qv-galleryid", c);
        d.empty();
        var e = b.images,
            f = parseInt(settings.img_main_width, 10),
            g = (f - 8) / 4;
        e.length > 1 && (cratezoomgalery(a, d, b.featured_image, g), a.each(e, function (b, c) {
            b > 0 && 4 > b && cratezoomgalery(a, d, c, g);
        }));
    }

    function cratezoomgalery(a, b, c, d) {
        var e = "max-width:" + d + "px;max-height:" + d + "px;", f = '<a href="#" data-image="' + QVBizweb.resizeImage(c, "large") + '" data-zoom-image="' + QVBizweb.resizeImage(c, "original") + '"  class="biz-qv-gallery-a" > <img src="' + QVBizweb.resizeImage(c, "large") + '" class="biz-qv-gallery-img" style="' + e + '"/> </a>';
        b.append(f);
    }

    function createZoomContainer(a, b, c) {
        var d = a("#biz-qv-zoomcontainer", c);
        d.empty();
        var e = noimage;
        null != b.featured_image && (e = b.featured_image), d.append('<img  id="biz-qv-zoomImg" style="max-width:' + settings.img_main_width + "px" + ";max-height:" + settings.img_main_width + "px" + '" src="' + QVBizweb.resizeImage(e, "large") + '" data-zoom-image="' + QVBizweb.resizeImage(e, "original") + '" alt=""  >');
    }

    function cleanTemplate(a, b) {
        var c = a("#biz-qv-zoomcontainer", b);
        c.empty();
        var d = a("#biz-qv-galleryid", b);
        d.empty();
        var e = a("#biz-qv-title", b);
        e.empty();
        var f = a("#biz-qv-price-container", b);
        f.empty();
        var g = a("#biz-qv-des", b);
        g.empty();
        var h = a("#biz-qv-add-item-form", b),
            i = a(".biz-qv-product-options", h),
            j = a("#biz-qv-variant-options", i);
        j.empty();
        var k = a("#biz-qv-product-selected", j);
        k.empty();
    }

    function preloadQV(a, b) {
        var c, d = a(".biz-qv-button, .custom-qv-button");
        if (b > -1 && d.length > b) {
            c = d.eq(b), console.log(c);
            var e = c.attr("handle");
            a.ajax({
                dataType: "json",
                url: "/products/" + e + ".js"
            })
                .done(function (a) {
                    QVBizweb.preload(a.images, "large"), QVBizweb.preload(a.images);
                });
        }
    }

    function preloadNearItem(a, b) {
        var c = a(".biz-qv-button, .custom-qv-button")
            .index(b);
        preloadQV(a, c - 1), preloadQV(a, c + 1);
    }

    function freegifts_filter(a, b) {
        var c = [];
        return a.each(b.variants, function (b, d) {
            var e = false;
            a.each(d.options, function (a, b) {
                if (b.length > 6 && "%off)" == b.substring(b.length - 6, b.length)) return e = true, false;
                if (b.length > 11 && "(Freegifts)" == b.substring(b.length - 11, b.length)) return e = true, false;
                try {
                    var c = /\(BK \d+\)/g;
                    if (b.match(c)) return e = true, false;
                } catch (d) {
                }
            }), e || c.push(d);
        }), b.variants = c, b;
    }

    function buyx_product_json(a, b) {
        for (var c = [], d = -1, e = 0, f = b.options.length; f > e; e++)
            if ("BuyXDiscount" == b.options[e]) {
                d = e + 1;
                break;
            }
        if (-1 == d) return b;
        b.options.length > 1 ? b.options.splice(d - 1, 1) : b.options[0] = "Title", d = "option" + d, b.available = false;
        for (var g = 0, h = b.variants.length; h > g; g++) "Default" == b.variants[g][d] && (b.variants[g][d] = "", c.push(b.variants[g]), b.available = b.available || b.variants[g].available);
        return b.variants = c, b;
    }

    function isMoblieBrowser() {
        var a = false;
        try {
            ! function (b) {
                (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino/i.test(b) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(b.substr(0, 4))) && (a = true);
            }(navigator.userAgent || navigator.vendor || window.opera);
        } catch (b) {
            console.log(b);
        }
        return a;
    }

    "undefined" == typeof QVBizweb && (QVBizweb = {}), QVBizweb.preload = function (a, b) {
        for (var c = 0; c < a.length; c++) {
            var d = a[c];
            QVBizweb.loadImage(QVBizweb.getSizedImageUrl(d, b));
        }
    }, QVBizweb.loadImage = function (a) {
        (new Image)
            .src = a;
    }, QVBizweb.getSizedImageUrl = function (a, b) {
        if (null == b) return a;
        if ("master" == b) return QVBizweb.removeProtocol(a);
        var c = a.match(/\.(jpg|jpeg|gif|png|bmp|bitmap|tiff|tif)(\?v=\d+)?$/i);
        if (null != c) {
            var d = a.split(c[0]), e = c[0];
            return QVBizweb.removeProtocol(d[0] + e); //return QVBizweb.removeProtocol(d[0] + "_" + b + e)
        }
        return null;
    }, QVBizweb.removeProtocol = function (a) {
        return a.replace(/http(s)?:/, "");
    };
    for (var method, noop = function () { }, methods = ["assert", "clear", "count", "debug", "dir", "dirxml", "error", "exception", "group", "groupCollapsed", "groupEnd", "info", "log", "markTimeline", "profile", "profileEnd", "table", "time", "timeEnd", "timeStamp", "trace", "warn"], length = methods.length, console = window.console = window.console || {}; length--;) method = methods[length], console[method] || (console[method] = noop);
    QVBizweb.money_format = "${{amount}}", QVBizweb.formatMoney = function (a, b) {
        function f(a, b) {
            return "undefined" == typeof a ? b : a;
        }

        function g(a, b, c, d) {
            if (b = f(b, 2), c = f(c, ","), d = f(d, "."), isNaN(a) || null == a) return 0;
            a = (a)
                .toFixed(b);
            var e = a.split("."),
                g = e[0].replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1" + c),
                h = e[1] ? d + e[1] : "";
            return g + h;
        }

        if ("undefined" != typeof Bizweb && "undefined" != typeof QVBizweb.formatMoney) return QVBizweb.formatMoney(a, b);
        "string" == typeof a && (a = a.replace(".", ""));
        var c = "",
            d = /\{\{\s*(\w+)\s*\}\}/,
            e = b || this.money_format;
        switch (e.match(d)[1]) {
            case "amount":
                c = g(a, 2);
                break;
            case "amount_no_decimals":
                c = g(a, 0);
                break;
            case "amount_with_comma_separator":
                c = g(a, 2, ".", ",");
                break;
            case "amount_no_decimals_with_comma_separator":
                c = g(a, 0, ".", ",");
        }
        return e.replace(d, c);
    }, QVBizweb.resizeImage = function (a, b) {
        try {
            if ("original" == b) return a;
            //var c = a.match(/(.*\/[\w\-\_\.]+)\.(\w{2,4})/);
            //return c[1] + "." + c[2] 
            return a.replace("//bizweb.dktcdn.net", "//bizweb.dktcdn.net/thumb/" + b);
        } catch (d) {
            return a
        }
    };

    var loadjscssfile = function (a, b) {
        if ("js" == b) {
            var c = document.createElement("script");
            c.setAttribute("type", "text/javascript"), c.setAttribute("src", a);
        } else if ("css" == b) {
            var c = document.createElement("link");
            c.setAttribute("rel", "stylesheet"), c.setAttribute("type", "text/css"), c.setAttribute("href", a);
        }
        "undefined" != typeof c && document.getElementsByTagName("head")[0].appendChild(c);
    },
        list_cart_variants = [],
        SCASettings = {
            loadSettings: function (a, b) {
                a("#biz-qv-detail").html(settings.view_detail_text);
                a("#biz-qv-cartform .biz-qv-product-options")
                        .append('<div id="biz-qv-addcart-msg" class="biz-qv-addcart-msg" style="position: absolute !important; margin-top:15px"></div>'),
                    void 0 != b.cart_notify_add_format && void 0 != b.cart_notify_in_format && (product_in_cart = b.cart_notify_in_format.replace("*", '<a href="/cart"  class="biz-qv-msg-cart-link">')
                        .replace("%", "</a>"), product_added = b.cart_notify_add_format.replace("*", '<a href="/cart"  class="biz-qv-msg-cart-link">')
                        .replace("%", "</a>"));
                var c = ".fancyox-view-detail .zoomWrapper img {  max-width:" + b.img_main_width + "px" + " !important ; max-height:" + b.img_main_width + "px" + " !important ;   }",
                    d = document.head || document.getElementsByTagName("head")[0],
                    e = document.createElement("style");
                if (void 0 != b.cart_color) {
                    var f = " a.biz-qv-cartbtn-config, input.biz-qv-cartbtn-config {background:none repeat scroll 0 0 " + b.cart_color + " !important;}";
                    c += f, a(".biz-qv-cartbtn")
                        .addClass("biz-qv-cartbtn-config");
                }
                if (void 0 != b.sale_icon_color) {
                    var g = "  .biz-qv-sale-settings {background-color:" + b.sale_icon_color + " !important;}";
                    c += g, a("#biz-qv-sale")
                        .addClass("biz-qv-sale-settings");
                }
                if (void 0 != b.link_color) {
                    var g = "  #biz-qv-right a {color:" + b.link_color + ";}";
                    c += g;
                }
                if (void 0 != b.title_color) {
                    var g = "  #biz-qv-title strong {color:" + b.title_color + ";}";
                    c += g;
                }
                e.type = "text/css", e.styleSheet ? e.styleSheet.cssText = c : e.appendChild(document.createTextNode(c)), d.appendChild(e);
                var h = a(".biz-qv-button"),
                i = h.parent();

                i.parent().addClass("biz-qv-image"),
                    h.text(b.bnt_text),
                    h.hover(function () {
                        //console.log("hover in");
                        a(this)
                            .css({
                                color: b.bnt_text_hover,
                                "background-color": b.bnt_color_hover
                            });
                    },
                        function () {
                            //console.log("hover out");
                            a(this)
                                .css({
                                    color: b.btn_text_color,
                                    "background-color": b.bnt_color
                                });
                        });

                h.css({
                    "font-family": "auto" != b.bnt_text_font ? b.bnt_text_font : "",
                    "font-size": b.bnt_text_font_size,
                    top: "50%",
                    left: (50) + "%",
                    color: b.btn_text_color,
                    "background-color": b.bnt_color
                }),
        a(".biz-qv-image").hover(function () {
            a(".biz-qv-button", this).parent().show();
        }, function () {
            a(".biz-qv-button", this).parent().hide();
        });

            }
        },
        SCABase64 = {
            _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",
            encode: function (a) {
                var c,
                    d,
                    e,
                    f,
                    g,
                    h,
                    i,
                    b = "",
                    j = 0;
                for (a = SCABase64._utf8_encode(a) ; j < a.length;) c = a.charCodeAt(j++), d = a.charCodeAt(j++), e = a.charCodeAt(j++), f = c >> 2, g = (3 & c) << 4 | d >> 4, h = (15 & d) << 2 | e >> 6, i = 63 & e, isNaN(d) ? h = i = 64 : isNaN(e) && (i = 64), b = b + this._keyStr.charAt(f) + this._keyStr.charAt(g) + this._keyStr.charAt(h) + this._keyStr.charAt(i);
                return b;
            },
            decode: function (a) {
                var c,
                    d,
                    e,
                    f,
                    g,
                    h,
                    i,
                    b = "",
                    j = 0;
                for (a = a.replace(/[^A-Za-z0-9\+\/\=]/g, "") ; j < a.length;) f = this._keyStr.indexOf(a.charAt(j++)), g = this._keyStr.indexOf(a.charAt(j++)), h = this._keyStr.indexOf(a.charAt(j++)), i = this._keyStr.indexOf(a.charAt(j++)), c = f << 2 | g >> 4, d = (15 & g) << 4 | h >> 2, e = (3 & h) << 6 | i, b += String.fromCharCode(c), 64 != h && (b += String.fromCharCode(d)), 64 != i && (b += String.fromCharCode(e));
                return b = SCABase64._utf8_decode(b);
            },
            _utf8_encode: function (a) {
                a = a.replace(/\r\n/g, "\n");
                for (var b = "", c = 0; c < a.length; c++) {
                    var d = a.charCodeAt(c);
                    128 > d ? b += String.fromCharCode(d) : d > 127 && 2048 > d ? (b += String.fromCharCode(192 | d >> 6), b += String.fromCharCode(128 | 63 & d)) : (b += String.fromCharCode(224 | d >> 12), b += String.fromCharCode(128 | 63 & d >> 6), b += String.fromCharCode(128 | 63 & d));
                }
                return b;
            },
            _utf8_decode: function (a) {
                for (var b = "", c = 0, d = c1 = c2 = 0; c < a.length;) d = a.charCodeAt(c), 128 > d ? (b += String.fromCharCode(d), c++) : d > 191 && 224 > d ? (c2 = a.charCodeAt(c + 1), b += String.fromCharCode((31 & d) << 6 | 63 & c2), c += 2) : (c2 = a.charCodeAt(c + 1), c3 = a.charCodeAt(c + 2), b += String.fromCharCode((15 & d) << 12 | (63 & c2) << 6 | 63 & c3), c += 3);
                return b;
            }
        },
        settings,
        moneyFormat,
        add_to_cart_text,
        unavailable_text = "Unavailable",
        noimage,
        loadScript = function (a, b) {
            var c = document.createElement("script");
            c.type = "text/javascript", c.readyState ? c.onreadystatechange = function () {
                ("loaded" == c.readyState || "complete" == c.readyState) && (c.onreadystatechange = null, b());
            } : c.onload = function () {
                b();
            }, c.src = a, document.getElementsByTagName("head")[0].appendChild(c);
        },

        initQuickViewContent = function (a) {
            for (var b = '<div class="biz-qv-button-wrap" style="display: none !important;" ><a class="biz-qv-button"  href="#biz-qv-showqv" handle="?" ></a></div>',
                c = a('a[href*="/"]:not([href*=".jp"]):not(form a[href*="/"]):not(.related-products a[href*="/"]):not(.not-biz-qv a[href*="/"]):not([href*=".JP"]):not([href*=".png"]):not([href*=".PNG"])')
                    .has('img[src*="/products/"]:not([class*="not-biz-qv"]), img[src*="/no-image"], img[src*="/noimage"]'),
                d = 0; d < c.length; ++d) {
                var e = c.eq(d),
                    f = e.attr("href")
                        .split("/"),
                    g = f[f.length - 1].split("?")[0];
                null != collection_handle && (g = e.attr("href")
                    .split("?")[0] + ".js");
                
                var h = e.parent();
                
                try {
                    h = findQVContainer(a, e.parent());
                } catch (i) {
                    console.log("error when get product container "), console.log(i);
                }
                (void 0 == h || null == h) && (h = e.parent()), 0 == a(".biz-qv-button", h)
                    .length && h.append(b.replace("?", g));
            }
        },


        collection_handle,
        initSettings = function (a) {
            a = QVBizweb.jQuery, loadProductFromCart(a);
            var b = false;
            
            c = a("#bizqv-metadata");
            
            if (c.length < 1) return false;
            var d = {};
            d.jsondata = c.attr("jsondata"), d.moneyFormat = c.attr("moneyFormat"), d.noimage = c.attr("noimage"), d.autoconfig = c.attr("autoconfig"),
                b = loadData(a, d), b && (onAddCartClicked(a), displayQuickView(a));
            return b;

            //return a.ajax({
            //    dataType: "json"
            //    , url: "/index?view=sca.quickviewpro"
            //    , contentType: "application/json; charset=utf-8"
            //    , success: function (c) {
            //        b = loadData(a, c), b && (onAddCartClicked(a), displayQuickView(a))
            //    }
            //    , error: function () {
            //        console.log("cant  load metadata and try with html");
            //        var c = a("#scaqv-metadata");
            //        if (c.length < 1) return false;
            //        var d = {};
            //        d.jsondata = c.attr("jsondata"), d.moneyFormat = c.attr("moneyFormat"), d.noimage = c.attr("noimage"), d.autoconfig = c.attr("autoconfig"),
            //        b = loadData(a, d), b && (onAddCartClicked(a), displayQuickView(a))
            //    }
            //}), b
        },

        getProductJson = function (a, b) {
            var c; //= null != collection_handle ? b : "/products/" + b + ".js";
            return c = null != collection_handle ? b : "/products/" + b + ".js", a.ajax({
                dataType: "json",
                url: c,
                async: false
            }).responseText;
        },

        displayQuickView = function (a) {
            a = QVBizweb.jQuery;
            var b = false,
                c = 9999,
                d = 9999,
                e = parseInt(settings.wd_width, 10) || 720,
                f = parseInt(settings.wd_height, 10) || 200;
            ("auto" == settings.wd_width || "auto" == settings.wd_height) && (b = true, c = e), "auto" != settings.wd_height && (d = f),
                a(".biz-qv-button, .custom-qv-button").scafancybox({
                    arrows: false,
                    openEffect: "elastic",
                    scrolling: "no",
                    maxHeight: d,
                    maxWidth: c,
                    autoSize: b,
                    minHeight: f,
                    minWidth: e,
                    title: null,
                    helpers: {
                        overlay: {
                            locked: false
                        }
                    },
                    beforeLoad: function () {
                        loadProductFromCart(a), cleanTemplate(a, a("#biz-qv-showqv")), a("#biz-qv-addcart-msg")
                            .hide(), a("#biz-qv-sale")
                            .addClass("biz-qv-hidden");
                    },
                    afterShow: function () {
                        var b = a(this.element);
                        b.scashowLoading();
                        var c, d = b.attr("handle");
                        if (void 0 != d) {
                            var e = getProductJson(a, a.trim(d));
                            c = a.parseJSON(e);
                            //c = a.parseJSON(e);
                            var f = [];
                            a.each(c.options, function (a, b) {
                                f[a] = b.name;
                            }),
                                c.options = f;
                        } else if (a('span[class="biz-qv-handle"]', b.parent())
                            .length > 0) {
                            d = a('span[class="biz-qv-handle"]', b.parent());
                            var e = getProductJson(a, a.trim(d.html()));
                            c = a.parseJSON(e);
                            var f = [];
                            a.each(c.options, function (a, b) {
                                f[a] = b.name;
                            }),
                                c.options = f;
                        } else d = a("span", b.parent()), c = a.parseJSON(a.trim(d.html()));
                        try {
                            c = freegifts_filter(a, c), c = buyx_product_json(a, c);
                        } catch (g) {
                            console.log(g);
                        }
                        var h = a("#biz-qv-left");
                        createZoomContainer(a, c, h),
                            createGallery(a, c, h),
                            QVBizweb.preload(c.images),
                            QVBizweb.preload(c.images, "large");
                        var i = a("#biz-qv-right");
                        createTitle(a, c, i), createPrice(a, c, i), createDesc(a, c, i), createDetail(a, c, i, d), createCartForm(a, c, i);

                        var j = new Image;
                        j.onload = function () {
                            var b = j.height,
                                c = 10,
                                d = setInterval(function () {
                                    j = new Image, j.src = a("#biz-qv-zoomImg")
                                        .attr("src"), b = j.height, --c, (0 == c || b > 0) && (window.clearInterval(d), zoomAllProduct(a), a("#biz-qv-zoomcontainer")
                                        .outerHeight() < a("#biz-qv-zoomImg")
                                        .outerHeight() && a("#biz-qv-zoomcontainer")
                                        .height(a("#biz-qv-zoomImg")
                                            .outerHeight()), "auto" == settings.wd_width || "auto" == settings.wd_height ? a.scafancybox.scaupdate() : (a("#biz-qv-right")
                                        .outerHeight() > a("#biz-qv-left")
                                        .outerHeight() && a("#biz-qv-left")
                                        .outerHeight(a("#biz-qv-right")
                                            .outerHeight()), a.scafancybox.hideLoading()));
                                }, 300);
                        }, j.onerror = function () {
                            console.error("Cannot load image"), a.scafancybox.hideLoading();
                        }, j.src = a("#biz-qv-zoomImg")
                            .attr("src");
                    },
                    afterClose: function () {
                        a.scafancybox.hideLoading();
                    }
                });
        },
        zoomAllProduct = function (a) {
            function b(a) {
                a("#biz-qv-zoomImg")
                    .elevateZoom({
                        gallery: "biz-qv-galleryid",
                        zoomWindowOffetx: 10,
                        borderSize: 1,
                        scrollZoom: true,
                        cursor: "pointer"
                    });
            }

            b(a);
        },
        onAddCartClicked = function ($) {
            function updateCartcount(a) {
                var b = parseInt($('[name="quantity"]', a)
                        .val(), 10) || 1,
                    c = parseInt($(settings.cartcount)
                        .text(), 10) || 0,
                    d = c + b;
                return $(settings.cartcount).text(d), $(settings.cartcount).show(), b;
            }

            function updateCartTotal() {
                $.getJSON("/cart.js", function (a) {
                    $(settings.cart_total)
                        .html(QVBizweb.formatMoney(a.total_price, moneyFormat)), $(settings.cart_total)
                        .show();
                });
            }

            function updateCart(a, b) {
                console.log(b), $.ajax({
                    type: "get",
                    cache: false,
                    async: false,
                    url: b,
                    success: function (b) {
                        var c = $("<div/>").html(b);
                        $.each(a.split("|"), function (a, b) {
                            var d = $.trim(b), e = $(d, c);
                            $(d)
                                .empty(), $(d)
                                .append(e.html());
                        });
                    },
                    error: function () {
                        console.log("add to cart error");
                    }
                });
            }

            function addItem(a, b) {
                $.ajax({
                    type: "POST",
                    url: "/cart/add.js",
                    dataType: "json",
                    data: b.serialize(),
                    success: scaonSuccess(b),
                    error: scaonError
                })
                    .done(function () {
                        if (Bizweb) {
                            Bizweb.getCart(function (cart) {
                                Bizweb.updateCartFromForm(cart, 'cart-sidebar');
                            });
                        }
                        var b = window.location.protocol + "//" + window.location.host + window.location.pathname, c = settings.cartcount + "|" + settings.cart_total;
                        updateCart(c, b);
                    });
            }

            //Jquery event
            $(".biz-qv-cartbtn")
                .click(function (a) {

                    var b = $(this), c = $("#biz-qv-add-item-form");
                    $(b).prop("disabled", true), a.preventDefault(), addItem("biz-qv-add-item-form", c);

                    //if ("no" == settings.cart_go) {
                    //    var b = $(this), c = $("#biz-qv-add-item-form");
                    //    $(b).prop("disabled", true), a.preventDefault(), addItem("biz-qv-add-item-form", c);
                    //} else {
                    //    alert("cart go != no");
                    //    var c = $("#biz-qv-add-item-form");
                    //    c.attr("action", "/cart/add"), c.submit();
                    //}
                });

            var scaonSuccess = function (a) {
                $("#biz-qv-addcart-msg").hide(),
                $("#biz-qv-addcart-msg").html(product_added),
                $("#biz-qv-addcart-msg").fadeIn(700, function () {
                    var b = $(".biz-qv-cartbtn", a);
                    b.removeAttr("disabled");
                });
            },
                scaonError = function (XMLHttpRequest, textStatus) {
                    var data = eval("(" + XMLHttpRequest.responseText + ")");
                    data.message ? alert(data.message + "(" + data.status + "): " + data.description) : alert("Error : " + scafullMessagesFromErrors(data)
                        .join("; ") + "."), $(".biz-qv-cartbtn")
                        .removeAttr("disabled");
                },
                scafullMessagesFromErrors = function (a) {
                    var b = [];
                    return $.each(a, function (a, c) {
                        $.each(c, function (c, d) {
                            b.push(a + " " + d);
                        });
                    }), b;
                };
        },
        $checkVersion = function (a, b) {
            try {
                var c = a.split("."),
                    d = b.split("."),
                    e = 1e8 * parseInt(c[0]) + 1e6 * parseInt(c[1]) + 1e4 * parseInt(c[2]),
                    f = 1e8 * parseInt(d[0]) + 1e6 * parseInt(d[1]) + 1e4 * parseInt(d[2]);
                return e > f ? 1 : f > e ? -1 : 0;
            } catch (g) {
                console.log(g);
            }
            return 1;
        };
    //var started = false;
    //var start = function () {
    //    if (!started) {
    //        started = true;
    isMoblieBrowser() ? console.log("is mobile browser ! exit.") : (loadScript("//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js", function () {
        jQuery191 = jQuery.noConflict(true), QVBizweb.jQuery = jQuery191, jQuery191(document)
            .ready(function () {
                loadScript("//cdnjs.cloudflare.com/ajax/libs/json2/20130526/json2.min.js", function () { });
                
                initSettings(jQuery191);

            });
    }));
    //    }           
    //}

    //start();
}();


////option select
function floatToString(t, e) {
    var o = t.toFixed(e).toString();
    return o.match(/^\.\d+/) ? "0" + o : o;
}

if ("undefined" == typeof Bizweb) var Bizweb = {};
Bizweb.each = function (t, e) {
    for (var o = 0; o < t.length; o++) e(t[o], o);
}, Bizweb.map = function (t, e) {
    for (var o = [], i = 0; i < t.length; i++) o.push(e(t[i], i));
    return o;
},
    Bizweb.arrayIncludes = function (t, e) {
        for (var o = 0; o < t.length; o++)
            if (t[o] == e) return !0;
        return !1;
    },
    Bizweb.uniq = function (t) {
        for (var e = [], o = 0; o < t.length; o++) Bizweb.arrayIncludes(e, t[o]) || e.push(t[o]);
        return e;
    },
    Bizweb.isDefined = function (t) {
        return "undefined" == typeof t ? !1 : !0;
    },
    Bizweb.getClass = function (t) {
        return Object.prototype.toString.call(t).slice(8, -1);
    },
    Bizweb.extend = function (t, e) {
        function o() { }

        o.prototype = e.prototype, t.prototype = new o, t.prototype.constructor = t, t.baseConstructor = e, t.superClass = e.prototype;
    },
    Bizweb.urlParam = function (t) {
        var e = RegExp("[?&]" + t + "=([^&]*)").exec(window.location.search);
        return e && decodeURIComponent(e[1].replace(/\+/g, " "));
    },
    Bizweb.Product = function (t) {
        Bizweb.isDefined(t) && this.update(t);
    },
    Bizweb.Product.prototype.update = function (t) {
        for (property in t) this[property] = t[property];
    },
    Bizweb.Product.prototype.optionNames = function () {
        return "Array" == Bizweb.getClass(this.options) ? this.options : [];
    },
    Bizweb.Product.prototype.optionValues = function (t) {
        if (!Bizweb.isDefined(this.variants)) return null;
        var e = Bizweb.map(this.variants, function (e) {
            var o = "option" + (t + 1);
            return void 0 == e[o] ? null : e[o];
        });
        return null == e[0] ? null : Bizweb.uniq(e);
    },
    Bizweb.Product.prototype.getVariant = function (t) {
        var e = null;
        return t.length != this.options.length ? e : (Bizweb.each(this.variants, function (o) {
            for (var i = !0, r = 0; r < t.length; r++) {
                var n = "option" + (r + 1);
                o[n] != t[r] && (i = !1);
            }
            return 1 == i ? void (e = o) : void 0;
        }), e);
    },
    Bizweb.Product.prototype.getVariantById = function (t) {
        for (var e = 0; e < this.variants.length; e++) {
            var o = this.variants[e];
            if (t == o.id) return o;
        }
        return null;
    },
    Bizweb.money_format = "${{amount}}", QVBizweb.formatMoney = function (t, e) {
        function o(t, e) {
            return "undefined" == typeof t ? e : t;
        }

        function i(t, e, i, r) {
            if (e = o(e, 2), i = o(i, ","), r = o(r, "."), isNaN(t) || null == t) return 0;
            t = (t).toFixed(e);
            var n = t.split("."),
                a = n[0].replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1" + i),
                s = n[1] ? r + n[1] : "";
            return a + s;
        }

        "string" == typeof t && (t = t.replace(".", ""));
        var r = "",
            n = /\{\{\s*(\w+)\s*\}\}/,
            a = e || this.money_format;
        switch (a.match(n)[1]) {
            case "amount":
                r = i(t, 2);
                break;
            case "amount_no_decimals":
                r = i(t, 0);
                break;
            case "amount_with_comma_separator":
                r = i(t, 2, ".", ",");
                break;
            case "amount_no_decimals_with_comma_separator":
                r = i(t, 0, ".", ",");
        }
        return a.replace(n, r);
    },
    Bizweb.OptionSelectors = function (t, e) {
        return this.selectorDivClass = "selector-wrapper", this.selectorClass = "single-option-selector", this.variantIdFieldIdSuffix = "-variant-id",
            this.variantIdField = null, this.historyState = null,
            this.selectors = [],
            this.domIdPrefix = t,
            this.product = new Bizweb.Product(e.product),
            this.onVariantSelected = Bizweb.isDefined(e.onVariantSelected) ? e.onVariantSelected : function () { },
            this.replaceSelector(t),
            this.initDropdown(), e.enableHistoryState && (this.historyState = new Bizweb.OptionSelectors.HistoryState(this)), !0;
    },
    Bizweb.OptionSelectors.prototype.initDropdown = function () {
        var t = {
            initialLoad: !0
        },
            e = this.selectVariantFromDropdown(t);
        if (!e) {
            var o = this;
            setTimeout(function () {
                o.selectVariantFromParams(t) || o.fireOnChangeForFirstDropdown.call(o, t);
            });
        }
    },
    Bizweb.OptionSelectors.prototype.fireOnChangeForFirstDropdown = function (t) {
        this.selectors[0].element.onchange(t);
    },
    Bizweb.OptionSelectors.prototype.selectVariantFromParamsOrDropdown = function (t) {
        var e = this.selectVariantFromParams(t);
        e || this.selectVariantFromDropdown(t);
    },
    Bizweb.OptionSelectors.prototype.replaceSelector = function (t) {
        var e = document.getElementById(t),
            o = e.parentNode;
        Bizweb.each(this.buildSelectors(), function (t) {
            o.insertBefore(t, e);
        }), e.style.display = "none", this.variantIdField = e;
    },
    Bizweb.OptionSelectors.prototype.selectVariantFromDropdown = function (t) {
        var e = document.getElementById(this.domIdPrefix).querySelector("[selected]");
        if (e || (e = document.getElementById(this.domIdPrefix).querySelector('[selected="selected"]')), !e) return !1;
        var o = e.value;
        return this.selectVariant(o, t);
    },
    Bizweb.OptionSelectors.prototype.selectVariantFromParams = function (t) {
        var e = Bizweb.urlParam("variant");
        return this.selectVariant(e, t);
    },
    Bizweb.OptionSelectors.prototype.selectVariant = function (t, e) {
        var o = this.product.getVariantById(t);
        if (null == o) return !1;
        for (var i = 0; i < this.selectors.length; i++) {
            var r = this.selectors[i].element,
                n = r.getAttribute("data-option"),
                a = o[n];
            null != a && this.optionExistInSelect(r, a) && (r.value = a);
        }
        return "undefined" != typeof jQuery ? jQuery(this.selectors[0].element).trigger("change", e) : this.selectors[0].element.onchange(e), !0;
    },
    Bizweb.OptionSelectors.prototype.optionExistInSelect = function (t, e) {
        for (var o = 0; o < t.options.length; o++)
            if (t.options[o].value == e) return !0;
    },
    Bizweb.OptionSelectors.prototype.insertSelectors = function (t, e) {
        Bizweb.isDefined(e) && this.setMessageElement(e), this.domIdPrefix = "product-" + this.product.id + "-variant-selector";
        var o = document.getElementById(t);
        Bizweb.each(this.buildSelectors(), function (t) {
            o.appendChild(t);
        });
    },
    Bizweb.OptionSelectors.prototype.buildSelectors = function () {
        for (var t = 0; t < this.product.optionNames().length; t++) {
            var e = new Bizweb.SingleOptionSelector(this, t, this.product.optionNames()[t], this.product.optionValues(t));
            e.element.disabled = !1, this.selectors.push(e);
        }
        var o = this.selectorDivClass,
            i = this.product.optionNames(),
            r = Bizweb.map(this.selectors, function (t) {
                var e = document.createElement("div");
                if (e.setAttribute("class", o), i.length > 1) {
                    var r = document.createElement("label");
                    r.htmlFor = t.element.id, r.innerHTML = t.name, e.appendChild(r);
                }
                return e.appendChild(t.element), e;
            });
        return r;
    },
    Bizweb.OptionSelectors.prototype.selectedValues = function () {
        for (var t = [], e = 0; e < this.selectors.length; e++) {
            var o = this.selectors[e].element.value;
            t.push(o);
        }
        return t;
    },
    Bizweb.OptionSelectors.prototype.updateSelectors = function (t, e) {
        var o = this.selectedValues(),
            i = this.product.getVariant(o);
        i ? (this.variantIdField.disabled = !1, this.variantIdField.value = i.id) : this.variantIdField.disabled = !0, this.onVariantSelected(i, this, e), null != this.historyState && this.historyState.onVariantChange(i, this, e);
    },
    Bizweb.OptionSelectorsFromDOM = function (t, e) {
        var o = e.optionNames || [],
            i = e.priceFieldExists || !0,
            r = e.delimiter || "/",
            n = this.createProductFromSelector(t, o, i, r);
        e.product = n, Bizweb.OptionSelectorsFromDOM.baseConstructor.call(this, t, e);
    },
    Bizweb.extend(Bizweb.OptionSelectorsFromDOM, Bizweb.OptionSelectors), Bizweb.OptionSelectorsFromDOM.prototype.createProductFromSelector = function (t, e, o, i) {
        if (!Bizweb.isDefined(o)) var o = !0;
        if (!Bizweb.isDefined(i)) var i = "/";
        var r = document.getElementById(t),
            n = r.childNodes,
            a = (r.parentNode, e.length),
            s = [];
        Bizweb.each(n, function (t) {
            if (1 == t.nodeType && "option" == t.tagName.toLowerCase()) {
                var r = t.innerHTML.split(new RegExp("\\s*\\" + i + "\\s*"));
                0 == e.length && (a = r.length - (o ? 1 : 0));
                var n = r.slice(0, a),
                    p = o ? r[a] : "",
                    l = (t.getAttribute("value"), {
                        available: t.disabled ? !1 : !0,
                        id: parseFloat(t.value),
                        price: p,
                        option1: n[0],
                        option2: n[1],
                        option3: n[2]
                    });
                s.push(l);
            }
        });
        var p = {
            variants: s
        };
        if (0 == e.length) {
            p.options = [];
            for (var l = 0; a > l; l++) p.options[l] = "option " + (l + 1);
        } else p.options = e;
        return p;
    },
    Bizweb.SingleOptionSelector = function (t, e, o, i) {
        this.multiSelector = t, this.values = i, this.index = e, this.name = o, this.element = document.createElement("select");
        for (var r = 0; r < i.length; r++) {
            var n = document.createElement("option");
            n.value = i[r], n.innerHTML = i[r], this.element.appendChild(n);
        }
        return this.element.setAttribute("class", this.multiSelector.selectorClass), this.element.setAttribute("data-option", "option" + (e + 1)), this.element.id = t.domIdPrefix + "-option-" + e, this.element.onchange = function (o, i) {
            i = i || {}, t.updateSelectors(e, i);
        }, !0;
    },
    Bizweb.Image = {
        preload: function (t, e) {
            for (var o = 0; o < t.length; o++) {
                var i = t[o];
                this.loadImage(this.getSizedImageUrl(i, e));
            }
        },
        loadImage: function (t) {
            (new Image).src = t;
        },
        switchImage: function (t, e, o) {
            if (t && e) {
                var i = this.imageSize(e.src),
                    r = this.getSizedImageUrl(t.src, i);
                o ? o(r, t, e) : e.src = r;
            }
        },
        imageSize: function (t) {
            var e = t.match(/_(1024x1024|2048x2048|pico|icon|thumb|small|compact|medium|large|grande)\./);
            return null != e ? e[1] : null;
        },
        getSizedImageUrl: function (t, e) {
            if (null == e) return t;
            if ("master" == e) return this.removeProtocol(t);
            var o = t.match(/\.(jpg|jpeg|gif|png|bmp|bitmap|tiff|tif)(\?v=\d+)?$/i);
            if (null != o) {
                var i = t.split(o[0]),
                    r = o[0];
                return this.removeProtocol(i[0] + "_" + e + r);
            }
            return null;
        },
        removeProtocol: function (t) {
            return t.replace(/http(s)?:/, "");
        }
    },
    Bizweb.OptionSelectors.HistoryState = function (t) {
        this.browserSupports() && this.register(t);
    },
    Bizweb.OptionSelectors.HistoryState.prototype.register = function (t) {
        window.addEventListener("popstate", function () {
            t.selectVariantFromParamsOrDropdown({
                popStateCall: !0
            });
        });
    },
    Bizweb.OptionSelectors.HistoryState.prototype.onVariantChange = function (t, e, o) {
        this.browserSupports() && (!t || o.initialLoad || o.popStateCall || window.history.replaceState({}, document.title, "?variant=" + t.id));
    },
    Bizweb.OptionSelectors.HistoryState.prototype.browserSupports = function () {
        return window.history && window.history.replaceState;
    };