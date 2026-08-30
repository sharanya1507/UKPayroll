using Microsoft.AspNetCore.Mvc;
using UKPayroll.DataLayer;
using UKPayroll.DataLayer.Interfaces;
using UKPayroll.DataLayer.Models;

namespace UKPayroll.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeService;

        public EmployeeController(IEmployeeRepo employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeesInfo employee)
        {
            var newEmployee = await _employeeService.AddEmployeeAsync(employee);

            return Ok(newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeesInfo employee)
        {
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _employeeService.DeleteEmployeeAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok("Employee deleted successfully.");
        }

        [HttpGet("role/{jobRole}")]
        public async Task<IActionResult> GetEmployeesByJobRole(string jobRole)
        {
            var employees = await _employeeService.GetEmployeeByJobRoleAsync(jobRole);

            return Ok(employees);
        }


        [HttpGet("sorted")]
        public async Task<IActionResult> GetEmployeesSorted()
        {
            var employees = await _employeeService.GetEmployeesSortedAsync();

            return Ok(employees);
        }

        [HttpGet("with-department")]
        public async Task<IActionResult> GetEmployeesWithDepartment()
        {
            var employees = await _employeeService.GetEmployeesWithDepartmentAsync();

            return Ok(employees);
        }
    }
}