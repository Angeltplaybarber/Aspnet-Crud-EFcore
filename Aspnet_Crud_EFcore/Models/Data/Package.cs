using System;
using System.Collections.Generic;

namespace Aspnet_Crud_EFcore.Models.Data;

public partial class Package
{
    public int PackageId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? TypeId { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual PackageType? Type { get; set; }
}
