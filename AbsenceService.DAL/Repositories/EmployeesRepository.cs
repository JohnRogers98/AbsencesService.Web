using AbsencesService.Domain.Repositories;
using Microsoft.Data.SqlClient;

namespace AbsenceService.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        #region Actions 

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            string sqlExpression = "select * from employees";
            var employees = new List<Employee>();

            using SqlConnection connection = new SqlConnection(StaticResources.ConnectionString);
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var employee = new Employee
                    {
                        Id = (int)reader["id"],
                        Last_Name = (string)reader["last_name"],
                        First_Name = (string)reader["first_name"]
                    };

                    employees.Add(employee);
                }
            }

            return employees;
        }

        #endregion

    }
}
