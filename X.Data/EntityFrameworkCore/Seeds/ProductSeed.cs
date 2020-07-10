using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using X.Core.Entities;

namespace X.Data.EntityFrameworkCore.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product{Id=1,Name = "Kalem",Price = 10.00m,Description = "Kurşun Kalem"},
                new Product{Id=2,Name = "Masa",Price = 100.00m,Description = "Tahta Masa"}
            );
        }
    }
}
