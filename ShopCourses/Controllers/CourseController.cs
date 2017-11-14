using ShopCourses.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopCourses.Controllers
{
    public class CourseController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string nameCategory)
        {
            var category = db.Categories.Include("Courses").Where(k => k.NameCategory.ToUpper() == nameCategory.ToUpper()).Single();
            var courses = category.Courses.ToList();

            return View(courses);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MenuCategory()
        {
            var categories = db.Categories.ToList();

            return PartialView("_MenuCategory", categories);
        }

    }
}