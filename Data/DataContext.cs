using Microsoft.EntityFrameworkCore;
using SisComWebApi.Models;

namespace SisComWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {}

        public DbSet<Product> Products {get; set; }
        public DbSet<Category> Categories {get; set; }
        public DbSet<Supplier> Suppliers {get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankAccount> BankAccounts {get; set; }
        public DbSet<Phone> Phones {get; set; }
    }
}