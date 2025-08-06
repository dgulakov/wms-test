using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Entities;
using Warehouse.Core.Entities.ReceiptAggregate;

namespace Warehouse.Infrastracture.Data;

public class WarehouseDbContext : DbContext
{
    public DbSet<Resource> Resources { get; set; }

    public DbSet<Measure> Measures { get; set; }

    public DbSet<Receipt> Receipts { get; set; }

    public DbSet<ReceiptLine> ReceiptLines { get; set; }


    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
