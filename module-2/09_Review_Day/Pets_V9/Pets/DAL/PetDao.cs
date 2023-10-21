using PetInfo.DAL.Interfaces;
using PetInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.ExceptionServices;

namespace PetInfo.DAL
{
    public class PetDao: IPetDao
    {
        private string connectionString;
        public PetDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Pet> ListPets()
        {
            List<Pet> pets = new List<Pet>();

            string sql = "SELECT id, name, age, type " +
                "FROM Pet;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Pet pet = new Pet();
                        pet.Id = Convert.ToInt32(reader["id"]);
                        pet.Name = Convert.ToString(reader["name"]);
                        pet.Age = Convert.ToInt32(reader["id"]);
                        pet.Type = Convert.ToString(reader["type"]);
                        pets.Add(pet);
                    }
                }
            }
            catch (SqlException ex)
            {
                //todo add logging here for exception
                pets = new List<Pet>();
            }
           
            return pets;
        }

        public Pet GetPet(int petId)
        {    
            return null;
        }

        public Pet AddPet(Pet newPet)
        {
           
            int pet_id = 0;

            string sql = "INSERT INTO Pet (name, age, type)" +
                " OUTPUT INSERTED.id" +
                " VALUES (@name, @age, @type);";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", newPet.Name);
                    cmd.Parameters.AddWithValue("@age", newPet.Age);
                    cmd.Parameters.AddWithValue("@type", newPet.Type);

                    pet_id = (int)cmd.ExecuteScalar();
                    newPet.Id = pet_id;
                }
            }
            catch (SqlException ex)
            {
                return newPet;
            }
            newPet.Id = pet_id;

            return newPet;
        }

        public Pet UpdatePet(Pet newPet)
        {
            string sql = "Update pet " +
                "SET name = @name, age = @age, type =@type " +
                "WHERE id =@id;";

            int numberOfRows = 0;
            Pet result = new Pet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", newPet.Id);
                    cmd.Parameters.AddWithValue("@name", newPet.Name);
                    cmd.Parameters.AddWithValue("@age", newPet.Age);
                    cmd.Parameters.AddWithValue("@type", newPet.Type);

                    result = newPet;

                    numberOfRows = cmd.ExecuteNonQuery();

                    
                }
            }
            catch (SqlException ex)
            {
                newPet = null;
            }
            if (numberOfRows == 0)
            {
               newPet = null;
            }

            return newPet;
        }

        public bool DeletePet(int petId)
        {
            bool result = false;
            string sql = "DELETE FROM Pet " +
                "WHERE id = @id ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", petId);
                    int count = cmd.ExecuteNonQuery();

                    if (count == 1)
                    {
                        result = true;
                    }
                }
            }
            catch (SqlException ex)
            { //todo add logging for SQL errors
                result = false;
            }
            return result;
        }
    }
}
