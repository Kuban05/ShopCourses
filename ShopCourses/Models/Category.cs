using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCourses.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        //[Required(ErrorMessage = "Wprowadź nazwe kategorii")]
        //[StringLength(100)]
        public string NameCategory { get; set; }
        //[Required(ErrorMessage = "Wprowadź opis kategorii")]
        public string DescriptionCategory { get; set; }
        public string NameFileIcon { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}