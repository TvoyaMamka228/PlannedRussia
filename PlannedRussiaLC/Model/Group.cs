using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedRussiaLC.Model
{
    public class Group
    {
        string Name { get; set; }
        public Group(string name)
        {
            Name = name ?? throw new ArgumentNullException("Значение не может быть пустым",nameof(name));
        }

    }
}
