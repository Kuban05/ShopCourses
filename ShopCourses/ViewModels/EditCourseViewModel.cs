using ShopCourses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCourses.ViewModels
{
    public class EditCourseViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public bool? Confirm { get; set; }
    }
}