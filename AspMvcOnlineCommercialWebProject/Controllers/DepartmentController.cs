using MvcOnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcOnlineCommercialWebProject.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        //Şimdi departman ile ilgili işlemleri yazalım
        Context context = new Context();
        public ActionResult Index()
        {
            //Departmanları listeleme
            var values = context.Departments.Where(x => x.Durum == true).ToList();//bunu silinen departmanların durum değerini false
            //yapacağım için listelemede silinen görünmesin diye Where ile sadece durum değeri true olanları silinmemişleri göster diye şartlı sorgu yazdım

            return View(values);
        }
        //departman ekleme için get ve post metodlar 
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            department.Durum = true;
            context.Departments.Add(department);//context ile veritabanına Departments isimli tabloya burada Department sınıfından gönderilen değerleri ekle anlamına gelir
            //fonksiyonun parametresi Department buradaki sınıf yani buradan arayüzden gönderilen değerler iken Departments ise veritabanındaki tablo adı karşılığı olur.

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Departman Silme
        public ActionResult DeleteDepartment(int id)
        {
            //Diğer Category ve Product ile aynı
            var departments = context.Departments.Find(id);
            departments.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}