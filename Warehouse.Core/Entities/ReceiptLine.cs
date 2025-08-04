using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Entities
{
    public class ReceiptLine
    {
        public int Id { get; set; }

        public int ReceiptId { get; set; }

        public int ResourceId { get; set; }

        public int MeasureId { get; set; }

        public decimal Quantity { get; set; }
    }
}
