using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccses.MVVM.Model.ModelData
{
    public class Departament
    {
        public int ID_Departament { get; set; }
        public string Name_Departament { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
