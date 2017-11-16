using MvcSiteMapProvider;
using ShopCourses.DAL;
using ShopCourses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCourses.Infrastructure
{
    public class CategoriesDynamicNodeProvider : DynamicNodeProviderBase
    {
        CourseContext db = new CourseContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Category category in db.Categories)
            {
                DynamicNode nodeObj = new DynamicNode
                {
                    Title = category.NameCategory,
                    Key = "Category_" + category.CategoryId
                };
                nodeObj.RouteValues.Add("nameCategory", category.NameCategory);
                returnValue.Add(nodeObj);
            }

            return returnValue;
        }
    }
}