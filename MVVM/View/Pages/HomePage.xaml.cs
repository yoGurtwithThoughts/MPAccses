using MPAccses.MVVM.Core;
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
            var model = new TaskModel();
           

            
            var editStatus = new EditStatus();
            editStatus.StatusUpdated += (department, status) =>
            {
                model.Departament = department;
                model.Status = status;
            };

        }

        private void ShotDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }




        private void Edit_Click(object sender, MouseButtonEventArgs e)
        {
            var editStatusPage = new EditStatus();
            editStatusPage.StatusUpdated += UpdateStatusDisplay;
            string selectedDepartment = "Текущий цех";
            string selectedStatus = "Текущий статус";
            editStatusPage.SetInitialValues(selectedDepartment, selectedStatus);
            CoreNavigate.NavigatorCore.Navigate(editStatusPage);
        }

        private void UpdateStatusDisplay(string department, string status)
        {
            var model = this.DataContext as TaskModel;
            if (model != null)
            {
                model.Departament = department;
                model.Status = status;
            }
        
        }
        private void NewTask_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate(new NewTask());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
             
                border.Background = new SolidColorBrush(Colors.LightGray); 

                var departamentTextBlock = (TextBlock)border.FindName("DepartamentTextBlock");
                var statusTextBlock = (TextBlock)border.FindName("StatusTextBlock");

                string department = departamentTextBlock?.Text.Replace("Цех: ", "").Trim();
                string status = statusTextBlock?.Text.Replace("Статус: ", "").Trim();

              
                var editStatusPage = new EditStatus();
                editStatusPage.StatusUpdated += UpdateStatusDisplay;
                CoreNavigate.NavigatorCore.Navigate(editStatusPage);

               
                editStatusPage.SetInitialValues(department, status);
            }
        }
       
    }
}
