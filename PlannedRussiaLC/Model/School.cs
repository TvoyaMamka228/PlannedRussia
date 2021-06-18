using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedRussiaLC.Model
{
    public class School
    {
        string Name { get; set; }
        string Address { get; set; }
        public School(string name, string address)
        {
            Name = name ?? throw new ArgumentNullException("Значение не может быть пустым", nameof(name));
            Address = address ?? throw new ArgumentNullException("Значение не может быть пустым", nameof(address));
        }

    }
}
