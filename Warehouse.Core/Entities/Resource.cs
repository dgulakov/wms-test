using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Enums;
using Warehouse.Core.Interfaces;

namespace Warehouse.Core.Entities;

public class Resource : BaseWarehouseEntity, IAggregateRoot
{
    public string Name { get; private set; }

    public WarehouseEntityStatus Status { get; private set; } = WarehouseEntityStatus.Active;


    //For EF Core only
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Resource() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public Resource(string name)
    {
        ValidateName(name);

        Name = name;
    }


    public void UpdateName(string name)
    {
        ValidateName(name);

        Name = name;
    }

    public void Archive() => Status = WarehouseEntityStatus.Archived;

    public void Restore() => Status = WarehouseEntityStatus.Active;


    private static void ValidateName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
    }
}
