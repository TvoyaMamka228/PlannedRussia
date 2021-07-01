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
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public People() { }
        public int id { get; set; } = 0;
        private string _birthday="22.8.1488";
        private string _FerstName;
        private string _MiddleName;
        private string _LastName;

        public string FerstName
        {
            get { return _FerstName; }
            set { _FerstName = value; OnPropertyChanged("FerstName"); }
        }
        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; OnPropertyChanged("MiddleName"); }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; OnPropertyChanged("LastName"); }
        }

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
