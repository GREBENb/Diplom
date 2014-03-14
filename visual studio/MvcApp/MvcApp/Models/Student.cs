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
    
    public partial class Student
    {
        public Student()
        {
            this.StudentAchievements = new HashSet<StudentAchievement>();
            this.User_client = new HashSet<User_client>();
            this.ClassgroupControlled = new HashSet<Classgroup>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public string Studbook_number { get; set; }
        public System.Guid Classgroup_id { get; set; }
        public string user_created { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual ICollection<StudentAchievement> StudentAchievements { get; set; }
        public virtual ICollection<User_client> User_client { get; set; }
        public virtual Classgroup Classgroup { get; set; }
        public virtual ICollection<Classgroup> ClassgroupControlled { get; set; }
    }
}
