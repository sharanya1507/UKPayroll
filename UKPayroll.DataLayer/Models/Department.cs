using System;
using System.Collections.Generic;

namespace UKPayroll.DataLayer.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<EmployeesInfo> EmployeesInfos { get; set; } = new List<EmployeesInfo>();
}
