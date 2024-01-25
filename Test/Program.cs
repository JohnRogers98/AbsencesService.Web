using AbsenceService.DAL.Repositories;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        EmployeesRepository repository = new EmployeesRepository();
        var a = await repository.GetEmployeesAsync();
    }
}