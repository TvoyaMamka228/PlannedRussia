using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIewWPF.Models
{
    public class People : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _birthday="22.8.1488";
        public People() { OnPropertyChanged("id"); }
        public int id { get; set; }
        public string FerstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; OnPropertyChanged("Age"); }
        }

        public int Age
        {
            get
            {

                DateTime now = DateTime.Today;
                int age = now.Year - DateTime.Parse(Birthday).Year;
                if (DateTime.Parse(Birthday) > now.AddYears(-age)) age--;
                return age;
            }
        } 

    }

}
