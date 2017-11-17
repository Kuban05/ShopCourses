using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCourses.Models
{
    public class BasketItem
    {
        public Course Course { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}