using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ShopCourses.Infrastucture
{
    public class AppConfig
    {
        private static string _iconsCategoryFolder = ConfigurationManager.AppSettings["IconsCategoryFolder"];

        public static string IconsCategoryFolder
        {
            get
            {
                return _iconsCategoryFolder;
            }
        }

        private static string _imagesFolder = ConfigurationManager.AppSettings["ImagesFolder"];

        public static string ImagesFolder
        {
            get
            {
                return _imagesFolder;
            }
        }
    }
}