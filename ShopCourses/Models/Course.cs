using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopCourses.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int CategoryId { get; set; }
        //[Required(ErrorMessage = "Wprowadź tytuł kursu")]
        //[StringLength(100)]
        public string TitleCourse { get; set; }
        //[Required(ErrorMessage = "Wprowadź nazwe autora")]
        //[StringLength(100)]
        public string AuthorCourse { get; set; }
        public DateTime DateAdded { get; set; }
        //[StringLength(100)]
        public string NamePicture { get; set; }
        public string DescriptionCourse { get; set; }
        public decimal PriceCourse { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }
        public string ShortenedDescription { get; set; }

        public virtual Category Category { get; set; }
    }
}