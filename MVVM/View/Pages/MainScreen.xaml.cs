using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using MPAccses.MVVM.Model;
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




        private void NameTextBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox4.Text))
            {
                WatermarkText4.Visibility = Visibility.Visible;
            }
            else
            {
                WatermarkText4.Visibility = Visibility.Collapsed;
                WatermarkText4.VerticalAlignment = VerticalAlignment.Bottom;
            }
        }

        private void Valid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string inputCodeStr = WatermarkText1.Text.Trim();

            // Проверка на корректность ввода кода
            if (!int.TryParse(inputCodeStr, out int inputCode))
            {
                MessageBox.Show("Код сотрудника некорректен.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Получаем фамилию, имя и отчество
            string inputSureName = WatermarkText2.Text.Trim();
            string inputName = WatermarkText3.Text.Trim();
            string inputPatronymic = WatermarkText4.Text.Trim();

            // Проверка на заполненность полей
            if (string.IsNullOrWhiteSpace(inputSureName) || string.IsNullOrWhiteSpace(inputName) || string.IsNullOrWhiteSpace(inputPatronymic))
            {
                MessageBox.Show("Пожалуйста, заполните все поля: Фамилия, Имя и Отчество.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка роли
            if (!int.TryParse(WatermarkText4.Text.Trim(), out int inputRole)) // Предполагаем, что WatermarkText5 - это поле для роли
            {
                MessageBox.Show("Роль должна быть целым числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = new ISMPEntities())
                {
                    // Проверка существования пользователя
                    bool userExists = context.Users1.Any(u =>
                        u.ID_User == inputCode &&
                        u.Name.Equals(inputName, StringComparison.OrdinalIgnoreCase) &&
                        u.SureName.Equals(inputSureName, StringComparison.OrdinalIgnoreCase) &&
                        u.Patronymic.Equals(inputPatronymic, StringComparison.OrdinalIgnoreCase) &&
                        u.Role == inputRole);

                    if (userExists)
                    {
                        // Если пользователь найден, переходим на главную страницу
                        CoreNavigate.NavigatorCore.Navigate(new HomePage());
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с такими данными не найден. Проверьте введенные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void NameTextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Проверка текста в текстовом поле для имени
            if (string.IsNullOrEmpty(NameTextBox3.Text)) // исправлено с NameTextBox4 на NameTextBox3
            {
                WatermarkText3.Visibility = Visibility.Visible;
            }
            else
            {
                WatermarkText3.Visibility = Visibility.Collapsed; // Исправлено на правильный WatermarkText3
            }
        }

    }
}
