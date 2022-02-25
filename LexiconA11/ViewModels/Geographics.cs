using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LexiconA11.Models
{
    public class Geographics
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        public int idToAdd { get; set; }


        private List<CityModel> _cities;
        public List<CityModel> CityList
        {
            get => _cities; set => _cities = value;
        }

        private List<CountryModel> _countries;
        public List<CountryModel> CountryList { get => _countries; set => _countries = value; }


    }
}
