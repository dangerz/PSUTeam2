﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="Stylesheet" href="Styles/Site.css" type="text/css" />


    <title>Team 2 PSU</title>
</head>
    <script type="text/jscript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.csv-0.71.js"></script>
    <script type="text/javascript" src="Scripts/MapsScript.js"></script>
    <script type="text/javascript" src="Scripts/UpdateScripts.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAq3lhmAz62oIoRN0gjpIwJVsAS0Ez_e20"></script>     	
    <script type="text/javascript">
        var map;
        var quadPos = new google.maps.LatLng(-34.397, 150.644);
        var planePos = new google.maps.LatLng(-34.442, 150.999);
        var planeIcon = 'Plane.png';
        var quadIcon = 'quad.png';
        var quadMarker;
        var planeMarker;
        var bounds = new google.maps.LatLngBounds();
        var planeLongitudeLabel;
    </script>   
<body onload="initialize()">
        <div id="header">
			<h1>Team 2 PSU Mesh Network Project</h1>
		</div>

        <div id="map-canvas"></div>                 
		<div id="image-canvas">
			<img src="cow.jpg" width="100%" height="100%" alt="Photo"/>
		</div>
		<div id="map-data">
            <table>
                <tr>
                    <th>Node</th>
                    <th>Latitude</th>
                    <th>Longitude</th>
                    <th>Altitude</th>
                </tr>
                <tr>
                    <td>Plane</td>    
                    <td><div id="PlaneLatitude"></div></td>
                    <td><div id="PlaneLongitude"></div></td>
                    <td><div id="PlaneAltitude"></div></td>
                </tr>
                <tr>
                    <td>Quad</td>
                    <td><div id="QuadLatitude"></div></td>
                    <td><div id="QuadLongitude"></div></td>
                    <td><div id="QuadAltitude"></div></td>
                </tr>
            </table>
        </div>	
		<div id="footer">
			FOOTER
		</div>
</body>
</html>
