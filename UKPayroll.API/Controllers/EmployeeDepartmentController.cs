using Microsoft.AspNetCore.Mvc;
using UKPayroll.DataLayer.Interfaces;
using UKPayroll.Shared.DTO;

namespace UKPayroll.API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    [Tags("Employee With Department")]
    public class EmployeeDepartmentController : ControllerBase
    {
        private readonly IEmployeeDepartmentRepo _employeeDepartmentRepo;

        public EmployeeDepartmentController(IEmployeeDepartmentRepo employeeDepartmentRepo)
        {
            _employeeDepartmentRepo = employeeDepartmentRepo;
        }

        [HttpGet("with-department")]
        public async Task<IActionResult> GetEmployeesWithDepartment()
        {
            var employees = await _employeeDepartmentRepo.GetEmployeesWithDepartmentAsync();

            return Ok(employees);
        }

        [HttpGet("employee-department")]
        public async Task<IActionResult> GetEmployeesDepWithDepartment()
        {
            var employees = await _employeeDepartmentRepo.GetEmployeesDepWithDepartmentAsync();

            return Ok(employees);
        }

        [HttpPost("Relationship-Post")]
        public async Task<IActionResult> AddEmployeeWithDepartment(EmployeeCreateDto employee)
        {
            var result = await _employeeDepartmentRepo.AddEmployeeWithDepartmentAsync(employee);

            if (result == null)
                return BadRequest("Department does not exist.");

            return Ok(result);
        }

        [HttpPut("with-department/{id}")]
        public async Task<IActionResult> UpdateEmployeeWithDepartment(int id, EmployeeUpdateDto employee)
        {
            var result = await _employeeDepartmentRepo.UpdateEmployeeWithDepartmentAsync(id, employee);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("with-department/{id}")]
        public async Task<IActionResult> DeleteEmployeeWithDepartment(int id)
        {
            var result = await _employeeDepartmentRepo.DeleteEmployeewithDepartmentAsync(id);

            if (!result)
                return NotFound();

            return Ok("Employee deleted successfully.");
        }

        [HttpPatch("{id}/department")]
        public async Task<IActionResult> PatchEmployeeDepartment(int id, int departmentId)
        {
            var result = await _employeeDepartmentRepo.PatchEmployeeDepartmentAsync(id, departmentId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
