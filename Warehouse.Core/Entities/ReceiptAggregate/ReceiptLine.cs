using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Enums;
using Warehouse.Core.Exceptions;

namespace Warehouse.Core.Entities.ReceiptAggregate;

public class ReceiptLine : BaseWarehouseEntity
{
    public Guid ReceiptId { get; private set; }

    public Guid ResourceId { get; private set; }

    public Guid MeasureId { get; private set; }

    public decimal Quantity { get; private set; }


    public Receipt? Receipt { get; private set; }

    public Resource? Resource { get; private set; }

    public Measure? Measure { get; private set; }


    private ReceiptLine() { }

    public ReceiptLine(Receipt receipt, Resource resource, Measure measure, decimal quantity)
    {
        ArgumentNullException.ThrowIfNull(receipt);
        ArgumentNullException.ThrowIfNull(resource);
        ArgumentNullException.ThrowIfNull(measure);

        if (resource.Status == WarehouseEntityStatus.Archived)
        {
            throw new DomainException("Cannot use archived resource for new receipt line");
        }

        if (measure.Status == WarehouseEntityStatus.Archived)
        {
            throw new DomainException("Cannot use archived measure for new receipt line");
        }

        ValidateQuantity(quantity);

        Receipt = receipt;
        ReceiptId = receipt.Id;

        Resource = resource;
        ResourceId = resource.Id;

        Measure = measure;
        MeasureId = measure.Id;

        Quantity = quantity;
    }


    public void UpdateReceiptLine(decimal quantity, Resource? resource = null, Measure? measure = null)
    {
        if (resource != null && resource.Status == WarehouseEntityStatus.Archived && resource.Id != ResourceId)
        {
            throw new DomainException("Cannot change to archived resource");
        }

        if (measure != null && measure.Status == WarehouseEntityStatus.Archived && measure.Id != MeasureId)
        {
            throw new DomainException("Cannot change to archived measure");
        }

        ValidateQuantity(quantity);

        if (resource != null && resource.Id != ResourceId)
        {
            Resource = resource;
            ResourceId = resource.Id;
        }

        if (measure != null && measure.Id != MeasureId)
        {
            Measure = measure;
            MeasureId = measure.Id;
        }

        Quantity = quantity;
    }


    private static void ValidateQuantity(decimal quantity) => ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(quantity, 0);
}
