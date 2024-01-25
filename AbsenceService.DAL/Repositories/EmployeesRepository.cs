
using Microsoft.Data.SqlClient;

namespace AbsenceService.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        #region Actions 

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync()
        {
            string sqlExpression = "select * from employees";
            var employees = new List<EmployeeModel>();
            
            using SqlConnection connection = new SqlConnection(StaticResources.ConnectionString);
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var employee = new EmployeeModel
                    {
                        Id = (int)reader["id"],
                        LastName = (string)reader["last_name"],
                        FirstName = (string)reader["first_name"]
                    };

                    employees.Add(employee);
                }
            }

            return employees;
        }

        #endregion

    }
}
