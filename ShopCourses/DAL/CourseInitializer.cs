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
                new Category(){CategoryId=1, NameCategory="Asp.Net",NameFileIcon="aspnet.png",DescriptionCategory="Programowanie web aplikacji."},
                new Category(){CategoryId=2, NameCategory="JavaScript",NameFileIcon="javascript.png",DescriptionCategory="Skryptowy język."},
                new Category(){CategoryId=3, NameCategory="jQuery",NameFileIcon="jquery.png",DescriptionCategory="Lekka biblioteka."},
                new Category(){CategoryId=4, NameCategory="Html5",NameFileIcon="html.png",DescriptionCategory="Język wykorzystywany do przedstawiania zawartości strony."},
                new Category(){CategoryId=5, NameCategory="Css3",NameFileIcon="css.png",DescriptionCategory="Język służący do stylowania."},
                new Category(){CategoryId=6, NameCategory="Xml",NameFileIcon="xml.png",DescriptionCategory="Uniwersalny język."},
                new Category(){CategoryId=7, NameCategory="C#",NameFileIcon="csharp.png",DescriptionCategory="Obiektowy jęztyk."}
            };

            foreach (var item in category)
            {
                context.Categories.AddOrUpdate(item);
            }
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course(){CourseId=1, AuthorCourse="Tomek Kowal",TitleCourse="Asp.Net Mvc",CategoryId=1,PriceCourse=99,Bestseller=true,NamePicture="obrazekmvc.png",DateAdded=DateTime.Now,DescriptionCourse="Kurs ASP.NET MVC"},
                new Course(){CourseId=2, AuthorCourse="Jacek Klej",TitleCourse="Asp.Net",CategoryId=1,PriceCourse=120,Bestseller=true,NamePicture="obrazekaspnet.png",DateAdded=DateTime.Now,DescriptionCourse="Kurs ASP.NET"},
                new Course(){CourseId=3, AuthorCourse="Irek Macał",TitleCourse="Asp.Net Mvc - Shortcut",CategoryId=1,PriceCourse=120,Bestseller=false,NamePicture="obrazekmvc2.png",DateAdded=DateTime.Now,DescriptionCourse="Kurs ASP.NET MVC - skrót."},
                new Course(){CourseId=4, AuthorCourse="Romek Wisz",TitleCourse="Javascript",CategoryId=2,PriceCourse=140,Bestseller=true,NamePicture="obrazekjavascript.png",DateAdded=DateTime.Now,DescriptionCourse="Kurs Javascript - język skryptowy."},
                new Course(){CourseId=5, AuthorCourse="Edyta Kruk",TitleCourse="jQuery",CategoryId=3,PriceCourse=140,Bestseller=true,NamePicture="obrazekjquery.png",DateAdded=DateTime.Now,DescriptionCourse="Kurs jQuery - Framework javascript - owy."},
                new Course(){CourseId=6, AuthorCourse="Izolda Ptak",TitleCourse="Html5",CategoryId=4,PriceCourse=140,Bestseller=true,NamePicture="obrazekhtml.png",DateAdded=DateTime.Now,DescriptionCourse="Kurs HTML5 - składnia."},
                new Course(){CourseId=7, AuthorCourse="Stefan Żeromski",TitleCourse="Css3",CategoryId=5,PriceCourse=140,Bestseller=true,NamePicture="obrazekcss.png",DateAdded=DateTime.Now,DescriptionCourse="Kurs CSS - język stylowy."},
                new Course(){CourseId=4, AuthorCourse="Mariusz Nowak",TitleCourse="Xml",CategoryId=6,PriceCourse=140,Bestseller=false,NamePicture="obrazekxml.png",DateAdded=DateTime.Now,DescriptionCourse="Kurs Xml - język uniwersalny."},
                new Course(){CourseId=4, AuthorCourse="Rafał Krupa",TitleCourse="C#",CategoryId=7,PriceCourse=140,Bestseller=true,NamePicture="obrazekcsharp.png",DateAdded=DateTime.Now,DescriptionCourse="Kurs C# - Poziom Zaawansowany"}
            };

            foreach (var item in courses)
            {
                context.Courses.AddOrUpdate(item);
            }
            context.SaveChanges();
        }
    }
}