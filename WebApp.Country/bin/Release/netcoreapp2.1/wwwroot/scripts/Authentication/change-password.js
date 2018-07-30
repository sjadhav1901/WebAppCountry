
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
    var result = AjaxCall("/api/changepassword", JSON.stringify(data), "POST");
    if (result.id > 0) {
        $("#alert-error").html("Your password is changed successfully.");
        $("#alert-error").show();
        return false;
    }
    else {
        $btn.button('reset');
        $("#alert-error").html("Password is not changed. Please try again.");
        $("#alert-error").show();
        return false;
    }
    return false;
});