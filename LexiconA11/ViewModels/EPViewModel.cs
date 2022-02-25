using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LexiconA11.Models
{
    public class EPViewModel
    {
        public PersonModel PersonModel;
        public List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Languages = new();
    }
}
