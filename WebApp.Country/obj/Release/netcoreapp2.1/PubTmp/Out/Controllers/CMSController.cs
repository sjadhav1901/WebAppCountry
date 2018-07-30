using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using WebApp.Country.ApiIntegrations;
using WebApp.Country.ApiIntegrations.HttpHelpers;
using WebApp.Country.Helpers;
using WebApp.Country.Repositories;

namespace Web.Country.FactBook.Controllers
{
    public class CMSController : Controller
    {
        private IApiCountryAll _apiCountryAll;
        private ICountryRepository _countryRepository;
        private IActivityHelper _activityHelper;
        private IUserRepository _userRepository;
        public CMSController(IApiCountryAll apiCountryAll, ICountryRepository countryRepository, IActivityHelper activityHelper, IUserRepository userRepository)
        {
            _apiCountryAll = apiCountryAll;
            _countryRepository = countryRepository;
            _activityHelper = activityHelper;
            _userRepository = userRepository;
        }

        [Route("synccountries")]
        public IActionResult SyncCountries()
        {
            return View();
        }

        [Route("synccountries/start")]
        public IActionResult BeginSyncCountries()
        {
            return View();
        }

        [Route("manage/countries")]
        public IActionResult ManageCountry()
        {
            return View();
        }

        [Route("usermanagement")]
        public IActionResult UserManagement()
        {
            return View();
        }

        [HttpPost]
        [Route("api/synccountries")]
        public bool SyncCountries([FromBody] Contracts.Models.User model)
        {
            List<Contracts.Models.ApiIntegrations.Country> countries = _apiCountryAll.GetAllCountries();
            List<Contracts.DataModels.Country> countryList = new List<Contracts.DataModels.Country>();
            IEnumerable<Contracts.DataModels.Country> availableCountryList = _countryRepository.GetAll(null);
            foreach (Contracts.Models.ApiIntegrations.Country itemCountry in countries)
            {
                Contracts.DataModels.Country isCountryExist = availableCountryList.Where(w => w.Name == itemCountry.name).FirstOrDefault();
                try
                {
                    if (isCountryExist == null)
                    {
                        countryList.Add(new Contracts.DataModels.Country
                        {
                            Name = itemCountry.name,
                            NativeName = itemCountry.nativeName,
                            AlphaTwoCode = itemCountry.alpha2Code,
                            AlphaThreeCode = itemCountry.alpha3Code,
                            Capital = itemCountry.capital,
                            Flags = itemCountry.flag,
                            Area = itemCountry.area.ToString(),
                            Region = itemCountry.region,
                            SubRegion = itemCountry.subregion,
                            Population = itemCountry.population,
                            Currency = Mapper<string>.MapObjectToJsonString(itemCountry.currencies),
                            Language = Mapper<string>.MapObjectToJsonString(itemCountry.languages),
                            TimeZone = itemCountry.timezones != null ? itemCountry.timezones[0] : null,
                            CreatedBy = model.AltId
                        });
                    }
                }
                catch (Exception ex)
                {
                }
            }
            Dapper.DynamicParameters dynamicParameters = new Dapper.DynamicParameters();
            dynamicParameters.Add("@XmlSeatLayout", Serialize<List<Contracts.DataModels.Country>>(countryList), System.Data.DbType.Xml);
            _countryRepository.ExecuteStoredProcedure("spInsertCountries", dynamicParameters);
            _activityHelper.SaveActivity("Country Data Synchronization", "You have performed country data sync opertion on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), model.AltId);
            return true;
        }

        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                System.IO.StringWriter stringwriter = new System.IO.StringWriter();
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/manage/countries")]
        public List<Contracts.Models.Country> GetAllCountries()
        {
            try
            {
                List<Contracts.Models.Country> country = AutoMapper.Mapper.Map<List<Contracts.Models.Country>>(_countryRepository.GetAll(null).OrderBy(o=>o.Name)).ToList();
                return country;
            }
            catch (Exception)
            {
            }
            return new List<Contracts.Models.Country>();
        }

        [HttpPost]
        [Route("/api/country/activate")]
        public Contracts.DataModels.Country ActivateCountry([FromBody] Contracts.DataModels.Country model)
        {
            try
            {
                Contracts.DataModels.Country country = _countryRepository.GetByAltId(model.AltId);
                if (country != null)
                {
                    country.IsEnabled = model.IsEnabled;
                    _countryRepository.Save(country);
                    if (!model.IsEnabled)
                    {
                        _activityHelper.SaveActivity("Deactivated Country - " + country.Name, "You have deactivatred country  " + country.Name + " on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), model.CreatedBy);
                    }
                    else
                    {
                        _activityHelper.SaveActivity("Activated Country - " + country.Name, "You have activatred country  " + country.Name + " on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), model.CreatedBy);
                    }
                    return country;
                }
            }
            catch (Exception ex)
            {
            }
            return new Contracts.DataModels.Country();
        }

        [HttpPost]
        [Route("/api/country/delete")]
        public bool DeleteCountry([FromBody] Contracts.DataModels.Country model)
        {
            try
            {
                Contracts.DataModels.Country country = _countryRepository.GetByAltId(model.AltId);
                if (country != null)
                {
                    _countryRepository.Delete(country);
                    _activityHelper.SaveActivity("Deleted Country - " + country.Name, "You have deleted country  " + country.Name + " on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), model.CreatedBy);
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        [HttpGet]
        [Route("api/all/users")]
        public List<Contracts.Models.User> GetAllUsers()
        {
            try
            {
                List<Contracts.Models.User> users = AutoMapper.Mapper.Map<List<Contracts.Models.User>>(_userRepository.GetAll(null)).ToList();
                return users;
            }
            catch (Exception)
            {
            }
            return new List<Contracts.Models.User>();
        }

        [HttpPost]
        [Route("/api/user/delete")]
        public bool DeleteUser([FromBody] Contracts.DataModels.User model)
        {
            try
            {
                Contracts.DataModels.User user = _userRepository.GetByAltId(model.AltId);
                if (User != null)
                {
                    _userRepository.Delete(user);
                    _activityHelper.SaveActivity("Deleted Country - " + user.Email, "You have deleted user on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), model.CreatedBy);
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        [HttpPost]
        [Route("/api/user/activate")]
        public Contracts.DataModels.User ActivateUser([FromBody] Contracts.DataModels.User model)
        {
            try
            {
                Contracts.DataModels.User user = _userRepository.GetByAllAltId(model.AltId);
                if (user != null)
                {
                    user.IsEnabled = model.IsEnabled;
                    _userRepository.Save(user);
                    if (!model.IsEnabled)
                    {
                        _activityHelper.SaveActivity("Deactivated User - " + user.Email, "You have deactivatred user on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), model.CreatedBy);
                    }
                    else
                    {
                        _activityHelper.SaveActivity("Activated User - " + user.Email, "You have activatred user on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), model.CreatedBy);
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
            }
            return new Contracts.DataModels.User();
        }

        [HttpPost]
        [Route("/api/user/changerole")]
        public Contracts.DataModels.User ChangeRole([FromBody] Contracts.DataModels.User model)
        {
            try
            {
                Contracts.DataModels.User user = _userRepository.GetByAllAltId(model.AltId);
                if (user != null)
                {
                    user.RoleId = model.RoleId;
                    _userRepository.Save(user);
                    _activityHelper.SaveActivity("Changed user Role - " + user.Email, "You have chnaged user role on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), model.CreatedBy);
                    return user;
                }
            }
            catch (Exception ex)
            {
            }
            return new Contracts.DataModels.User();
        }
    }
}