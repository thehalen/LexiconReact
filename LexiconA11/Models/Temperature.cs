using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Models
{
    public class Temperature
    {
        readonly string scale;
        double temperature;
        public Temperature(double temp, string sca)
        {
            temperature = temp;
            scale = sca;
        }

        public double Temp { get => temperature; set => temperature = value; }

        public static string SupportedScales() //doesn't make sense to evaluate before we have an instance and values to work with...
        {
            return "This module supports fahrenheit and celsius";
        }

        public string Fever()
        {
            if (scale=="fahrenheit") temperature = ((temperature-32.0)*5.0/9.0);
            string res = this.temperature switch
            {
                3.6 => "Not great, not terrible. IF YOU ARE A FRIDGE!",
                < 0.0 => "Human popsicle.",
                < 20.0 => "Stage 4 profound hypothermia. No vital signs. You are dead. RIP.",
                < 28.0 => "Stage 3 severe hypothermia. Unconscious, not shivering.",
                < 32.0 => "Stage 2 moderate hypothermia. Drowsy and not shivering.",
                < 35.0 => "Stage 1 mild hypothermia. Awake and shivering.",
                < 36.5 => "A bit cold. Better do some jumping jacks!",
                < 37.5 => "Perfectly normal. Unless you're a beer or a cup of coffee.",
                < 38.3 => "You're running a bit of a fever. Water and paracetamol for you.",
                < 40 => "Severe hyperthermia. Better cool down quickly!",
                < 41.99 => "Hyperpyrexia. This is life threatening!",
                <= 42 => "Answer to the Ultimate Question of Life, the Universe, and Everything. And the end of those things as far as you are concerned.",
                < 50 => "You are dead from heat stroke. RIP",
                < 54 => "Rare. Dr. Lecter approves.",
                < 65 => "Medium. Still juicy.",
                < 80 => "Well done. Probably a bit dry.",
                _ => "You are aware that this is in " + scale + ", right?",
            };
            return res;
        }
    }
}
