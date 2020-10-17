using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopingStoreSample.Models;
using ShopingStoreSample.ViewModel;

namespace ShopingStoreSample.Controllers
{
    public class ProductsController : Controller
    {
        OnlineShopingEntities context = new OnlineShopingEntities();
        
        //Show All Products
        public ActionResult Index()
        {    
            return View(context.Products.ToList());
        }

        // Add Product TO Send Categories
        public ActionResult AddProduct()
        {
            var category = (from cat in context.Categories
                            select cat).ToList();
            ViewBag.cat = category;
            return View();
        }


        [HttpPost]
        public ActionResult SaveProdcut(Product prod)
        {
           
            try
            {
                HttpPostedFileBase postedFile = Request.Files["file"];
                postedFile.SaveAs(Server.MapPath("~/Content/image/") + System.IO.Path.GetFileName(postedFile.FileName));

                if (postedFile.FileName != "" && prod.Name!=null
                    && prod.Price>0 && prod.Quantity >0)
                {
                    prod.Image = "image/" + postedFile.FileName;
                    context.Products.Add(prod);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    var category = (from cat in context.Categories
                                    select cat).ToList();
                    ViewBag.cat = category;
                    return View("AddProduct",prod);
                }
            }
            catch 
            {
                var category = (from cat in context.Categories
                                select cat).ToList();
                ViewBag.cat = category;
                return View("AddProduct",prod);
            }
            
            }


        public ActionResult Edit(int id)
        {
       
            Product prod = (from i in context.Products
                             where i.ID == id
                             select i).FirstOrDefault();
            var category = (from cat in context.Categories
                            select cat).ToList();
            ViewBag.cat = category;
            return View(prod);
        }


        // POST: category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product prod)
        {
            try
            {
                //Get Old reference from Context
                Product oldprod =context.Products.FirstOrDefault(d => d.ID == id);
                //Updat eData Dept ==>Html
                oldprod.Name =prod.Name;
                oldprod.Price = prod.Price;
                oldprod.Quantity = prod.Quantity;
                oldprod.CategoryID = prod.CategoryID;
                HttpPostedFileBase postedFile = Request.Files["file"];
                postedFile.SaveAs(Server.MapPath("~/Content/image/") + System.IO.Path.GetFileName(postedFile.FileName));
               
                if (postedFile.FileName != "" && oldprod.Name != null
                    && oldprod.Price > 0 && oldprod.Quantity > 0)
                {
                    oldprod.Image = "image/" + postedFile.FileName;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    var category = (from cat in context.Categories
                                    select cat).ToList();
                    ViewBag.cat = category;
                    return View("Edit", prod);
                }


            }
            catch
            {
                var category = (from cat in context.Categories
                                select cat).ToList();
                ViewBag.cat = category;
                return View("Edit", prod);
            }
        }


        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product quer = (from i in context.Products
                             where i.ID == id
                             select i).FirstOrDefault();
            List<Order> OR= (from i in context.Orders
                             where i.ProductID == id
                             select i).ToList();
            foreach (var item in OR)
            {

                context.Orders.Remove(item);
            }
            context.Products.Remove(quer);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}