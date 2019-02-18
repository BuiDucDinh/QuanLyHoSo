jQueryDD(document).ready(function () {
    var baseUrl = "https://dailydeal.bizwebapps.vn";
    //var baseUrl = "https://dailydeal.bizweb.dev.local";
    var url = baseUrl + "/app/displaycountdown/";

    if (jQueryDD('[name=dd-countdown-box]').length != 0) {
        var countdownBox = jQueryDD('[name=dd-countdown-box]');
        var collectionId = countdownBox[0].id.replace("dd-", "");
        for (var i = 1; i < countdownBox.length; i++) {
            collectionId += ("," + countdownBox[i].id.replace("dd-", ""));
        }
        var noTitle = countdownBox.attr('data-notitle');
        var store = "";
        if (Bizweb != null) {
            store = Bizweb.store;
        }
        jQueryDD.ajax({
            type: 'GET',
            url: url,
            crossDomain: true,
            dataType: 'json',
            data: {
                store: store,
                collectionid: collectionId,
                notitle: noTitle
            },
            success: function (data) {
                if (data != null && data.countdowns!= null) {
                    for (var item in data.countdowns) {
                        var countdownBox = jQueryDD("#dd-" + data.countdowns[item].id);
                        countdownBox.html(data.countdowns[item].content);
                        countdownBox.css("width", data.countdowns[item].width);
                        var endtime = data.countdowns[item].endtime;
                        initializeClock('timer' + data.countdowns[item].id, endtime);
                    }
                }
            }
        });
    }
});
function getTimeRemaining(endtime) {
    var end = new Date(endtime).toUTCString();
    var start = new Date().toUTCString();
    var t = new Date(end) - new Date(start);
    var seconds = Math.floor((t / 1000) % 60);
    var minutes = Math.floor((t / 1000 / 60) % 60);
    var hours = Math.floor((t / (1000 * 60 * 60)) % 24);
    var days = Math.floor(t / (1000 * 60 * 60 * 24));
    return {
        'total': t,
        'days': days,
        'hours': hours,
        'minutes': minutes,
        'seconds': seconds
    };
}
function initializeClock(id, endtime) {
    var clock = document.getElementById(id);
    var daysSpan = clock.querySelector('.days');
    var hoursSpan = clock.querySelector('.hours');
    var minutesSpan = clock.querySelector('.minutes');
    var secondsSpan = clock.querySelector('.seconds');

    function updateClock() {
        var t = getTimeRemaining(endtime);

        daysSpan.innerHTML = t.days;
        hoursSpan.innerHTML = ('0' + t.hours).slice(-2);
        minutesSpan.innerHTML = ('0' + t.minutes).slice(-2);
        secondsSpan.innerHTML = ('0' + t.seconds).slice(-2);

        if (t.total <= 0) {
            clearInterval(timeinterval);
        }
    }

    updateClock();
    var timeinterval = setInterval(updateClock, 1000);
}
function zoom() {
    var previewBlockWidth = $("#preview-block").width();
    var currentBoxWidth = $("#BoxWidth").val();
    var scaleRate = parseFloat(previewBlockWidth) / parseFloat(currentBoxWidth);
    if (scaleRate < 1) {
        $(".preview-box").css("zoom", scaleRate);
        $(".preview-box").css("-moz-transform", "scale(" + scaleRate + ")");
        $(".preview-box").css("-moz-transform-origin", "center left");
    }
}