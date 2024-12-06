using DocumentFormat.OpenXml.Bibliography;
using MPAccses.MVVM.Model.ModelData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MPAccses.MVVM.ViewModel
{
    public class BottomBarViewModel : INotifyPropertyChanged
    {
        private string _currentDateTime;
        private int _currentShift;
        private int _count = 0;

        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Count));
                }
            }
        }

        public string CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                if (_currentDateTime != value)
                {
                    _currentDateTime = value;
                    OnPropertyChanged(nameof(CurrentDateTime));
                }
            }
        }

        public int CurrentShift
        {
            get => _currentShift;
            set
            {
                if (_currentShift != value)
                {
                    _currentShift = value;
                    OnPropertyChanged(nameof(CurrentShift));
                }
            }
        }

        public BottomBarViewModel()
        {
            LoadCount(); 
            _currentShift = LoadShiftFromSettings();

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += UpdateDateTime;
            timer.Start();
        }

        private void UpdateDateTime(object sender, EventArgs e)
        {
            CurrentDateTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void SaveCount()
        {
            Properties.Settings.Default.LastLoginCount = _count;
            Properties.Settings.Default.Save();
        }

        private void IncrementLastCount()
        {
            Count++;
            SaveCount();
        }

        private void LoadCount()
        {
            Count = Properties.Settings.Default.LastLoginCount;
        }

        private int LoadShiftFromSettings()
        {
            int savedShift = Properties.Settings.Default.LastShift;
            int newShift = savedShift + 1;
            Properties.Settings.Default.LastShift = newShift;
            Properties.Settings.Default.Save();

            return newShift;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
