using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using VIewWPF.Models;




namespace VIewWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Context db = new Context();
        public MainWindow()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, MainColor + Coloring);

            db.Peoples.Load();
            GridPeople.ItemsSource = db.Peoples.Local.ToBindingList();
            AllPeoples.Text = "Всего людей: " + Convert.ToString(db.Peoples.Count());
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
            GridPeople.ItemsSource = null;
            GridPeople.ItemsSource = db.Peoples.Local.ToBindingList();
        }

        private void MetroWindow_Closing(object sender, EventArgs e)
        {
            db.Dispose();
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GridPeople.SelectedItems.Count > 0)
            {
                for (int i = 0; i < GridPeople.SelectedItems.Count; i++)
                {
                    People people = GridPeople.SelectedItems[i] as People;
                    if (people != null)
                    {
                        db.Peoples.Remove(people);
                    }
                }
            }
            db.SaveChanges();
        }

        private void GridPeople_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }
    }
}

