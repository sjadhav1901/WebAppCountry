var countryData = [];
$(document).ready(function () {
    GetCountryDetails();
});

function GetCountryDetails() {
    var countryAltId = localStorage.getItem('countryAltId');
    var country = AjaxCall("/api/get/countries/" + countryAltId, "", "GET");
    if (country.id > 0) {
        countryData = country;
        $("#input-name").val(country.name);
        $("#input-nativename").val(country.nativeName);
        $("#input-capital").val(country.capital);
        $("#input-alphatwocode").val(country.alphaTwoCode);
        $("#input-alphathreecode").val(country.alphaThreeCode);
        $("#input-region").val(country.region);
        $("#input-subregion").val(country.subRegion);

        var Languages = JSON.parse(country.language);
        var sbLanguages = "";
        Languages.forEach(function (val, index) {
            sbLanguages += "<label class='col-sm-3'  style='padding-left:3px;'>" +
                " <input type=\"checkbox\" checked id=\"chk-rememberme\" value=\"" + val.name + "\"> " + val.name + " (" + val.nativeName + ")" +
                " </label>";
        });
        $("#div-chk-languages").html(sbLanguages);

        var currencies = JSON.parse(country.currency);
        var sbCurrencies = "";
        sbCurrencies = "";
        currencies.forEach(function (val, index) {
            sbCurrencies += "<label class='col-sm-3' style='padding-left:3px;'>" +
                " <input type=\"checkbox\" checked id=\"chk-rememberme\" value=\"" + val.code + "\"> " + val.name + " (" + val.code + ")" +
                " </label>";
        });
        $("#div-chk-curreincies").html(sbCurrencies);
    }
}

$("#btn-edit").click(function () {
    if ($("#input-name").val() == "") {
        $("#alert-error").html("Please enter country name");
        $("#alert-error").show();
        return false;
    }
    if ($("#input-nativename").val() == "") {
        $("#alert-error").html("Please enter native name");
        $("#alert-error").show();
        return false;
    }
    if ($("#input-capital").val() == "") {
        $("#alert-error").html("Please enter capital");
        $("#alert-error").show();
        return false;
    }
    if ($("#input-alphatwocode").val() == "") {
        $("#alert-error").html("Please enter alpha two code");
        $("#alert-error").show();
        return false;
    }
    if ($("#input-alphathreecode").val() == "") {
        $("#alert-error").html("Please enter alpha three code");
        $("#alert-error").show();
        return false;
    }
    if ($("#input-region").val() == "") {
        $("#alert-error").html("Please enter region");
        $("#alert-error").show();
        return false;
    }
    if ($("#input-subregion").val() == "") {
        $("#alert-error").html("Please enter sub region");
        $("#alert-error").show();
        return false;
    }

    var currencyValues = "";
    $('#div-chk-curreincies input:checkbox').each(function () {
        currencyValues = (this.checked ? $(this).val() : "");
    });

    if (currencyValues == "") {
        $("#alert-error").html("Please select at least one currency");
        $("#alert-error").show();
        return false;
    }

    var LanguageValues = "";
    $('#div-chk-languages input:checkbox').each(function () {
        LanguageValues = (this.checked ? $(this).val() : "");
    });
    
    if (LanguageValues == "") {
        $("#alert-error").html("Please select at least one langauge");
        $("#alert-error").show();
        return false;
    }

    var Languages = JSON.parse(countryData.language);
    var languagesTemp = [];
    Languages.forEach(function (val, index) {
        if (LanguageValues.indexOf(val.name)) {
            languagesTemp.push(val);
        }
    });

    var currencies = JSON.parse(countryData.currency);
    var CurrencyTemp = [];
    currencies.forEach(function (val, index) {
        if (LanguageValues.indexOf(val.code)) {
            CurrencyTemp.push(val);
        }
    });

    $("#alert-error").hide();
    var user = JSON.parse(localStorage.getItem('user'));
    var data = {
        altId: localStorage.getItem('countryAltId'),
        name: $("#input-name").val(),
        nativeName: $("#input-nativename").val(),
        alphaTwoCode: $("#input-alphatwocode").val(),
        alphaThreeCode: $("#input-alphatwocode").val(),
        capital: $("#input-capital").val(),
        region: $("#input-region").val(),
        subRegion: $("#input-subregion").val(),
        currency: JSON.stringify(CurrencyTemp),
        language: JSON.stringify(languagesTemp),
        updatedBy: user.altId
    }
    var result = AjaxCall("/api/country/edit", JSON.stringify(data), "POST");
    if (result.id > 0) {
        alert("Country detail updated successfully.")
    }
    else {
        alert("Failed to update country details. Please try again.")
    }
    return false;
});

