using FitnessReservatie.BL.Interfaces;
using FItnessReservatieDL.Exeptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FItnessReservatieDL
{
    public class ToestelRepoADO : IToestelRepository
    {
        private string connectionstring;

        public ToestelRepoADO(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(this.connectionstring);
        }

        public IReadOnlyList<string> KiesToestel()
        {
            SqlConnection connection = GetConnection();
            string query = "SELECT DISTINCT Type FROM [dbo].[Toestel] WHERE Is_Bruikbaar =1";
            List<string> slots = new List<string>();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                connection.Open();
                try
                {
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read())
                    {
                        slots.Add((string)reader["Type"]);
                    }
                    reader.Close();
                    return slots.AsReadOnly();
                }
                catch (Exception ex)
                {
                    throw new ToestelRepoADOException("kiesToestel", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}

