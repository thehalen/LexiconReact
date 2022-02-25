using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Models
{
    [Table("People")]
    public class PersonModel 
    {
        [DataType(DataType.Text)]
        [Display(Name = "Name: ")]
        //[Required(ErrorMessage = "Name is required!"), MaxLength(80), MinLength(4)]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number: ")]
        //[Required]
        public string PhoneNr { get; set; }
        public List<PersonLanguage> Languages { get; set; }
        //[DataType(DataType.Text)]
        //[Display(Name = "City: ")]
        //[Required]
        public CityModel City { get; set; }
        public int CityId { get; set; }

        [Key]
        public int PersonId { get; set; }
        public static int Counter = 0;
        public string AddLang;
        public static int GetNewID()
        {            
            return Counter++;
        }


        public PersonModel()
        {
            //PersonId = GetNewID();
        }

        public PersonModel(string name, int cityId, string phonenr)
        {
            Name = name;
            CityId = cityId;
            PhoneNr = phonenr;
            //PersonId = GetNewID();
        }



    }
}
