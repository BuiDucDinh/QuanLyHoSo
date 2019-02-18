<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Map.ascx.cs" Inherits="Control_Map_Map" %>

<div style="height: 110px">
    <div id="ImageManager">
        <ext:ImageButton runat="server" ID="btnShowMap" ImageUrl="/images/select_image_vi.jpg" FieldLabel="Thêm bản đồ">
            <Listeners>
                <Click Handler="#{wdMap}.show()" />
            </Listeners>
        </ext:ImageButton>
    </div>
    <ext:Window runat="server" ID="wdMap" Hidden="true" Title="Tài liệu" Icon="ApplicationForm"
        DefaultButton="0" Border="false" AutoScroll="false" Maximizable="true" Collapsible="true"
        MinWidth="680" MinHeight="500" Modal="true" Padding="3" Resizable="false">
        <AutoLoad Url="~/Control/Map/AddMarkerMap.aspx" Mode="IFrame" ShowMask="true" />
        <Listeners>
            <Hide Fn="getMarker" />
        </Listeners>
    </ext:Window>
    <ext:Hidden runat="server" ID="txtMarkers" ClientIDMode="Static" />
    <div class="error"></div>
</div>
