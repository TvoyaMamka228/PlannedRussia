﻿using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace VIewWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, MainColor+Coloring);

        }
        string MainColor = "Dark.";
        string Coloring = "Blue";
        private void Palette_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var s = Palette.SelectedValue;
            var s2 = MahApps.Metro.Controls.ColorHelper.GetColorName((Color?)s, null);
            string[] Color = s2.Split(' ');
            string Coloring = Color[0];
            ThemeManager.Current.ChangeTheme(this, MainColor+Coloring);
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
            ThemeManager.Current.ChangeTheme(this, MainColor+Coloring);
        }
    }
}
