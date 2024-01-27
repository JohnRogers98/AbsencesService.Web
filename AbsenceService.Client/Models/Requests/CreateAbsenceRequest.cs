namespace AbsenceService.Client.Models.Requests
{
    public class CreateAbsenceRequest
    {
        public int Id { get; init; }
        public int EmployeeId { get; init; }
        public AbsenceReason Reason { get; set; }
        public DateOnly StartDate { get; set; }
        public int Duration { get; set; }
        public bool Discounted { get; set; }
        public string Description { get; set; }
    }
}
