using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LexiconA11.Data;

namespace LexiconA11.Models
{
    public class ReactViewModel
    {
        public string Fisk = "En reactviewmodel";
        public List<ReactPeopleVM> PersonList { get; set; }
        public List<ReactLanguageVM> LanguageList { get; set; }
        public List<ReactCityViewModel> CityList { get; set; }
        public ReactViewModel()
        {
            PersonList = new();
            CityList = new();
        }
    }
}
