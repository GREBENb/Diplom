//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contest_result
    {
        public Contest_result()
        {
            this.Point_exceptiontable = new HashSet<Point_exceptiontable>();
            this.Point_maintable = new HashSet<Point_maintable>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public string user_created { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual ICollection<Point_exceptiontable> Point_exceptiontable { get; set; }
        public virtual ICollection<Point_maintable> Point_maintable { get; set; }
    }
}
