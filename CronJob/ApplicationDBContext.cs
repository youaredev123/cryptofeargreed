using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CronJob
{
    public class ApplicationDBContext : DbContext
    {
        private static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public DbSet<MeterModel> MeterModel { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<CoinHistory> CoinHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MeterModel>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<Coin>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

            modelBuilder.Entity<CoinHistory>(entity =>
            {
                entity.HasKey(e => e.ID);
            });

        }
    }
}
