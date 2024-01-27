

namespace AbsenceService.Client.Models
{
    public class Absence
    {   
        public int Id { get; init; }
        public Employee Employee { get; init; }
        public AbsenceReason Reason { get; set; }
        public DateOnly StartDate { get; set; }
        public int Duration { get; set; }
        public bool Discounted { get; set; }
        public string Description { get; set; }
    }

    public enum AbsenceReason
    {
        Vacation,
        SickLeave,
        Unknown
    }
}