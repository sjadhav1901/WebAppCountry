
$("#btn-forgot-pwd").click(function () {
    if ($("#input-email").val() == "") {
        $("#alert-error").html("Please enter email address");
        $("#alert-error").show();
        return false;
    }
    $("#alert-error").hide();

    var result = AjaxCall("/api/forgotpassword/" + $("#input-email").val(), "", "GET");
    if (result.id > 0) {
        localStorage.setItem('user', JSON.stringify(result));
        window.location.href = "/resetpassword/" + result.altId;
    }
    else {
        $("#alert-error").html("Invalid email address.");
        $("#alert-error").show();
        return false;
    }
    return false;
});