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
    public class KlantRepoADO : IKlantRepository
    {
        private string connectionstring;
        public KlantRepoADO(string connectionString)
        {
            this.connectionstring = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(this.connectionstring);
        }
        public string ZoekKlantVoornaam(int? id,string email)
        {
            if((!id.HasValue) && (string.IsNullOrEmpty(email) == true))
            {
                throw new KlantRepoADOException("ZoekKlant - geen geldige input");
            }
            SqlConnection connection = GetConnection();
            string query = "SELECT Voornaam from dbo.Klant ";// WHERE Email=@email";
            using (SqlCommand cmd = connection.CreateCommand())
            {
                if (id.HasValue)
                {
                    query += "WHERE ID=@id";
                }else
                {
                    query += "WHERE Email=@email";
                }

                {
                    cmd.CommandText = query;
                    connection.Open();
                    try
                    {
                        if (id.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id",id);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@email",email);
                        }
                        //cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                        //cmd.Parameters["@email"].Value = email;
                        cmd.CommandText= query;       
                        string KlantVoornaam = (string)cmd.ExecuteScalar();
                        if (string.IsNullOrEmpty(KlantVoornaam))
                        {
                            throw new KlantRepoADOException("Klant bestaat niet.");
                        }
                        return KlantVoornaam;
                    }
                    catch (KlantRepoADOException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {

                        throw new KlantRepoADOException("ZoekKlant",ex) ;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public Klant ZoekKlantDetails(int? id, string email)
        {
            if ((!id.HasValue) && (string.IsNullOrEmpty(email) == true))
            {
                throw new KlantRepoADOException("ZoekKlant - geen geldige input");
            }
            SqlConnection connection = GetConnection();
            string query = "SELECT * from dbo.Klant ";// WHERE Email=@email";
                    using (SqlCommand cmd = connection.CreateCommand())
            {
                if (id.HasValue)
                {
                    query += "WHERE ID=@id";
                }
                else
                {
                    query += "WHERE Email=@email";
                }

                {
                    cmd.CommandText = query;
                    connection.Open();
                    try
                    {
                        if (id.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@email", email);
                        }
                        //cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                        //cmd.Parameters["@email"].Value = email;
                        cmd.CommandText = query;
                        IDataReader reader = cmd.ExecuteReader();
                        if (reader.Read()) 
                        {
                            int klantID = (int)reader["ID"];
                            string KlantVoornaam = (string)reader["Voornaam"];
                            string KlantAchternaam = (string)reader["Familienaam"];
                            string klantEmail = (string)reader["Email"];
                            reader.Close();
                            Klant k = new Klant(klantID,klantEmail,KlantVoornaam,KlantAchternaam);
                            return k;
                        }
                        else
                        {
                            throw new KlantRepoADOException("ZoekKlantDetails - klant niet gevonden");
                        }
                        //string KlantVoornaam = (string)cmd.ExecuteScalar();
                        //if (string.IsNullOrEmpty(KlantVoornaam))
                        //{
                        //    throw new KlantRepoADOException("Klant bestaat niet.");
                        //}
                        //return KlantVoornaam;
                    }
                    catch (KlantRepoADOException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {

                        throw new KlantRepoADOException("ZoekKlant", ex);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            }
        }
}
