using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccses.MVVM.Model.ModelData
{
    public class User
    {
        public int ID_User { get; set; }
        public string Code_User {  get; set; }
        public string SureName { get; set; }
        public string Name { get; set; }
        public int Role {  get; set; }
        public  string Patronymic {  get; set; }

    }
}