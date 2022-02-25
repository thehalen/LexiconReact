using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Models
{
    public class ReactPeopleVM
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNr { get; set; }
        public string City { get; set; } 
        public string Languages { get; set; }
        public ReactPeopleVM(int id, string name, string phoneNumber, string cityName, string langs)
        {
            PersonId = id;
            Name = name;
            PhoneNr = phoneNumber;
            City = cityName;
            Languages = langs;
        }
        public ReactPeopleVM()
        {
           
        }
    }
}
