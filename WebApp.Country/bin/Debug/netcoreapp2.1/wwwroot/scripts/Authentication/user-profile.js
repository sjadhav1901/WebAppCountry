$(document).ready(function () {
    if (localStorage.getItem('user') != null) {
        var user = JSON.parse(localStorage.getItem('user'));
        if (user != null) {
            $("#div-name").html(user.firstName + " " + user.lastName);
            $("#div-email").html(user.email);
            var role = user.roleId == 1 ? "Admin" : user.roleId == 2 ? "Editor" : "User";
            $("#div-role").html("Role - " + role);
        }
    }
    else {
        window.location.href = "/forgotpassword";
    }
});