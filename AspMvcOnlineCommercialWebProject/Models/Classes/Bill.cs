using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Bill
    {
        //Property'lerle class özelliklerini tutuyoruz.
        [Key]
        public int BillID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string BillSerialNo { get; set; }//Fatura Seri Numarası
        [Column(TypeName = "Varchar")]
        [StringLength(6)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string  BillRowNumber{ get; set; }//Fatura Sıra Numarası
        public DateTime Date { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string TaxAdministration{ get; set; }// Vergi Dairesi
        public DateTime Hour { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string Submitter { get; set; }//Teslim eden kişi
        [Column(TypeName = "Varchar")]
        [StringLength(30)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string Receiver { get; set; }//Teslim alan kişi
        //Fatura ve içeriği yani fatura kalemi arasında ilişki kurulacak 
        //Bir faturanın birden fazla fatura kalemi olabilir. O yüzden ICollection Bill classında yazılır. 
        public ICollection<BillItem> BillItems { get; set; }//kurulan ilişki


    }
}