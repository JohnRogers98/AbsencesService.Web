using AbsenceService.Client.Helpers;
using AbsenceService.Client.Models;
using AbsenceService.Client.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbsenceService.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task<JsonResult> OnGetAbsencesListAsync()
        {
            var absences = await HttpHelper.GetAsync<IEnumerable<Absence>>("https://localhost:7195/api/Absences");

            return new JsonResult(absences);
        }

        public async Task<JsonResult> OnGetEmployeesListAsync()
        {
            var employees = await HttpHelper.GetAsync<IEnumerable<Employee>>("https://localhost:7195/api/Employees");

            return new JsonResult(employees);
        }

        public async Task<JsonResult> OnPostAbsenceAsync([FromForm] CreateAbsenceRequest absence)
        {
            if (absence.StartDate == DateOnly.FromDateTime(DateTime.MinValue))
            {
                absence.StartDate = DateOnly.FromDateTime(DateTime.Now);
            }

            var status = await HttpHelper.PostAsync("https://localhost:7195/api/Absences", absence);

            if (status == System.Net.HttpStatusCode.OK)
                return new JsonResult("Data is saved");
            return new JsonResult("Saving broken");

        }

        public async Task<JsonResult> OnPostDeleteAbsenceAsync([FromForm] int id)
        {
            var status = await HttpHelper.DeleteAsync("https://localhost:7195/api/Absences?id=" + id);

            if (status == System.Net.HttpStatusCode.OK)
                return new JsonResult("Data is saved");
            return new JsonResult("Saving broken");
        }

        public async Task<JsonResult> OnPutAbsenceAsync([FromForm] Absence absence)
        {
            var status = await HttpHelper.PutAsync("https://localhost:7195/api/Absences", absence);

            if (status == System.Net.HttpStatusCode.OK)
                return new JsonResult("Data is updated");
            return new JsonResult("Updating broken");
        }
    }
}
