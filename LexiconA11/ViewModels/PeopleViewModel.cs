using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Models
{
    public class PeopleViewModel : CreatePersonViewModel
    {

        public string filterC ="",filterN;
		public static string filter_C="*", filter_N="*";

		public  List<PersonModel> personsListView = new List<PersonModel>();
		public  List<PersonModel> listOfPeople = new List<PersonModel>();
		private DbContext _context;
        public List<PersonModel> PersonsListView
		{			
			get 
			{
				personsListView.Clear();
				var foo = listOfPeople.Where(c => c.City.Name == filter_C && c.Name == filter_N);
				personsListView.AddRange(foo);
				return listOfPeople;
				//return PeopleViewModel.personsListView;
			}
			set => personsListView = value;
		}
        public string FilterC { get => filterC; set => filterC = value; }
        public string FilterN { get => filterN; set => filterN = value; }

		public PeopleViewModel()
		{
			personsListView = new List<PersonModel>();
		}

		
		
		public PeopleViewModel(Data.ApplicationDbContext context)
		{
			_context = context;
			personsListView = new List<PersonModel>();
			listOfPeople = context.People.Include(p => p.City).Include(p => p.Languages).ToList();
		}

		public void AddPerson(string name, int cityId, string phonenr)
		{
			PersonModel person = new PersonModel(name, cityId, phonenr);
			AddPerson(person);
		}

		public PersonModel GetPersonByID(int id)
        {
			return (PersonModel)listOfPeople.First(x => x.PersonId == id);
        }

		public void AddPerson(PersonModel pm)
		{
			listOfPeople.Add(pm);
		}

		public void DeletePerson(int ind)
		{
			listOfPeople.Remove(GetPersonByID(ind));
			//return false;
		}

		public void MakePeople()
		{
			//app peeps
			listOfPeople.Add(new PersonModel() { Name = "Nisse", CityId = 1, PhoneNr = "09341" });
			listOfPeople.Add(new PersonModel() { Name = "Hans", CityId = 2, PhoneNr = "020KNDÖDEN" });
			listOfPeople.Add(new PersonModel() { Name = "Bojan", CityId = 3, PhoneNr = "123CALLING" });
		}

	}
}
