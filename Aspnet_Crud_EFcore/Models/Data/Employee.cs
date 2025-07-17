using System;
using System.Collections.Generic;

namespace Aspnet_Crud_EFcore.Models.Data;

public partial class Employee
{
    public int EmployeesId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
