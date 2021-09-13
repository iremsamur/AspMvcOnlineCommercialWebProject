using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string UserName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string Password { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string Authority { get; set; }//Yetki, Yetkisine göre uygun sekmeler görünecek
    }
}