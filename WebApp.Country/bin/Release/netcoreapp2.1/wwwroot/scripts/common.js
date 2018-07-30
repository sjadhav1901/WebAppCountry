function AjaxCall(url, data, method) {
    var ajaxResult = "";
    $.ajax({
        type: method,
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        failure: function (data) {
            hideLoader();
            alert(data.responseText);
        },
        error: function (data) {
            hideLoader();
            alert(data.responseText);
        },
        beforeSend: function () {
            showLoader();
        },
        success: function (data) {
            ajaxResult = data;
        },
        complete: function (data) {
            hideLoader();
        }
    });
    return ajaxResult;
}

function showLoader() {
    $("#dvLoader").show();
}

function hideLoader() {
    $("#dvLoader").hide();
}

function ValidateEmail(email) {
    var isNumber = email[0].match(/\d+/g);
    if (isNumber) {
        return false;
    }
    var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    return expr.test(email);
};

function IsNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function logout() {
    localStorage.removeItem('user')
    window.location.href = "/";
}