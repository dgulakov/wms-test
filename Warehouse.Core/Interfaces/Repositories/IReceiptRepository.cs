using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Entities.ReceiptAggregate;

namespace Warehouse.Core.Interfaces.Repositories;

public interface IReceiptRepository : IRepository<Receipt>
{
    Task<bool> ExistsByNumberAsync(string number);

    Task<Receipt> GetWithLinesAsync(Guid id);
}
