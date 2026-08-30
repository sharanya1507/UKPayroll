using System;
using System.Collections.Generic;

namespace UKPayroll.DataLayer.Models;

public partial class EmployeesInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string JobRole { get; set; } = null!;

    public decimal BasicSalary { get; set; }

    public decimal? Allowance { get; set; }

    public decimal? Overtime { get; set; }

    public decimal? Tax { get; set; }

    public decimal? NationalInsurance { get; set; }

    public decimal? Pension { get; set; }

    public decimal? GrossPay { get; set; }

    public decimal? NetPay { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
