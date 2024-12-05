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

namespace MPAccses.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {  private int _count = 0;
        private void IncrementLastCount()
        {
            _count++; 
            UpdateLastCountText(); 
        }

        private void UpdateLastCountText()
        {
            Count.Text = _count.ToString();
            SaveCount();
        }
        private void LoadCount()
        {
            _count = Properties.Settings.Default.LastLoginCount;
        }
        public HomePage()
        {
            InitializeComponent();
            this.DataContext = new BottomBarViewModel();
         
        }

        private void ShotDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void SaveCount()
        {
            Properties.Settings.Default.LastLoginCount = _count;
            Properties.Settings.Default.Save();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCount();
            IncrementLastCount();
        }
    }
}
