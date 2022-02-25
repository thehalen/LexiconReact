using LexiconA11.Data;
using LexiconA11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Controllers
{
    public class Language : Controller
    {
        private readonly ApplicationDbContext _context;

        public Language(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            LanguageViewModel lm = new LanguageViewModel
            {
                Languages = _context.Languages.ToList()
            };
            return View(lm);            
        }

        public ActionResult Delete(int id)
        {
            var p = _context.Languages.Find(id);
            _context.Remove(p);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(LanguageViewModel g)
        {
            if (ModelState.IsValid)
            {
                _context.Languages.Add(new LanguageModel() { Name = g.LanguageToAdd});
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return StatusCode(400);
        }
    }
}
