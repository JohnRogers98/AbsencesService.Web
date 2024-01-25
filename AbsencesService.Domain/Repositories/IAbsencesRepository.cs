

using AbsencesService.Domain.Models;

namespace AbsencesService.Domain.Repositories
{
    public interface IAbsencesRepository
    {
        Task<IEnumerable<AbsenceModel>> GetAbsencesAsync();
        Task<int> AddAbsenceAsync(CreateAbsenceModel createAbsenceModel);
        Task<int> UpdateAbsenceAsync(UpdateAbsenceModel updateAbsenceModel);
        Task<int> DeleteAnsenceAsync(DeleteAbsenceModel deleteAbsenceModel);
    }
}
