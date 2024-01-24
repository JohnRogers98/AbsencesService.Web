using AbsencesService.Domain.Repositories;
using Microsoft.Data.SqlClient;

namespace AbsenceService.DAL.Repositories
{
    public class AbsencesRepository : IAbsencesRepository
    {

        #region Actions

        public async Task<IEnumerable<Absence>> GetAbsencesAsync()
        {
            string sqlExpression = "select * from timesheet";
            var absences = new List<Absence>();

            using SqlConnection connection = new SqlConnection(StaticResources.ConnectionString);
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var absence = new Absence
                    {
                        Id = (int)reader["id"],
                        EmployeeId = (int)reader["employee"],
                        Reason = (AbsenceReason)reader["reason"],
                        Start_Date = DateOnly.FromDateTime((DateTime)reader["start_date"]),
                        Duration = (int)reader["duration"],
                        Discounted = (bool)reader["discounted"],
                        Description = (string)reader["description"]
                    };

                    absences.Add(absence);
                }
            }

            return absences;
        }

        public async Task<int> AddAbsenceAsync(Absence absence)
        {
            string sqlExpression = "insert into timesheet (employee, reason, start_date, duration, discounted, description) " +
                "values (@employee, @reason, @start_date, @duration, @discounted, @description)";

            using SqlConnection connection = new SqlConnection(StaticResources.ConnectionString);
            await connection.OpenAsync();

            var sqlParams = new SqlParameter[] {
                new SqlParameter("@employee", absence.EmployeeId),
                new SqlParameter("@reason", absence.Reason),
                new SqlParameter("@start_date", absence.Start_Date),
                new SqlParameter("@duration", absence.Duration),
                new SqlParameter("@discounted", absence.Discounted),
                new SqlParameter("@description", absence.Description)
            };

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddRange(sqlParams);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateAbsence(Absence absence)
        {
            string sqlExpression = "update timesheet set " +
                "employee = @employee, reason = @reason, start_date = @start_date, duration = @duration, discounted = @discounted, description = @description " +
               "where id = @id";

            using SqlConnection connection = new SqlConnection(StaticResources.ConnectionString);
            await connection.OpenAsync();

            var sqlParams = new SqlParameter[] {
                new SqlParameter("@id", absence.Id),
                new SqlParameter("@employee", absence.EmployeeId),
                new SqlParameter("@reason", absence.Reason),
                new SqlParameter("@start_date", absence.Start_Date),
                new SqlParameter("@duration", absence.Duration),
                new SqlParameter("@discounted", absence.Discounted),
                new SqlParameter("@description", absence.Description)
            };

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddRange(sqlParams);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteAnsenceAsync(int id)
        {
            string sqlExpression = "delete from timesheet where id = @id";

            using SqlConnection connection = new SqlConnection(StaticResources.ConnectionString);
            await connection.OpenAsync();

            var sqlParams = new SqlParameter[] {
                new SqlParameter("@id", id),
            };

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddRange(sqlParams);

            return await command.ExecuteNonQueryAsync();
        }

        #endregion

    }
}
