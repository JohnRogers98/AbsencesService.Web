namespace AbsenceService.DAL.DTOEntities
{
    public class Absence
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public AbsenceReason Reason { get; set; }
        public DateOnly Start_Date { get; set; }
        public int Duration { get; set; }
        public bool Discounted { get; set; }
        public string Description { get; set; }
    }
}
