<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMarkerMap1.aspx.cs" Inherits="AddMarkerMap" %>

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
    <div id="floating-panel">
        <input onclick="clearMarkers();" type="button" value="Hide Markers">
        <input onclick="showMarkers();" type="button" value="Show All Markers">
        <input onclick="deleteMarkers();" type="button" value="Delete Markers">
        <input onclick="updateMarkers();" type="button" value="Update Markers">
    </div>
    <input id="pac-input" class="controls top60" type="text" placeholder="Enter a location">
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
        <br />
        <button onclick="popup();" id="btnPopup">
            Thêm địa chỉ
        </button>
        <button id="btnDelete" class="edit-btn hidden">
            Xóa địa chỉ
        </button>
    </div>
    <div class="overflow hidden">
        <div style="position: relative">
            <div class="info">
                <button id="btnClose" class="btn-close">X</button>
                <input type="hidden" id="txtIDPopup" />
                <input id="txtName" class="controls edit" type="text" placeholder="Nhập tên"><br />
                <input id="txtAddress" class="controls edit" type="text" placeholder="Nhập địa chỉ"><br />
                <textarea id="txtMoTa" class="controls edit" placeholder="Nhập mô tả" style="max-height: 400px"></textarea>
                <button id="btnUpdate" class="edit-btn">
                    Cập nhật địa chỉ
                </button>
            </div>
        </div>
    </div>
    <script>
        var map;
        var infowindow;
        var markers = [];
        var markerSelected;
        function initMap() {
            $.ajax({
                type: "POST",
                url: "/Control/Map/AddMarkerMap.aspx/loadMap",
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
                        infowindowContent.children['txtID'].value = "0";
                        infowindowContent.children['place-address'].textContent = place.formatted_address;
                        infowindowContent.children['place-des'].textContent = "";
                        infowindowContent.children['lat'].value = place.geometry.location.lat();
                        infowindowContent.children['lng'].value = place.geometry.location.lng();
                        infowindowContent.children['btnPopup'].textContent = "Thêm địa điểm";
                        infowindow.open(map, marker);
                        $('#btnDelete').addClass('hidden');

                        google.maps.event.addListener(marker, 'click', function () {
                            infowindowContent.children['place-name'].textContent = place.name;
                            infowindowContent.children['txtID'].value = "0";//place.place_id;
                            infowindowContent.children['place-address'].textContent = place.formatted_address;
                            infowindowContent.children['place-des'].textContent = "";
                            infowindowContent.children['btnPopup'].textContent = "Thêm địa điểm";
                            infowindowContent.children['lat'].value = place.geometry.location.lat();
                            infowindowContent.children['lng'].value = place.geometry.location.lng();
                            $('#btnUpdate').html('Thêm địa điểm');
                            $('#btnDelete').addClass('hidden');
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
            var pinImage = new google.maps.MarkerImage("http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|FE7569");
            var marker = new google.maps.Marker({
                position: position,
                map: map,
                icon: pinImage
            });
            markers.push(marker);
            google.maps.event.addListener(marker, 'click', function () {
                markerSelected = marker;

                var infowindowContent = document.getElementById('infowindow-content');
                if (infowindowContent == null) {
                    var infoContent = '<input type="hidden" id="txtID" />' +
                    '<input type="hidden" id="lat" />' +
                    '<input type="hidden" id="lng" />' +
                    '<span id="place-name" class="title"></span><br>' +
                    '<span id="place-address"></span><br />' +
                    '<span id="place-des"></span><br />' +
                    '<button onclick="popup();" id="btnPopup">Thêm địa chỉ </button>' +
                    '<button id="btnDelete" class="edit-btn hidden">Xóa địa chỉ</button>';
                    var div = document.createElement('div');
                    div.id = 'infowindow-content';
                    div.innerHTML = infoContent;
                    document.body.appendChild(div);
                    infowindowContent = document.getElementById('infowindow-content');
                }
                infowindowContent.children['place-name'].textContent = location.name
                infowindowContent.children['txtID'].value = location.key;
                infowindowContent.children['place-address'].textContent = location.address;
                infowindowContent.children['place-des'].textContent = location.content;
                infowindowContent.children['lat'].value = location.lat;
                infowindowContent.children['lng'].value = location.lng;
                infowindowContent.children['btnPopup'].textContent = "Sửa địa điểm";
                infowindow.open(map, this);
                $('#btnDelete').removeClass('hidden');
            });
        }
        function popup() {
            $('.overflow').removeClass('hidden');
            if ($('#txtID').val() != $('#txtIDPopup').val() || $('#txtID').val() == 0) {
                $('#txtIDPopup').val($('#txtID').val());
                $('#txtName').val($('#place-name').text());
                $('#txtAddress').val($('#place-address').text());
                $('#txtMoTa').val($('#place-des').text());
            }
        }
        $('#btnClose').click(function () {
            $('.overflow').addClass('hidden');
        });
        $('#btnDelete').click(function () {
            var obj = {};
            obj.id = $('#txtID').val();
            if (obj.id != 0) {
                var retVal = confirm("Bạn có chắc muốn xóa địa điểm này ?");
                if (retVal == true) {
                    $.ajax({
                        type: "POST",
                        url: "/Control/Map/AddMarkerMap.aspx/deleteMarker",
                        data: JSON.stringify(obj),
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            markerSelected.setMap(null);
                            $('.overflow').addClass('hidden');
                        },
                        error: function (xhr, status, error) {
                            $('.error').html(xhr.responseText);
                            //alert(xhr.responseText);
                        }
                    });
                }
            }
        });
        $('#btnUpdate').click(function () {
            var obj = {};
            var marker = {};
            marker.key = $('#txtIDPopup').val()
            marker.name = $('#txtName').val();
            marker.address = $('#txtAddress').val();
            marker.content = $('#txtMoTa').val();
            marker.lat = $('#lat').val();
            marker.lng = $('#lng').val();
            obj.marker = marker;
            $.ajax({
                type: "POST",
                url: "/Control/Map/AddMarkerMap.aspx/updateMarker",
                data: JSON.stringify(obj),
                async: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('#pac-input').val("");
                    $('#txtIDPopup').val("");
                    $('#txtName').val("");
                    $('#txtAddress').val("");
                    $('#txtMoTa').val("");
                    $('.overflow').addClass('hidden');
                    addMarker(marker);
                    alert("Thêm địa điểm thành công");
                },
                error: function (xhr, status, error) {
                    $('.error').html(xhr.responseText);
                    //alert(xhr.responseText);
                }
            });
        });


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
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD_72FyxCCTTLUco3O1ARstHzh9_0UTnDc&libraries=places&callback=initMap" async defer></script>
</body>
</html>
