function getPageData() {
    updateMapLocations();
    
    //Updating image one of these functions has to be commented out or the image will be replaced twice

    //Use server to pull latest image gs might drag:
    updateImage();

    //Have image file replaced using same name - page flashes, might be necessary to keep gs running OK though
    //updateImageStatic()
    
}


function updateMapLocations() {

    $.ajax({
        type: "POST",
        url: "Default.aspx/GetUpdatedLocationData",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            
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

function updateImageStatic() {
    updatePageImageStatic('latest_image.jpg');
}