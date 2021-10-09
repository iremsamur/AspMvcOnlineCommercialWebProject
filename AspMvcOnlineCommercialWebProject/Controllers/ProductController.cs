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
            //var products = context.Products.ToList();
            //İilişkili tablolarda bize silme durumunda hata vereceği için remove ile silmek yerine
            //durumunu false yaptık. Ve burada da şimdi sadece değeri true olan ürünleri getir diyerek düzenliyoruz.

            var products = context.Products.Where(x => x.Durum == true).ToList();//Şarta göre sorgu yazmam gerektiğinde bu şekilde Where kullanırım.

            return View(products);
        }
        //yeni ürün için action result
        [HttpGet]
        public ActionResult AddProduct()//Buna bir view ekleyelim.
        {
            //ürün ekleme işlemi için ürün eklerken kategoriyi dropdown listten seçmeni sağlayalım.
            //Bunun için AddProduct metodunun HttpGet kısımına kategorileri listeleme işlemini yazmalıyız.
            //Çünkü post tarafına ekleme işlemi yazılırken , get tarafına sayfa açıldığında hemen gerçekleşmesi gereken işlemleri yazarız
            //Burada da ürün ekleme sayfası açıldığında hemen kategorilerin dropdown list içinde olması gerektiği için buraya yazarız.
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,//kullanıcıya görünecek yani dropdown da listelenecek olan kategori adları
                                                   Value = x.CategoryID.ToString()//o kategorinin id değeri 
                                                   /*Bu kullanım önemlidir. 
                                                    Bu yapı ile categories için bir liste oluşturdum. Categories yani veritabanındaki
                                                   categories tablosy içinde dolaşarak bunun değerlerini SelectListItem ile getirir.
                                                   bunun içinde Text ve value olarak iki değer olur.
                                                   Text kısımı kullanıcıya görünecek kısım iken value bunun  kullanıcıya görünmeyen
                                                   yani arka planda çalışan id değeri olur. */
                                               }).ToList();//Veritabanından bunları çekip categories listesine atar.
            //şimdi bu controller tarafından aldığım listeyi yani değeri her zaman view tarafına taşırken Viewbag kullanılır.
            /*ViewBag önemli bir konu
             ViewBag controller tarafından view tarafına değer taşımak için kullanılır.
            Kullanımı ViewBag.değişkenadı = atanacak değer şeklinde olur.*/
            ViewBag.a = categories;//categories değerini viewbag.a ile a değerine atayıp view tarafına taşıyacağız.

            
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult ProductDelete(int id)
        {
            var value = context.Products.Find(id);
            value.Durum = false;//ilişkili tablolarda silme işleminde hata vereceği için 
            //bu durumu engellemek için id'si bulunan ürünü silmek yerine durum değerini false yaparak gerçekleştiririz.
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //ürün güncelleme işlemlerini yazalım.
        public ActionResult ProductListPageForUpdate(int id)
        {
            //güncelleme işlemi içinde kategorilerin dropdown listten seçilip değiştirileceği için aynı kodları burayada yazalım
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,//kullanıcıya görünecek yani dropdown da listelenecek olan kategori adları
                                                   Value = x.CategoryID.ToString()//o kategorinin id değeri 
                                                   /*Bu kullanım önemlidir. 
                                                    Bu yapı ile categories için bir liste oluşturdum. Categories yani veritabanındaki
                                                   categories tablosy içinde dolaşarak bunun değerlerini SelectListItem ile getirir.
                                                   bunun içinde Text ve value olarak iki değer olur.
                                                   Text kısımı kullanıcıya görünecek kısım iken value bunun  kullanıcıya görünmeyen
                                                   yani arka planda çalışan id değeri olur. */
                                               }).ToList();//Veritabanından bunları çekip categories listesine atar.
            ViewBag.a = categories;

            var productValue = context.Products.Find(id);//Seçilen ürünün id'sini veritabanından bul
            return View("ProductListPageForUpdate", productValue);//bu controller çalışınca Ürün güncelle sayfası için ürünleri listeleme için productValue dan aldığı
            //bulduğu id değeri ile birlikte getirir.
            //Buna ProductListPageForUpdate  view'ini ekleyelim .Yani bu sayfanın view tarafını.
        }
        //şimdi asıl ürün güncelleme işlemini yapacak metodu yazalım.
        public ActionResult ProductUpdate(Product product)
        {
            //gönderilen ürün için id sini bulup o id değerindeki ürünün 
            //yeni atanan özelliklerini özellik olarak alarak güncelleme işlemi yapıyor.
            var productValue = context.Products.Find(product.ProductID);
            productValue.PurchasePrice = product.PurchasePrice;//view üzerinden kullanıcının değiştirdiği yeni değeri o ürünün yeni değeri olarak atar.
            productValue.SalePrice = product.SalePrice;
            productValue.Durum = product.Durum;
            productValue.CategoryID = product.CategoryID;
            productValue.Brand = product.Brand;
            productValue.Stock = product.Stock;
            productValue.ProductName = product.ProductName;
            productValue.ProductImage = product.ProductImage;
            context.SaveChanges();
            return RedirectToAction("Index");
                
        }
        

        
    }
}