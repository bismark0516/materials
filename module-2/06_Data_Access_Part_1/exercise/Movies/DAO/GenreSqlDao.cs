using Movies.Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Movies.DAO
{
    public class GenreSqlDao : IGenreDao
    {
        private readonly string connectionString;

        public GenreSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Genre GetGenreById(int id)
        {
            Genre genre = null;
            string sql = "SELECT genre_id, genre_name FROM genre WHERE genre_id = @genre_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@genre_id", id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read() == true)
                        {
                            Genre temp = new Genre();
                            temp.Id = Convert.ToInt32(reader["genre_id"]);
                            temp.Name = Convert.ToString(reader["genre_name"]);
                            return temp;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            return genre;
        }

        public List<Genre> GetGenres()
        {
            string sql = "SELECT * FROM genre";
            List<Genre> collection = new List<Genre>();
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
                            Genre temp = new Genre();
                            temp.Id = Convert.ToInt32(reader["genre_id"]);
                            temp.Name = Convert.ToString(reader["genre_name"]);
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

        public List<Genre> GetGenresByName(string name, bool useWildCard)
        {

            List<Genre> genre = new List<Genre>();
            string sql = "SELECT genre_id, genre_name FROM genre WHERE genre_name ";
            if (useWildCard)
            {
                name = "%" + name + "%";
                sql += "LIKE @genre_name;";
            }
            else
            {
                sql += "= @genre_name;";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@genre_name", name);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Genre temp = new Genre();
                        temp.Name = Convert.ToString(reader["genre_name"]);
                        temp.Id = Convert.ToInt32(reader["genre_id"]);
                        genre.Add(temp);
                    }
                }
            }
            return genre;
        }
    }
}

