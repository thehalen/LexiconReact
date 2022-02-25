using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Models
{
    public class LanguageModel
    {
        [Key]
        public int LanguageId { get; set; }
        private static int Counter = 0;
        public string Name { get; set; }
        public List<PersonLanguage> Persons { get; set; }


        public static int GetNewID()
        {
            return Counter++;
        }


        public LanguageModel()
        {
            Counter = GetNewID();
        }
    }
}
