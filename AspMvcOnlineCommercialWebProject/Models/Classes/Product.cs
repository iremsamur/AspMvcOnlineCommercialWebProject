using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Product
    {
        [Key]//primary key olduğunu belirten annotasyondur. id'lerin üstüne her tablo için her classda yazılır.
        public int ProductID  { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(30)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum. O Özelliğin üstüne yazarak bu şekilde kullanırım.
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum. 
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; } //Alış fiyatı
        public decimal SalePrice { get; set; } //Satış Fiyatı
        public bool Durum { get; set; }/*ürün durumuna göre kritik seviyede olup olmadığının kontrolünü sağlarım.*/
        [Column(TypeName = "Varchar")]
        [StringLength(250)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string ProductImage { get; set; }
        //İlişki karşılığı için, her ürünün bir tane kategorisi olabiliri şöyle yazarız.
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }//Kategori tablosuyla ilişkisini yazdım.
        //DbFirst kullanmadığımız için virtual gelmedi . O yüzden ilişkili tablolardaki değerler kullanmak için virtual yazarım.
        //Böylece Category sınıfındaki değerlere ulaşabilirim.

        //Satış hareketleri ile ilişkisi 
        public ICollection<SalesMove> SalesMoves { get; set; }

    }
}