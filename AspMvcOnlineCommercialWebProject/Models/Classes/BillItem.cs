using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class BillItem
    {
        //Fatura Kalemi
        [Key]
        public int BillItemID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string Explanation { get; set; }
        public int Amount { get; set; }//Miktar
        public decimal UnitPrice { get; set; }//Birim Fiyat
        public decimal TotalPrice { get; set; }//Tutar
        public Bill Bill { get; set; }//Bill'deki ilişkinin karşılığınıda burada yazarım.


    }
}