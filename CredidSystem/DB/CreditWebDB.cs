using CredidSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace CredidSystem.DB
{
    public class CreditWebDB : DbContext
    {
        public CreditWebDB(DbContextOptions<CreditWebDB> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 💣 Отключаем все каскадные удаления, чтобы убрать ошибки циклов
            foreach (var fk in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Все твои конфигурации
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CreditWebDB).Assembly);
        }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        



    }


}
