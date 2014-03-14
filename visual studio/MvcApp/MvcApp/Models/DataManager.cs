using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Data;
using System.Web.Security;
using System.Data.Entity.Infrastructure;
using MvcApp.Models;



namespace MvcApp.Models
{
    public class DataManager
    {
        private testEntities db = new testEntities();

        public void Save()
        {
            db.SaveChanges();
        }

        public void RemoveRecords()
        {

            var del = this.Get_Achievement_Type();
            del.ForEach(o => db.Achievement_type.Remove(o));
            this.Save();

            var del2 = this.Get_Achievements();
            del2.ForEach(o => db.Achievements.Remove(o));
            this.Save();

            var del3 = this.Get_Contest_Results();
            del3.ForEach(o => db.Contest_result.Remove(o));
            this.Save();

            var del4 = this.Get_Level_Type();
            del4.ForEach(o => db.Level_type.Remove(o));
            this.Save();

            var del5 = this.Get_Organisator();
            del5.ForEach(o => db.Organisators.Remove(o));
            this.Save();

            var del6 = this.Get_Semestr();
            del6.ForEach(o => db.Semestrs.Remove(o));
            this.Save();


            var del7 = this.Get_Student();
            del7.ForEach(o => db.Students.Remove(o));
            this.Save();

            var del8 = this.Get_Classgroup();
            del8.ForEach(o => db.Classgroups.Remove(o));
            this.Save();

            
            var del9 = this.Get_Group_Achievement();
            del9.ForEach(o => db.GroupAchievements.Remove(o));
            this.Save();

            var del10 = this.Get_Student_Achievement();
            del10.ForEach(o => db.StudentAchievements.Remove(o));
            this.Save();
            


        }



