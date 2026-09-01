using System;
using System.Collections.Generic;
using System.Text;

namespace UKPayroll.Shared.DTO
{
    public class EmployeeDepartmentDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string JobRole { get; set; }
        public decimal BasicSalary { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
