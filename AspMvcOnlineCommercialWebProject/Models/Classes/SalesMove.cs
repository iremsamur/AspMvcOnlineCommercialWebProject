using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class SalesMove
    {
        [Key]
        //Satış Hareketleri
        public int SalesID { get; set; }
        //ürün- ne satıldı
        //cari- müşteri- kime satıldı.
        //personel- kim sattı bunlar ilişkiden gelecek
        

        public DateTime Date { get; set; }
        public int Piece { get; set; }//adet
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }//Toplam tutar

        //Şimdi bu ilişkili alanları yazalım.
        public Product Products  { get; set; }//ürünle ilişkisi
        public Customer Customers { get; set; }//cariyle ilişkisi
        public Employee Employees { get; set; }//personelle ilişkisi
        //Tüm ilişkileri burada yazdıktan sonra, ilişki olduğu diğer sınıflarlada ilişkilerini yazarım.


    }
}