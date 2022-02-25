using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Models
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        private static int Counter = 0;
        public string Name { get; set; }
        public List<CityModel> Cities { get; set; }

        public static int GetNewID()
        {
            return Counter++;
        }


        public CountryModel()
        {
            CountryId = GetNewID();
        }
    }
}
