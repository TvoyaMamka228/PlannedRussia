using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIewWPF.Models
{ 
    public class Revolutions : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _RevolutionPeopls;
        private int _Weapons;
        private int _Bomb;
        public Revolutions() { }
        public int id { get; set; }
        public int RevolutionPeopls 
        {
            get { return _RevolutionPeopls; } 
            set { _RevolutionPeopls = value; OnPropertyChanged("RevolutionPeopls"); }
        }
        public int Weapons
        {
            get { return _Weapons; }
            set { _Weapons = value; OnPropertyChanged("Weapons"); }
        }
        public int Bomb
        {
            get { return _Bomb; }
            set { _Bomb = value; OnPropertyChanged("Bomb"); }
        }

    }
}
