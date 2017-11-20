using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ShopCourses.App_Start;
using ShopCourses.DAL;
using ShopCourses.Infrastructure;
using ShopCourses.Models;
using ShopCourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopCourses.Controllers
{
    public class BasketController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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

        public async Task<ActionResult> Pay()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order()
                {
                    FirstName = user.DataUser.FirstName,
                    LastName = user.DataUser.LastName,
                    Address = user.DataUser.Address,
                    City = user.DataUser.City,
                    PostCode = user.DataUser.PostCode,
                    PhoneNumber = user.DataUser.PhoneNumber,
                    Email = user.DataUser.Email
                };

                return View(order);
            }
            else
            {
                //parametr do zwrocenia uzytkownika na strone placenia
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Pay","Basket")});
            }
        }

        [HttpPost]
        public async Task<ActionResult> Pay(Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var newOrder = basketManager.CreateOrder(orderDetails, userId);

                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.DataUser);
                await UserManager.UpdateAsync(user);

                basketManager.EmptyBasket();

                return RedirectToAction("ConfirmOrder");
            }
            else
            {
                return View(orderDetails);
            }
        }

        public ActionResult ConfirmOrder()
        {
            return View();
        }
    }
}