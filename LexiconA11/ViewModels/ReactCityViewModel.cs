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
    public class ReactCityViewModel
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public ReactCityViewModel(int id, string name)
        {
            CityId = id;
            Name = name;
        }
        public ReactCityViewModel()
        {
            
        }
    }
}
