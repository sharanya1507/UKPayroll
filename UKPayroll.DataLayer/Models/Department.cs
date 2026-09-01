using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UKPayroll.DataLayer.Models;

public partial class Department
{
    [Key]
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

     [JsonIgnore]
     public virtual ICollection<EmployeesInfo> EmployeesInfos { get; set; } = new List<EmployeesInfo>();


}
