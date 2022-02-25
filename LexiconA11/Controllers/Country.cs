using LexiconA11.Data;
using LexiconA11.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Country : Controller
    {
        private readonly ApplicationDbContext _context;

        public Country(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Geographics citiesVM = new Geographics
            {
                CityList = _context.Cities.ToList(),
                CountryList = _context.Countries.ToList()
            };
            return View(citiesVM);
        }

        public ActionResult Delete(int id)
        {
            var p = _context.Countries.Find(id);
            _context.Remove(p);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Add(Geographics g)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(new CountryModel() { Name = g.Name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return StatusCode(400);
        }
    }
}
