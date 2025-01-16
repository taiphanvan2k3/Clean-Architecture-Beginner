using Microsoft.EntityFrameworkCore;

namespace MiniATM.Infrastructure.SqlServer.Repositories.SqlServer.DataContext
{
    public class MiniATMContext : DbContext
    {
        private readonly string connectionString;

        public MiniATMContext()
        {
            connectionString = @"Server=.;Database=MiniATM;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public MiniATMContext(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
