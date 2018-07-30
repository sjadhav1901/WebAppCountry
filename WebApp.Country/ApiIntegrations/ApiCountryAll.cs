using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Country.ApiIntegrations.HttpHelpers;

namespace WebApp.Country.ApiIntegrations
{
    public interface IApiCountryAll
    {
        List<Contracts.Models.ApiIntegrations.Country> GetAllCountries();
    }

    public class ApiCountryAll : IApiCountryAll
    {
        public ApiCountryAll()
        {
        }

        public List<Contracts.Models.ApiIntegrations.Country> GetAllCountries()
        {
            Urls.BaseUrl = "https://restcountries.eu/rest/v2/all";
            string response = HttpWebRequestHelpers.GetWebRequest(Urls.BaseUrl, "GET");
            return Mapper<List<Contracts.Models.ApiIntegrations.Country>>.MapJsonStringToObject(response);
        }
    }
}
