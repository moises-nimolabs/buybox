using System.Linq;
using BuyBox.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace BuyBox.Data.Impl
{
    public class BuyBoxDbContext : DbContext
    {
        private readonly string _connectionString;

        public BuyBoxDbContext(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("BuyBoxDbContext");
        }
        public BuyBoxDbContext(string connectionString)
        {
            this._connectionString = connectionString;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }
        public DbSet<LedgerEntry> LedgerEntries { get; set; }
        public DbSet<SellableItem> SellableItems { get; set; }
        public DbSet<TradeToken> TradeTokens { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Token>().ToTable("Token");
            modelBuilder.Entity<StockHistory>().ToTable("StockHistory");
            modelBuilder.Entity<LedgerEntry>().ToTable("LedgerEntry");
            modelBuilder.Entity<SellableItem>().HasNoKey().ToView("SellableItem");
            modelBuilder.Entity<TradeToken>().HasNoKey().ToView("TradeToken");
        }
    }
}