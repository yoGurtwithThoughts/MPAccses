using DocumentFormat.OpenXml.Bibliography;
using MPAccses.MVVM.Model;
using MPAccses.MVVM.ViewModel;
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
using System.Windows.Threading;
using static MPAccses.MVVM.Core.Navigation;

namespace MPAccses.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditStatus.xaml
    /// </summary>
    public partial class EditStatus : Page
    {
        private DispatcherTimer _timer;
        private ISMPEntities1 _db = new ISMPEntities1();
        public EditStatus()
        {
            InitializeComponent();
            this.DataContext = new BottomBarViewModel();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += Timer_Tick;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            Message.Visibility = Visibility.Collapsed;
            _timer.Stop();
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
            
            var button = sender as Button;
            if (button != null)
            {
                string status = button.Tag.ToString();

               
                TextBlock statusTextBlock = (TextBlock)FindName("StatusTextBlock");
                if (statusTextBlock != null)
                {
                    statusTextBlock.Text = $"Статус: {status}";
                }
            }
        }
        private void UpdateDepartament(object sender)
        {

            var button = sender as Button;
            if (button != null)
            {
                string depart = button.Tag.ToString();


                TextBlock DepartamentTextBlock = (TextBlock)FindName("DepartamentTextBlock");
                if (DepartamentTextBlock != null)
                {
                    DepartamentTextBlock.Text = $" {depart}";
                }
            }
        }

        private void SaveStatus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock departamentTextBlock = (TextBlock)FindName("DepartamentTextBlock");
            TextBlock statusTextBlock = (TextBlock)FindName("StatusTextBlock");

            if (statusTextBlock != null && departamentTextBlock != null)
            {
                string currentStatus = statusTextBlock.Text.Replace("Статус: ", "");
                string departamentName = departamentTextBlock.Text; 

                var status = new Status
                {
                    Status1 = currentStatus,
                    
                };

                using (var context = new ISMPEntities1())
                {
                    var departament = new Departament 
                    {
                        Name = departamentName 
                    };

                    
                    var task = new Tasks
                    {
                        Status1 = status,
                        Departament = departament 
                    };

                    context.Tasks.Add(task);
                   
                }

                Message.Text = "Данные сохранены!";
                Message.Visibility = Visibility.Visible;

                _timer.Start();
            }
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
    }
}
