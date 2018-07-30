$(document).ready(function () {
    ValidateResetUserDetails();
});

function ValidateResetUserDetails() {
    if (localStorage.getItem('user') != null) {
        var user = JSON.parse(localStorage.getItem('user'));
        if (user == null) {
            $("#alert-error").html("Invalid user details.");
            $("#alert-error").show();
        }
    }
    else {
        window.location.href = "/forgotpassword";
    }
}

$("#btn-reset-pwd").click(function () {
    if ($("#input-password").val() == "") {
        $("#alert-error").html("Please enter password");
        $("#alert-error").show();
        return false;
    }
    if ($("#input-confirm-password").val() == "") {
        $("#alert-error").html("Please enter confirm password");
        $("#alert-error").show();
        return false;
    }
    if ($("#input-confirm-password").val() != $("#input-password").val()) {
        $("#alert-error").html("Please enter valid confirm password. Password mismatch.");
        $("#alert-error").show();
        return false;
    }
    $("#alert-error").hide();
    var user = JSON.parse(localStorage.getItem('user'));
    var data = {
        email: user.email,
        altId: user.altId,
        password: $("#input-password").val()
    }
    var result = AjaxCall("/api/resetpassword", JSON.stringify(data), "POST");
    if (result.id > 0) {
        $("#alert-error").html("Your password is reseted successfully, please click here to <a href='/'>Sign in</a>.");
        $("#alert-error").show();
        return false;
    }
    else {
        $btn.button('reset');
        $("#alert-error").html("Password is not reseted. Please try again.");
        $("#alert-error").show();
        return false;
    }
    return false;
});