using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPAccses.MVVM.Model.ModelData
{
    [Table("Users1")] // Указываем, что это таблица Users1
    public class User
    {
        [Key] 
        public int Id { get; set; } 

        [Column("Code_User")] 
        public string Code_User { get; set; }

        [Column("SureName")] 
        public string SureName { get; set; }

        [Column("Name")] // Указываем, что это поле соответствует столбцу Name
        public string Name { get; set; }

        [Column("Patronymic")] // Указываем, что это поле соответствует столбцу Patronymic
        public string Patronymic { get; set; }

        public int Role { get; set; } // Или string, если это строка
    }
}