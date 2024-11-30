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
                if (int.TryParse(NameTextBox.Text, out int parsedValue))
                {

                    WatermarkText.Visibility = Visibility.Collapsed;

                }
                else
                {

                    MessageBox.Show("Введите корректное числовое значение.", "Ошибка", MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
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
        public class ISMPEntities : DbContext
        {
            public DbSet<User> Users1 { get; set; } // Здесь указываем DbSet для User

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>()
                    .HasKey(u => u.Id); // Указываем, что Id - это первичный ключ

                // Другие конфигурации модели (если необходимо)
            }
        }
        private List<User> LoadUsers()
        {
            using (var context = new ISMPEntities())
            {
                return context.Users1.ToList(); // Загружаем всех пользователей
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
            }
        }
        private void Valid_MouseDown(object sender, MouseButtonEventArgs e)
        {
//            // Получаем данные из полей
//            string inputCodeStr = WatermarkText.Text.Trim(); // Код сотрудника
//            string inputSureName = WatermarkText1.Text.Trim(); // Фамилия
//            string inputName = WatermarkText2.Text.Trim(); // Имя
//            string inputPatronymic = WatermarkText3.Text.Trim(); // Отчество

//            // Проверяем, что все поля заполнены
//            if (string.IsNullOrWhiteSpace(inputCodeStr) ||
//                string.IsNullOrWhiteSpace(inputSureName) ||
//                string.IsNullOrWhiteSpace(inputName) ||
//                string.IsNullOrWhiteSpace(inputPatronymic))
//            {
//                MessageBox.Show("Пожалуйста, заполните все поля: Код сотрудника, Фамилия, Имя, Отчество.",
//                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
//                return;
//            }

//            string inputCode = inputCodeStr; // Можно оставить так, если код хранится как строка


//            try
//            {
//                using(var context = new ISMPEntities())
//{
//                    var user = context.Users1.FirstOrDefault(u =>
//                        u.Code_User.Equals(inputCode, StringComparison.OrdinalIgnoreCase) &&
//                        u.Name.Equals(inputName, StringComparison.OrdinalIgnoreCase) &&
//                        u.SureName.Equals(inputSureName, StringComparison.OrdinalIgnoreCase) &&
//                        u.Patronymic.Equals(inputPatronymic, StringComparison.OrdinalIgnoreCase)
//                    );

//                    if (user != null)
//                    {
                        // Пользователь найден, переходим на главную страницу
                        CoreNavigate.NavigatorCore.Navigate(new HomePage());
            //        }
            //        else
            //        {
            //            // Пользователь не найден
            //            MessageBox.Show("Пользователь с такими данными не найден. Проверьте введенные данные.",
            //                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //        }
            //    }
            //}
            //catch (SqlException sqlEx)
            //{
            //    MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}",
            //        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Произошла ошибка: {ex.Message}",
            //        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
    }
}
