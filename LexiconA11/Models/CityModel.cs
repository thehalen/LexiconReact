using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Models
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }
        private static int Counter = 0;
        public string Name { get; set; }       
        public List<PersonModel> Persons { get; set; }
        [Required]
        [ForeignKey("CountryId")]
        public CountryModel Country { get; set; }
        public int CountryId { get; set; }

        public static int GetNewID()
        {            
            return Counter++;
        }


        public CityModel()
        {
            Persons = new();
        }
    }
}
