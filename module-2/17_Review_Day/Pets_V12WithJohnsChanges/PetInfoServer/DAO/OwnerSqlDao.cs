using PetInfoServer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetInfoServer.DAO
{
    public class OwnerSqlDao : IOwnerDao
    {
        private string connectionString = "";

        private string sqlListOwners = "SELECT id, name, email FROM owner;";
        private string sqlGetOwner = "SELECT id, name, email FROM owner " +
            "WHERE id = @id;";
        private string sqlAddAOwner = "INSERT INTO owner (name, email) " +
            "OUTPUT INSERTED.id " +
            "VALUES (@name, @email);";
        private string SqlUpdateOwner = "UPDATE owner SET name=@name, email=@email " +
            "WHERE id = @id";
        private string SqlDeleteOwner = "DELETE FROM owner WHERE id=@id;";


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

        public Owner GetOwner(int petId)
        {
            Owner pet = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlGetOwner, conn))
                {
                    cmd.Parameters.AddWithValue("@id", petId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            pet = MapRowToOwner(reader);
                        }
                    }
                }
            }
            return pet;
        }

        public Owner AddAOwner(Owner newOwner)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlAddAOwner, conn))
                {
                    cmd.Parameters.AddWithValue("@name", newOwner.Name);
                    cmd.Parameters.AddWithValue("@email", newOwner.Email);

                    newOwner.Id = (int)cmd.ExecuteScalar();
                }
            }
            return newOwner;
        }

        public Owner UpdateOwner(Owner updatedOwner)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlUpdateOwner, conn))
                {
                    cmd.Parameters.AddWithValue("@name", updatedOwner.Name);
                    cmd.Parameters.AddWithValue("@email", updatedOwner.Email);
                    cmd.Parameters.AddWithValue("@id", updatedOwner.Id);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return updatedOwner;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public bool DeleteAOwner(int petId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlDeleteOwner, conn))
                {
                    cmd.Parameters.AddWithValue("@id", petId);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
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




