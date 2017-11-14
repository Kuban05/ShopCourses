using ShopCourses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCourses.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Category { get; set; }

        public IEnumerable<Course> News { get; set; }

        public IEnumerable<Course> Bestseller { get; set; }
    }
}