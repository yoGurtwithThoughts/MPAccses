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
    
    public partial class Detailes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Detailes()
        {
            this.Assemblies = new HashSet<Assemblies>();
            this.Process1 = new HashSet<Process>();
            this.Subassemblies = new HashSet<Subassemblies>();
            this.Subassemblies1 = new HashSet<Subassemblies>();
            this.Tasks = new HashSet<Tasks>();
            this.Tasks1 = new HashSet<Tasks>();
        }
    
        public int ID_Details { get; set; }
        public string Name_Details { get; set; }
        public string Material { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Storage { get; set; }
        public Nullable<int> Process { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assemblies> Assemblies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Process> Process1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subassemblies> Subassemblies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subassemblies> Subassemblies1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks1 { get; set; }
    }
}
