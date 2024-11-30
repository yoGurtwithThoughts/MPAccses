using MPAccses.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MPAccses.MVVM.ViewModel
{
    //    public class TaskViewModel 
    //    {
    //        public ObservableCollection<TaskViewModel> Tasks { get; set; }

    //        public TaskViewModel()
    //        {
    //            LoadTasks();
    //        }

    //        private void LoadTasks()
    //        {
    //            using (var context = new ISMPEntities()) // Предполагается, что у вас есть контекст базы данных
    //            {
    //                var tasksFromDb = context.Tasks.ToList(); // Получение задач из базы данных
    //                Tasks = new ObservableCollection<TaskViewModel>(
    //                    tasksFromDb.Select(task => new TaskViewModel
    //                    {
    //                        Name_Task = task.Name_Task,
    //                        Date = task.Date,
    //                        Departament = task.Departament,
    //                        BackgroundColor = GetBackgroundColor(task.Status) // Получение цвета на основе статуса
    //                    }));
    //            }
    //        }

    //        private SolidColorBrush GetBackgroundColor(int? status)
    //        {
    //            return status switch
    //            {
    //                1 => new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF808080")), // Серый
    //                _ => new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000")) // Черный
    //            };
    //        }
    //    }
}
//}
