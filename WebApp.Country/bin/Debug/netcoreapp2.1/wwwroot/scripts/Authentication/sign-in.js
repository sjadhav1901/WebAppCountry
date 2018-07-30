$(document).ready(function () {
    GetRememberedCrdentails();
});

function GetRememberedCrdentails() {
    var result = getCookie('user');
    if (result != "") {
        result = JSON.parse(result);
        $("#input-email").val(result.email);
        $("#input-password").val(result.password);
        $("#chk-rememberme").prop("checked", true);
    }
}

$("#btn-sign-in").click(function () {
    if ($("#input-email").val() == "") {
        $("#alert-error").html("Please enter email address");
        $("#alert-error").show();
        return false;
    }
    if (!ValidateEmail($("#input-email").val())) {
        $("#alert-error").html("Please enter valid email address");
        $("#alert-error").show();
        return false;
    }
    if ($("#input-password").val() == "") {
        $("#alert-error").html("Please enter password");
        $("#alert-error").show();
        return false;
    }
    $("#alert-error").hide();
    var data = {
        email: $("#input-email").val(),
        password: $("#input-password").val()
    }
    var result = AjaxCall("/api/authenticate", JSON.stringify(data), "POST");
    if (result.id > 0) {
        if ($("#chk-rememberme").is(':checked')) {
            setCookie('user', JSON.stringify(result), 1);
        }
        localStorage.setItem('user', JSON.stringify(result));
        window.location.href = "/dashboard";
    }
    else {
        $("#alert-error").html("Invalid email address or password");
        $("#alert-error").show();
    }
    return false;
});

