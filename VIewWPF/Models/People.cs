using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIewWPF.Models
{
    public class People: INotifyPropertyChanged
    {
        public static int AllPeoples { get; set; }
        public People(string ferstName, string middleName, string lastName, DateTime birthday)
        {
            FerstName = ferstName ?? throw new ArgumentNullException(nameof(ferstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Birthday = birthday;
        }
        public People() { }

        private string _FerstName;
        private string _LastName;
        private string _MiddleName;
        public int id { get; set; }
        public string FerstName
        {
            get { return _FerstName; }
            set { _FerstName = value; OnPropertyChange("FerstName"); }
        }
        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; OnPropertyChange("MiddleName"); }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; OnPropertyChange("LastName"); }
        }
        public DateTime Birthday { get; set; }
        public int Age 
        {

            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - Birthday.Year;
                if (Birthday > now.AddYears(-age)) age--;
                return age;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
