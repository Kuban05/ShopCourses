using MvcSiteMapProvider;
using ShopCourses.DAL;
using ShopCourses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCourses.Infrastructure
{
    public class CoursesDynamicNodeProvider : DynamicNodeProviderBase
    {
        private CourseContext db = new CourseContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            
            foreach (Course course in db.Courses)
            {
                DynamicNode nodeObj = new DynamicNode
                {
                    Title = course.TitleCourse,
                    Key = "Course_" + course.CourseId,
                    ParentKey = "Category_" + course.CategoryId
                };
                nodeObj.RouteValues.Add("id", course.CourseId);
                returnValue.Add(nodeObj);
            }

            return returnValue;
        }
    }
}