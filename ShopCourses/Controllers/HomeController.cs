using ShopCourses.DAL;
using ShopCourses.Models;
using ShopCourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopCourses.Controllers
{
    public class HomeController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: Home
        public ActionResult Index()
        {
            var category = db.Categories.OrderByDescending(o => o.NameCategory).ToList();
            var news = db.Courses.Where(c => !c.Hidden).OrderBy(o => Guid.NewGuid()).Take(3).ToList();
            var bestseller = db.Courses.Where(c => !c.Hidden && c.Bestseller).OrderBy(o => o.DateAdded).Take(3).ToList();

            var vm = new HomeViewModel()
            {
                Category = category,
                News = news,
                Bestseller = bestseller
            };

            return View(vm);
        }

        public ActionResult SitesStatic(string name)
        {
            return View(name);
        }
    }
}