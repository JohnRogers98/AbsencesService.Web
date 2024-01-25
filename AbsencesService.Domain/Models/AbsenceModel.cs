
namespace AbsencesService.Domain.Models
{
    public record class AbsenceModel
    {
        public int Id { get; init; }
        public EmployeeModel Employee { get; init; }
        public AbsenceReason Reason { get; set; }
        public DateOnly StartDate { get; set; }
        public int Duration { get; set; }
        public bool Discounted { get; set; }
        public string Description { get; set; }
    }
}
