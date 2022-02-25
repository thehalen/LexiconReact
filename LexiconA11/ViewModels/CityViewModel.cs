using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LexiconA11.Models
{
    public class CountryViewModel
    {
        [Display(Name = "City name")]
        public string Name { get; set; }

        private List<CityModel> _cities;
        public List<CityModel> CityList
        {
            get
            {
                //_cities.Clear();
                //var foo = listOfPeople.Where(c => c.City.Name == filter_C && c.Name == filter_N);
                //personsListView.AddRange(foo);
                return _cities;
                //return PeopleViewModel.personsListView;
            }
            set => _cities = value; }


        private List<CountryModel> _countries;
        public List<CountryModel> Countries { get => _countries; set => _countries = value; }

        //public void CreateCountriesSelectList(List<Country> countryList)
        //{
        //    List<SelectListItem> countriesSelectList = new List<SelectListItem>();
        //    foreach (var country in countryList)
        //    {
        //        countriesSelectList.Add(new SelectListItem { Value = country.Id.ToString(), Text = country.Name });
        //    }
        //    _countries = countriesSelectList;
        //}

    }
}
