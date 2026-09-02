using Microsoft.EntityFrameworkCore;
using UKPayroll.DataLayer.Interfaces;
using UKPayroll.DataLayer.Models;

namespace UKPayroll.DataLayer.Repo;

public class EmployeeRepo : IEmployeeRepo
{
    private readonly AppDbContext _context;

    public EmployeeRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EmployeesInfo>> GetEmployeesAsync()  //This method can perform asynchronous work using await.
    {
        return await _context.EmployeesInfos.ToListAsync();
    }

    public async Task<EmployeesInfo?> GetEmployeeAsync(int id)
    {
        return await _context.EmployeesInfos.FindAsync(id);
    }

    public async Task<EmployeesInfo> AddEmployeeAsync(EmployeesInfo employee)
    {
        _context.EmployeesInfos.Add(employee);

        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<EmployeesInfo?> UpdateEmployeeAsync(int id, EmployeesInfo employee)
    {
        var existingEmployee = await _context.EmployeesInfos.FindAsync(id);

        if (existingEmployee == null)
        {
            return null;
        }

        _context.Entry(existingEmployee).CurrentValues.SetValues(employee);

        await _context.SaveChangesAsync();

        return existingEmployee;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        var employee = await _context.EmployeesInfos.FindAsync(id);

        if (employee == null)
        {
            return false;
        }

        _context.EmployeesInfos.Remove(employee);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<EmployeesInfo>> GetEmployeeByJobRoleAsync(string jobRole)
    {
        return await _context.EmployeesInfos
           .Where(e => e.JobRole == jobRole)
           .ToListAsync();
    }

    public async Task<List<EmployeesInfo>> GetEmployeesSortedAsync()
    {
        return await _context.EmployeesInfos
           .OrderBy(e => e.BasicSalary)
           .ThenBy(e => e.Name)
           .ToListAsync();
    }
}
