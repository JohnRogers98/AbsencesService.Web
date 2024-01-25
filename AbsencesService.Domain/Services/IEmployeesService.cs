

using AbsencesService.Domain.Models;

namespace AbsencesService.Domain.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync();
    }
}
