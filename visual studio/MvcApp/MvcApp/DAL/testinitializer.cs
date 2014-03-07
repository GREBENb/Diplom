using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcApp.Models;


namespace MvcApp.DAL
{
    public class testinitializer 
    {
         private testEntities context = new testEntities();

         protected void Seed()
        {
            var Contest_result = new List<Contest_result>
            {
            new Contest_result{Name="Первое место"},
            new Contest_result{Name="Второе место"},
            new Contest_result{Name="Третье место"},
            new Contest_result{Name="Участник"},
            };

            Contest_result.ForEach(s => context.Contest_result.Add(s));
            context.SaveChanges();       
           
            var Organisator = new List<Organisator>
            {
            new Organisator{Name="Иванов Иван Иванович"},
            new Organisator{Name="Петров Петр Петрович"},
            new Organisator{Name="Семёнов Сёмен Семёнович"}
            };
            Organisator.ForEach(s => context.Organisators.Add(s));
            context.SaveChanges();

            var Level_type = new List<Level_type>
            {
            new Level_type{Name="Институтский"},
            new Level_type{Name="Региональный"},
            new Level_type{Name="Межрегиональный"},
            new Level_type{Name="Международный"},
            };
            Level_type.ForEach(s => context.Level_type.Add(s));
            context.SaveChanges();


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
            Achievement_type.ForEach(s => context.Achievement_type.Add(s));
            context.SaveChanges();

         }
    }
}