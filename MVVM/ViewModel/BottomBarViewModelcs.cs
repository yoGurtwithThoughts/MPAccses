using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public string CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                _currentDateTime = value;
                OnPropertyChanged(nameof(CurrentDateTime));
            }
        }

        public int CurrentShift
        {
            get => _currentShift;
            set
            {
                _currentShift = value;
                OnPropertyChanged(nameof(CurrentShift));
            }
        }

        public BottomBarViewModel()
        {
            // Устанавливаем начальные данные
            _currentShift = LoadShiftFromSettings();

            // Запуск таймера для обновления времени
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

        private int LoadShiftFromSettings()
        {
            // Логика загрузки смены (например, из файла, БД или настроек приложения)
            // Пример с использованием свойств приложения:
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
