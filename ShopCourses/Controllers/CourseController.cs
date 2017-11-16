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

        public ActionResult List(string nameCategory, string searchQuery = null)
        {
            var category = db.Categories.Include("Courses").Where(k => k.NameCategory.ToUpper() == nameCategory.ToUpper()).Single();
            var courses = category.Courses.Where(c => (searchQuery == null ||
            c.AuthorCourse.ToLower().Contains(searchQuery.ToLower()) ||
            c.TitleCourse.ToLower().Contains(searchQuery.ToLower())) && !c.Hidden);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CoursesList", courses);
            }

            return View(courses);
        }

        public ActionResult Details(int id)
        {
            var course = db.Courses.Find(id);

            return View(course);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60000)]
        public ActionResult MenuCategory()
        {
            var categories = db.Categories.ToList();

            return PartialView("_MenuCategory", categories);
        }

        public ActionResult CoursesTips(string term)
        {
            var courses = db.Courses
                .Where(c => !c.Hidden && c.TitleCourse.ToLower().Contains(term.ToLower()))
                .Take(5)
                .Select(s => new { label = s.TitleCourse });

            return Json(courses, JsonRequestBehavior.AllowGet);
        }

    }
}