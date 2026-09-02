using System;
using System.Collections.Generic;

namespace UKPayroll.DataLayer.Models;

public partial class Employment
{
    public Guid EmploymentNo { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual EmployeesInfo Employee { get; set; } = null!;
}
