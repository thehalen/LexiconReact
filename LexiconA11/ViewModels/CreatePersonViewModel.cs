using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Models
{
    public class CreatePersonViewModel
    {
		[DataType(DataType.Text)]
		[Display(Name = "Name: ")]
		[Required(ErrorMessage = "Name is required!"), MaxLength(80), MinLength(4)]
		public string Name { get; set; }

		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Phone number: ")]
		[Required]
		public string PhoneNr { get; set; }

		
		[Display(Name = "City: ")]
		[Required]
		public CityModel City { get; set; }
		public int CityId { get; set; }

		[Key]
		public int PersonId { get; set; }
		public static int Id = 0;

		public List<PersonLanguage> Languages { get; set; }

		public CreatePersonViewModel()
		{
		}
	}
}
