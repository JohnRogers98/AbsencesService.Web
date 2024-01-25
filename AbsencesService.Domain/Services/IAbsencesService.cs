

using AbsencesService.Domain.Models;

namespace AbsencesService.Domain.Services
{
    public interface IAbsencesService
    {
        Task<IEnumerable<AbsenceModel>> GetAllAbsencesAsync();
        Task CreateAbsenceAsync(CreateAbsenceModel createAbsenceModel);
        Task UpdateAbsenceAsync(UpdateAbsenceModel updateAbsenceModel);
        Task DeleteAnsenceAsync(DeleteAbsenceModel deleteAbsenceModel);
    }
}