        public void AddRecords()
        {
            var Contest_result = new List<Contest_result>
            {
            new Contest_result{Name="Первое место"},
            new Contest_result{Name="Второе место"},
            new Contest_result{Name="Третье место"},
            new Contest_result{Name="Участник"},
            };

            Contest_result.ForEach(s => this.Contest_Result_Create(s));
            Save();



            var Organisator = new List<Organisator>
            {
            new Organisator{Name="Иванов Иван Иванович"},
            new Organisator{Name="Петров Петр Петрович"},
            new Organisator{Name="Семёнов Сёмен Семёнович"}
            };

            Organisator.ForEach(s => this.Organisator_Create(s));
            Save();



            var Level_type = new List<Level_type>
            {
            new Level_type{Name="Институтский"},
            new Level_type{Name="Региональный"},
            new Level_type{Name="Межрегиональный"},
            new Level_type{Name="Международный"},
            };

            Level_type.ForEach(s => this.Level_Type_Create(s));
            Save();



            var Achievement_type = new List<Achievement_type>
             {
             new Achievement_type{Name="Учебный"},
             new Achievement_type{Name="Научный"},
             new Achievement_type{Name="Общественный"},
             new Achievement_type{Name="Волонтерская деятельность"},
             new Achievement_type{Name="Творческий"},
             new Achievement_type{Name="Спортивный"},
             new Achievement_type{Name="Бонус"},
             new Achievement_type{Name="Штраф"},
             };
            Achievement_type.ForEach(s => this.Achievement_Type_Create(s));
            Save();



            var Semesrt = new List<Semestr>
            {
                new Semestr{Name="1", Start_date=DateTime.Parse("01.09.2013"), End_date=DateTime.Parse("31.12.2013")},
                new Semestr{Name="2", Start_date=DateTime.Parse("07.01.2014"), End_date=DateTime.Parse("01.06.2014")},
                new Semestr{Name="3", Start_date=DateTime.Parse("01.09.2014"), End_date=DateTime.Parse("31.12.2013")}
            };
            Semesrt.ForEach(s => this.Semestr_Create(s));
            Save();


            var Achievement = new List<Achievement>
            {
                new Achievement
                {
                    Name="Чемпионат института по футболу", 
                    Start_date  =DateTime.Parse("10.10.2013"), 
                    End_date = DateTime.Parse("10.10.2013"),
                    Level_type_id = Level_type.Single(s => s.Name == "Институтский").ID,
                    Achievement_type_id = Achievement_type.Single(s => s.Name == "Спортивный").ID,
                    Organisator_id = Organisator.Single(s => s.Name == "Семёнов Сёмен Семёнович").ID,
                },
                new Achievement
                {
                    Name="Областная олимпиада по ТОЭ",
                    Start_date = DateTime.Parse("25.01.2014"),
                    End_date = DateTime.Parse("26.01.2014"),
                    Level_type_id = Level_type.Single(s => s.Name ==  "Региональный").ID,
                    Achievement_type_id = Achievement_type.Single(s => s.Name == "Учебный").ID,
                    Organisator_id = Organisator.Single(s => s.Name == "Петров Петр Петрович").ID,  
                }
                

            };
            Achievement.ForEach(s => this.Achievement_Create(s));
            Save();


            var Classgroup = new List<Classgroup>
           {
                new Classgroup {Name = "АС-09", Students_count = 6},                 
                new Classgroup {Name = "ВМ-09", Students_count = 5},                  
                new Classgroup {Name = "ЭМ-09", Students_count = 4},
           };
            Classgroup.ForEach(s => this.Classgroup_Create(s));
            Save();

            var Student = new List<Student>
            {
                //AC-09
                new Student {Name = "Игнатов Борис Владиславович", Studbook_number = "K-09001", Classgroup_id = Classgroup.Single(s => s.Name ==  "АС-09").ID},
                new Student {Name = "Борисов Василий Евгеньевич", Studbook_number = "K-09002", Classgroup_id = Classgroup.Single(s => s.Name ==  "АС-09").ID},
                new Student {Name = "Миронов Ростислав Юрьевич", Studbook_number = "K-09003", Classgroup_id = Classgroup.Single(s => s.Name ==  "АС-09").ID},
                new Student {Name = "Морозов Николай Матвеевич", Studbook_number = "K-09004", Classgroup_id = Classgroup.Single(s => s.Name ==  "АС-09").ID},
                new Student {Name = "Шашков Анатолий Кириллович", Studbook_number = "K-09005", Classgroup_id = Classgroup.Single(s => s.Name ==  "АС-09").ID},
                new Student {Name = "Русаков Александр Фёдорович", Studbook_number = "K-09006", Classgroup_id = Classgroup.Single(s => s.Name ==  "АС-09").ID},
               //ВМ-09
                new Student {Name = "Мухин Фёдор Григорьевич", Studbook_number = "K-09007", Classgroup_id = Classgroup.Single(s => s.Name ==  "ВМ-09").ID},
                new Student {Name = "Юдин Олег Львович", Studbook_number = "K-09008", Classgroup_id = Classgroup.Single(s => s.Name ==  "ВМ-09").ID}, 
                new Student {Name = "Мишин Евгений Егорович", Studbook_number = "K-09009", Classgroup_id = Classgroup.Single(s => s.Name ==  "ВМ-09").ID},
                new Student {Name = "Анисимов Геннадий Ярославович", Studbook_number = "K-09010", Classgroup_id = Classgroup.Single(s => s.Name ==  "ВМ-09").ID},
                new Student {Name = "Тимофеев Владимир Вячеславович", Studbook_number = "K-09011", Classgroup_id = Classgroup.Single(s => s.Name ==  "ВМ-09").ID},
               //ЭМ-09
                new Student {Name = "Новиков Роман Вадимович", Studbook_number = "K-09012", Classgroup_id = Classgroup.Single(s => s.Name ==  "ЭМ-09").ID},
                new Student {Name = "Константинов Юрий Григорьевич", Studbook_number = "K-09013", Classgroup_id = Classgroup.Single(s => s.Name ==  "ЭМ-09").ID},
                new Student {Name = "Данилов Николай Николаевич", Studbook_number = "K-09014", Classgroup_id = Classgroup.Single(s => s.Name ==  "ЭМ-09").ID},
                new Student {Name = "Колесников Илья Русланович", Studbook_number = "K-09015", Classgroup_id = Classgroup.Single(s => s.Name ==  "ЭМ-09").ID},
            };
            Student.ForEach(s => this.Student_Create(s));
            Save();



            var GroupAchievement = new List<GroupAchievement>
            {
                new GroupAchievement
                {
                    Name="1",
                    Count=6,
                    Start_date=DateTime.Parse("01.09.2013"), 
                    End_date=DateTime.Parse("31.12.2013"),
                    Achievement_id = Achievement.Single(s => s.Name ==  "Чемпионат института по футболу").ID,
                    Classgroup_id = Classgroup.Single(s => s.Name == "АС-09").ID
                }
             };
            GroupAchievement.ForEach(s => this.Group_Achievement_Create(s));
            Save();



            var StudentAchievement = new List<StudentAchievement>
            {
                new StudentAchievement
                {
                    Achievement_id = Achievement.Single(s => s.Name == "Областная олимпиада по ТОЭ").ID,
                    Student_id = Student.Single(s => s.Name == "Мишин Евгений Егорович").ID,
                    Contest_result_id = Contest_result.Single(s => s.Name == "Третье место").ID,
                }
            };
            StudentAchievement.ForEach(s => this.Student_Achievement_Create(s));
            Save(); 
        }


       


