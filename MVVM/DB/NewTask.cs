using MPAccses.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccses.MVVM.DB
{
   
        public partial class Tasks
        {
            public int ID_Tasks { get; set; }  // Идентификатор задачи
            public string Name_Task { get; set; }  // Название задачи
            public Nullable<DateTime> Date { get; set; }  // Дата выполнения задачи
            public Nullable<int> Departament { get; set; }  // Идентификатор департамента
            public int Details { get; set; }  // Идентификатор детали
            public Nullable<int> Status { get; set; }  // Статус задачи

            // Навигационные свойства
            public virtual Department Department { get; set; }  // Связь с департаментом
            public virtual Detailes Detailes { get; set; }  // Связь с деталями
            public virtual Status Status1 { get; set; }  // Связь с статусом
        }

        // Модель для процесса
        public partial class Process
        {
            public int ID_Process { get; set; }  // Идентификатор процесса
            public string Name_Process { get; set; }  // Название процесса
            public Nullable<int> Departament { get; set; }  // Идентификатор департамента

            // Навигационные свойства
            public virtual Detailes Detailes { get; set; }  // Связь с деталями
        }

        // Модель для департамента
        public partial class Department
        {
            public int ID_Departament { get; set; }  // Идентификатор департамента
            public string Name_Departament { get; set; }  // Название департамента
            public Nullable<int> Users { get; set; }  // Идентификатор пользователей

            // Навигационные свойства
            public virtual ICollection<Assemblies> Assemblies { get; set; }  // Связь с коллекцией сборок (1 ко многим)
            public virtual ICollection<Role> Role { get; set; }  // Связь с ролями (1 ко многим)
            public virtual ICollection<Subassemblies> Subassemblies { get; set; }  // Связь с подсборками (1 ко многим)
            public virtual ICollection<Tasks> Tasks { get; set; }  // Связь с задачами (1 ко многим)
            public virtual ICollection<Tasks> Tasks1 { get; set; }  // Связь с дополнительными задачами (1 ко многим)
        }

        // Модель для деталей
        public partial class Detailes
        {
            public int ID_Details { get; set; }  // Идентификатор детали
            public string Name_Details { get; set; }  // Название детали
            public string Material { get; set; }  // Материал
            public Nullable<int> Quantity { get; set; }  // Количество
            public Nullable<int> Storage { get; set; }  // Местоположение хранения
            public Nullable<int> Process { get; set; }  // Идентификатор процесса

            // Навигационные свойства
            public virtual ICollection<Assemblies> Assemblies { get; set; }  // Связь с коллекцией сборок
            public virtual ICollection<Process> Process1 { get; set; }  // Связь с коллекцией процессов
            public virtual ICollection<Subassemblies> Subassemblies { get; set; }  // Связь с коллекцией подсборок
            public virtual ICollection<Subassemblies> Subassemblies1 { get; set; }  // Дополнительная связь с подсборками
            public virtual ICollection<Tasks> Tasks { get; set; }  // Связь с коллекцией задач
            public virtual ICollection<Tasks> Tasks1 { get; set; }  // Дополнительная связь с задачами
        }

        // Модель для сборок
        public partial class Assemblies
        {
            public int ID_Assembly { get; set; }  // Идентификатор сборки
            public string Name_Assembly { get; set; }  // Название сборки
            public Nullable<int> Detailes { get; set; }  // Идентификатор деталей
            public Nullable<int> Quantity { get; set; }  // Количество
            public Nullable<int> Storage { get; set; }  // Местоположение хранения
            public Nullable<int> Departament { get; set; }  // Идентификатор департамента

            // Навигационные свойства
            public virtual Department Department { get; set; }  // Связь с департаментом
            public virtual Detailes Detailes1 { get; set; }  // Связь с деталями
            public virtual ICollection<Subassemblies> Subassemblies { get; set; }  // Связь с подсборками
        }

        // Модель для подсборок
        public partial class Subassemblies
        {
            public int ID_Subassemblies { get; set; }  // Идентификатор подсборки
            public string Name_Subassemblies { get; set; }  // Название подсборки
            public Nullable<int> Details { get; set; }  // Идентификатор деталей
            public Nullable<int> Assemblyes { get; set; }  // Идентификатор сборок
            public Nullable<int> Departament { get; set; }  // Идентификатор департамента

            // Навигационные свойства
            public virtual Assemblies Assemblies { get; set; }  // Связь с сборками
            public virtual Department Department { get; set; }  // Связь с департаментом
            public virtual Detailes Detailes { get; set; }  // Связь с деталями
        }

        // Модель для статуса
        public partial class Status
        {
            public int ID_Status { get; set; }  // Идентификатор статуса
            public string Name_Status { get; set; }  // Название статуса
        }

        // Модель для роли
        public partial class Role
        {
            public int ID_Role { get; set; }  // Идентификатор роли
            public string Name_Role { get; set; }  // Название роли
        }
    }

