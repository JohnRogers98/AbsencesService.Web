using AbsencesService.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbsenceService.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeesService employeesService, ILogger<EmployeesController> logger)
        {
            _employeesService = employeesService;
            _logger = logger;
        }

        #region Actions 

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeesService.GetAllEmployeesAsync();

            return Ok(employees);
        }

        #endregion

    }
}
