using LexiconA11.Data;
using LexiconA11.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class EntityPersons : Controller
    {
        private readonly ApplicationDbContext _context;


        public EntityPersons(ApplicationDbContext context)
        {
            _context = context;
        }
        private PeopleViewModel PersonVM() {
            return new PeopleViewModel()
            {
                listOfPeople = _context.People.Include(p => p.City).Include(p => p.Languages).ToList()
            };
        } 

        public IActionResult Index()
        {
            //personVM.listOfPeople = _context.People.Include(p => p.City).ToList();
            //PeopleViewModel.listOfPeople = _context.People.ToList();
            PeopleViewModel pVM = PersonVM();
            return View("Index", pVM);
        }

    //    rVM.PersonList = (from x in _context.People
    //              select new ReactPeopleVM
    //                          {
    //                              PersonId = x.PersonId,
    //                              Name = x.Name,
    //                              PhoneNr = x.PhoneNr,
    //                              City = x.City.Name,
    //                              Languages = (from l in x.Languages
    //                                           select new ReactLanguageVM
    //                                           {
    //                                               LanguageId = l.LanguageId,
    //                                               Name = l.Language.Name
    //}
    //                                           ).ToList()
    //                          }


[HttpPost]
        public ActionResult AddPerson(PeopleViewModel personVM)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(new PersonModel { Name = personVM.Name, CityId = personVM.CityId, PhoneNr = personVM.PhoneNr });
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePerson(int id)
        {
            var p = _context.People.Find(id);
            _context.Remove(p);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(PersonModel personModel) //får inte med sig nya språket, what gives #¤&¤E&¤%ER&
        {
            if (ModelState.IsValid)
            {                
                _context.Update(personModel);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddLang(PersonModel personModel)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }

            return View("Edit", personModel);
        }

        public ActionResult Edit(int id)
            {
            if (ModelState.IsValid)
            {
                PersonModel personModel = _context.People.Where(x => x.PersonId == id).Include(p => p.City).Include(l => l.Languages).FirstOrDefault();
                EPViewModel ePViewModel = new()
                {
                    PersonModel = personModel
                };
                //List<LanguageModel> ll = ;
                foreach (LanguageModel lm in _context.Languages.ToList())
                {
                    ePViewModel.Languages.Add(new SelectListItem
                    {
                        Text = lm.Name,
                        Value = lm.LanguageId.ToString()
                    });
                }
            return View("Edit", personModel);
            }

            return View();
        }

        public ActionResult Edits(PersonModel personModel)
        {
            return View("Update",personModel);
        }

    }
}
