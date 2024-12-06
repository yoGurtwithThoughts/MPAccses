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
using static MPAccses.MVVM.Core.Navigation;

namespace MPAccses.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditStatus.xaml
    /// </summary>
    public partial class EditStatus : Page
    {
        private ISMPEntities1 _db = new ISMPEntities1();
        public EditStatus()
        {
            InitializeComponent();
            this.DataContext = new BottomBarViewModel();

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

        private void SaveStatus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock statusTextBlock = (TextBlock)FindName("StatusTextBlock");
            if (statusTextBlock != null)
            {
                string currentStatus = statusTextBlock.Text.Replace("Статус: ", "");

               
                var status = new Status
                {
                    Status1 = currentStatus 
                };

                using (var context = new ISMPEntities1()) 
                {
                   
                    var task = new Tasks
                    {
                        Status1 = status 
                                         
                    };

                    context.Tasks.Add(task); 
                   
                }

               
                MessageBox.Show("Статус успешно сохранен!");
            }
        }
    }
}
