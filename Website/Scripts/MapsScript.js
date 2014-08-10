var imageNum = 0;
var initialized = false;

function initialize() {
    if (!initialized) {
        initialized = true;

        var mapOptions = {
            center: new google.maps.LatLng(32.647009,-97.393725),
            zoom: 16,
            streetViewControl: false,
            mapTypeId: google.maps.MapTypeId.TERRAIN
        };

        google.maps.event.addDomListener(window, 'load', initialize);

        map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);

        setupMarkers();
        setInterval(updateTest, 3000);
        setInterval(updateImage, 1000);
    }
}

function writeDebug ( whatToWrite )
{
	var currentValue = document.getElementById("debugConsole").innerHTML;
	document.getElementById("debugConsole").innerHTML = whatToWrite + "<br />" + currentValue;
}
function updateImage()
{
	imageNum++;
	document.getElementById("latestImage").src = "cow.jpg?t=" + new Date().getTime();
}
function updatePage(locations) {
    if (locations[0] != 0) {
        updateMap(locations);
        updateTable(locations);

        var connectedString = "Connected";
        document.getElementById("connectionStatus1").className = "vehicleConnected";
        document.getElementById("connectionStatus1").innerHTML = connectedString;

        document.getElementById("connectionStatus2").className = "vehicleConnected";
        document.getElementById("connectionStatus2").innerHTML = connectedString + "&nbsp;<img src='images/connected.gif' alt='Connected' />";
    }
}

function updateTable(locations) 
{
    document.getElementById("PlaneLatitude").innerHTML = locations[0];
    document.getElementById("PlaneLongitude").innerHTML = locations[1];
    document.getElementById("PlaneAltitude").innerHTML = locations[2];
}

function updateMap(locations) {
    updatePositions(locations);
    moveMarkers();
    panMap();
}

function updatePositions(locations) {
    lat = locations[0];
    lng = locations[1];
    planePos = new google.maps.LatLng(lat, lng);
}

function moveMarkers() {
    planeMarker.setPosition(planePos);
}

function panMap() {
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