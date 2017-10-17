//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayerFromDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class MyTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyTask()
        {
            this.Users = new HashSet<User>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> ResponsibleUserID { get; set; }
        public int CurrentPriority { get; set; }
        public System.DateTime TimeStart { get; set; }
        public System.DateTime TimeStop { get; set; }
        public System.TimeSpan Prognosis { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
