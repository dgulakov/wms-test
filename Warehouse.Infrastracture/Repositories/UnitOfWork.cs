using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Interfaces;
using Warehouse.Infrastracture.Data;

namespace Warehouse.Infrastracture.Repositories;

public class UnitOfWork(WarehouseDbContext context) : IUnitOfWork
{
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);

    public Task RollbackAsync()
    {
        context.ChangeTracker.Clear();
        return Task.CompletedTask;
    }
}
