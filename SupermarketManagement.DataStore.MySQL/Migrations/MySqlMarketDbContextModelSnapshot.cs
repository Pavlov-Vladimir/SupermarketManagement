﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupermarketManagement.DataStore.MySQL;

#nullable disable

namespace SupermarketManagement.DataStore.MySQL.Migrations
{
    [DbContext(typeof(MySqlMarketDbContext))]
    partial class MySqlMarketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SupermarketManagement.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Beverage",
                            Name = "Beverage"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Bakery",
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Meat",
                            Name = "Meat"
                        });
                });

            modelBuilder.Entity("SupermarketManagement.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(19,4)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Coca-Cola",
                            Price = 1.11m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Pepsi",
                            Price = 1.22m,
                            Quantity = 150
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Name = "White bread",
                            Price = 0.70m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "Black bread",
                            Price = 0.99m,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Name = "Pork",
                            Price = 2.99m,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Name = "Beef",
                            Price = 3.33m,
                            Quantity = 70
                        });
                });

            modelBuilder.Entity("SupermarketManagement.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CashierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(19,4)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("QtyBefore")
                        .HasColumnType("int");

                    b.Property<int>("QtySold")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SupermarketManagement.Entities.Product", b =>
                {
                    b.HasOne("SupermarketManagement.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SupermarketManagement.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
