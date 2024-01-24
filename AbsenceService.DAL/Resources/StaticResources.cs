
using System.Configuration;

namespace AbsenceService.DAL.Resources
{
    public static class StaticResources
    {
        public static string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
    }
}
