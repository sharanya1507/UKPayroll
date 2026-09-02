using UKPayroll.DataLayer.Models;
using UKPayroll.Shared.DTO;

namespace UKPayroll.DataLayer.Interfaces
{
    public interface IEmployeeDepartmentRepo
    {
        Task<List<EmployeesInfo>> GetEmployeesWithDepartmentAsync();

        Task<List<EmployeeDepartmentDto>> GetEmployeesDepWithDepartmentAsync();

        // for relationship post, put, patch, delete operations
        Task<EmployeeDepartmentDto> AddEmployeeWithDepartmentAsync(EmployeeCreateDto employee);

        Task<EmployeeDepartmentDto> UpdateEmployeeWithDepartmentAsync(int id, EmployeeUpdateDto employee);

        Task<bool> DeleteEmployeewithDepartmentAsync(int id);

        Task<EmployeeDepartmentDto> PatchEmployeeDepartmentAsync(int id, int departmentId);
    }
}
