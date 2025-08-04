using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Enums;

namespace Warehouse.Core.Entities
{
    public class Measure
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public WarehouseEntityStatus Status { get; set; } = WarehouseEntityStatus.Active;
    }
}
