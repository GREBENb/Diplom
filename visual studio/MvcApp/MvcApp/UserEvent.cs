//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserEvent
    {
        public System.Guid ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public System.Guid User_Client_id { get; set; }
        public System.Guid Event_id { get; set; }
        public string user_created { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual User_client User_client { get; set; }
    }
}