        //Организаторы

        public List<Organisator> Get_Organisator()
        {
            return db.Organisators.ToList();
        }

        public Organisator Get_Organistor_Result_By_ID(System.Guid id)
        {
            return db.Organisators.FirstOrDefault(o => o.ID == id);
        }

        public Organisator Organisator_Get_Element(Guid id)
        {
            return db.Organisators.Find(id);
        }

        public Organisator Organisator_Create(Organisator obj)
        {
            obj.ID = Guid.NewGuid();
            db.Organisators.Add(obj);
            db.SaveChanges();
            obj = db.Organisators.FirstOrDefault(o => o.ID == obj.ID);
            return obj;

        }



        public Organisator Organisator_Edit(Organisator obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            obj = db.Organisators.SingleOrDefault(o => o.ID == obj.ID);
            return obj;
        }


        public Organisator Organisator_Delete(Organisator obj)
        {
            Organisator organisator = db.Organisators.SingleOrDefault(o => o.ID == obj.ID);
            db.Organisators.Remove(organisator);
            db.SaveChanges();
            return organisator;
        }


        // Типы достижений

        public List<Achievement_type> Get_Achievement_Type()
        {
            return db.Achievement_type.ToList();
        }

        public Achievement_type Achievement_Type_Get_Element(Guid id)
        {
            return db.Achievement_type.Find(id);
        }

        public Achievement_type Achievement_Type_Create(Achievement_type obj)
        {
            obj.ID = Guid.NewGuid();
            db.Achievement_type.Add(obj);
            db.SaveChanges();
            obj = db.Achievement_type.FirstOrDefault(o => o.ID == obj.ID);
            return obj;
        }


        public Achievement_type Achievement_Type_Edit(Achievement_type obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            obj = db.Achievement_type.SingleOrDefault(o => o.ID == obj.ID);
            return obj;
        }




        public Achievement_type Achievement_Type_Delete(Achievement_type obj)
        {
            Achievement_type achievement_type = db.Achievement_type.SingleOrDefault(o => o.ID == obj.ID);
            db.Achievement_type.Remove(achievement_type);
            db.SaveChanges();
            return achievement_type;
        }




        //Результаты

        public List<Contest_result> Get_Contest_Results()
        {
            return db.Contest_result.ToList();
        }

        public Contest_result Get_Contest_Result_By_ID(System.Guid id)
        {

            return db.Contest_result.FirstOrDefault(o => o.ID == id);

        }

        public Contest_result Contest_Result_Get_Element(System.Guid id)
        {
            return db.Contest_result.Find(id);

        }


        public Contest_result Contest_Result_Create(Contest_result obj)
        {

            obj.ID = Guid.NewGuid();
            db.Contest_result.Add(obj);
            db.SaveChanges();
            obj = db.Contest_result.FirstOrDefault(o => o.ID == obj.ID);
            return obj;


        }






        public Contest_result Contest_resultEdit(Contest_result obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            obj = db.Contest_result.SingleOrDefault(o => o.ID == obj.ID);
            return obj;
        }


