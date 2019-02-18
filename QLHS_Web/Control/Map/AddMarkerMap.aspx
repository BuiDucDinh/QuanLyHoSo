<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMarkerMap.aspx.cs" Inherits="AddMarkerMap" %>

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
    <input id="pac-input" class="controls top60" style="width:300px" type="text" placeholder="Nhập địa chỉ">
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
                infowindowContent.children['place-name'].textContent = location.Ten
                infowindowContent.children['txtID'].value = location.ID;
                infowindowContent.children['place-address'].textContent = location.DiaChi;
                infowindowContent.children['place-des'].textContent = location.MoTa;
                infowindowContent.children['lat'].value = location.Lat;
                infowindowContent.children['lng'].value = location.Lng;
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
            var qString = window.location.href.split("?")[1];
            var obj = {};
            var marker = {};
            marker.ID = $('#txtIDPopup').val()
            marker.DiSanID = qString.split('=')[1].split('&')[0];
            marker.DiaChi = $('#txtAddress').val();
            marker.MoTa = $('#txtMoTa').val();
            marker.Lat = $('#lat').val();
            marker.Lng = $('#lng').val();
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
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD_72FyxCCTTLUco3O1ARstHzh9_0UTnDc&libraries=places&callback=initMap" async defer></script>
</body>
</html>
