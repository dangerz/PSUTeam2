<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="Stylesheet" href="Styles/Site.css" type="text/css" />
    <title>Multi-UAV Area Reconnaisance System</title>
</head>
    <script type="text/jscript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.csv-0.71.js"></script>
    <script type="text/javascript" src="Scripts/MapsScript.js"></script>
    <script type="text/javascript" src="Scripts/UpdateScripts.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAq3lhmAz62oIoRN0gjpIwJVsAS0Ez_e20"></script>     	
    <script type="text/javascript">
        var map;
        var quadPos = new google.maps.LatLng(32.647009,-97.393725);
        var planePos = new google.maps.LatLng(32.647009,-97.393725);
        var planeIcon = 'Plane.png';
        var quadIcon = 'quad.png';
        var quadMarker;
        var planeMarker;
        var bounds = new google.maps.LatLngBounds();
        var planeLongitudeLabel;
    </script>   
    <body onload="initialize()">
        <div id="systemContainer">
            <div id="header"><img src="images/header.png" alt="Header" /></div>
            <div id="connectionStatus1" class="vehicleNotConnected">Not Connected</div>
            <div id="dataContainer">
                <div id="map-container">
                    Vehicle Locations<br />
                    <div id="map-canvas"></div>               
		        </div>
                <div id="image-container">
                    Latest Image<br />
                    <img id="latestImage" src="images/loading.png" alt="Latest Imagery"/>
                </div>
                <div class="clear"></div>
            </div>
            <div id="connectionStatus2" class="vehicleNotConnected">Not Connected</div>
		    <div id="vehicleData">
                <table>
                    <tr>
                        <th>Node</th>
                        <th>Latitude</th>
                        <th>Longitude</th>
                        <th>Altitude</th>
                    </tr>
                    <tr>
                        <td style="background-color: #012853; color: #fff;">MARS-1</td>
                        <td><div id="PlaneLatitude"></div></td>
                        <td><div id="PlaneLongitude"></div></td>
                        <td><div id="PlaneAltitude"></div></td>
                    </tr>
                </table>
            </div>	
		    <div id="debugConsole">&nbsp;</div>
        </div>
</body>
</html>
