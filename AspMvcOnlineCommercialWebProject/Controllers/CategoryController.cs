using MvcOnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AspMvcOnlineCommercialWebProject.Controllers
{
    public class CategoryController : Controller
    {
        //Category sınıfı ile ilgili veritabanı işlemlerini burada yazarım
        // GET: Category
        Context context = new Context();//Tablolarıma classlara ulaşmak için Context sınıfı kullanırım

        public ActionResult Index()
        {
            //listeleme işlemi yapar
            var values = context.Categories.ToList();
            return View(values);
            //Controller tarafında değişiklik yapılınca gelmesi için projenin yeniden derlenmesi gerekir.
        }
        //Kategori ekleme işlemi için ekleme işleminin yapılacağı bir sayfa için ActionResult oluşturalım
        /*Ekleme işlemi olduğu için ActionResult'ı iki kere yazdım. Yani kategori ekle metodunun form yüklendiği zaman da çalışması gerekir. Boş veri eklemesini engellemek için HttpGet ve HttpPost kullanırım
         Form yüklendiğinde HttpGet , butona tıklayınca HttpPost çalışsın dedim*/
        [HttpGet]
        public ActionResult AddCategory()
        {
            //Get bu şekilde boş kalır.
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            //veritabanına ekleme yapması için post tarafında ekleme işlemleri yazılır.
            context.Categories.Add(c);//Refernası gönderilen kategoriyi yani c'yi tüm bilgilerini veritabanına ekler.
            context.SaveChanges();//Yapılan değişiklikleri veritabanına yansıtır. Bu entity frameworkdeki karşılığıdır. Ado nette ise
            //komut.ExecuteNonQuery(); komutu ile bu yapılır
            return RedirectToAction("Index");//Değişiklikleri yaptıktan sonra bizi Index sayfasına yönlendirmesini sağlar.
            //Buna view ekliyorum. Bu view _AdminLayout'u kullanacak
            //Bu controller'da AddCategory.cshtml'ye bağlı
        }
        //Silme işlemi için Action Result- View
        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);//Benim silinmesini istediğim kategoriyi yani ona göre id'sine gönderdiğim ögeyi bul dedim.
            context.Categories.Remove(value);//Bu id 'si bulunan değeri Categories içinden sil
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Güncelleme işlemi için Action Result- View 
        //Burada şuanda güncelleme işlemi için action result yazmadığımdan henüz güncelleme yapmadı sadece seçili kategorinin değerlerini UpdateCategory view sayfasına getirdi
        public ActionResult UpdateCategory(int id)//Bu id'si verilen kategoriyi getirir.
        {
            var value = context.Categories.Find(id);//Benim güncellemesini istediğim kategoriyi yani ona göre id'sine gönderdiğim ögeyi bul dedim.
            return View("UpdateCategory", value);//bana UpdateCategory sayfasını value değişkeninden gelen değerle birlikte döndür.
            //Burada şuanda güncelleme işlemi için action result yazmadığımdan henüz güncelleme yapmadı sadece seçili kategorinin değerlerini UpdateCategory view sayfasına getirdi
        }
        //Güncelleme işlemini yani alınan id'li kategoriyi güncellemeyi burada yapmak için bir action result oluşturalım
        public ActionResult CategoryUpdateOperation(Category c)//Bu id'si bilinen kategori bilgilerini günceller
        {
            //Asıl güncelleme işlemi burada yapılır
            var value = context.Categories.Find(c.CategoryID);//Seçilen kategorinin id'sini veritabanından bul. bu değişken ile sayfada seçilen id'yi hafızaya al
            value.CategoryName = c.CategoryName;//c burada parametre olarak view tarafına göndereceğimiz değerlerdir.
            //Değer değiştirme yapıyor . Artık CategoryName değerini sayfadan girilen değiştirilen yeni gönderilen kategori adı olarak değiştiriyor.
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}