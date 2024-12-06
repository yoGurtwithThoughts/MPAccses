﻿using MPAccses.MVVM.Core;
using MPAccses.MVVM.Model;
using MPAccses.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
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
using static MPAccses.MVVM.Core.Navigation;

namespace MPAccses.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    { 
        public HomePage()
        {
            InitializeComponent();
            this.DataContext = new BottomBarViewModel();
           
        }

        private void ShotDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
      

       

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new EditStatus());
        }

        private void NewTask_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new NewTask());
        }
    }
}
