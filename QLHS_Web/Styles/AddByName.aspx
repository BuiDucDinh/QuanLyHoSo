<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddByName.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html>
<html>
<head>
    <title>Place ID Finder</title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <script src="/Template/js/jquery-2.0.3.min.js"></script>
    <style>
        #map {
            height: 100%;
        }
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #floating-panel {
            position: absolute;
            top: 10px;
            left: 50%;
            z-index: 5;
            background-color: #fff;
            padding: 5px;
            border: 1px solid #999;
            text-align: center;
            font-family: 'Roboto','sans-serif';
            line-height: 30px;
            padding-left: 10px;
            transform: translateX(-50%);
        }

        .controls {
            background-color: #fff;
            border-radius: 2px;
            border: 1px solid transparent;
            box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
            box-sizing: border-box;
            font-family: Roboto;
            font-size: 15px;
            font-weight: 300;
            height: 29px;
            /*margin-left: 17px;*/
            margin-top: 60px;
            outline: none;
            padding: 0 11px 0 13px;
            text-overflow: ellipsis;
            width: 400px;
        }

            .controls:focus {
                border-color: #4d90fe;
            }

        .title {
            font-weight: bold;
        }

        #infowindow-content {
            display: none;
        }

        #map #infowindow-content {
            display: inline;
        }

        .hidden {
            display: none;
        }

        .overflow {
            position: absolute;
            width: 100%;
            height: 100%;
            background: rgba(0,0,0,.5);
        }

        .info {
            width: 50%;
            margin: 30px auto;
            background: #fff;
        }
    </style>
</head>
<body>
    <div id="floating-panel">
        <input onclick="clearMarkers();" type="button" value="Hide Markers">
        <input onclick="showMarkers();" type="button" value="Show All Markers">
        <input onclick="deleteMarkers();" type="button" value="Delete Markers">
        <input onclick="updateMarkers();" type="button" value="Update Markers">
    </div>
    <input id="pac-input" class="controls" type="text" placeholder="Enter a location">
    <div id="map"></div>
    <div id="infowindow-content">
        <input type="hidden" id="txtID" />
        <span id="place-name" class="title"></span>
        <br>
        <%--Place ID <span id="place-id"></span>
        <br>--%>
        <span id="place-address"></span>
        <br />
        <button onclick="popup();" id="btnPopup">
            Thêm địa chỉ
        </button>
    </div>
    <div class="overflow hidden">
        <div class="info">
            <input type="hidden" id="txtIDPopup" />
            <input id="txtName" class="controls" type="text" placeholder="Nhập tên">
            <input id="txtMoTa" class="controls" type="text" placeholder="Nhập mô tả">
            <button onclick="updateMarkers();" id="btnUpdate">
                Thêm địa chỉ
            </button>
        </div>
    </div>
    <script>
        var map;
        var infowindow;
        var markers = [];
        function initMap() {
            $.ajax({
                type: "POST",
                url: "/Styles/AddByName.aspx/loadMap",
                async: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var haightAshbury = data.d;
                    var position = { lat: haightAshbury[0].lat, lng: haightAshbury[0].lng };
                    map = new google.maps.Map(document.getElementById('map'), {
                        zoom: 12,
                        center: position,
                    });

                    var input = document.getElementById('pac-input');

                    var autocomplete = new google.maps.places.Autocomplete(input);
                    autocomplete.bindTo('bounds', map);

                    map.controls[google.maps.ControlPosition.TOP_CENTER].push(input);

                    infowindow = new google.maps.InfoWindow();
                    var infowindowContent = document.getElementById('infowindow-content');
                    infowindow.setContent(infowindowContent);

                    var pinImage = new google.maps.MarkerImage("http://www.googlemapsmarkers.com/v1/009900/");
                    var marker = new google.maps.Marker({
                        map: map,
                        icon: pinImage
                    });

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
                        infowindowContent.children['txtID'].value = "0";
                        infowindowContent.children['place-address'].textContent = place.formatted_address;
                        infowindowContent.children['btnPopup'].textContent = "Thêm địa điểm";
                        infowindow.open(map, marker);

                        google.maps.event.addListener(marker, 'click', function () {
                            infowindowContent.children['place-name'].textContent = place.name;
                            infowindowContent.children['txtID'].value = "0";//place.place_id;
                            infowindowContent.children['place-address'].textContent = place.formatted_address;
                            infowindowContent.children['btnPopup'].textContent = "Thêm địa điểm";
                            infowindow.open(map, marker);
                        });
                    });

                    for (var i = 0; i < haightAshbury.length; i++) {
                        addMarker(haightAshbury[i]);
                    }
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
            var position = { lat: location.lat, lng: location.lng };
            var marker = new google.maps.Marker({
                position: position,
                map: map
            });
            markers.push(marker);
            google.maps.event.addListener(marker, 'click', function () {
                var infowindowContent = document.getElementById('infowindow-content');
                infowindowContent.children['txtID'].value = location.key;
                infowindowContent.children['place-name'].textContent = location.name;
                infowindowContent.children['place-address'].textContent = location.content;
                infowindowContent.children['btnPopup'].textContent = "Sửa địa điểm";
                infowindow.open(map, this);
            });
        }
        function popup() {
            $('.overflow').removeClass('hidden');
        }
        function updateMarkers(map) {
            var obj = {};
            var lst = new Array();
            for (var i = 0; i < markers.length; i++) {
                var marker = markers[i];
                var item = {};
                item.key = $('#id').val();
                item.name = "";
                item.content = "";
                item.lat = marker.position.lat();
                item.lng = marker.position.lng();
                lst.push(item);
            }
            obj.lst = lst;
            $.ajax({
                type: "POST",
                url: "/Styles/AddByName.aspx/updateMap",
                data: JSON.stringify(obj),
                async: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert('seccess');
                },
                error: function (xhr, status, error) {
                    $('.error').html(xhr.responseText);
                    //alert(xhr.responseText);
                }
            });
        }

        // Sets the map on all markers in the array.
        function setMapOnAll(map) {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(map);
            }
        }
        // Removes the markers from the map, but keeps them in the array.
        function clearMarkers() {
            setMapOnAll(null);
        }

        // Shows any markers currently in the array.
        function showMarkers() {
            setMapOnAll(map);
        }

        // Deletes all markers in the array by removing references to them.
        function deleteMarkers() {
            clearMarkers();
            markers = [];
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD_72FyxCCTTLUco3O1ARstHzh9_0UTnDc&libraries=places&callback=initMap"
        async defer></script>
</body>
</html>
