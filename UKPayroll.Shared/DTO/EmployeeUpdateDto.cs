using System;
using System.Collections.Generic;
using System.Text;

namespace UKPayroll.Shared.DTO
{
    public class EmployeeUpdateDto
    {
        public string Name { get; set; }
        public string JobRole { get; set; }
        public decimal BasicSalary { get; set; }
        public int DepartmentId { get; set; }
    }
}
