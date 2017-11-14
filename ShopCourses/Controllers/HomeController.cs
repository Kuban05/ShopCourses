using ShopCourses.DAL;
using ShopCourses.Models;
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
           

            return View();
        }
    }
}