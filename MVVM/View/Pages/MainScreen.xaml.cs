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
using MPAccses.MVVM.Core;
using MPAccses.MVVM.ViewModel;

namespace MPAccses.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Page
    {
        private bool _isMenuOpen = false;
        public MainScreen()
        {
            InitializeComponent();
            FontLoader.LoadFonts();
            this.DataContext = new RoleViewModel();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                WatermarkText.Visibility = Visibility.Visible;
            }
            else
            {
                WatermarkText.Visibility = Visibility.Collapsed;
                WatermarkText.VerticalAlignment = VerticalAlignment.Bottom;
            }
        }

        private void NameTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox1.Text))
            {
                WatermarkText1.Visibility = Visibility.Visible; 
            }
            else
            {
                WatermarkText1.Visibility = Visibility.Collapsed;
                WatermarkText1.VerticalAlignment = VerticalAlignment.Bottom;
            }
        }

        private void NameTextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox2.Text))
            {
                WatermarkText2.Visibility = Visibility.Visible;
            }
            else
            {
                WatermarkText2.Visibility = Visibility.Collapsed;
                WatermarkText2.VerticalAlignment = VerticalAlignment.Bottom;
            }
        }

        private void NameTextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox3.Text))
            {
                WatermarkText3.Visibility = Visibility.Visible; 
            }
            else
            {
                WatermarkText3.Visibility = Visibility.Collapsed;
                WatermarkText3.VerticalAlignment = VerticalAlignment.Bottom;
            }
        }

        
        private void NameTextBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox3.Text))
            {
                WatermarkText3.Visibility = Visibility.Visible;
            }
            else
            {
                WatermarkText3.Visibility = Visibility.Collapsed;
                WatermarkText3.VerticalAlignment = VerticalAlignment.Bottom;
            }
        }
    }
}
