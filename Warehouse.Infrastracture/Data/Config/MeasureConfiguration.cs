using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Entities;

namespace Warehouse.Infrastracture.Data.Config;

public class MeasureConfiguration : BaseWarehouseEntityConfiguration<Measure>
{
    public override void Configure(EntityTypeBuilder<Measure> builder)
    {
        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.HasIndex(m => m.Name)
            .IsUnique();
    }
}
