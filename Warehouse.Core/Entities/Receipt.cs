using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Entities
{
    public class Receipt
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime ReceiptDate { get; set; }

        public List<ReceiptLine> Lines { get; private set; } = [];
    }
}
