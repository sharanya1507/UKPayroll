using UKPayroll.DataLayer;
using UKPayroll.DataLayer.Models;
using UKPayroll.Shared.DTO;

namespace UKPayroll.DataLayer.Interfaces
{
    public interface IEmployeeRepo
    {
        
        Task<List<EmployeesInfo>> GetEmployeesAsync();  //"I'm going to get a list of employees when this operation finishes."

        Task<EmployeesInfo?> GetEmployeeAsync(int id);

        Task<EmployeesInfo> AddEmployeeAsync(EmployeesInfo employee);

        Task<EmployeesInfo?> UpdateEmployeeAsync(int id, EmployeesInfo employee);

        Task<bool> DeleteEmployeeAsync(int id);

        Task<List<EmployeesInfo>> GetEmployeeByJobRoleAsync(string jobRole);

        Task<List<EmployeesInfo>> GetEmployeesSortedAsync();
        Task<List<EmployeesInfo>> GetEmployeesWithDepartmentAsync();
        Task<List<EmployeeDepartmentDto>> GetEmployeesDepWithDepartmentAsync();

        // for relationship post, put, patch, delete operations
        Task<EmployeeDepartmentDto> AddEmployeeWithDepartmentAsync(EmployeeCreateDto employee);

        Task<EmployeeDepartmentDto> UpdateEmployeeWithDepartmentAsync(int id, EmployeeUpdateDto employee);

        Task<bool> DeleteEmployeewithDepartmentAsync(int id);

        Task<EmployeeDepartmentDto> PatchEmployeeDepartmentAsync(int id, int departmentId);
    }
}