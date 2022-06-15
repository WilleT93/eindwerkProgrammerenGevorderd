using FitnessReservatie.BL.Domein;
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

        public IReadOnlyList<Toestel> ZoekAlleToestellen()
        {
            List<Toestel> toestel = new List<Toestel>();
            SqlConnection conn = GetConnection();
            string query = "SELECT * FROM [dbo].[Toestel]";
            List<string> slots = new List<string>();
            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = query;
                conn.Open();
                try
                {
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read())
                    {
                        int id =(int)reader["ID"];
                        string type = (string)reader["Type"];
                        bool availability = (bool)reader["Is_Bruikbaar"];
                        Toestel d = new Toestel(id, type, availability);
                        toestel.Add(d);
                    }
                    reader.Close();
                    return toestel.AsReadOnly();
                }
                catch (Exception ex)
                {
                    throw new ToestelRepoADOException("kiesToestel", ex);
                }
                finally
                {
                    conn.Close();
                }
            }  
        }

        public IReadOnlyList<Toestel> ZoekToestellenVanType(string selectedItem)
        {
            List<Toestel> toestel = new List<Toestel>();
            SqlConnection conn = GetConnection();
            string query = "SELECT * FROM [dbo].[Toestel] WHERE Type=@type";
            List<string> slots = new List<string>();
            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = query;
                conn.Open();
                try
                {
                    command.Parameters.AddWithValue("@type",selectedItem);
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read())
                    {
                        int id = (int)reader["ID"];
                        string type = (string)reader["Type"];
                        bool availability = (bool)reader["Is_Bruikbaar"];
                        Toestel d = new Toestel(id, type, availability);
                        toestel.Add(d);
                    }
                    reader.Close();
                    return toestel.AsReadOnly();
                }
                catch (Exception ex)
                {
                    throw new ToestelRepoADOException("ZoekToestellenVanType", ex);
                }
                finally
                {
                    conn.Close();
                }
            }    
        }

        public void VerwijderToestel(int toestelID)
        {
            SqlConnection conn = GetConnection();
            string query = "DELETE FROM [dbo].[Toestel] WHERE ID=@id";
            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = query;
                conn.Open();
                try
                {
                    command.Parameters.AddWithValue("@id", toestelID);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ToestelRepoADOException("VerwijderToestel", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void ZetToeselBeschikbaar(int id)
        {
            SqlConnection conn = GetConnection();
            string query = "UPDATE [dbo].[Toestel] SET Is_Bruikbaar=1 WHERE ID=@id";
            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = query;
                conn.Open();
                try
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ToestelRepoADOException("VerwijderToestel", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void ZetToestelOnbeschikbaar(int id)
            {
            SqlConnection conn = GetConnection();
            string query = "UPDATE [dbo].[Toestel] SET Is_Bruikbaar=0 WHERE ID=@id";
            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = query;
                conn.Open();
                try
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ToestelRepoADOException("VerwijderToestel", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void VoegToestelToe(string type)
        {
            SqlConnection conn = GetConnection();
            string query = "INSERT INTO [dbo].[Toestel] (Type,Is_Bruikbaar) VALUES (@type,1)";
            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = query;
                conn.Open();
                try
                {
                    command.Parameters.AddWithValue("@type", type);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ToestelRepoADOException("VoegToestelToe", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
    }


