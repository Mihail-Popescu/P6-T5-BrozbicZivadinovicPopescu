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

        public DbSet<Admin> ActiveService { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Client> Category { get; set; }
        public DbSet<Deposit> Customer { get; set; }
        public DbSet<Transactions> Order { get; set; }
        public DbSet<Transfer> OrderItem { get; set; }
        public DbSet<Withdrawal> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
