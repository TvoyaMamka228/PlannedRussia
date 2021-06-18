using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedRussiaLC.Model
{
    public class SchoolProfil
    {
        string Mathematics { get; set;}
        string RussianLanguage { get; set; }
        string ComputerScience { get; set; }
        string Physics { get; set; }
        string Chemistry { get; set; }
        string Biology { get; set; }
        string History { get; set; }
        string Literature { get; set; }
        public SchoolProfil
            (string mathematics= Res,
            string russianLanguage, string computerScience, 
            string physics, string chemistry, 
            string biology,
            string history, string literature)
        {
            Mathematics = mathematics;
            RussianLanguage = russianLanguage;
            ComputerScience = computerScience;
            Physics = physics;
            Chemistry = chemistry;
            Biology = biology;
            History = history;
            Literature = literature;
        }


    }
}
