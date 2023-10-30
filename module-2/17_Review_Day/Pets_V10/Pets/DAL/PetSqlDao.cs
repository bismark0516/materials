using PetInfo.DAL.Interfaces;
using PetInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace PetInfo.DAL
{
    public class PetSqlDao : IPetDao
    {
        private string connectionString = "";

        private string sqlListPets = "SELECT pet.id, pet.name, age, type, owner, owner.name as owner_name FROM pet " +
            "JOIN owner on owner.id = pet.owner;";
        private string sqlGetPet = "SELECT pet.id, pet.name, age, type, owner, owner.name as owner_name FROM pet " +
            "JOIN owner on owner.id = pet.owner " +
            "WHERE pet.id = @id;";
        private string sqlAddAPet = "INSERT INTO pet (name, age, type, owner) " +
            "OUTPUT INSERTED.id " +
            "VALUES (@name, @age, @type, @owner);";
        private string SqlUpdatePet = "UPDATE pet SET name=@name, age=@age, " +
            "type=@type, owner=@owner " +
            "WHERE id = @id";
        private string SqlDeletePet = "DELETE FROM pet WHERE id=@id;";


        public PetSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Pet> ListPets()
        {
            List<Pet> pets = new List<Pet>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlListPets, conn))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Pet pet = new Pet();
                            pet = MapRowToPet(reader);
                            pets.Add(pet);
                        }
                    }
                }
            }
            return pets;
        }

        public Pet GetPet(int petId)
        {
            Pet pet = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlGetPet, conn))
                {
                    cmd.Parameters.AddWithValue("@id", petId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pet = MapRowToPet(reader);
                        }
                    }
                }
            }
            return pet;
        }

        public Pet AddAPet(Pet newPet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlAddAPet, conn))
                {
                    cmd.Parameters.AddWithValue("@name", newPet.Name);
                    cmd.Parameters.AddWithValue("@age", newPet.Age);
                    cmd.Parameters.AddWithValue("@type", newPet.Type);
                    cmd.Parameters.AddWithValue("@owner", newPet.Owner);

                    newPet.Id = (int)cmd.ExecuteScalar();
                }
            }
            return newPet;
        }

        public Pet UpdatePet(Pet updatedPet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlUpdatePet, conn))
                {
                    cmd.Parameters.AddWithValue("@name", updatedPet.Name);
                    cmd.Parameters.AddWithValue("@age", updatedPet.Age);
                    cmd.Parameters.AddWithValue("@type", updatedPet.Type);
                    cmd.Parameters.AddWithValue("@id", updatedPet.Id);
                    cmd.Parameters.AddWithValue("@owner", updatedPet.Owner);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return updatedPet;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public bool DeleteAPet(int petId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlDeletePet, conn))
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

        private Pet MapRowToPet(SqlDataReader reader)
        {
            Pet pet = new Pet();
            pet.Id = Convert.ToInt32(reader["id"]);
            pet.Name = Convert.ToString(reader["name"]);
            pet.Age = Convert.ToInt32(reader["age"]);
            pet.Type = Convert.ToString(reader["type"]);
            pet.Owner = Convert.ToInt32(reader["owner"]);
            pet.OwnerName = Convert.ToString(reader["owner_name"]);
            return pet;
        }
    }
}