        public Contest_result Contest_Result_Delete(Contest_result obj)
        {
            Contest_result contest_result = db.Contest_result.SingleOrDefault(o => o.ID == obj.ID);
            db.Contest_result.Remove(contest_result);
            db.SaveChanges();
            return contest_result;
        }


        //
        // Уровни достижения
        //

        public List<Level_type> Get_Level_Type()
        {
            return db.Level_type.ToList();
        }

        public Level_type Level_Type_Get_Element(Guid id)
        {
            return db.Level_type.Find(id);
        }

        public Level_type Level_Type_Create(Level_type obj)
        {
            obj.ID = Guid.NewGuid();
            db.Level_type.Add(obj);
            db.SaveChanges();
            obj = db.Level_type.FirstOrDefault(o => o.ID == obj.ID);
            return obj;
        }


        public Level_type Level_Type_Edit(Level_type obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            obj = db.Level_type.SingleOrDefault(o => o.ID == obj.ID);
            return obj;
        }


        public Level_type Level_Type_Delete(Level_type obj)
        {
            Level_type level_type = db.Level_type.SingleOrDefault(o => o.ID == obj.ID);
            db.Level_type.Remove(level_type);
            db.SaveChanges();
            return level_type;
        }


        //Семестры


        public List<Semestr> Get_Semestr()
        {
            return db.Semestrs.ToList();
        }

        public Semestr Get_Semestr_By_ID(System.Guid id)
        {
            return db.Semestrs.SingleOrDefault(o => o.ID == id);
        }

        public Semestr Semestr_Get_Element(Guid id)
        {
            return db.Semestrs.SingleOrDefault(o => o.ID == id);
        }

        public Semestr Semestr_Create(Semestr obj)
        {
            obj.ID = Guid.NewGuid();
            db.Semestrs.Add(obj);
            db.SaveChanges();
            obj = db.Semestrs.FirstOrDefault(o => o.ID == obj.ID);
            return obj;
        }



        public Semestr Semestr_Edit(Semestr obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            obj = db.Semestrs.SingleOrDefault(o => o.ID == obj.ID);
            return obj;
        }




        public Semestr Semestr_Delete(Semestr obj)
        {
            Semestr semestr = db.Semestrs.SingleOrDefault(o => o.ID == obj.ID);
            db.Semestrs.Remove(semestr);
            db.SaveChanges();
            return semestr;
        }


        //Достижения

        public List<Achievement> Get_Achievements()
        {
            return db.Achievements.ToList();
        }

        public Achievement Get_Achievement_By_ID(Guid id)
        {
            return db.Achievements.SingleOrDefault(o => o.ID == id);
        }

        public Achievement Achievement_Get_Element(Guid id)
        {
            return db.Achievements.Find(id);
        }




        public Achievement Achievement_Create(Achievement obj)
        {
            obj.ID = Guid.NewGuid();
            db.Achievements.Add(obj);
            db.SaveChanges();
            obj = db.Achievements.FirstOrDefault(o => o.ID == obj.ID);
            return obj;

        }



        public Achievement Achievement_Edit(Achievement obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            obj = db.Achievements.SingleOrDefault(o => o.ID == obj.ID);
            return obj;
        }




        public Achievement Achievement_Delete(Achievement obj)
        {
            Achievement achievement = db.Achievements.SingleOrDefault(o => o.ID == obj.ID);
            db.Achievements.Remove(achievement);
            db.SaveChanges();
            return achievement;
        }

        // Группы

        public List<Classgroup> Get_Classgroup()
        {
            return db.Classgroups.ToList();
        }

        public Classgroup Get_Classgroup_By_ID(Guid id)
        {
            return db.Classgroups.SingleOrDefault(o => o.ID == id);
        }


        public Classgroup Classgroup_Get_Element(Guid id)
        {
            return db.Classgroups.Find(id);
        }

        public Classgroup Classgroup_Create(Classgroup obj)
        {
            obj.ID = Guid.NewGuid();
            db.Classgroups.Add(obj);
            db.SaveChanges();
            obj = db.Classgroups.FirstOrDefault(o => o.ID == obj.ID);
            return obj;
        }


