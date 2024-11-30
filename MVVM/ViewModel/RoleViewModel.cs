using MPAccses.MVVM.DB;
using MPAccses.MVVM.Model.ModelData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MPAccses.MVVM.ViewModel
{
    public class RoleViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Role> Roles { get; set; }

        private Role _selectedRole;

        public Role SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                OnPropertyChanged();
            }
        }

        public RoleViewModel()
        {
            Roles = new ObservableCollection<Role>();
            LoadRoles(); // Загружаем роли при инициализации
        }

        private void LoadRoles()
        {
            using (var context = new ApplicationDbContext())
            {
                var roles = context.Roles.ToList(); // Загрузка данных из базы
                Roles.Clear();
                foreach (var role in roles)
                {
                    Roles.Add(role);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
