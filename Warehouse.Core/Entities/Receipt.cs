using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Entities
{
    public class Receipt : BaseWarehouseEntity
    {
        public string Number { get; set; } = "";

        public DateTimeOffset ReceiptDate { get; set; }

        public List<ReceiptLine> Lines { get; private set; } = [];
    }
}
