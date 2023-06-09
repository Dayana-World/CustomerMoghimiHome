﻿using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
public class ProductCategoryEntity : BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryDescription { get; set; } = string.Empty;
    public string ImagePath { get; set; }
    public string ImageAlt { get; set; }
    public string Tags { get; set; }
    public List<ProductEntity> ProductList { get; set; } = new();
}

public class ProductCategoryEntityConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
{
    public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.CategoryName).IsRequired();
        builder.Property(e => e.CategoryName).IsRequired();
        #endregion
    }
}