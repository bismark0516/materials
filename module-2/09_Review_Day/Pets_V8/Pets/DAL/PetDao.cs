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
            return null;
        }

        public Pet UpdatePet(Pet newPet)
        {
            return null;
        }

        public bool DeletePet(int petId)
        {
            return false;
        }
    }
}
