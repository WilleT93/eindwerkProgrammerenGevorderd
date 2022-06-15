using FitnessReservatie.BL.Domein;
using FitnessReservatie.BL.DTO;
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
    public class ReservatieRepoADO : IReservatieRepository
    {
        private string connectionString;

        public ReservatieRepoADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(this.connectionString);
        }
        public IReadOnlyList<ReservatieInfoDTO> ZoekReservatie(int id)
        {
            if(id <= 0)
            {
                throw new ReservatieRepoADOException("GetReservations - ongeldig ID");
            }
            List<ReservatieInfoDTO> reservaties = new List<ReservatieInfoDTO>();
            SqlConnection conn = GetConnection();
            string query = "SELECT r.Datum, Slot, Type " +
                "FROM Reservatie r " +
                "INNER JOIN ReservatieDetails rd ON r.ID=rd.Reservatie_id " +
                "INNER JOIN Tijdslot t ON t.ID=rd.Tijdslot_id " +
                "INNER JOIN Toestel toe ON toe.ID=rd.Toestel_id " +
                "WHERE r.Klant_id=1;";
            using (SqlCommand cmd = conn.CreateCommand()) 
            {
                conn.Open(); 
            try
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = query;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime Datum = (DateTime)reader ["Datum"];
                        string slot = (string)reader["slot"];
                        string type = (string)reader["type"];
                        reservaties.Add(new ReservatieInfoDTO(Datum, slot, type));
                    }
                    return reservaties.AsReadOnly();

             }
             catch(Exception ex)
            {
                    throw new ReservatieRepoADOException("ZoekReservaties");
            }
                finally
                {
                    conn.Close();
                }
                
            }
        }

        public int? ZoekReservatieId(int KlantId, DateTime reservatieDatum)//geeft 0 als iks gevonden is
        {
            if (KlantId <= 0)
            {
                throw new ReservatieRepoADOException("ZoekReservatieId");
            }
            SqlConnection connection = GetConnection();
            string query = "SELECT ID from dbo.Reservatie " +
                "WHERE Klant_id=@KlantId AND Datum=@reservatieDatum";
            using (SqlCommand cmd = connection.CreateCommand())
            {
                    cmd.CommandText = query;
                    connection.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@KlantId", KlantId);
                    cmd.Parameters.AddWithValue("#reservatieDatum", reservatieDatum);
                    cmd.CommandText = query;
                    int? reservatieId = (int?)cmd.ExecuteScalar();
                    //if(reservatieId == null)
                    //{
                    //    return -1;
                    //}
                    //return (int)reservatieId;
                    return reservatieId;
                }




                catch (Exception ex)
                {

                    throw new ReservatieRepoADOException("ZoekReservatieId", ex);
                }
                finally
                {
                    connection.Close();
                }
                
            }
        }

        public int SchrijfReservatieIndDB(int id, DateTime date)
        {
            if (id <= 0)
            {
                throw new ReservatieRepoADOException("SchrijfReservatieInDB - ongeldige input");
            }
            SqlConnection conn = GetConnection();
            string query = "INSERT INTO dbo.Reservatie(Klant_id,Datum) "
                + "output INSERTED.ID VALUES(@id,@date)";
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@date", System.Data.SqlDbType.Date));
                    cmd.Parameters["@id"].Value = id;
                    cmd.Parameters["#date"].Value = date;
                    cmd.CommandText = query;
                    int reservatieId = (int)cmd.ExecuteScalar();
                    return reservatieId;
                }
            }
            catch (Exception ex)
            {
                throw new ReservatieRepoADOException("SchrijfReservatieInDB", ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public void SchrijfReservatieDetailsInDB(int reservatieId, int toestelId, int tijdslotId)
        {
            if (reservatieId <= 0 || toestelId <= 0 || tijdslotId <= 0)
            {
                throw new ReservatieRepoADOException("SchrijfReservatieDetailsInDB - ongeldige input");
            }
            SqlConnection conn = GetConnection();
            string query = "INSERT INTO dbo.ReservatieDetails(Reservatie_id,Toestel_id,Tijdslot_id) "
                + "VALUES(@reservatieid,@toestelid,@tijdslotid)";
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add(new SqlParameter("@reservatieid", System.Data.SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@toestelid", System.Data.SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@tijdslotid", System.Data.SqlDbType.Int));
                    cmd.Parameters["@reservatieid"].Value = reservatieId;
                    cmd.Parameters["@toestelid"].Value = toestelId;
                    cmd.Parameters["@tijdslotid"].Value = tijdslotId;
                    cmd.CommandText = query;
                    cmd.ExecuteScalar();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ReservatieRepoADOException("SchrijfReservatieInDB", ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
