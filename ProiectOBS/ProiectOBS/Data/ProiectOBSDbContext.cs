using ProiectOBS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProiectOBS.Data
{
    public class ProiectOBSDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ProiectOBSDbContext(DbContextOptions<ProiectOBSDbContext> options, IConfiguration configuration)
    : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Transfer> Transfer { get; set; }
        public DbSet<Withdrawal> Withdrawal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
