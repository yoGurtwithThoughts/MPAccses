using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccses.MVVM.ViewModel
{
    public class TaskModel : INotifyPropertyChanged
    {
        
        private string _departament;
        private string _status1;

     

        public string Departament
        {
            get => _departament;
            set
            {
                _departament = value;
                OnPropertyChanged(nameof(Departament));
            }
        }

        public string Status1
        {
            get => _status1;
            set
            {
                _status1 = value;
                OnPropertyChanged(nameof(Status1));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    }
