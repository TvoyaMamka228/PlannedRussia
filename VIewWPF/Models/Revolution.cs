using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIewWPF.Models
{ 
    public class Revolution
    {
        public Revolution(int peopls, int weapons, int granate)
        {
            Peopls = peopls;
            Weapons = weapons;
            Granate = granate;
        }

        public int Id { get; set; }
        public int Peopls { get; set; }
        public int Weapons { get; set; }
        public int Granate { get; set; }

    }
}
