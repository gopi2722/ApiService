using Microsoft.Data.SqlClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MsoneData
{
    public static class DButilities
    {
        public static string ConnectionString = string.Empty;
        //public static string ConnectionString = "Data Source=DESKTOP-14AG7NV\\SQLDB;Initial Catalog=VZBASE;User ID=SA;Password=TEST";
        //public static string ConnectionString = "Server=ms-sql-server,1433;Initial Catalog=VZBASE;User ID=SA;Password=Passw0rd";
        //public static string ConnectionString = "Data Source=ATDEVELOP;Initial Catalog=VZBASE;User ID=SA;Password=ZuLu@2020";
        public static async Task<DateTime> LocalDateTime(CancellationToken cancellationToken)
        {
            var dateTime = new DateTime();
            using (SqlConnection sql = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DBO.GetClientDate() AS DT", sql))
                {
                    await sql.OpenAsync(cancellationToken);
                    var result = await cmd.ExecuteScalarAsync(cancellationToken);
                    dateTime = Convert.ToDateTime(result);
                }
            }
            return dateTime;
        }
    }
}
