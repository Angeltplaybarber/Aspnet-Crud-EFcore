using System;
using System.Collections.Generic;

namespace Aspnet_Crud_EFcore.Models.Data;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? ClientId { get; set; }

    public int? PackageId { get; set; }

    public DateOnly? ReservationDate { get; set; }

    public int NumberOfPeople { get; set; }

    public decimal TotalPrice { get; set; }

    public int EmployeeId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Package? Package { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
