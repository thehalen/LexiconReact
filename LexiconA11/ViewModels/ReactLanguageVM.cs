using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Models
{
    public class ReactLanguageVM
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public ReactLanguageVM()
        {

        }

        public ReactLanguageVM(int id, string name)
        {
            LanguageId = id;
            Name = name;
        }
    }
}
