//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MPAccses.MVVM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Process
    {
        public int ID_Process { get; set; }
        public string Name_Process { get; set; }
        public Nullable<int> Departament { get; set; }
    
        public virtual Detailes Detailes { get; set; }
    }
}
