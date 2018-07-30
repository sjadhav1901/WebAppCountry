
$(document).ready(function () {
    if (localStorage.getItem('user') != null) {
        var user = JSON.parse(localStorage.getItem('user'));
        $.ajax({
            url: "http://webappcountry.azurewebsites.net/api/authednavmenu/" + user.altId,
            type: "GET",
            cache: false,
            success: function (response, status, xhr) {
                var nvContainer = $('#div-authed-nav-menu');
                nvContainer.html(response);
                $("#div-child-body").show();
                $("#dvLoader").hide();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var nvContainer = $('#div-authed-nav-menu');
                nvContainer.html(errorThrown);
                $("#div-child-body").show();
                $("#dvLoader").hide();
            }
        });
    }
    else {
        window.location.href = "/";
    }
});
