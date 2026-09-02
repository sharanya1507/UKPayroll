using Microsoft.AspNetCore.Mvc;
using UKPayroll.DataLayer.Interfaces;

namespace UKPayroll.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Employment - GUID")]
    public class EmploymentController : ControllerBase
    {
        private readonly IEmploymentRepo _employmentRepo;

        public EmploymentController(IEmploymentRepo employmentRepo)
        {
            _employmentRepo = employmentRepo;
        }

        [HttpGet("{employmentNo:guid}")]
        public async Task<IActionResult> GetEmployment(Guid employmentNo)
        {
            var result = await _employmentRepo.GetEmploymentAsync(employmentNo);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployment(
            int employeeId,
            DateTime startDate,
            DateTime? endDate)
        {
            var result = await _employmentRepo.AddEmploymentAsync(
                employeeId,
                startDate,
                endDate);

            if (result == null)
                return NotFound("Employee not found.");

            return Ok(result);
        }

        [HttpPut("{employmentNo:guid}")]
        public async Task<IActionResult> UpdateEmployment(
            Guid employmentNo,
            int employeeId,
            DateTime startDate,
            DateTime? endDate)
        {
            var result = await _employmentRepo.UpdateEmploymentAsync(
                employmentNo,
                employeeId,
                startDate,
                endDate);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{employmentNo:guid}")]
        public async Task<IActionResult> DeleteEmployment(Guid employmentNo)
        {
            var result = await _employmentRepo.DeleteEmploymentAsync(employmentNo);

            if (!result)
                return NotFound();

            return Ok("Employment deleted successfully.");
        }

        [HttpPatch("{employmentNo:guid}")]
        public async Task<IActionResult> PatchEmployment(
            Guid employmentNo,
            DateTime? endDate)
        {
            var result = await _employmentRepo.PatchEmploymentEndDateAsync(
                employmentNo,
                endDate);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
