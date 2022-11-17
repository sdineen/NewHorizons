﻿// <auto-generated />
using System;
using ClassLibrary.Repository.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassLibrary.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    partial class EcommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassLibrary.Entity.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = "acc1",
                            Name = "John Smith",
                            Password = "AA95E9BD10D4074140899E90E041A1DBFA05D769632EA01CF9216AABD1B57DE6"
                        },
                        new
                        {
                            Id = "acc2",
                            Name = "Jane Jones",
                            Password = "AA95E9BD10D4074140899E90E041A1DBFA05D769632EA01CF9216AABD1B57DE6"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Entity.LineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("ClassLibrary.Entity.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("AccountId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ClassLibrary.Entity.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("CostPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RetailPrice")
                        .HasColumnType("float");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = "p1",
                            CostPrice = 0.69999999999999996,
                            Name = "Pedigree Chum",
                            RetailPrice = 1.4199999999999999
                        },
                        new
                        {
                            Id = "p2",
                            CostPrice = 0.59999999999999998,
                            Name = "Knife",
                            RetailPrice = 1.3100000000000001
                        },
                        new
                        {
                            Id = "p3",
                            CostPrice = 0.75,
                            Name = "Fork",
                            RetailPrice = 1.5700000000000001
                        },
                        new
                        {
                            Id = "p4",
                            CostPrice = 0.90000000000000002,
                            Name = "Spaghetti",
                            RetailPrice = 1.9199999999999999
                        },
                        new
                        {
                            Id = "p5",
                            CostPrice = 0.65000000000000002,
                            Name = "Cheddar Cheese",
                            RetailPrice = 1.47
                        },
                        new
                        {
                            Id = "p6",
                            CostPrice = 15.199999999999999,
                            Name = "Bean bag",
                            RetailPrice = 32.200000000000003
                        },
                        new
                        {
                            Id = "p7",
                            CostPrice = 22.300000000000001,
                            Name = "Bookcase",
                            RetailPrice = 46.32
                        },
                        new
                        {
                            Id = "p8",
                            CostPrice = 55.200000000000003,
                            Name = "Table",
                            RetailPrice = 134.80000000000001
                        },
                        new
                        {
                            Id = "p9",
                            CostPrice = 43.700000000000003,
                            Name = "Chair",
                            RetailPrice = 110.2
                        },
                        new
                        {
                            Id = "p10",
                            CostPrice = 3.2000000000000002,
                            Name = "Doormat",
                            RetailPrice = 7.4000000000000004
                        });
                });

            modelBuilder.Entity("ClassLibrary.Entity.LineItem", b =>
                {
                    b.HasOne("ClassLibrary.Entity.Order", null)
                        .WithMany("LineItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("ClassLibrary.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ClassLibrary.Entity.Order", b =>
                {
                    b.HasOne("ClassLibrary.Entity.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });
#pragma warning restore 612, 618
        }
    }
}
