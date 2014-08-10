function initialize() {

    var mapOptions = {
        center: new google.maps.LatLng(-34.397, 150.644),
        zoom: 8,
        streetViewControl: false,
        mapTypeId: google.maps.MapTypeId.TERRAIN
    };

    google.maps.event.addDomListener(window, 'load', initialize);

    map = new google.maps.Map(document.getElementById("map-canvas"),
                mapOptions);
    setupMarkers();
    setInterval(updateTest, 3000);
}


function updatePage(locations) {
    //alert();
    updateMap(locations);

    updateTable(locations);
}

function updateTable(locations) {
    document.getElementById("PlaneLatitude").innerHTML = locations[0];
    document.getElementById("PlaneLongitude").innerHTML = locations[1];
    document.getElementById("PlaneAltitude").innerHTML = locations[2];
    //document.getElementById("QuadLatitude").innerHTML = locations[3];
    //document.getElementById("QuadLongitude").innerHTML = locations[4];
    //document.getElementById("QuadAltitude").innerHTML = locations[5];

}

function updateMap(locations) {
    updatePositions(locations);
    moveMarkers();
    panMap();
}

function updatePositions(locations) {
    //alert("Updating Positions");
    //var lat = locations[3];
    //var lng = locations[4];
    //quadPos = new google.maps.LatLng(lat, lng);

    lat = locations[0];
    lng = locations[1];
    planePos = new google.maps.LatLng(lat, lng);
}

function moveMarkers() {
    //alert("Moving Markers");
    planeMarker.setPosition(planePos);
    //quadMarker.setPosition(quadPos);

}

function panMap() {
    //var midLat = (quadPos.lat() + planePos.lat()) / 2;
    //var midLng = (planePos.lng() + planePos.lng()) / 2;
    //map.panTo(new google.maps.LatLng(midLat, midLng));
    map.panTo(planePos);
  
}

function setupMarkers() {
    //quadMarker = new google.maps.Marker({
    //    position: quadPos,
    //    map: map,
    //    title: 'Quad',
    //    icon: quadIcon
    //});

    planeMarker = new google.maps.Marker({
        position: planePos,
        map: map,
        title: 'Plane',
        icon: planeIcon
    })
}