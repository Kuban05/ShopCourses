using ShopCourses.DAL;
using ShopCourses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCourses.Infrastructure
{
    public class BasketManager
    {
        private CourseContext db;
        private ISessionManager session;

        public BasketManager(ISessionManager session, CourseContext db)
        {
            this.db = db;
            this.session = session;
        }

        public List<BasketItem> GetBasket()
        {
            List<BasketItem> basket;

            if (session.Get<List<BasketItem>>(Consts.BasketSessionKey) == null)
            {
                basket = new List<BasketItem>();
            }
            else
            {
                basket = session.Get<List<BasketItem>>(Consts.BasketSessionKey) as List<BasketItem>;
            }

            return basket;
        }

        public void AddToBasket(int courseId)
        {
            var basket = GetBasket();
            var basketItem = basket.Find(b => b.Course.CourseId == courseId);

            if (basketItem != null) 
            {
                basketItem.Quantity++;
            }
            else
            {
                var AddCourseToList = db.Courses.Where(c => c.CourseId == courseId).SingleOrDefault();

                if (AddCourseToList != null) 
                {
                    var newItemBasket = new BasketItem()
                    {
                        Course = AddCourseToList,
                        Quantity = 1,
                        Value = AddCourseToList.PriceCourse
                    };
                    basket.Add(newItemBasket);
                }
            }

            session.Set(Consts.BasketSessionKey, basket);
        }

        public int RemoveFromBasket(int courseId)
        {
            var basket = GetBasket();
            var basketItem = basket.Find(b => b.Course.CourseId == courseId);

            if (basketItem != null) 
            {
                if (basketItem.Quantity > 1)
                {
                    basketItem.Quantity--;
                    return basketItem.Quantity;
                }
                else
                {
                    basket.Remove(basketItem);
                }
            }

            return 0;
        }

        public decimal GetValueBasket()
        {
            var basket = GetBasket();
            return basket.Sum(k => (k.Quantity * k.Course.PriceCourse));
        }

        public int GetQuantityBasketItem()
        {
            var basket = GetBasket();
            int quantity = basket.Sum(k => k.Quantity);
            return quantity;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var basket = GetBasket();
            newOrder.DateAdded = DateTime.Now;
            //newOrder.userId = userId;

            db.Orders.Add(newOrder);

            if (newOrder.OrderItem == null) 
            {
                newOrder.OrderItem = new List<OrderItem>();
            }

            decimal basketValue = 0;

            foreach (var item in basket)
            {
                var newOrderItem = new OrderItem()
                {
                    CourseId = item.Course.CourseId,
                    Quantity = item.Quantity,
                    PurchasePrice = item.Course.PriceCourse
                };

                basketValue += (item.Quantity * item.Course.PriceCourse);
                newOrder.OrderItem.Add(newOrderItem);
            }

            newOrder.OrderValue = basketValue;
            db.SaveChanges();

            return newOrder;
        }

        public void EmptyBasket()
        {
            session.Set<List<BasketItem>>(Consts.BasketSessionKey, null);
        }
    }
}