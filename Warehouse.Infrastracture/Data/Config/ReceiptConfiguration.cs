using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Entities.ReceiptAggregate;

namespace Warehouse.Infrastracture.Data.Config;

public class ReceiptConfiguration : BaseWarehouseEntityConfiguration<Receipt>
{
    public override void Configure(EntityTypeBuilder<Receipt> builder)
    {
        base.Configure(builder);

        builder.Property(r => r.Number)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(r => r.ReceiptDate)
            .IsRequired();

        builder.HasIndex(r => r.Number)
            .IsUnique();
    }
}
