using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;


namespace MvcApp.Models
{
    [MetadataType(typeof(OrganisatorMetaData))]
    public partial class Organisator
    {
        public class OrganisatorMetaData
        {
            public int ID;

            [Display(Name = "Имя")]
            [Required(ErrorMessage = "Обязательное поле")]
            public string Name { get; set; }
        }
    }


    [MetadataType(typeof(level_typeMetaData))]
    public partial class Level_type
    {
        public class level_typeMetaData
        {
            public int ID;

            [Display(Name = "Уровень")]
            [Required(ErrorMessage = "Обязательное поле")]
            public string Name { get; set; }
        }
    }


    [MetadataType(typeof(Contest_resultMetadata))]
    public partial class Contest_result
    {
        public class Contest_resultMetadata
        {
            public int ID;

            [Display(Name = "Результат")]
            [Required(ErrorMessage = "Обязательное поле")]
            public string Name { get; set; }

           

        }
    }


    [MetadataType(typeof(Achievement_typeMetadata))]
    public partial class Achievement_type
    {
        public class Achievement_typeMetadata
        {
            public int ID;

            [Display(Name = "Тип")]
            [Required(ErrorMessage = "Обязательное поле")]
            public string Name { get; set; }
        }
    }


    [MetadataType(typeof(AchievementMetadata))]
    public partial class Achievement
    {
        public class AchievementMetadata
        {
            public int ID;

            [Display(Name = "Наименование")]
            [Required(ErrorMessage = "Обязательное поле")]
            public string Name { get; set; }

            [Display(Name = "Дата начала")]
            public DateTime Start_date { get; set; }

            [Display(Name = "Дата Окончания")]
            public DateTime End_date { get; set; }

            [Display(Name = "Уровень достижения")]
            [Required(ErrorMessage = "Обязательное поле")]
            public int Level_type_id { get; set; }

            [Display(Name = "Тип достижения")]
            [Required(ErrorMessage = "Обязательное поле")]
            public int Achievement_type_id { get; set; }

            [Display(Name = "Организатор")]
            public int Organisator_id { get; set; }

        }
    }

    [MetadataType(typeof(SemestrMetaData))]
    public partial class Semestr
    {
        public class SemestrMetaData
        {
            public int ID;

            [Display(Name = "Семестр")]
            [Required(ErrorMessage = "Обязательное поле")]
            public string Name { get; set; }

            [Display(Name = "Дата начала")]
            public DateTime Start_date { get; set; }

            [Display(Name = "Дата Окончания")]
            public DateTime End_date { get; set; }

        }
    }


    [MetadataType(typeof(Student))]
    public partial class Student
    {
        public class StudentMetaData
        {
            public int ID;

            [Display(Name = "Студент")]
            [Required(ErrorMessage = "Обязательнлое поле")]
            public string Name { get; set; }

            [Display(Name = "Номер зачетной книжки")]
            [Required(ErrorMessage = "Обязательнлое поле")]
            public string Stoodbook_Number { get; set; }

            [Display(Name = "Группа")]
            [Required(ErrorMessage = "Обязательнлое поле")]
            public int Classgroup_id { get; set; }
        }
    }



    [MetadataType(typeof(Classgroup))]
    public partial class Classgroup
    {
        public class ClassgroupMetaData
        {
            public int ID;

            [Display(Name = "Группа")]
            [Required(ErrorMessage = "Обязательнлое поле")]
            public string Name { get; set; }

            [Display(Name = "Количество студентов")]
            [Required(ErrorMessage = "Обязательнлое поле")]
            public int Students_Count { get; set; }

            [Display(Name = "Староста")]
            public int Mainstudent_id { get; set; }
        }
    }

    
}



