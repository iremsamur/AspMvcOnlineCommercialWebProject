using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Customer
    {
        //Cariler=Customer=Müşteriler
        //Current=Cari
        [Key]
        public int CustomerID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string CustomerName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string CustomerSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.

        public string CustomerCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string CustomerMail { get; set; }

        //Satış hareketleri ile ilişkisi 
        public ICollection<SalesMove> SalesMoves { get; set; }
    }
}