using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Movies.DAO
{
    public class PersonSqlDao : IPersonDao
    {
        private readonly string connectionString;

        public PersonSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Person GetPersonById(int id)
        {
            Person person = new Person();

            string sql = "SELECT person_id, " +
                "person_name , " +
                "birthday, " +
                "deathday, " +
                "biography, " +
                "profile_path, " +
                "home_page " +
                "FROM person " +
                "WHERE person_id = @person_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@person_id", id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read() == true)
                        {
                            
                            person.Id = Convert.ToInt32(reader["person_id"]);
                            person.Name = Convert.ToString(reader["person_name"]);
                            person.Birthday = SqlUtil.NullableDateTime(reader["birthday"]);
                            person.DeathDate = SqlUtil.NullableDateTime(reader["deathday"]);
                            person.Biography = SqlUtil.NullableString(reader["biography"]);
                            person.ProfilePath = Convert.ToString(reader["profile_path"]);
                            person.HomePage = SqlUtil.NullableString(reader["home_page"]);
                            return person;
                        }
                    }
                }
                return null;
            }
            catch (SqlException ex)
            {

            }
            return person;
        }

        public List<Person> GetPersons()
        {
            string sql = "SELECT * FROM person";
            List<Person> collection = new List<Person>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read() == true)
                        {
                            Person temp = new Person();
                            temp.Id = Convert.ToInt32(reader["person_id"]);
                            temp.Name = Convert.ToString(reader["person_name"]);
                            collection.Add(temp);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            return collection;
        }


        public List<Person> GetPersonsByCollectionName(string collectionName, bool useWildCard)
        {
            List<Person> person = new List<Person>();
            string sql = "SELECT collection_name " +
                "FROM movie " +
                "JOIN person ON movie.director_ID " +
                "JOIN [collection] ON movie.collection_id = [collection].collection_id" +
                "WHERE collection_name ";
            if (useWildCard)
            {
                collectionName = "%" + collectionName + "%";
                sql += "LIKE @collection_name;";
            }
            else
            {
                sql += "= @collection_name;";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@collection_name", collectionName);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Person temp = new Person();
                        temp.Name = Convert.ToString(reader["person_name"]);
                        temp.Id = Convert.ToInt32(reader["person_id"]);
                        temp.Birthday = SqlUtil.NullableDateTime(reader["birthday"]);
                        temp.DeathDate = SqlUtil.NullableDateTime(reader["deathday"]);
                        temp.Biography = SqlUtil.NullableString(reader["biography"]);
                        temp.ProfilePath = Convert.ToString(reader["profile_path"]);
                        temp.HomePage = SqlUtil.NullableString(reader["home_page"]);
                        person.Add(temp);
                    }
                }
            }
            return person;
        }

        public List<Person> GetPersonsByName(string name, bool useWildCard)
        {

            List<Person> person = new List<Person>();
            string sql = "SELECT person_id, person_name FROM person WHERE person_name ";
            if (useWildCard)
            {
                name = "%" + name + "%";
                sql += "LIKE @person_name;";
            }
            else
            {
                sql += "= @person_name;";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@person_name", name);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Person temp = new Person();
                        temp.Name = Convert.ToString(reader["person_name"]);
                        temp.Id = Convert.ToInt32(reader["person_id"]);
                        person.Add(temp);
                    }
                }
            }
            return person;
        }
    }
}

