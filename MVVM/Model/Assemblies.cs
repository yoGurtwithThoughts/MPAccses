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
    
    public partial class Assemblies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assemblies()
        {
            this.Subassemblies = new HashSet<Subassemblies>();
        }
    
        public int ID_Assembly { get; set; }
        public string Name_Assembly { get; set; }
        public Nullable<int> Detailes { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Storage { get; set; }
        public Nullable<int> Departament { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Detailes Detailes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subassemblies> Subassemblies { get; set; }
    }
}
