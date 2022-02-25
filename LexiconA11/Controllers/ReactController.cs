using LexiconA11.Data;
using LexiconA11.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Controllers
{
    
    public class ReactController : Controller
    {
        
        public ReactController(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {
            ReactViewModel rVM = new();
            Console.WriteLine(ModelState.IsValid);
            rVM.PersonList = (from x in _context.People
                              select new ReactPeopleVM
                              {
                                  PersonId = x.PersonId,
                                  Name = x.Name,
                                  PhoneNr = x.PhoneNr,
                                  City = x.City.Name,
                                  Languages = x.Languages.Count + ": " + string.Join(", ", (from l in x.Languages
                                               select l.Language.Name).ToArray())
                              }
                  ).ToList();

            rVM.LanguageList = (from x in _context.Languages
                                select new ReactLanguageVM
                                {
                                    LanguageId = x.LanguageId,
                                    Name = x.Name
                                }
                          ).ToList();

            rVM.CityList = (from x in _context.Cities.Include(c => c.Country).ToList()
                          select new ReactCityViewModel
                          {
                              CityId = x.CityId,
                              Name = x.Name + ", " + x.Country.Name
                          }
                          ).ToList();
            return Json(rVM);
        }

        [HttpPost]
        public IActionResult AddPerson(PersonModel personData)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(personData);
                _context.SaveChanges();
                return StatusCode(200);
            }
            return StatusCode(400);
        }

            public IActionResult DeletePersonById(int personID)
        {
            var p = _context.People.Find(personID);
            if (ModelState.IsValid && p != null)
            {
                _context.Remove(p);
                _context.SaveChanges();
                return StatusCode(200);
            }
            return StatusCode(400);
        }


    }
}
