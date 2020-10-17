using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopingStoreSample.Models;

namespace ShopingStoreSample.Controllers
{
    public class CategoryController : Controller
    {
        OnlineShopingEntities context = new OnlineShopingEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";
            List<Category> cate = context.Categories.ToList();

            return View(cate);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cate)
        {
            try
            {
                HttpPostedFileBase postedFile = Request.Files["file"];
                postedFile.SaveAs(Server.MapPath("~/Content/image/") + System.IO.Path.GetFileName(postedFile.FileName));
                cate.Image = "image/" + postedFile.FileName;
                context.Categories.Add(cate);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cate);
            }
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Your contact page.";
            Category quer = (from i in context.Categories
                             where i.ID == id
                             select i).FirstOrDefault();

            return View(quer);
        }


        // POST: category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category cate)
        {
            try
            {

                //Get Old reference from Context
                Category oldDept =
                    context.Categories.FirstOrDefault(d => d.ID == id); 
                //Updat eData Dept ==>Html
                oldDept.Name = cate.Name;
                HttpPostedFileBase postedFile = Request.Files["file"];
               
                if (postedFile.FileName !="" && oldDept.Name!=null)
                {
                    postedFile.SaveAs(Server.MapPath("~/Content/image/") + System.IO.Path.GetFileName(postedFile.FileName));
                    oldDept.Image = "image/" + postedFile.FileName;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Edit", cate);
                }
                
                
            }
            catch
            {
                return View(cate);
            }
        }

        // GET: category/Delete/5
        public ActionResult Delete(int id)
        {
            Category quer = (from i in context.Categories
                             where i.ID == id
                             select i).FirstOrDefault();

            var prod = (from i in context.Products
                                 where i.CategoryID == id
                                 select i).ToList();
            var Ord = (from i in context.Orders
                        where i.Product.CategoryID == id
                        select i).ToList();

            foreach (var item in prod)
            {
                context.Products.Remove(item);
            }

            foreach (var item in Ord)
            {
                context.Orders.Remove(item);
            }
            context.Categories.Remove(quer);
            context.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}