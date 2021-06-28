using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIewWPF.Models
{
    public class Factory
    {
        public Factory(int machines, int peoples)
        {
            Machines = machines;
            Peoples = peoples;
        }
        public int Id { get; set; }
        public int Machines { get; set; }
        public int Peoples { get; set; }
    }
}
