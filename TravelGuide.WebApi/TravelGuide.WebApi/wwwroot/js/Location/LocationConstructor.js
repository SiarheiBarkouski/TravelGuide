//#region Listbox

function addLocationsToListbox() {
    var locations = $("#google-map").locations;
    $.each(locations, function (location) {
        var row = "<li id='" + location.Id + "' class='btn btn-outline-primary m-2'>" + location.Name + ": " + location.Description + "</div></li>";
        $("#locationsList").append(row);
    });
}

function addLocationToListbox(map, location) {
    var row = "<li id='" + location.Id + "' class='btn btn-outline-primary m-2'>" + location.Name + ": " + location.Description + "</li>";
    $("#locationsList").append(row);
}

function updateLocationsInListbox(map, location) {
    if (location != null && location != 'undefined') {
        var listItem = $("#locationsList #" + location.Id);
        listItem.html("");
        var row = location.Name + ": " + location.Description;
        listItem.html(row);
    }
}

function checkLocationInListbox(map, location) {
    var listItem = $("#locationsList #" + location.Id);
    listItem.addClass("active");
}

function uncheckLocationInListbox(map, location) {
    var listItem = $("#locationsList #" + location.Id);
    listItem.removeClass("active");
}

function deleteLocationFromListbox(map, locationId) {
    var listItem = $("#locationsList #" + locationId);
    listItem.remove();
}

$(document).ready(function () {
    addLocationsToListbox();
});

$(document).on("location-added", function (event, map, location) {
    addLocationToListbox(map, location);
});

$(document).on("location-updated", function (event, map, location) {
    updateLocationsInListbox(map, location);
});

$(document).on("location-checked", function (event, map, location) {
    checkLocationInListbox(map, location);
});

$(document).on("location-unchecked", function (event, map, location) {
    uncheckLocationInListbox(map, location);
});

$(document).on("location-deleted", function (event, map, locationId) {
    deleteLocationFromListbox(map, locationId);
});

//#endregion

//#region ButtonHandlers
$(document).on("click", "#saveRoute", function () {


    //function (event) {
    //    var locations = map.locations;
    //    $.ajax({
    //            method: "POST",
    //            url: "/api/Location/SaveLocations",
    //            data: JSON.stringify(locations)
    //        })
    //        .done(function (msg) {
    //            alert("Data Saved: " + msg);
    //        });
    $(document).trigger("save-route-btn-clicked");
});
//#endregion