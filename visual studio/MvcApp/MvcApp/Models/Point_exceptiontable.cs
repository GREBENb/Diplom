//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Point_exceptiontable
    {
        public System.Guid ID { get; set; }
        public int Points { get; set; }
        public System.Guid Achievement_id { get; set; }
        public Nullable<System.Guid> Contest_result_id { get; set; }
        public string user_created { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string Name { get; set; }
    
        public virtual Achievement Achievement { get; set; }
        public virtual Contest_result Contest_result { get; set; }
    }
}
