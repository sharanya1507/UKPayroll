using Microsoft.EntityFrameworkCore;
using UKPayroll.DataLayer.Interfaces;
using UKPayroll.DataLayer.Models;
using UKPayroll.Shared.DTO;

namespace UKPayroll.DataLayer.Repo;

public class EmploymentRepo : IEmploymentRepo
{
    private readonly AppDbContext _context;

    public EmploymentRepo(AppDbContext context)
    {
        _context = context;
    }

    private static EmploymentDto ToDto(Employment employment)
    {
        return new EmploymentDto
        {
            EmploymentNo = employment.EmploymentNo,
            EmployeeId = employment.EmployeeId,
            EmployeeName = employment.Employee.Name,
            StartDate = employment.StartDate.ToDateTime(TimeOnly.MinValue),
            EndDate = employment.EndDate.HasValue ? employment.EndDate.Value.ToDateTime(TimeOnly.MinValue) : null
        };
    }

    public async Task<List<EmploymentDto>> GetEmploymentsAsync()
    {
        return await _context.Employments
            .Include(e => e.Employee)
            .Select(e => new EmploymentDto
            {
                EmploymentNo = e.EmploymentNo,
                EmployeeId = e.EmployeeId,
                EmployeeName = e.Employee.Name,
                StartDate = e.StartDate.ToDateTime(TimeOnly.MinValue),
                EndDate = e.EndDate.HasValue ? e.EndDate.Value.ToDateTime(TimeOnly.MinValue) : null
            })
            .ToListAsync();
    }

    public async Task<EmploymentDto?> GetEmploymentAsync(Guid employmentNo)
    {
        var employment = await _context.Employments
            .Include(e => e.Employee)
            .FirstOrDefaultAsync(e => e.EmploymentNo == employmentNo);

        return employment == null ? null : ToDto(employment);
    }

    public async Task<EmploymentDto?> AddEmploymentAsync(int employeeId, DateTime startDate, DateTime? endDate)
    {
        var employee = await _context.EmployeesInfos.FindAsync(employeeId);

        if (employee == null)
            return null;

        var employment = new Employment
        {
            EmployeeId = employeeId,
            StartDate = DateOnly.FromDateTime(startDate),
            EndDate = endDate.HasValue ? DateOnly.FromDateTime(endDate.Value) : null
        };

        _context.Employments.Add(employment);

        await _context.SaveChangesAsync();

        employment.Employee = employee;

        return ToDto(employment);
    }

    public async Task<EmploymentDto?> UpdateEmploymentAsync(Guid employmentNo, int employeeId, DateTime startDate, DateTime? endDate)
    {
        var employment = await _context.Employments
            .Include(e => e.Employee)
            .FirstOrDefaultAsync(e => e.EmploymentNo == employmentNo);

        if (employment == null)
            return null;

        var employee = await _context.EmployeesInfos.FindAsync(employeeId);

        if (employee == null)
            return null;

        employment.EmployeeId = employeeId;
        employment.StartDate = DateOnly.FromDateTime(startDate);
        employment.EndDate = endDate.HasValue ? DateOnly.FromDateTime(endDate.Value) : null;

        await _context.SaveChangesAsync();

        employment.Employee = employee;

        return ToDto(employment);
    }

    public async Task<bool> DeleteEmploymentAsync(Guid employmentNo)
    {
        var employment = await _context.Employments.FindAsync(employmentNo);

        if (employment == null)
            return false;

        _context.Employments.Remove(employment);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<EmploymentDto?> PatchEmploymentEndDateAsync(Guid employmentNo, DateTime? endDate)
    {
        var employment = await _context.Employments
            .Include(e => e.Employee)
            .FirstOrDefaultAsync(e => e.EmploymentNo == employmentNo);

        if (employment == null)
            return null;

        employment.EndDate = endDate.HasValue ? DateOnly.FromDateTime(endDate.Value) : null;

        await _context.SaveChangesAsync();

        return ToDto(employment);
    }
}
