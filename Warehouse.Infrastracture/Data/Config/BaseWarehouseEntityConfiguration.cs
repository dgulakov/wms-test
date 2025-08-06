using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Entities;

namespace Warehouse.Infrastracture.Data.Config;

public class BaseWarehouseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseWarehouseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.ConcurencyToken)
            .IsRowVersion()
            .IsConcurrencyToken();
    }
}
