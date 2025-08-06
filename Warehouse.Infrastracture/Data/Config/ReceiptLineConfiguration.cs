using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Entities.ReceiptAggregate;

namespace Warehouse.Infrastracture.Data.Config;

public class ReceiptLineConfiguration : BaseWarehouseEntityConfiguration<ReceiptLine>
{
    public override void Configure(EntityTypeBuilder<ReceiptLine> builder)
    {
        base.Configure(builder);

        builder.Property(l => l.Quantity)
            .HasColumnType("decimal(18,4)")
            .IsRequired();

        builder.HasOne(l => l.Receipt)
            .WithMany(r => r.Lines)
            .HasForeignKey(l => l.ReceiptId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(l => l.Resource)
            .WithMany()
            .HasForeignKey(l => l.ResourceId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(l => l.Measure)
            .WithMany()
            .HasForeignKey(l => l.MeasureId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
