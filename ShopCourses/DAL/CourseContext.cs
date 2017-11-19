using Microsoft.AspNet.Identity.EntityFramework;
using ShopCourses.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ShopCourses.DAL
{
    public class CourseContext : IdentityDbContext<ApplicationUser>
    {
        public CourseContext() : base("CourseContext")
        {

        }
        static CourseContext()
        {
            Database.SetInitializer<CourseContext>(new CourseInitializer());
        }

        public static CourseContext Create()
        {
            return new CourseContext();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //using using System.Data.Entity.ModelConfiguration.Conventions;
        //    //Wylacza konwencje, ktora automatycznie tworzy liczbe mnoga dla nazw tabel w bazie danych
        //    //Zamiast Kategorie zostałaby stworzona tabela o nazwie Kategories

        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}