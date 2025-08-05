using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Entities;

namespace Warehouse.Core.Interfaces.Repositories;

public interface IMeasureRepository : IRepository<Resource>
{
    Task<bool> ExistsByNameAsync(string name, Guid excludeId);

    Task<IEnumerable<Resource>> GetActiveEntitiesAsync();
}
