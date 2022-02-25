using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LexiconA11.Models
{
    public class LanguageViewModel
    {

        private List<LanguageModel> _languages;
        public List<LanguageModel> Languages
        {
            get
            {
                return _languages;
            }
            set => _languages = value; }


    }
}
