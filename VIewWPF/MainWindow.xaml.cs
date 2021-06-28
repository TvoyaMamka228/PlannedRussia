using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using VIewWPF.Models;




namespace VIewWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        static private BindingList<People> Peoples = new BindingList<People>();
        public MainWindow()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, MainColor + Coloring);
            using (Context db = new Context())
            {
                foreach (var i in db.Peoples)
                {
                    Peoples.Add(i);
                }
                //Peoples = new BindingList<People>(db.Peoples.ToList()) { };
                People.AllPeoples = Peoples.Count;
                AllPeoples.Text = "Всего людей: " + Convert.ToString(People.AllPeoples);
                GridPeople.ItemsSource = Peoples;
                Peoples.ListChanged += Peoples_ListChanged;
            }
        }

        string MainColor = "Dark.";
        string Coloring = "Blue";
        private void Palette_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var s = Palette.SelectedValue;
            var s2 = MahApps.Metro.Controls.ColorHelper.GetColorName((Color?)s, null);
            string[] Color = s2.Split(' ');
            string Coloring = Color[0];
            ThemeManager.Current.ChangeTheme(this, MainColor + Coloring);
        }

        private void Palette2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var s = Palette2.SelectedValue;
            var s2 = MahApps.Metro.Controls.ColorHelper.GetColorName((Color?)s, null);
            string[] Color = s2.Split(' ');
            if (Color[0] == "Black")
            {
                MainColor = "Dark.";
            }
            else MainColor = "Light.";
            ThemeManager.Current.ChangeTheme(this, MainColor + Coloring);
        }

        private void Peoples_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType ==  ListChangedType.ItemAdded)
            {

                People.AllPeoples = Peoples.Count;
                AllPeoples.Text = "Всего людей: " + Convert.ToString(People.AllPeoples);
            }

            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                
            }

            if(e.ListChangedType == ListChangedType.ItemDeleted)
            {

            }
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            using (Context db = new Context())
            {
                foreach(var i in Peoples)
                {
                }
            }
        }
    }
}

