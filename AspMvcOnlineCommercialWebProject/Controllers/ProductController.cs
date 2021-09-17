using MvcOnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcOnlineCommercialWebProject.Controllers
{
    public class ProductController : Controller
    {
        //Şimdi veritabanında ürünlerle ilgili işlemleri yapmak için Product class'ı için Prdocut Controller oluşturdum.
        // GET: Product
        Context context = new Context();
        //Listeleme işlemi
        public ActionResult Index()
        {
            //Ürünleri bize listeler.
            var products = context.Products.ToList();
            return View(products);
        }
        //yeni ürün için action result
        [HttpGet]
        public ActionResult AddProduct()//Buna bir view ekleyelim.
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
            
        }

    }
}