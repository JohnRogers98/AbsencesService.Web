
namespace AbsencesService.Domain.Models
{
    public record class EmployeeModel
    {
        public int Id { get; init; }
        public string LastName { get; init; }
        public string FirstName { get; init; }
    }
}
