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
    public class TijdslotRepoADO : ITijdslotRepository
    {
        private string connectionstring;

        public TijdslotRepoADO(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(this.connectionstring);
        }

        public IReadOnlyList<string> KiesTijdslot()
        {
            SqlConnection connection = GetConnection();
            string query = "SELECT Slot FROM [dbo].[Tijdslot] ";
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
                        slots.Add((string)reader["Slot"]);
                    }
                    reader.Close();
                    return slots.AsReadOnly();
                }
                catch (Exception ex)
                {
                    throw new TijdslotRepoADOException ("KiesTijdslot", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}
