using AbsencesService.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace AbsenceService.Web.Models.Requests
{
    public record class CreateAbsenceRequest
    {
        [Required]
        public EmployeeModel Employee { get; init; }
        [Required]
        public AbsenceReason Reason { get; init; }
        [Required]
        public DateOnly StartDate { get; init; }
        [Required]
        public int Duration { get; init; }
        [Required]
        public bool Discounted { get; init; }
        [Required]
        public string Description { get; init; }
    }
}
