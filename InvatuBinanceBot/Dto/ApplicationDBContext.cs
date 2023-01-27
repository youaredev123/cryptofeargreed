using Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
       public DbSet<MeterModel> MeterModel { get; set; }
       public DbSet<Coin> Coins { get; set; }
       public DbSet<CoinHistory> CoinHistories { get; set; }
        public DbSet<UserEmotions> UserEmotions { get; set; }
        public DbSet<CommonUserEmotions> CommonUserEmotion { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<CommonUserEmotions>(entity =>
            {
                entity.HasKey(e => e.ID);
            });
        }
    }
}
