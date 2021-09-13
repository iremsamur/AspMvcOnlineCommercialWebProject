using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]//Veritabanında fazla yer kaplamaması için tüm string türlü özelliklere bu kısıtlamaları getiriyorum.
        public string DepartmentName { get; set; }
        //Bir departman birden fazla personelde bulunabilir. Ama yine her personelin sadece bir departmanı olabilir . 1'e N ilişki var
        //Şimdi Departman ve Employee arasında ilişkiyi yazalım.//Çok bulunabilecek , tekrarlanacak olana buna ICollection yazarım.
        public ICollection<Employee> Employees { get; set; }
    }
}