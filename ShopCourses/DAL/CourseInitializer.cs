using ShopCourses.Migrations;
using ShopCourses.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ShopCourses.DAL
{
    public class CourseInitializer : MigrateDatabaseToLatestVersion<CourseContext, Configuration>
    {
        //protected override void Seed(CoursesContext context)
        //{
        //    SeedCoursesData(context);

        //    base.Seed(context);
        //}

        public static void SeedCoursesData(CourseContext context)
        {
            var category = new List<Category>
            {
                new Category(){CategoryId=1, NameCategory="Asp",NameFileIcon="asp.png",DescriptionCategory="opis asp net mvc"},
                new Category(){CategoryId=2, NameCategory="Java",NameFileIcon="java.png",DescriptionCategory="opis java"},
                new Category(){CategoryId=3, NameCategory="Php",NameFileIcon="php.png",DescriptionCategory="opis php"},
                new Category(){CategoryId=4, NameCategory="Html",NameFileIcon="html.png",DescriptionCategory="opis html"},
                new Category(){CategoryId=5, NameCategory="Css",NameFileIcon="css.png",DescriptionCategory="opis css"},
                new Category(){CategoryId=6, NameCategory="Xml",NameFileIcon="xml.png",DescriptionCategory="opis xml"},
                new Category(){CategoryId=7, NameCategory="C#",NameFileIcon="c#.png",DescriptionCategory="opis c#"}
            };

            foreach (var item in category)
            {
                context.Categories.AddOrUpdate(item);
            }

            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course(){AuthorCourse="tomek",TitleCourse="asp.net mvc",CategoryId=1,PriceCourse=99,Bestseller=true,NamePicture="obraz",DateAdded=DateTime.Now,DescriptionCourse="opis kursu"},
                new Course(){AuthorCourse="jacek",TitleCourse="asp.net mvc3",CategoryId=1,PriceCourse=120,Bestseller=true,NamePicture="obraz3",DateAdded=DateTime.Now,DescriptionCourse="opis kursu3"},
                new Course(){AuthorCourse="irek",TitleCourse="asp.net mvc4",CategoryId=1,PriceCourse=120,Bestseller=true,NamePicture="obraz4",DateAdded=DateTime.Now,DescriptionCourse="opis kursu4"},
                new Course(){AuthorCourse="romek",TitleCourse="asp.net mvc5",CategoryId=1,PriceCourse=140,Bestseller=true,NamePicture="obraz5",DateAdded=DateTime.Now,DescriptionCourse="opis kursu5"}
            };

            foreach (var item in courses)
            {
                context.Courses.AddOrUpdate(item);
            }

            context.SaveChanges();
        }
    }
}