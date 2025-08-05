using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Interfaces;

namespace Warehouse.Core.Entities.ReceiptAggregate
{
    public class Receipt : BaseWarehouseEntity, IAggregateRoot
    {
        private readonly List<ReceiptLine> _lines = [];


        public string Number { get; private set; }

        public DateTimeOffset ReceiptDate { get; set; }

        public IReadOnlyList<ReceiptLine> Lines => _lines.AsReadOnly();


        //For EF Core only
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private Receipt() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public Receipt(string number, DateTimeOffset receiptDate)
        {
            ValidateNumber(number);

            Number = number;
            ReceiptDate = receiptDate;
        }


        public void UpdateReceipt(string number, DateTimeOffset receiptDate)
        {
            ValidateNumber(number);

            Number = number;
            ReceiptDate = receiptDate;
        }

        public void AddLine(Resource resource, Measure measure, decimal quantity)
        {
            _lines.Add(new ReceiptLine(this, resource, measure, quantity));
        }


        private static void ValidateNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Number cannot be blank");
            }
        }
    }
}
