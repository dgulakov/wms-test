using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Entities;

namespace Warehouse.Infrastracture.Data.Config;

public class ResourceConfiguration : BaseWarehouseEntityConfiguration<Resource>
{
    public override void Configure(EntityTypeBuilder<Resource> builder)
    {
        base.Configure(builder);

        builder.Property(res => res.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(res => res.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.HasIndex(res => res.Name)
            .IsUnique();
    }
}
