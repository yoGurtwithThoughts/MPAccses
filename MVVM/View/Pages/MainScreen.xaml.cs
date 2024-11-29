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

namespace MPAccses.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Page
    {
        public MainScreen()
        {
            InitializeComponent();
            FontLoader.LoadFonts();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        

            // Управляем видимостью WatermarkText в зависимости от текста в NameTextBox
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

        }

        private void NameTextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NameTextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DropButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
    
}
