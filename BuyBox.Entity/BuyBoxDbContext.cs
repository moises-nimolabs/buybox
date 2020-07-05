using BuyBox.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BuyBox.Data
{
    /// <summary>
    ///     Data Context used to perform Database Operations.
    /// </summary>
    public class BuyBoxDbContext : DbContext
    {
        private readonly string _connectionString;

        public BuyBoxDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BuyBoxDbContext");
        }

        public BuyBoxDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Product> Products { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Token> Tokens { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<StockEntry> StockHistories { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<LedgerEntry> LedgerEntries { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<SellableItem> SellableItems { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Session> Sessions { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<ExchangeToken> ExchangeTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().ToTable("Session");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Token>().ToTable("Token");
            modelBuilder.Entity<StockEntry>().ToTable("StockEntry");
            modelBuilder.Entity<LedgerEntry>().ToTable("LedgerEntry");
            modelBuilder.Entity<SellableItem>().HasNoKey().ToView("SellableItem");
            modelBuilder.Entity<ExchangeToken>().HasNoKey().ToView("ExchangeToken");
        }
    }
}