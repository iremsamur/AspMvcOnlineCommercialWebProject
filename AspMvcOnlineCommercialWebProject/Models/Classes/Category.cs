using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Category
    {
        //Önce kategori tablomu oluştururum 
        //Bunu Code First Yaklaşımı ile yapıyoruz.
        /*DB First'te hazır veritabanıyla dahil ettiğimde sınıflar içindeki property'lerle bunlara erişebiliyordum.*/
        /*Biz burada Entity Framework kullanırım . Bunun için key'ler kullanırım.*/
        [Key]
        public int CategoryID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string CategoryName { get; set; }
        //Şimdi kategori ve ürün arasında 1'e Çoklu ilişki kurarız. Çünkü her ürünün bir tane kategorisi olabilir . Ama Her kategorinin birden çok ürünü olabilir.
        //İlişkiyi şöyle kurarım.
        public ICollection<Product> Products { get; set; } //ilişki kurulacak sınıf yazılır. Yani bunun anlamı her kategoride birden fazla ürün yer alır.
        //int , short , decimalde sorun yok ama string olarak tanımladığım değişkenleri sql'a attığım zaman nvarchar olarak tutacak çok fazla karakter olacak buna ileride bir kısıtlama getirmeliyim.

    }
}