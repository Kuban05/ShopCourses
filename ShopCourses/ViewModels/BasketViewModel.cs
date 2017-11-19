using ShopCourses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCourses.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketItem> BasketItem { get; set; }

        public decimal TotalPrice { get; set; }
    }
}