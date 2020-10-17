using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopingStoreSample.Models;
using ShopingStoreSample.ViewModel;

namespace ShopingStoreSample.Controllers
{
    public class HomeController : Controller
    {
        OnlineShopingEntities context = new OnlineShopingEntities();

        public ActionResult Index()
        {
            return View(context.Products.ToList());
        }

        public ActionResult AllOrders()
        {
            var OR =(from o in context.Orders 
                     select o).ToList();
            AllOrders test;
            List<AllOrders> AllO = new List<AllOrders>();
            // Product Prod = context.Products.FirstOrDefault(d => d.ID == .ProductID);
            foreach (var item in OR)
            {
                test = new AllOrders();
                test.ID=(from o in context.Products
                           where o.ID == item.ProductID
                           select o.ID).FirstOrDefault();
                test.Name = (from o in context.Products
                           where o.ID == item.ProductID
                           select o.Name).FirstOrDefault();
                test.Image = (from o in context.Products
                           where o.ID == item.ProductID
                           select o.Image).FirstOrDefault();
                test.Price = (decimal)(from o in context.Products
                           where o.ID == item.ProductID
                           select o.Price).FirstOrDefault();
                test.Quantity =(int)(from o in context.Orders
                           where o.ID == item.ID
                           select o.Quantity).FirstOrDefault();
                AllO.Add(test);
            }
            
            return View(AllO);
        }
        public ActionResult AddOrders(int ID)
        {
            Order OR = new Order();
            var check = (from o in  context.Orders
                                 where o.ProductID==ID select o).FirstOrDefault();
            Product pro = context.Products.FirstOrDefault(p => p.ID == ID);

            if (check == null)
            {
                if (pro.Quantity > 0)
                {
                    pro.Quantity = pro.Quantity - 1;
                    OR.ProductID = ID;
                    OR.Quantity = 1;
                    context.Orders.Add(OR);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else { return RedirectToAction("Index"); }
            }
            else
            {
                if (pro.Quantity > 0)
                {
                    check.Quantity =check.Quantity + 1;
                    pro.Quantity = pro.Quantity - 1;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else { return RedirectToAction("Index"); }

            }
                


            /*  if (check.ID!=null && check.ID > 0)
              {
                  if (pro.Quantity > 0) {
                      check.Quantity += 1;
                      pro.Quantity = pro.Quantity - 1;
                      context.SaveChanges();
                      return RedirectToAction("Index");
                  }
              else { return RedirectToAction("Index"); }
          }
              else
              {
                  if (pro.Quantity > 0)
                  {
                      pro.Quantity = pro.Quantity - 1;
                      OR.ProductID = ID;
                      OR.Quantity= 1;
                      context.Orders.Add(OR);
                      context.SaveChanges();
                      return RedirectToAction("Index");
                  }
                  else { return RedirectToAction("Index"); }
              }*/

        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}