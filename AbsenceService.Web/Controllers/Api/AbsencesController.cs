using AbsenceService.Web.Models.Requests;
using AbsencesService.Domain.Models;
using AbsencesService.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AbsenceService.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsencesController : ControllerBase
    {
        private readonly IAbsencesService _absencesService;
        private readonly ILogger<AbsencesController> _logger;
        private readonly IMapper _mapper;

        public AbsencesController(IAbsencesService absencesService, ILogger<AbsencesController> logger, IMapper mapper)
        {
            _absencesService = absencesService;
            _logger = logger;
            _mapper = mapper;
        }

        #region Actions

        [HttpGet]
        public async Task<IActionResult> GetAllAbsences()
        {
            var absences = await _absencesService.GetAllAbsencesAsync();

            return Ok(absences);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbsence(CreateAbsenceRequest request)
        {
            var createAbsenceModel = _mapper.Map<CreateAbsenceModel>(request);

            await _absencesService.CreateAbsenceAsync(createAbsenceModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbsence(UpdateAbsenceRequest request)
        {
            var updateAbsenceModel = _mapper.Map<UpdateAbsenceModel>(request);

            await _absencesService.UpdateAbsenceAsync(updateAbsenceModel);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbsence(int id)
        {
            var request = new DeleteAbsenceRequest { Id = id };

            var deleteAbsenceModel = _mapper.Map<DeleteAbsenceModel>(request);

            await _absencesService.DeleteAnsenceAsync(deleteAbsenceModel);

            return Ok();
        }

        #endregion

    }
}
