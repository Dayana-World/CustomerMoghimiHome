﻿// <auto-generated />
using System;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Customer.CustomerDetailEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerDetailEntity", "dbo");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.File.ImageEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImageEntity", "dbo");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Seo.AltEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AltEntity", "dbo");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Seo.TagEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TagEntity", "dbo");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.BasketProductEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BasketId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("BasketProductEntity", "dbo");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductCategoryEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProductCategoryEntity", "dbo");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BuilderCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(24,4)");

                    b.Property<long>("ProductCategoryEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryEntityId");

                    b.ToTable("ProductEntity", "dbo");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.UserBasketEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserBasketEntity", "dbo");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.UserOrderEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductTotalPrice")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserBasketId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserBasketId")
                        .IsUnique()
                        .HasFilter("[UserBasketId] IS NOT NULL");

                    b.ToTable("UserOrderEntity", "dbo");
                });

            modelBuilder.Entity("ProductEntityUserBasketEntity", b =>
                {
                    b.Property<long>("ProductEntitiesId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserBasketEntitiesId")
                        .HasColumnType("bigint");

                    b.HasKey("ProductEntitiesId", "UserBasketEntitiesId");

                    b.HasIndex("UserBasketEntitiesId");

                    b.ToTable("ProductEntityUserBasketEntity", "dbo");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductEntity", b =>
                {
                    b.HasOne("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductCategoryEntity", "ProductCategory")
                        .WithMany("ProductList")
                        .HasForeignKey("ProductCategoryEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.UserOrderEntity", b =>
                {
                    b.HasOne("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.UserBasketEntity", "UserBasket")
                        .WithOne("UserOrder")
                        .HasForeignKey("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.UserOrderEntity", "UserBasketId");

                    b.Navigation("UserBasket");
                });

            modelBuilder.Entity("ProductEntityUserBasketEntity", b =>
                {
                    b.HasOne("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductEntity", null)
                        .WithMany()
                        .HasForeignKey("ProductEntitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.UserBasketEntity", null)
                        .WithMany()
                        .HasForeignKey("UserBasketEntitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductCategoryEntity", b =>
                {
                    b.Navigation("ProductList");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.UserBasketEntity", b =>
                {
                    b.Navigation("UserOrder")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
