$(document).ready(function () {
    GetAllCountries();
});

function GetAllCountries() {
    var result = AjaxCall("/api/manage/countries", "", "GET");
    if (result.length > 0) {
        var tBody = "";
        result.forEach(function (val, index) {
            var Languages = JSON.parse(val.language);
            var strLanguages = "";
            Languages.forEach(function (val, index) {
                var nativeName = val.name == val.nativeName ? ", " : " (" + val.nativeName + "), ";
                strLanguages += val.name + nativeName;
            });

            var currencies = JSON.parse(val.currency);
            var strCurrencies = "";
            currencies.forEach(function (val, index) {
                strCurrencies += val.name + " (" + val.code + "), ";
            });

            tBody += "<tr>";
            tBody += "<td>" + val.name + "</td>";
            tBody += "<td>" + val.alphaTwoCode + "</td>";
            tBody += "<td>" + val.alphaThreeCode + "</td>";
            tBody += "<td>" + val.capital + "</td>";
            tBody += "<td>" + strLanguages.substring(0, strLanguages.length - 2) + "</td>";
            tBody += "<td>" + strCurrencies.substring(0, strCurrencies.length - 2) + "</td>";
            tBody += "<td><img src='" + val.flags + "' style='width: 40px;'></td>";
            tBody += "<td>" + val.timeZone + "</td>";
            tBody += "<td  style='color: #007bff;'>";
            tBody += " <a href=\"javascript:void(0);\" onclick=\"EditCountry('" + val.altId + "')\">Edit</a>";
            tBody += " | <a href=\"javascript:void(0);\" onclick=\"DeleteCountry('" + val.altId + "')\">Delete</a>";
            if (val.isEnabled) {
                tBody += " | <a href=\"javascript:void(0);\" onclick=\"ActivateCountry('" + val.altId + "',0)\">Dectivate</a>";
            }
            else {
                tBody += " | <a href=\"javascript:void(0);\" onclick=\"ActivateCountry('" + val.altId + "',1)\">Activate</a>";
            }
            tBody += "</td>";
            tBody += "</tr>";
        });
        $("#table-body").html(tBody);
        $('#example').DataTable();
    }
}

function ActivateCountry(altId, isEnabled) {
    var user = JSON.parse(localStorage.getItem('user'));
    var data = {
        altId: altId,
        isEnabled: isEnabled,
        createdBy: user.altId,
    }
    var result = AjaxCall("/api/country/activate", JSON.stringify(data), "POST");
    if (result.id > 0) {
        if (isEnabled == 0) {
            alert("Country is successfully deactivated.");
        } else {
            alert("Country is successfully activated.");
        }
        GetAllCountries();
    }
    else {
        if (isEnabled == 0) {
            alert("Something went wrong, Counrty is not deacivated, please try again.")
        } else {
            alert("Something went wrong, Counrty is not acivated, please try again.")
        }
    }
}

function DeleteCountry(altId) {
    if (confirm("Are you sure you want to delete this?")) {
        var user = JSON.parse(localStorage.getItem('user'));
        var data = {
            altId: altId,
            createdBy: user.altId,
        }
        var result = AjaxCall("/api/country/delete", JSON.stringify(data), "POST");
        if (result) {
            alert("Country is deleted successfully.");
            GetAllCountries();
        }
        else {
            alert("Failed to delete country. Please try agin.");
        }
    }
    else {
        return false;
    }
}

function EditCountry(altId) {
    localStorage.setItem('countryAltId', altId);
    window.location.href = "/country/edit/" + altId;
}