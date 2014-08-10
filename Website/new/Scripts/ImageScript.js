function updatePageImage(imageLocation) {
    //alert("Updating Image" + imageLocation);

    var imgTxt = '<img src="images/' + imageLocation + '" width="100%" height="100%" alt="Photo">';

    document.getElementById("image-canvas").innerHTML = imgTxt;

    var curTxt = document.getElementById("image-canvas").innerHTML;
    //alert(imgTxt);
    if (imgTxt.toLowerCase() != curTxt.toLowerCase()) {
        //alert((document.getElementById('image-canvas').innerHTML).toLowerCase() + ' ' + imgTxt.toLowerCase());
        document.getElementById("image-canvas").innerHTML = imgTxt;
    } 
  
}

function updatePageImageStatic(imageLocation) {
    var d = new Date();
    imageLocation += "?" + d.getTime();

    var imgTxt = '<img src="images/' + imageLocation + '" width="100%" height="100%" alt="Photo">';

    document.getElementById("image-canvas").innerHTML = imgTxt;
}