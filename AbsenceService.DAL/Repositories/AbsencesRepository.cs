
using Microsoft.Data.SqlClient;

namespace AbsenceService.DAL.Repositories
{
    public class AbsencesRepository : IAbsencesRepository
    {

        #region Actions

        public async Task<IEnumerable<AbsenceModel>> GetAbsencesAsync()
        {
            string sqlExpression = "select * from timesheet";
            var absences = new List<AbsenceModel>();

            using SqlConnection connection = new SqlConnection(StaticResources.ConnectionString);
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var absence = new AbsenceModel
                    {
                        Id = (int)reader["id"],
                        Employee = new EmployeeModel { Id = (int)reader["employee"] },
                        Reason = (AbsenceReason)reader["reason"],
                        StartDate = DateOnly.FromDateTime((DateTime)reader["start_date"]),
                        Duration = (int)reader["duration"],
                        Discounted = (bool)reader["discounted"],
                        Description = (string)reader["description"]
                    };

                    absences.Add(absence);
                }
            }

            return absences;
        }

        public async Task<int> AddAbsenceAsync(CreateAbsenceModel createAbsenceModel)
        {
            string sqlExpression = "insert into timesheet (employee, reason, start_date, duration, discounted, description) " +
                "values (@employee, @reason, @start_date, @duration, @discounted, @description)";

            using SqlConnection connection = new SqlConnection(StaticResources.ConnectionString);
            await connection.OpenAsync();

            var sqlParams = new SqlParameter[] {
                new SqlParameter("@employee", createAbsenceModel.Employee.Id),
                new SqlParameter("@reason", createAbsenceModel.Reason),
                new SqlParameter("@start_date", createAbsenceModel.StartDate),
                new SqlParameter("@duration", createAbsenceModel.Duration),
                new SqlParameter("@discounted", createAbsenceModel.Discounted),
                new SqlParameter("@description", createAbsenceModel.Description)
            };

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddRange(sqlParams);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateAbsenceAsync(UpdateAbsenceModel updateAbsenceModel)
        {
            string sqlExpression = "update timesheet set " +
                "reason = @reason, start_date = @start_date, duration = @duration, discounted = @discounted, description = @description " +
               "where id = @id";

            using SqlConnection connection = new SqlConnection(StaticResources.ConnectionString);
            await connection.OpenAsync();

            var sqlParams = new SqlParameter[] {
                new SqlParameter("@id", updateAbsenceModel.Id),
                new SqlParameter("@reason", updateAbsenceModel.Reason),
                new SqlParameter("@start_date", updateAbsenceModel.StartDate),
                new SqlParameter("@duration", updateAbsenceModel.Duration),
                new SqlParameter("@discounted", updateAbsenceModel.Discounted),
                new SqlParameter("@description", updateAbsenceModel.Description)
            };

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddRange(sqlParams);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteAnsenceAsync(DeleteAbsenceModel deleteAbsenceModel)
        {
            string sqlExpression = "delete from timesheet where id = @id";

            using SqlConnection connection = new SqlConnection(StaticResources.ConnectionString);
            await connection.OpenAsync();

            var sqlParams = new SqlParameter[] {
                new SqlParameter("@id", deleteAbsenceModel.Id),
            };

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddRange(sqlParams);

            return await command.ExecuteNonQueryAsync();
        }

        #endregion

    }
}
