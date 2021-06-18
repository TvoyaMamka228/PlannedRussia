using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedRussiaLC.Model
{
    public class People
    {
        string FerstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        uint Passport { get; set; }
        DateTime Birthday { get; }
        int Age 
        {
            get 
            {
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - Birthday.Year;
                if (Birthday > nowDate.AddYears(-age)) 
                    age--;
                return age;
            }
        }
        public People(string ferstName, string lastName, string middleName, uint passport, DateTime birthday)
        {
            FerstName = ferstName ?? throw new ArgumentNullException("Значение не может быть пустым",nameof(ferstName));
            LastName = lastName ?? throw new ArgumentNullException("Значение не может быть пустым", nameof(lastName));
            MiddleName = middleName ?? throw new ArgumentNullException("Значение не может быть пустым", nameof(middleName));
            Passport = passport;
        }

    }
}
