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
    
    public partial class Achievement
    {
        public Achievement()
        {
            this.Point_exceptiontable = new HashSet<Point_exceptiontable>();
            this.StudentAchievements = new HashSet<StudentAchievement>();
            this.GroupAchievements = new HashSet<GroupAchievement>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Start_date { get; set; }
        public Nullable<System.DateTime> End_date { get; set; }
        public Nullable<System.Guid> Level_type_id { get; set; }
        public System.Guid Achievement_type_id { get; set; }
        public Nullable<byte> Verified { get; set; }
        public Nullable<System.Guid> Organisator_id { get; set; }
        public string user_created { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public System.Guid Achievement_typeID { get; set; }
    
        public virtual Organisator Organisator { get; set; }
        public virtual ICollection<Point_exceptiontable> Point_exceptiontable { get; set; }
        public virtual ICollection<StudentAchievement> StudentAchievements { get; set; }
        public virtual ICollection<GroupAchievement> GroupAchievements { get; set; }
        public virtual Achievement_type Achievement_type { get; set; }
        public virtual Level_type Level_type { get; set; }
    }
}
