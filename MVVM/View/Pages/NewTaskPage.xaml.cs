using MPAccses.MVVM.DB;
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

using Process = MPAccses.MVVM.Model.Process;
using Subassemblies = MPAccses.MVVM.Model.Subassemblies;
using Tasks = MPAccses.MVVM.Model.Tasks;

namespace MPAccses.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewTaskPage.xaml
    /// </summary>
    public partial class NewTaskPage : Page
    {
        private ISMPEntities2 _db = new ISMPEntities2();
        public NewTaskPage()
        {
            InitializeComponent();
            this.DataContext = new BottomBarViewModel();
        }

        private async void SaveStatus1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
               
                string taskName = CodebBox.Text; 
                string material = MaterialBox.Text;  
                int departamentId;
                string processingOption = VarProcBox.Text;  
                string subassemblyName = SubAssembly.Text;  
                int taskCount;

                
                if (string.IsNullOrEmpty(taskName) || string.IsNullOrEmpty(material) || string.IsNullOrEmpty(subassemblyName))
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля!");
                    return;
                }

               
                if (!int.TryParse(CountTask.Text, out taskCount))
                {
                    MessageBox.Show("Некорректное количество задачи!");
                    return;
                }

              
                if (!int.TryParse(NumberDepBox.Text, out departamentId))
                {
                    departamentId = 0; 
                }

                
                var newProcess = new Process
                {
                    Name_Process = taskName,
                    Departament = departamentId
                };

            
                _db.Process.Add(newProcess);
                await _db.SaveChangesAsync(); 

                
                var newTask = new Tasks
                {
                    Name_Task = material,  
                    Departament = departamentId,
                    Details = newProcess.ID_Process  
                };

               
                _db.Tasks.Add(newTask);
                await _db.SaveChangesAsync();  

               
                var newSubassembly = new Subassemblies
                {
                    Name_Subassemblies = subassemblyName,
                    Departament = departamentId
                };

               
                _db.Subassemblies.Add(newSubassembly);
                await _db.SaveChangesAsync();  

                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
            }
            _db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
           
    

        private void ArrowBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CoreNavigate.NavigatorCore.Navigate( new HomePage());
        }

        private void ShotDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
