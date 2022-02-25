using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Models
{
    public class PersonLanguage
    {
        public int PersonId { get; set; }
        public PersonModel Person { get; set; }
        public int LanguageId { get; set; }
        public LanguageModel Language { get; set; }


    }
}
