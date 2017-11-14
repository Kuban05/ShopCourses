using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopCourses.Infrastucture
{
    public static class UrlHelpers
    {
        public static string PathToIconsCategory(this UrlHelper helper, string nameIconCategory)
        {
            var IconsCategoryFolder = AppConfig.IconsCategoryFolder;
            var path = Path.Combine(IconsCategoryFolder, nameIconCategory);
            var pathAbsolute = helper.Content(path);

            return pathAbsolute;
        }

        public static string PathToImages(this UrlHelper helper, string nameImage)
        {
            var ImagesFolder = AppConfig.ImagesFolder;
            var path = Path.Combine(ImagesFolder, nameImage);
            var pathAbsolute = helper.Content(path);

            return pathAbsolute;
        }
    }
}