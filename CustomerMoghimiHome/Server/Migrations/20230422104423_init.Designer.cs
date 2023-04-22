﻿// <auto-generated />
using System;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230422104423_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.BetweenTables.ImagesForProductEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ImageId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("ImagesForProductEntity", "dbo");
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

                    b.Property<string>("CategoryPictureAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

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

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(24,4)");

                    b.Property<long>("ProductCategoryEnityId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryEnityId");

                    b.ToTable("ProductEntity", "dbo");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.BetweenTables.ImagesForProductEntity", b =>
                {
                    b.HasOne("CustomerMoghimiHome.Server.EntityFramework.Entities.File.ImageEntity", "Image")
                        .WithMany("ImageForProductList")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductEntity", "Product")
                        .WithMany("ImageForProductList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductEntity", b =>
                {
                    b.HasOne("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductCategoryEntity", "ProductCategory")
                        .WithMany("ProductList")
                        .HasForeignKey("ProductCategoryEnityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.File.ImageEntity", b =>
                {
                    b.Navigation("ImageForProductList");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductCategoryEntity", b =>
                {
                    b.Navigation("ProductList");
                });

            modelBuilder.Entity("CustomerMoghimiHome.Server.EntityFramework.Entities.Shop.ProductEntity", b =>
                {
                    b.Navigation("ImageForProductList");
                });
#pragma warning restore 612, 618
        }
    }
}