        public Classgroup Classgroup_Edit(Classgroup obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            obj = db.Classgroups.SingleOrDefault(o => o.ID == obj.ID);
            return obj;
        }

        public Classgroup Classgroup_Delete(Classgroup obj)
        {
            Classgroup classgroup = db.Classgroups.SingleOrDefault(o => o.ID == obj.ID);
            db.Classgroups.Remove(classgroup);
            db.SaveChanges();
            return classgroup;
        }
        

        //Студенты

        public List<Student> Get_Student()
        {
            return db.Students.ToList();
        }

        public Student Get_Student_By_ID(Guid id)
        {
            return db.Students.SingleOrDefault(o => o.ID == id);
        }


        public Student Student_Get_Element(Guid id)
        {
            return db.Students.Find(id);
        }

        public Student Student_Create(Student obj)
        {
            obj.ID = Guid.NewGuid();
            db.Students.Add(obj);
            db.SaveChanges();
            obj = db.Students.FirstOrDefault(o => o.ID == obj.ID);
            return obj;
        }


        public Student Classgroup_Edit(Student obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            obj = db.Students.SingleOrDefault(o => o.ID == obj.ID);
            return obj;
        }

        public Student Classgroup_Delete(Student obj)
        {
            Student student = db.Students.SingleOrDefault(o => o.ID == obj.ID);
            db.Students.Remove(student);
            db.SaveChanges();
            return student;
        }

     //   Групповые достижения

       

        public List<GroupAchievement> Get_Group_Achievement()
        {
            return db.GroupAchievements.ToList();
        }


        public GroupAchievement Get_Group_Achievement_By_ID(Guid id)
        {
            return db.GroupAchievements.SingleOrDefault(o => o.ID == id);
        }


        public GroupAchievement Group_Achievement_Get_Element(Guid id)
        {
            return db.GroupAchievements.Find(id);
        }

        public GroupAchievement Group_Achievement_Create(GroupAchievement obj)
        {
            obj.ID = Guid.NewGuid();
            db.GroupAchievements.Add(obj);
            db.SaveChanges();
            obj = db.GroupAchievements.FirstOrDefault(o => o.ID == obj.ID);
            return obj;
        }


        public GroupAchievement Group_Achievement_Edit(GroupAchievement obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            obj = db.GroupAchievements.SingleOrDefault(o => o.ID == obj.ID);
            return obj;
        }

        public GroupAchievement Classgroup_Delete(GroupAchievement obj)
        {
            GroupAchievement GroupAchievement = db.GroupAchievements.SingleOrDefault(o => o.ID == obj.ID);
            db.GroupAchievements.Remove(GroupAchievement);
            db.SaveChanges();
            return GroupAchievement;
        }
  

    //Достижения студентов



        public List<StudentAchievement> Get_Student_Achievement()
        {
            return db.StudentAchievements.ToList();
        }


        public StudentAchievement Get_Student_Achievement_By_ID(Guid id)
        {
            return db.StudentAchievements.SingleOrDefault(o => o.ID == id);
        }


        public StudentAchievement Student_Achievement_Get_Element(Guid id)
        {
            return db.StudentAchievements.Find(id);
        }

        public StudentAchievement Student_Achievement_Create(StudentAchievement obj)
        {
            obj.ID = Guid.NewGuid();
            db.StudentAchievements.Add(obj);
            db.SaveChanges();
            obj = db.StudentAchievements.FirstOrDefault(o => o.ID == obj.ID);
            return obj;
        }


        public StudentAchievement Student_Achievement_Edit(StudentAchievement obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            obj = db.StudentAchievements.SingleOrDefault(o => o.ID == obj.ID);
            return obj;
        }

        public StudentAchievement Student_Achievement_Delete(StudentAchievement obj)
        {
            StudentAchievement StudentAchievement = db.StudentAchievements.SingleOrDefault(o => o.ID == obj.ID);
            db.StudentAchievements.Remove(StudentAchievement);
            db.SaveChanges();
            return StudentAchievement;
        }
   
     }
}