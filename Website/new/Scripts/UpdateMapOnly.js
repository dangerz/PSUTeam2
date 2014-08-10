function getPageData() {
    //alert("GetPageData");
    updateMapLocations();
    //updateImage();
}


function updateMapLocations() {

    $.ajax({
        type: "POST",
        url: "Default.aspx/GetUpdatedLocationData",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            //alert(response.d);
            var locations = $.csv.toArray(response.d);

            updatePage(locations);
        },
        failure: function (response) {

        }
    });
}

function updateImage() {
    $.ajax({
        type: "POST",
        url: "Default.aspx/GetLatestImage",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            updatePageImage(response.d);
        },
        failure: function (response) { }
    });
}