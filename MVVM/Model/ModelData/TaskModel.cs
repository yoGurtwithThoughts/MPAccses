using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccses.MVVM.Model.ModelData
{
    public class TaskModel
    {
        public int ID_Tasks { get; set; }
        public string Name_Task { get; set; }
        public DateTime? Date { get; set; }
        public int? Departament { get; set; }
        public int Details { get; set; }
        public int? Status { get; set; }
    }
}
