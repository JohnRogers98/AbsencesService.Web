using System.ComponentModel.DataAnnotations;

namespace AbsenceService.Web.Models.Requests
{
    public record class DeleteAbsenceRequest
    {
        [Required]
        public int Id { get; init; }
    }
}
