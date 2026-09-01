using Microsoft.AspNetCore.Mvc;
using UKPayroll.DataLayer;
using UKPayroll.DataLayer.Interfaces;
using UKPayroll.DataLayer.Models;
using UKPayroll.Shared.DTO;

namespace UKPayroll.API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeRepo.GetEmployeesAsync();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeRepo.GetEmployeeAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeesInfo employee)
        {
            var newEmployee = await _employeeRepo.AddEmployeeAsync(employee);

            return Ok(newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeesInfo employee)
        {
            var updatedEmployee = await _employeeRepo.UpdateEmployeeAsync(id, employee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _employeeRepo.DeleteEmployeeAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok("Employee deleted successfully.");
        }

        [HttpGet("role/{jobRole}")]
        public async Task<IActionResult> GetEmployeesByJobRole(string jobRole)
        {
            var employees = await _employeeRepo.GetEmployeeByJobRoleAsync(jobRole);

            return Ok(employees);
        }


        [HttpGet("sorted")]
        public async Task<IActionResult> GetEmployeesSorted()
        {
            var employees = await _employeeRepo.GetEmployeesSortedAsync();

            return Ok(employees);
        }

        [HttpGet("with-department")]
        public async Task<IActionResult> GetEmployeesWithDepartment()
        {
            var employees = await _employeeRepo.GetEmployeesWithDepartmentAsync();

            return Ok(employees);
        }

        [HttpGet("employee-department")]
        public async Task<IActionResult> GetEmployeesDepWithDepartment()
        {
            var employees = await _employeeRepo.GetEmployeesDepWithDepartmentAsync();

            return Ok(employees);
        }

        [HttpPost("Relationship-Post")]
        public async Task<IActionResult> AddEmployeeWithDepartment(EmployeeCreateDto employee)
        {
            var result = await _employeeRepo.AddEmployeeWithDepartmentAsync(employee);

            if (result == null)
                return BadRequest("Department does not exist.");

            return Ok(result);
        }


        [HttpPut("with-department/{id}")]
        public async Task<IActionResult> UpdateEmployeeWithDepartment(int id, EmployeeUpdateDto employee)
        {
            var result = await _employeeRepo.UpdateEmployeeWithDepartmentAsync(id, employee);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("with-department/{id}")]
        public async Task<IActionResult> DeleteEmployeeWithDepartment(int id)
        {
            var result = await _employeeRepo.DeleteEmployeewithDepartmentAsync(id);

            if (!result)
                return NotFound();

            return Ok("Employee deleted successfully.");
        }


        [HttpPatch("{id}/department")]
        public async Task<IActionResult> PatchEmployeeDepartment(int id, int departmentId)
        {
            var result = await _employeeRepo
                .PatchEmployeeDepartmentAsync(id, departmentId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}