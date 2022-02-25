using LexiconA11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Controllers
{
    public class Persons : Controller
    {
        public IActionResult Index()        {
            PeopleViewModel personVM = new();
            //PeopleViewModel persons = new PeopleViewModel();
            if (personVM.PersonsListView.Count < 1)
            {
                personVM.MakePeople();
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(CreatePersonViewModel personVM)
        {
            PeopleViewModel peopleViewModel = new();

            peopleViewModel.AddPerson(personVM.Name,
                                      personVM.CityId,
                                      personVM.PhoneNr) ;
            if (ModelState.IsValid)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeletePerson(int id)
        {
            //PeopleViewModel.DeletePerson(id);
            return RedirectToAction("Index");
        }
    }
}
