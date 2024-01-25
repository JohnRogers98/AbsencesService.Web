
namespace AbsenceService.BLL.Services
{
    public class AbsencesService : IAbsencesService
    {

        private readonly IAbsencesRepository _absencesRepository;
        private readonly ILogger _logger;

        public AbsencesService(IAbsencesRepository absencesRepository, ILogger<EmployeesService> logger)
        {
            _absencesRepository = absencesRepository;
            _logger = logger;
        }

        #region Actions

        public async Task CreateAbsenceAsync(CreateAbsenceModel createAbsenceModel)
        {
            var changed = await _absencesRepository.AddAbsenceAsync(createAbsenceModel);

            if(changed == 1)
                _logger.LogDebug($"Absence has been created");
        }

        public async Task DeleteAnsenceAsync(DeleteAbsenceModel deleteAbsenceModel)
        {
            var changed = await _absencesRepository.DeleteAnsenceAsync(deleteAbsenceModel);

            if (changed == 1)
                _logger.LogDebug("Absence has been deleted");
        }

        public async Task<IEnumerable<AbsenceModel>> GetAllAbsencesAsync()
        {
            var absences = await _absencesRepository.GetAbsencesAsync();

            _logger.LogDebug($"Absences of count {absences.Count()} have been fetched from database");

            return absences;
        }

        public async Task UpdateAbsenceAsync(UpdateAbsenceModel updateAbsenceModel)
        {
            var changed = await _absencesRepository.UpdateAbsenceAsync(updateAbsenceModel);

            if (changed == 1)
                _logger.LogDebug("Absence has been updated");
        }

        #endregion

    }
}
