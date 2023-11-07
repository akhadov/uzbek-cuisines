using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzbekCuisines.Domain.Entities.Orders;
using UzbekCuisines.Domain.Entities.Products;

namespace UzbekCuisines.Persistence.Configurations;

internal class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.ToTable("LineItem");

        builder.HasKey(li => li.Id);

        builder.Property(li => li.Id).HasConversion(
            lineItem => lineItem.Value,
            value => new LineItemId(value));

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(li => li.ProductId);

        builder.OwnsOne(li => li.Price);
    }
}
