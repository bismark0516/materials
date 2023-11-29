using PetInfo.DAO.Interfaces;
using PetInfo.Models;
using PetInfoServer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetInfo.DAO
{
    public class OwnerSqlDao :IOwnerDao
    {
        private string connectionString;

        private string sqlListOwners = "SELECT id, name, email FROM Owner;";
        private string sqlAddOwner = "INSERT INTO Owner (name, email) " +
           "OUTPUT INSERTED.id " +
           "VALUES (@name, @email);";


        public OwnerSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Owner> ListOwners()
        {
            List<Owner> owners = new List<Owner>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlListOwners, conn))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Owner owner = new Owner();
                            owner = MapRowToOwner(reader);
                            owners.Add(owner);
                        }
                    }
                }
            }
            return owners;
        }

        public Owner AddOwner(Owner newOwner)
        {
            newOwner.Id = 0; //used as a marker to determine sucess

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlAddOwner, conn))
                {
                    cmd.Parameters.AddWithValue("@name", newOwner.Name);
                    cmd.Parameters.AddWithValue("@email", newOwner.Email);

                    newOwner.Id = (int)cmd.ExecuteScalar();
                }
            }

            return newOwner;
        }

        private Owner MapRowToOwner(SqlDataReader reader)
        {
            Owner owner = new Owner();
            owner.Id = Convert.ToInt32(reader["id"]);
            owner.Name = Convert.ToString(reader["name"]);
            owner.Email = Convert.ToString(reader["email"]);

            return owner;
        }

    }
}
