using ShopCourses.DAL;
using ShopCourses.Infrastructure;
using ShopCourses.Models;
using ShopCourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopCourses.Controllers
{
    public class BasketController : Controller
    {
        private BasketManager basketManager;
        private ISessionManager SessionManager { get; set; }
        private CourseContext db;

        public BasketController()
        {
            db = new CourseContext();
            SessionManager = new SessionManager();
            basketManager = new BasketManager(SessionManager, db);
        }

        // GET: Basket
        public ActionResult Index()
        {
            var basketItem = basketManager.GetBasket();
            var totalPrice = basketManager.GetValueBasket();

            BasketViewModel bVM = new BasketViewModel()
            {
                BasketItem = basketItem,
                TotalPrice = totalPrice
            };

            return View(bVM);
        }

        public ActionResult AddToBasket(int id)
        {
            basketManager.AddToBasket(id);

            return RedirectToAction("Index");
        }

        public int GetQuantityElementsBasket()
        {
            return basketManager.GetQuantityBasketItem();
        }

        public ActionResult RemoveFromBasket(int courseId)
        {
            int quantityItems = basketManager.RemoveFromBasket(courseId);
            int quantityBasketItems = basketManager.GetQuantityBasketItem();
            decimal basketValue = basketManager.GetValueBasket();

            BasketRemoveViewModel removeVM = new BasketRemoveViewModel()
            {
                IdItemsToRemove = courseId,
                BasketQuantityItems = quantityBasketItems,
                BasketTotalPrice = basketValue,
                QuantityItemsToRemove = quantityItems
            };

            return Json(removeVM);
        }
    }
}