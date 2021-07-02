using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
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
        BrushConverter bc = new BrushConverter();
        bool Save = true;
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
        Context db = new Context();
        public MainWindow()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, MainColor + Coloring);

            db.Peoples.Load();
            GridPeople.ItemsSource = db.Peoples.Local.ToBindingList();
            db.Peoples.Local.ToBindingList().ListChanged += MainWindow_ListChanged;
            AllPeoples.Text = "Всего людей: " + Convert.ToString(db.Peoples.Count());

            
            db.Factories.Load();
            GridFactory.ItemsSource = db.Factories.Local.ToBindingList();
            db.Factories.Local.ToBindingList().ListChanged += MainWindow_ListChanged;

            db.Revolutions.Load();
            GridRevolution.ItemsSource = db.Revolutions.Local.ToBindingList();
        }

        private void MainWindow_ListChanged(object sender, ListChangedEventArgs e)
        {
            //int LastPeopleId = (from m in db.Peoples select m.id).ToList().Last();
            //(sender as BindingList<People>)[GridPeople.Items.Count - 2].id = LastPeopleId;
            if ( e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                Save = false;
                SaveButton.Background = (Brush)bc.ConvertFrom("#7a4016");
                Coloring = "Orange";
                ThemeManager.Current.ChangeTheme(this, MainColor + Coloring);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
            Save = true;

            AllPeoples.Text = "Всего людей: " + Convert.ToString(db.Peoples.Count());

            SaveButton.Background = (Brush)bc.ConvertFrom("#3c5a1f");
            Coloring = "Green";
            ThemeManager.Current.ChangeTheme(this, MainColor + Coloring);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Save == false)
            {
                MessageBox.Show("Вы не сохранили данные");
                e.Cancel = true;
            }
        }
        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GridFactory.SelectedItem is Factories)
            {
                if (GridFactory.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < GridFactory.SelectedItems.Count; i++)
                    {
                        Factories factory = GridFactory.SelectedItems[i] as Factories;
                        if (factory != null)
                        {
                            db.Factories.Remove(factory);
                        }
                    }
                }
            }

            if (GridPeople.SelectedItem is People)
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
            }

        }


        private void GridPeople_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Save = false;
            SaveButton.Background = (Brush)bc.ConvertFrom("#7a4016");
            Coloring = "Orange";
            ThemeManager.Current.ChangeTheme(this, MainColor + Coloring);
        }

        private void Revolution_Click(object sender, RoutedEventArgs e)
        {
            int machines ;
            int peoples ;
            int res = 0;
            foreach (var i in db.Factories)
            {
                if (i.Machines <= i.Peoples)
                {
                    machines = i.Machines;
                    peoples = i.Peoples - machines;
                    res += 2 * machines + peoples;
                }
                else
                {
                    machines = i.Peoples;
                    res += 2 * machines;
                }
            }

            if (res >= db.Peoples.Count())
            {
                db.Revolutions.Find(1).RevolutionPeopls = 0;
                db.Revolutions.Find(1).Weapons = 0;
                db.Revolutions.Find(1).Bomb = 0;

            }
            else
            {
                db.Revolutions.Find(1).RevolutionPeopls = db.Peoples.Count() - res;
                db.Revolutions.Find(1).Weapons = (int)(0.2 * db.Revolutions.Find(1).RevolutionPeopls);
                db.Revolutions.Find(1).Bomb = (int)(0.05 * db.Revolutions.Find(1).RevolutionPeopls);
            }
            db.SaveChanges();
            

        }

        private void Military_Click(object sender, RoutedEventArgs e)
        { 
            Military.Text = $"Необходимо будет мобилизовать примерно {(int)(db.Revolutions.Find(1).RevolutionPeopls * 0.3)} человек для подавления.";
        }

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            Attack.Text = $"Приблизительные потери среди восставших до подавления: {(int)(db.Revolutions.Find(1).RevolutionPeopls * 0.7)}.";
        }
        private void Dead_Click(object sender, RoutedEventArgs e)
        {
            Dead.Text = $"При подавлении погибнет около {(int)(((int)(db.Revolutions.Find(1).RevolutionPeopls * 0.7))*0.4)} солдат.";
        }
    }
}