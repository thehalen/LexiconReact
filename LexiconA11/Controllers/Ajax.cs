using LexiconA11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Controllers
{
    public class Ajax : Controller
    {
        public IActionResult Index()
        {
            PeopleViewModel personVM = new();

            if (personVM.PersonsListView.Count < 1)
            {
                personVM.MakePeople();
            }
            return View();
        }

        //[HttpGet]
        //public IActionResult GetPersons()
        //{
        //    List<PersonModel> personModel = listOfPeople;
        //    return PartialView("_persons", personModel);
        //}

        //[HttpPost]
        //public IActionResult GetPersonByID(int PersonID)
        //{
        //    PersonModel personModel = GetPersonByID(PersonID);
        //    return PartialView("_persons", personModel);
        //}

        //[HttpPost]
        //public IActionResult DeletePersonById(int PersonID)
        //{            
        //    DeletePerson(PersonID);
        //    return RedirectToAction("Index");
        //}

    }
}
