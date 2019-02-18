<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BigMap.aspx.cs" Inherits="BigMap" %>

<!DOCTYPE html>
<html>
<head>
    <title>Place ID Finder</title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <script src="/Template/js/jquery-2.0.3.min.js"></script>
    <link href="/css/MapStyles.css" rel="stylesheet" />
</head>
<body>
    <div id="map"></div>
    <div id="infowindow-content">
        <input type="hidden" id="txtID" />
        <input type="hidden" id="lat" />
        <input type="hidden" id="lng" />
        <span id="place-name" class="title"></span>
        <br>
        <%--Place ID <span id="place-id"></span>
        <br>--%>
        <span id="place-address"></span>
        <br />
        <span id="place-des"></span>
        <a href="#" target="_blank" id="link"></a>
        <br />
    </div>

    <script>
        var map;
        var infowindow;
        var markers = [];
        var markerSelected;
        function initMap() {
            var qString = "?" + window.location.href.split("?")[1];
            $.ajax({
                type: "POST",
                url: "/Template/Controls/BigMap.aspx/loadMap" + qString,
                async: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var haightAshbury = data.d;
                    var position;
                    if (haightAshbury.length > 0) {
                        position = { lat: haightAshbury[0].Lat, lng: haightAshbury[0].Lng };
                        map = new google.maps.Map(document.getElementById('map'), {
                            zoom: 11,
                            center: position,
                        });
                        for (var i = 0; i < haightAshbury.length; i++) {
                            addMarker(haightAshbury[i]);
                        }
                    }
                    else {
                        position = { lat: 20.0746021, lng: 105.606621 };
                        map = new google.maps.Map(document.getElementById('map'), {
                            zoom: 11,
                            center: position,
                        });
                    }

                    infowindow = new google.maps.InfoWindow();
                    var infowindowContent = document.getElementById('infowindow-content');
                    infowindow.setContent(infowindowContent);


                    map.addListener('click', function (event) {
                        infowindow.close();
                    });
                },
                error: function (err) {
                    alert('lỗi t');
                }
            });
        }
        function addMarker(location) {
            var position = { lat: location.Lat, lng: location.Lng };
            var pinImage = new google.maps.MarkerImage("http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|FE7569");
            var marker = new google.maps.Marker({
                position: position,
                map: map,
                icon: pinImage
            });
            markers.push(marker);
            google.maps.event.addListener(marker, 'mouseover', function () {
                markerSelected = marker;

                var infowindowContent = document.getElementById('infowindow-content');
                if (infowindowContent == null) {
                    var infoContent = '<span id="place-name" class="title"></span><br>' +
                    '<span id="place-address"></span><br />' +
                    '<span id="place-des"></span><br />' +
                    '<a href="#" id="link"></a><br />';
                    var div = document.createElement('div');
                    div.id = 'infowindow-content';
                    div.innerHTML = infoContent;
                    document.body.appendChild(div);
                    infowindowContent = document.getElementById('infowindow-content');
                }
                infowindowContent.children['place-name'].textContent = location.Ten
                infowindowContent.children['place-address'].textContent = location.DiaChi;
                infowindowContent.children['place-des'].textContent = location.MoTa;
                infowindowContent.children['link'].href = location.Link;
                infowindowContent.children['link'].textContent = "Xem chi tiết";
                infowindow.open(map, this);
            });
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD_72FyxCCTTLUco3O1ARstHzh9_0UTnDc&libraries=places&callback=initMap" async defer></script>
</body>
</html>
