using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using MPAccses.MVVM.Model;
using MPAccses.MVVM.Model.ModelData;
using MPAccses.MVVM.ViewModel;
using static MPAccses.MVVM.Core.Navigation;

namespace MPAccses.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Page
    {
    
        private ISMPEntities1 _db = new ISMPEntities1();
        public MainScreen()
        {
            InitializeComponent();
            FontLoader.LoadFonts();
            


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

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

        private void Valid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string inputSureName = NameTextBox1.Text; 
            string inputName = NameTextBox2.Text;
            Console.WriteLine(_db.Database.Connection.ConnectionString);
            _db.Database.Log = Console.WriteLine;
           
            try
            {
                Users1 userModel = _db.Users1.FirstOrDefault(x => x.Name == NameTextBox2.Text && x.SureName == NameTextBox1.Text);

                if (userModel!=null)
                {
                    CoreNavigate.NavigatorCore.Navigate(new HomePage());
                }
                else
                {
                    MessageBox.Show($"Ошибка ввода данных",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    NameTextBox1.Text = string.Empty;
                    NameTextBox2.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
      
    }
}
