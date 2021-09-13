using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Context : DbContext
    {
        //Entity Özelliklerini kullanmak için DbContext sınıfından miras aldım.
        public DbSet<Admin> Admins { get; set; }//Admin sınıfımın yani Admin tablomun Sql içinde nasıl görüneceğini yazdım.
        //Diğer tablolar içinde bunu yapıyorum.
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalesMove> SalesMoves { get; set; }
        public DbSet<Product> Products { get; set; }





    }
}