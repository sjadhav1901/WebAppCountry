using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Country.Helpers;
using WebApp.Country.Repositories;

namespace WebApp.Country.Controllers
{
    public class CountryController : Controller
    {
        private ICountryRepository _countryRepository;
        private IActivityHelper _activityHelper;
        private IFavouriteRepository _favouriteRepository;
        public CountryController(ICountryRepository countryRepository, IActivityHelper activityHelper, IFavouriteRepository favouriteRepository)
        {
            _countryRepository = countryRepository;
            _activityHelper = activityHelper;
            _favouriteRepository = favouriteRepository;
        }
        [Route("browsecountry")]
        public IActionResult BrowseCountry()
        {
            return View();
        }
        [Route("country/edit/{altId}")]
        public IActionResult EditCountry(Guid altId)
        {
            return View();
        }
        [HttpGet]
        [Route("api/all/countries")]
        public List<Contracts.Models.Country> GetAllCountries()
        {
            try
            {
                List<Contracts.Models.Country> country = AutoMapper.Mapper.Map<List<Contracts.Models.Country>>(_countryRepository.GetAll(null).Where(w=>w.IsEnabled==true)).ToList();
                return country;
            }
            catch (Exception)
            {
            }
            return null;
        }

        [HttpGet]
        [Route("api/get/countries/{altId}")]
        public Contracts.Models.Country GetCountryDetails(Guid altId)
        {
            try
            {
                return AutoMapper.Mapper.Map<Contracts.Models.Country>(_countryRepository.GetByAltId(altId));
            }
            catch (Exception)
            {
                return new Contracts.Models.Country();
            }
        }

        [HttpPost]
        [Route("/api/favorite")]
        public Contracts.DataModels.Favourite Favourites([FromBody] Favourite model)
        {
            try
            {
                Contracts.Models.Country country = AutoMapper.Mapper.Map<Contracts.Models.Country>(_countryRepository.GetByAltId(model.CountryAltId));
                Contracts.DataModels.Favourite favourite = _favouriteRepository.GetByCountryIdAndCreatedBy(model.CountryAltId, model.CreatedBy);
                if (favourite == null)
                {
                    favourite = _favouriteRepository.Save(new Contracts.DataModels.Favourite
                    {
                        CountryAltId = model.CountryAltId,
                        IsEnabled = true,
                        CreatedUtc = DateTime.UtcNow,
                        CreatedBy = model.CreatedBy
                    });
                    _activityHelper.SaveActivity("Added to Favourites - " + country.Name, "You have added country " + country.Name + " to your favorite list on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), model.CreatedBy);
                }
                return favourite;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        [HttpPost]
        [Route("api/country/edit")]
        public Contracts.DataModels.Country Edit([FromBody]  Contracts.DataModels.Country model)
        {
            try
            {
                Contracts.DataModels.Country country = _countryRepository.GetByAltId(model.AltId);
                if (country != null)
                {
                    country.Name = model.Name;
                    country.NativeName = model.NativeName;
                    country.Region = model.Region;
                    country.SubRegion = model.SubRegion;
                    country.AlphaTwoCode = model.AlphaTwoCode;
                    country.AlphaThreeCode = model.AlphaThreeCode;
                    country.Language = model.Language;
                    country.Currency = model.Currency;
                    country.UpdatedUtc = DateTime.UtcNow;
                    country.UpdatedBy = model.UpdatedBy;
                    country = _countryRepository.Save(country);
                }
                _activityHelper.SaveActivity("Updated Country  - " + country.Name, "You have updated country " + country.Name + " on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), (Guid)model.UpdatedBy);
                return country;
            }
            catch (Exception ex)
            {
                return new Contracts.DataModels.Country();
            }
        }
    }
}