function updateTest() {

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