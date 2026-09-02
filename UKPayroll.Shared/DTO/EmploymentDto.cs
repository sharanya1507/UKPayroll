using System;
using System.Collections.Generic;
using System.Text;

namespace UKPayroll.Shared.DTO
{
    public class EmploymentDto
    {
        public Guid EmploymentNo { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
