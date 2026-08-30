using UKPayroll.DataLayer;
using UKPayroll.DataLayer.Models;

namespace UKPayroll.DataLayer.Interfaces
{
    public interface IEmployeeRepo
    {
        
        Task<List<EmployeesInfo>> GetEmployeesAsync();

        Task<EmployeesInfo?> GetEmployeeAsync(int id);

        Task<EmployeesInfo> AddEmployeeAsync(EmployeesInfo employee);

        Task<EmployeesInfo?> UpdateEmployeeAsync(int id, EmployeesInfo employee);

        Task<bool> DeleteEmployeeAsync(int id);

        Task<List<EmployeesInfo>> GetEmployeeByJobRoleAsync(string jobRole);

        Task<List<EmployeesInfo>> GetEmployeesSortedAsync();
        Task<object> GetEmployeesWithDepartmentAsync();
    }
}