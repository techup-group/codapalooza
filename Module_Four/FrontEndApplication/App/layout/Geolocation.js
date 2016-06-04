function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {
    var lat = position.coords.latitude;
    var longi = position.coords.longitude;

}


navigator.geolocation.getCurrentPosition(success, error);

function success(position) {
    var latitude = position.coords.latitude;
    var longitude = position.coords.longitude;

    var location = latitude +"," + longitude;
};
