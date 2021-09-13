using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Expense
    {
        //Gider Sınıfı
        [Key]
        public int ExpenseID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string  Explanation { get; set; }//açıklama
        public DateTime Date { get; set; }
        public decimal ExpenseAmount { get; set; }//Gider tutarı
    }
}