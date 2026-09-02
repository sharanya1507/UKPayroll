using Microsoft.EntityFrameworkCore;
using UKPayroll.DataLayer.Interfaces;
using UKPayroll.DataLayer.Models;
using UKPayroll.Shared.DTO;

namespace UKPayroll.DataLayer.Repo;

public class EmployeeDepartmentRepo : IEmployeeDepartmentRepo
{
    private readonly AppDbContext _context;

    public EmployeeDepartmentRepo(AppDbContext context)
    {
        _context = context;
    }

    // eager loading
    public async Task<List<EmployeesInfo>> GetEmployeesWithDepartmentAsync()
    {
        return await _context.EmployeesInfos
            .Include(e => e.Department)
            .ToListAsync();
    }

    public async Task<List<EmployeeDepartmentDto>> GetEmployeesDepWithDepartmentAsync()
    {
        return await _context.EmployeesInfos
            .Include(e => e.Department)
            .Where(e => e.Department!.DepartmentName == "HR" || e.Department.DepartmentName == "Finance")
            .Select(e => new EmployeeDepartmentDto  //imp
            {
                Name = e.Name,
                JobRole = e.JobRole,
                BasicSalary = e.BasicSalary,
                DepartmentName = e.Department!.DepartmentName
            })
            .ToListAsync();
    }

    public async Task<EmployeeDepartmentDto> AddEmployeeWithDepartmentAsync(EmployeeCreateDto employee)
    {
        var department = await _context.Departments.FindAsync(employee.DepartmentId);

        if (department == null)
            return null;

        var newEmployee = new EmployeesInfo
        {
            Name = employee.Name,
            JobRole = employee.JobRole,
            BasicSalary = employee.BasicSalary,
            DepartmentId = employee.DepartmentId
        };

        _context.EmployeesInfos.Add(newEmployee);

        await _context.SaveChangesAsync();

        return new EmployeeDepartmentDto
        {
            Id = newEmployee.Id,
            Name = newEmployee.Name,
            JobRole = newEmployee.JobRole,
            BasicSalary = newEmployee.BasicSalary,
            DepartmentId = department.DepartmentId,
            DepartmentName = department.DepartmentName
        };
    }

    public async Task<EmployeeDepartmentDto> UpdateEmployeeWithDepartmentAsync(
        int id,
        EmployeeUpdateDto employee)
    {
        var existingEmployee = await _context.EmployeesInfos.FindAsync(id);

        if (existingEmployee == null)
            return null;

        var department = await _context.Departments.FindAsync(employee.DepartmentId);

        if (department == null)
            return null;

        existingEmployee.Name = employee.Name;
        existingEmployee.JobRole = employee.JobRole;
        existingEmployee.BasicSalary = employee.BasicSalary;
        existingEmployee.DepartmentId = employee.DepartmentId;

        await _context.SaveChangesAsync();

        return new EmployeeDepartmentDto
        {
            Id = existingEmployee.Id,
            Name = existingEmployee.Name,
            JobRole = existingEmployee.JobRole,
            BasicSalary = existingEmployee.BasicSalary,
            DepartmentId = department.DepartmentId,
            DepartmentName = department.DepartmentName
        };
    }

    public async Task<bool> DeleteEmployeewithDepartmentAsync(int id)
    {
        var employee = await _context.EmployeesInfos.FindAsync(id);

        if (employee == null)
            return false;

        _context.EmployeesInfos.Remove(employee);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<EmployeeDepartmentDto> PatchEmployeeDepartmentAsync(int id, int departmentId)
    {
        var employee = await _context.EmployeesInfos.FindAsync(id);

        if (employee == null)
            return null;

        var department = await _context.Departments.FindAsync(departmentId);

        if (department == null)
            return null;

        employee.DepartmentId = departmentId;

        await _context.SaveChangesAsync();

        return new EmployeeDepartmentDto
        {
            Id = employee.Id,
            Name = employee.Name,
            JobRole = employee.JobRole,
            BasicSalary = employee.BasicSalary,
            DepartmentId = department.DepartmentId,
            DepartmentName = department.DepartmentName
        };
    }
}
