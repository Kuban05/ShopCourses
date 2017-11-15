using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopCourses
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CourseDetails",
                url: "Course-{id}.html",
                defaults: new { controller = "Course", action = "Details" });

            routes.MapRoute(
                name: "CoursesList",
                url: "Category/{nameCategory}",
                defaults: new { controller = "Course", action = "List" });

            routes.MapRoute(
                name: "SitesStatic",
                url: "site/{name}.html",
                defaults: new { controller = "Home", action = "SitesStatic" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
