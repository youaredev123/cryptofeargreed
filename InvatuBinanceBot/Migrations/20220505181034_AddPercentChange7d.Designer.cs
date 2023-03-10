// <auto-generated />
using System;
using Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvatuBinanceBot.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220505181034_AddPercentChange7d")]
    partial class AddPercentChange7d
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Dto.Coin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("CirculatingSupply")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("CoinMarketID")
                        .HasColumnType("int");

                    b.Property<decimal>("MarketCap")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("MaxSupply")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("PercentChange24H")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PercentChange7d")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Symbol")
                        .HasColumnType("text");

                    b.Property<decimal>("TotalSupply")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Volume24H")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("VolumeChange24H")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ID");

                    b.ToTable("Coins");
                });

            modelBuilder.Entity("Dto.CoinHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CoinId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ID");

                    b.ToTable("CoinHistories");
                });

            modelBuilder.Entity("Dto.CommonUserEmotions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Emotion")
                        .HasColumnType("text");

                    b.Property<string>("IPAddress")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("CommonUserEmotion");
                });

            modelBuilder.Entity("Dto.MeterModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MeterDate")
                        .HasColumnType("text");

                    b.Property<string>("MeterType")
                        .HasColumnType("text");

                    b.Property<string>("MeterVal")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("MeterModel");
                });

            modelBuilder.Entity("Dto.UserEmotions", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CoinName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Emotion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("ID");

                    b.ToTable("UserEmotions");
                });
#pragma warning restore 612, 618
        }
    }
}
