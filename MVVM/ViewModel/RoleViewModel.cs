using MPAccses.MVVM.DB;
using MPAccses.MVVM.Model;
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
using Xunit;
using Xunit.Sdk;

namespace MPAccses.MVVM.ViewModel
{
    public class RoleViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; }

        private User _selectedRole;

        public User SelectedRole
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
            Users = new ObservableCollection<User>();
            LoadUser(); 
        }

        private void LoadUser()
        {
            using (var context = new ISMPEntities())
            {
                var users = context.Users1.ToList(); 

                Users.Clear(); 

                foreach (var user in users)
                {
                    
                    //Users.Add(users);
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
