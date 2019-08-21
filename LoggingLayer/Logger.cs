using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Web;

namespace LoggingLayer
{
    public class Logger
    {

        static string connectionString;


        static Logger()
        {
            try
            {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while getting the DefaultConnectionString for Logger");
            }
        }


        public static void Log(Exception ex)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "Log_Insert";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Message", ex.Message);
                        command.Parameters.AddWithValue("@StackTrace", ex.StackTrace.ToString());
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                var path = HttpContext.Current.Server.MapPath("~");
                path += @"ErrorLog.Log";
                System.IO.File.AppendAllText(path, "While attempting to record the original exception to the database, this exception occurred\r\n");
                System.IO.File.AppendAllText(path, exc.ToString());
                System.IO.File.AppendAllText(path, "This is the Original Exception that was attempting to be written to the database\r\n");
                System.IO.File.AppendAllText(path, ex.ToString());
            }
        }

    }
}
