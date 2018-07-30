﻿$(document).ready(function () {
    SyncCountries();
});
function SyncCountries() {
    $("#div-sync").show();
    $("#div-sync-alert").hide();
    if (localStorage.getItem('user') != null) {
        var user = JSON.parse(localStorage.getItem('user'));
        var result = AjaxCall("/api/synccountries", JSON.stringify(user), "POST");
        if (result == true) {
            $("#p-alert").html("Synchronization completed successfully.");
            $("#div-sync").hide();
            $("#div-sync-alert").show();
        }
        else {
            $("#p-alert").html("Synchronization failed. Please try again");
            $("#div-sync").hide();
            $("#div-sync-alert").show();
        }
    }
    else {
        window.location.href = "/";
    }
    return false;
}

function RediectToListing() {
    window.location.href = "/manage/countries";
}