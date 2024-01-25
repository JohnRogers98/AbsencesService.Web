

using AbsencesService.Domain.Models;

namespace AbsencesService.Domain.Repositories
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<EmployeeModel>> GetEmployeesAsync();
    }
}
