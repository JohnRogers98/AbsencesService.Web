
using System.Configuration;

namespace AbsenceService.DAL.Resources
{
    public static class StaticResources
    {
        public static string ConnectionString => "Server=(localdb)\\ProjectModels;Database=absencesdb;Trusted_Connection=True;";
    }
}
