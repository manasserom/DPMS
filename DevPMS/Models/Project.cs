//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevPMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.TechStack = new HashSet<TechStack>();
        }
    
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string PathImages { get; set; }
        public bool LinkedIn { get; set; }
        public bool GitHub { get; set; }
        public string ToPerfect { get; set; }
        public string Others { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TechStack> TechStack { get; set; }
    }
}
