using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCourses.ViewModels
{
    public class BasketRemoveViewModel
    {
        public decimal BasketTotalPrice { get; set; }

        public int BasketQuantityItems { get; set; }

        public int QuantityItemsToRemove { get; set; }

        public int IdItemsToRemove { get; set; }
    }
}