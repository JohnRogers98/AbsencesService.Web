
namespace AbsenceService.BLL.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly ILogger _logger;

        public EmployeesService(IEmployeesRepository employeeRepository, ILogger<EmployeesService> logger)
        {
            _employeesRepository = employeeRepository;
            _logger = logger;
        }

        #region Actions

        public async Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync()
        {
            var employees = await _employeesRepository.GetEmployeesAsync();

            _logger.LogDebug($"Employees of count {employees.Count()} have been fetched from database");

            return employees;
        }

        #endregion

    }
}
