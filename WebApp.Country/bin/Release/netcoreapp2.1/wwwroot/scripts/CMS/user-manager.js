$(document).ready(function () {
    GetAllUsers();
});

function GetAllUsers() {
    var result = AjaxCall("/api/all/users", "", "GET");
    if (result.length > 0) {
        var tBody = "";
        result.forEach(function (val, index) {
            tBody += "<tr>";
            tBody += "<td>" + val.firstName + "</td>";
            tBody += "<td>" + val.lastName + "</td>";
            tBody += "<td>" + val.email + "</td>";
            var role = val.roleId == 1 ? "Admin" : val.roleId == 2 ? "Editor" : "User";
            tBody += "<td>" + role + "</td>";
            tBody += "<td>" + GetRoles(val.altId, val.roleId) + "</td>";
            tBody += "<td style='color: #007bff;'>";
            tBody += " <a href=\"javascript:void(0);\" onclick=\"ChangeRole('" + val.altId + "')\">Change Role</a>";
            tBody += " | <a href=\"javascript:void(0);\" onclick=\"DeleteUser('" + val.altId + "')\">Delete</a>";
            if (val.isEnabled) {
                tBody += " | <a href=\"javascript:void(0);\" onclick=\"ActivateUser('" + val.altId + "',0)\">Dectivate</a>";
            }
            else {
                tBody += " | <a href=\"javascript:void(0);\" onclick=\"ActivateUser('" + val.altId + "',1)\">Activate</a>";
            }
            tBody += "</td>";
            tBody += "</tr>";
        });
        $("#table-body").html(tBody);
        $('#example').DataTable();
    }
}

function ActivateUser(altId, isEnabled) {
    var user = JSON.parse(localStorage.getItem('user'));
    var data = {
        altId: altId,
        isEnabled: isEnabled,
        createdBy: user.altId,
    }
    var result = AjaxCall("/api/user/activate", JSON.stringify(data), "POST");
    if (result.id > 0) {
        if (isEnabled == 0) {
            alert("Country is successfully deactivated.");
        } else {
            alert("Country is successfully activated.");
        }
        GetAllUsers();
    }
    else {
        if (isEnabled == 0) {
            alert("Something went wrong, Counrty is not deacivated, please try again.")
        } else {
            alert("Something went wrong, Counrty is not acivated, please try again.")
        }
    }
}

function DeleteUser(altId) {
    if (confirm("Are you sure you want to delete this?")) {
        var user = JSON.parse(localStorage.getItem('user'));
        var data = {
            altId: altId,
            createdBy: user.altId,
        }
        var result = AjaxCall("/api/user/delete", JSON.stringify(data), "POST");
        if (result) {
            alert("Country is deleted successfully.");
            GetAllUsers();
        }
        else {
            alert("Failed to delete country. Please try agin.");
        }
    }
    else {
        return false;
    }
}

function GetRoles(altId, roleId) {
    var select = "";
    select += "<select id='select" + altId + "' class='form-control' style='font-size:13px;height: 33px;'>";
    if (roleId == 1) {
        select += "<option value='1' selected>Admin</option>";
    }
    else {
        select += "<option value='1'>Admin</option>";
    }
    if (roleId == 2) {
        select += "<option value='2' selected>Editor</option>";
    }
    else {
        select += "<option value='2'>Editor</option>";
    }
    if (roleId == 3) {
        select += "<option value='3' selected>User</option>";
    }
    else {
        select += "<option value='3'>User</option>";
    }
    select += "</select>";
    return select;
}

function ChangeRole(altId) {
    var user = JSON.parse(localStorage.getItem('user'));
    var data = {
        altId: altId,
        roleId: $("#select" + altId).val(),
    }
    var result = AjaxCall("/api/user/changerole", JSON.stringify(data), "POST");
    if (result.id > 0) {
        alert("User role is changed successfully.");
        GetAllUsers();
    }
    else {
        alert("Failed to chnage user role. please try again.");
    }
}