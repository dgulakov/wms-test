using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Entities
{
    public abstract class BaseWarehouseEntity
    {
        public int Id { get; protected set; }

        public byte[] ConcurencyToken { get; set; } = [];
    }
}
