using AbsenceService.DAL.DTOEntities;
using AbsenceService.DAL.Repositories;

internal class Program
{
    private async  static Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        EmployeesRepository repository = new EmployeesRepository();
        var a = await repository.GetEmployeesAsync();

        AbsencesRepository a_repository = new AbsencesRepository();
        var a2 = await a_repository.GetAbsencesAsync();

        //await a_repository.AddAbsence(new Absence
        //{
        //    EmployeeId = 7,
        //    Description = "i dona now",
        //    Start_Date = DateOnly.FromDateTime(DateTime.Now),
        //    Discounted = false,
        //    Reason = AbsenceReason.Unknown,
        //    Duration = 2
        //});

        //await a_repository.DeleteAnsenceAsync(1);

        await a_repository.UpdateAbsence(new Absence
        {
            Id = 2,
            EmployeeId = 9,
            Description = "i dona now",
            Start_Date = DateOnly.FromDateTime(DateTime.Now),
            Discounted = false,
            Reason = AbsenceReason.Unknown,
            Duration = 2
        });
    }
}