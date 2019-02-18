<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="Map" %>

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
    <input id="pac-input" class="controls top60" type="text" placeholder="Enter a location">
    <div id="map"></div>
    <div id="infowindow-content">
        <span id="place-name" class="title"></span>
        <br>
        <%--Place ID <span id="place-id"></span>
        <br>--%>
        <span id="place-address"></span>
        <br />
        <span id="place-des"></span>
        <br />
    </div>
    <script>
        var map;
        var infowindow;
        function initMap() {
            var qString = "?" + window.location.href.split("?")[1];
            $.ajax({
                type: "POST",
                url: "/Control/Map/AddMarkerMap.aspx/loadMap" + qString,
                async: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var haightAshbury = data.d;
                    var position;
                    if (haightAshbury.length > 0) {
                        position = { lat: haightAshbury[0].Lat, lng: haightAshbury[0].Lng };
                        map = new google.maps.Map(document.getElementById('map'), {
                            zoom: 12,
                            center: position,
                        });
                        for (var i = 0; i < haightAshbury.length; i++) {
                            addMarker(haightAshbury[i]);
                        }
                    }
                    else {
                        position = { lat: 20.0746021, lng: 105.606621 };
                        map = new google.maps.Map(document.getElementById('map'), {
                            zoom: 10,
                            center: position,
                        });
                    }

                    var input = document.getElementById('pac-input');

                    var autocomplete = new google.maps.places.Autocomplete(input);
                    autocomplete.bindTo('bounds', map);

                    map.controls[google.maps.ControlPosition.TOP_CENTER].push(input);

                    //var pinImage = new google.maps.MarkerImage("http://www.googlemapsmarkers.com/v1/009900/");
                    var pinImage = new google.maps.MarkerImage("http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|34ba46");
                    var marker = new google.maps.Marker({
                        map: map,
                        icon: pinImage
                    });

                    infowindow = new google.maps.InfoWindow();
                    var infowindowContent = document.getElementById('infowindow-content');
                    infowindow.setContent(infowindowContent);

                    autocomplete.addListener('place_changed', function () {
                        var place = autocomplete.getPlace();
                        if (!place.geometry) {
                            return;
                        }

                        if (place.geometry.viewport) {
                            map.fitBounds(place.geometry.viewport);
                        } else {
                            map.setCenter(place.geometry.location);
                            map.setZoom(16);
                        }

                        // Set the position of the marker using the place ID and location.
                        marker.setPlace({
                            placeId: place.place_id,
                            location: place.geometry.location
                        });
                        marker.setVisible(true);

                        infowindowContent.children['place-name'].textContent = place.name;
                        infowindowContent.children['place-address'].textContent = place.formatted_address;
                        infowindowContent.children['place-des'].textContent = "";
                        infowindow.open(map, marker);
                        $('#btnDelete').addClass('hidden');

                        google.maps.event.addListener(marker, 'click', function () {
                            infowindowContent.children['place-name'].textContent = place.name;
                            infowindowContent.children['place-address'].textContent = place.formatted_address;
                            infowindowContent.children['place-des'].textContent = "";
                            infowindow.open(map, marker);
                        });
                    });

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

            google.maps.event.addListener(marker, 'click', function () {
                var infowindowContent = document.getElementById('infowindow-content');
               
                infowindowContent.children['place-name'].textContent = location.Ten
                infowindowContent.children['place-address'].textContent = location.DiaChi;
                infowindowContent.children['place-des'].textContent = location.MoTa;
                infowindow.open(map, this);
            });
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD_72FyxCCTTLUco3O1ARstHzh9_0UTnDc&libraries=places&callback=initMap" async defer></script>
</body>
</html>
