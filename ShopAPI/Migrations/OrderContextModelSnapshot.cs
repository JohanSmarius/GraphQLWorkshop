﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopAPI.Database;

#nullable disable

namespace ShopAPI.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ShopAPI.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EMailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Customer 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Customer 2"
                        });
                });

            modelBuilder.Entity("ShopAPI.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            OrderStatus = 0,
                            OrderTime = new DateTime(2024, 5, 2, 14, 2, 6, 256, DateTimeKind.Local).AddTicks(3540)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            OrderStatus = 0,
                            OrderTime = new DateTime(2024, 5, 2, 14, 2, 6, 256, DateTimeKind.Local).AddTicks(3600)
                        });
                });

            modelBuilder.Entity("ShopAPI.Model.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orderlines");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            DiscountPercentage = 0m,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 1,
                            DiscountPercentage = 5m,
                            OrderId = 1,
                            ProductId = 2,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 3,
                            DiscountPercentage = 0m,
                            OrderId = 2,
                            ProductId = 1,
                            Quantity = 7
                        },
                        new
                        {
                            Id = 4,
                            DiscountPercentage = 20.0m,
                            OrderId = 2,
                            ProductId = 2,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("ShopAPI.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EanCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Weight")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EanCode = "123439900",
                            Name = "Product 1",
                            Price = 100m,
                            Weight = 300m
                        },
                        new
                        {
                            Id = 2,
                            EanCode = "37034034039",
                            Name = "Product 2",
                            Price = 200m,
                            Weight = 700m
                        });
                });

            modelBuilder.Entity("ShopAPI.Model.Order", b =>
                {
                    b.HasOne("ShopAPI.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShopAPI.Model.OrderLine", b =>
                {
                    b.HasOne("ShopAPI.Model.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopAPI.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopAPI.Model.Order", b =>
                {
                    b.Navigation("OrderLines");
                });
#pragma warning restore 612, 618
        }
    }
}
