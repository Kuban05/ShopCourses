using NLog;
using ShopCourses.DAL;
using ShopCourses.Infrastructure;
using ShopCourses.Models;
using ShopCourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShopCourses.Controllers
{
    public class HomeController : Controller
    {
        private CourseContext db = new CourseContext();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: Home
        public ActionResult Index()
        {
            logger.Info("Jesteś na stronie głównej");

            ICacheProvider cache = new DefaultCacheProvider();

            List<Category> category;
            if (cache.IsSet(Consts.CategoryCacheKey))
            {
                category = cache.Get(Consts.CategoryCacheKey) as List<Category>;
            }
            else
            {
                category = db.Categories.ToList();
                cache.Set(Consts.CategoryCacheKey, category, 60);
            }

            List<Course> news;
            if (cache.IsSet(Consts.NewsCacheKey))
            {
                news = cache.Get(Consts.NewsCacheKey) as List<Course>;
            }
            else
            {
                news = db.Courses.Where(c => !c.Hidden).OrderByDescending(o => o.DateAdded).Take(3).ToList();
                cache.Set(Consts.NewsCacheKey, news, 1);
            }

            List<Course> bestseller;
            if (cache.IsSet(Consts.BestsellerCacheKey))
            {
                bestseller = cache.Get(Consts.BestsellerCacheKey) as List<Course>;
            }
            else
            {
                bestseller = db.Courses.Where(c => !c.Hidden && c.Bestseller).OrderBy(o => Guid.NewGuid()).Take(3).ToList();
                cache.Set(Consts.BestsellerCacheKey, bestseller, 1);
            }

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