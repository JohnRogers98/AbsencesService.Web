

namespace AbsencesService.Domain.Models
{
    public record class UpdateAbsenceModel
    {
        public int Id { get; init; }
        public AbsenceReason Reason { get; init; }
        public DateOnly StartDate { get; init; }
        public int Duration { get; init; }
        public bool Discounted { get; init; }
        public string Description { get; init; }
    }
}
