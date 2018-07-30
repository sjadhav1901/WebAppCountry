var data = [];
var countryData = [];
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/api/all/countries",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            data = $.map(result, function (item) {
                return {
                    label: item.name,
                    val: item.altId
                }
            });
            countryData = result;
            var sum = 0;
            result.forEach(function (val, index) {
                sum += val.population;
            });
            $("#hdnPopulation").val(sum);
            InitializeAutoComplete();
        },
        error: function (response) {
            //alert(response.responseText);
        },
        failure: function (response) {
            //alert(response.responseText);
        }
    });
});

function InitializeAutoComplete() {
    $("#tags").autocomplete({
        source: data,
        select: function (e, i) {
            $("#hdnCountryId").val(i.item.val);
            GetCountryDetails();
        },
        minLength: 0
    }).focus(function () {
        if ($(this).autocomplete("widget").is(":visible")) {
            return;
        }
    });
}

function GetCountryDetails() {
    $("#div-details").hide();
    var country = $.grep(countryData, function (val) {
        return val.altId == $("#hdnCountryId").val();
    });
    country = country[0];
    //var country = AjaxCall("/api/get/countries/" + $("#hdnCountryId").val(), "", "GET");
    if (country.id > 0) {
        $("#div-details").show();
        var tBody = "";
        var sb = "<table class=\"table\" style=\"font-size: 14px;\">" +
            "<tbody>" +
            "<tr>" +
            "<td style=\"border-top: none;font-weight: 600;\">Country</td>" +
            "<td style=\"border-top: none;\">" + country.name + "</td>" +
            "</tr>";
        sb += "<tr>" +
            "<td style=\"font-weight: 600;\">Flag</td>" +
            "<td><img src='" + country.flags + "' style='width: 50px;' /> </td>" +
            "</tr>";
        sb += "<tr>" +
            "<td style=\"font-weight: 600;\">Alpha Two Code</td>" +
            "<td>" + country.alphaTwoCode + "</td>" +
            "</tr>";
        sb += "<tr>" +
            "<td style=\"font-weight: 600;\">Alpha Three Code</td>" +
            "<td>" + country.alphaThreeCode + "</td>" +
            "</tr>";
        sb += "<tr>" +
            "<td style=\"font-weight: 600;\">Capital</td>" +
            "<td>" + country.capital + "</td>" +
            "</tr>";
        sb += "<tr>" +
            "<td style=\"font-weight: 600;\">Region</td>" +
            "<td>" + country.region + "</td>" +
            "</tr>";
        sb += "<tr>" +
            "<td style=\"font-weight: 600;\">SubRegion</td>" +
            "<td>" + country.subRegion + "</td>" +
            "</tr>";
        sb += "<tr>" +
            "<td style=\"font-weight: 600;\">Population</td>" +
            "<td>" + country.population + "</td>" +
            "</tr>";
        sb += "<tr>" +
            "<td style=\"font-weight: 600;\">% Of World's Population</td>" +
            "<td>" + ((country.population / $("#hdnPopulation").val()) * 100).toFixed(2) + "%</td>" +
            "</tr>";
        sb += "<tr>" +
            "<td style=\"font-weight: 600;\">TimeZone</td>" +
            "<td>" + country.timeZone + "</td>" +
            "</tr>";
        $("#div-country").html(sb);

        var Languages = JSON.parse(country.language);
        var strLanguages = "";
        Languages.forEach(function (val, index) {
            strLanguages += "<p style=\"border-top: 1px solid #dee2e6;margin-top:0px;margin-bottom:0px;\"><b> Name:</b> " +
                "<span class=\"f6 text-gray\">" + val.name
            "</span></p>";
            strLanguages += "<p><b> Native Name:</b> " +
                "<span class=\"f6 text-gray\">" + val.nativeName
            "</span></p>";
        });
        if (strLanguages != "") {
            $("#dvLanguages").html(strLanguages);
        }
        else {
            $("#dvLanguages").html("No language details available.");
        }
        var currencies = JSON.parse(country.currency);
        var strCurrencies = "";
        currencies.forEach(function (val, index) {
            if (val.name != null && val.name != "null") {
                strCurrencies += "<p style=\"border-top: 1px solid #dee2e6;margin-top:0px;margin-bottom:0px;\"><b> Name:</b> " +
                    "<span class=\"f6 text-gray\">" + val.name + "" +
                    "</span></p>";
                strCurrencies += "<p style=\"margin-top:0px;margin-bottom:0px;\"><b> Code:</b> " +
                    "<span class=\"f6 text-gray\">" + val.code + "" +
                    "</span></p>";
                strCurrencies += "<p style=\"margin-top:0px;margin-bottom:0px;\"><b> Symbol:</b> " +
                    "<span class=\"f6 text-gray\"> " + val.symbol + "" +
                    "</span></p>";
                var url = "https://free.currencyconverterapi.com/api/v6/convert?q=" + val.code.toUpperCase() + "_INR"
                var exchnageRate = 0;
                $.ajax({
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    async: false,
                    success: function (data) {
                        exchnageRate = data.results[val.code.toUpperCase() + "_INR"].val;
                        strCurrencies += "<p><b> Local (INR) Conversion Rate :</b> " +
                            "<span class=\"f6 text-gray\"> " + exchnageRate + "" +
                            "</span></p>";
                    }
                });
            }
        });
        if (strCurrencies != "") {
            $("#dvCurrencies").html(strCurrencies);
        }
        else {
            $("#dvCurrencies").html("Np currency details available.");
        }
    }
}


$("#btn-favorite").click(function () {
    var user = JSON.parse(localStorage.getItem('user'));
    var data = {
        countryAltId: $("#hdnCountryId").val(),
        createdBy: user.altId
    }
    var result = AjaxCall("/api/favorite", JSON.stringify(data), "POST");
    if (result != null) {
        alert("Country is added successfully to favourite list");
    }
    else {
        alert("Please try again. Country is not added to favourite list")
        return false;
    }
    return false;
});