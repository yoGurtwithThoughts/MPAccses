using DocumentFormat.OpenXml.Bibliography;
using MPAccses.MVVM.Model;
using MPAccses.MVVM.Model.ModelData;
using MPAccses.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
using System.Windows.Threading;
using static MPAccses.MVVM.Core.Navigation;
using Department = MPAccses.MVVM.Model.Department;

namespace MPAccses.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditStatus.xaml
    /// </summary>
    public partial class EditStatus : Page
    {
        public event Action<string, string> StatusUpdated;
        private DispatcherTimer _timer;
        private ISMPEntities1 _db = new ISMPEntities1();

        public EditStatus()
        {
            InitializeComponent();
            this.DataContext = new BottomBarViewModel();
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5)
            };
            _timer.Tick += Timer_Tick1;
        }



        private void ArrowBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new HomePage());
        }

        private void ShotDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListData.IsOpen = true;
        }

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus(sender);
        }

        private void Already_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus(sender);
        }

        private void NewPr_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus(sender);
        }


        private void UpdateStatus(object sender)
        {
            if (sender is Button button)
            {
                string status = button.Tag.ToString();
                TextBlock statusTextBlock = (TextBlock)FindName("StatusTextBlock");

                if (statusTextBlock != null)
                {
                    statusTextBlock.Text = $"Статус: {status}";
                }

                ListData.IsOpen = false;
            }
        }

        private void UpdateDepartament(object sender)
        {
            if (sender is Button button)
            {
                string department = button.Tag.ToString();
                TextBlock departmentTextBlock = (TextBlock)FindName("DepartamentTextBlock");

                if (departmentTextBlock != null)
                {
                    departmentTextBlock.Text = $"Цех: {department}";
                }

                DepartamentMenu.IsOpen = false;
            }
        }

        private void SaveStatus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock departmentTextBlock = (TextBlock)FindName("DepartamentTextBlock");
            TextBlock statusTextBlock = (TextBlock)FindName("StatusTextBlock");

            if (departmentTextBlock == null || statusTextBlock == null)
            {
                Message.Text = "Ошибка: Не удалось найти текстовые блоки.";
                Message.Visibility = Visibility.Visible;
                return;
            }

            string currentDepartment = departmentTextBlock.Text.Replace(": ", "").Trim();
            string currentStatus = statusTextBlock.Text.Replace(": ", "").Trim();

            if (string.IsNullOrEmpty(currentDepartment) || string.IsNullOrEmpty(currentStatus))
            {
                Message.Text = "Ошибка: Необходимо выбрать статус и департамент.";
                Message.Visibility = Visibility.Visible;
                return;
            }

            try
            {
                using (var context = new ISMPEntities1())
                {
                    var department = context.Department.FirstOrDefault(d => d.Name_Departament == currentDepartment)
                                     ?? new Department { Name_Departament = currentDepartment };

                    var status = context.Status.FirstOrDefault(s => s.Status1 == currentStatus)
                                 ?? new Status { Status1 = currentStatus };

                    var newTask = new Tasks
                    {
                        Department1 = department,
                        Status1 = status
                    };

                    context.Tasks.Add(newTask);
                    context.SaveChanges();
                }

                Message.Text = "Данные успешно сохранены!";
                Message.Visibility = Visibility.Visible;

               
                StatusUpdated?.Invoke(currentDepartment, currentStatus);
            }
            catch (Exception ex)
            {
                Message.Text = "Произошла ошибка! ";
                Message.Visibility = Visibility.Visible;
                StartErrorMessageTimer();
                StatusUpdated?.Invoke(currentDepartment, currentStatus);
            }
        }

            private void StartErrorMessageTimer()
        {
            _timer.Interval = TimeSpan.FromSeconds(10);
            _timer.Tick += Timer_Tick1; 
            _timer.Start(); 
        }

       
       private void Timer_Tick1(object sender, EventArgs e)
        {
            Message.Visibility = Visibility.Collapsed; 
            _timer.Stop(); 
        }

        private void D1_Click(object sender, RoutedEventArgs e)
        {
            UpdateDepartament(sender);
        }

        private void D2_Click(object sender, RoutedEventArgs e)
        {
            UpdateDepartament(sender);
        }

        private void D3_Click(object sender, RoutedEventArgs e)
        {
            UpdateDepartament(sender);
        }


        private void OpenMenuDepart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DepartamentMenu.IsOpen = true;
        }
        public void SetInitialValues(string department, string status)
        {
            TextBlock departamentTextBlock = (TextBlock)FindName("DepartamentTextBlock");
            TextBlock statusTextBlock = (TextBlock)FindName("StatusTextBlock");

            if (departamentTextBlock != null)
            {
                departamentTextBlock.Text = $"Цех: {department}";
            }

            if (statusTextBlock != null)
            {
                statusTextBlock.Text = $"Статус: {status}";
            }
        }
    }
}
