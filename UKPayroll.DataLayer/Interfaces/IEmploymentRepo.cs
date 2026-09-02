using UKPayroll.Shared.DTO;

namespace UKPayroll.DataLayer.Interfaces
{
    public interface IEmploymentRepo
    {
        Task<List<EmploymentDto>> GetEmploymentsAsync();

        Task<EmploymentDto?> GetEmploymentAsync(Guid employmentNo);

        Task<EmploymentDto?> AddEmploymentAsync(int employeeId, DateTime startDate, DateTime? endDate);

        Task<EmploymentDto?> UpdateEmploymentAsync(Guid employmentNo, int employeeId, DateTime startDate, DateTime? endDate);

        Task<bool> DeleteEmploymentAsync(Guid employmentNo);

        Task<EmploymentDto?> PatchEmploymentEndDateAsync(Guid employmentNo, DateTime? endDate);
    }
}
