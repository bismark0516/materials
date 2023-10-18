using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Movies.DAO
{
    public class MovieSqlDao : IMovieDao
    {
        private readonly string connectionString;

        public MovieSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Movie GetMovieById(int id)
        {
            Movie movie = null;
            string sql = "SELECT movie.movie_id " +
            ",title " +
            ",tagline " +
            ",poster_path " +
            ",home_page " +
            ",release_date " +
             ",length_minutes " +
            ",director_id " +
            ",collection_id " +
            " FROM movie " +
            " WHERE movie_id = @movie_id ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@movie_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        Movie movies = new Movie();
                        movies.Id = Convert.ToInt32(reader["movie_id"]);
                        movies.Title = Convert.ToString(reader["title"]);
                        movies.Tagline = Convert.ToString(reader["tagline"]);
                        movies.PosterPath = Convert.ToString(reader["poster_path"]);
                        movies.HomePage = SqlUtil.NullableString(reader["home_page"]);
                        movies.ReleaseDate = Convert.ToDateTime(reader["release_date"]);
                        movies.LengthMinutes = Convert.ToInt32(reader["length_minutes"]);
                        movies.DirectorId = Convert.ToInt32(reader["director_id"]);
                        movies.CollectionId = SqlUtil.NullableInt(reader["collection_id"]);
                        return movies;
                    }
                }
            }
            return movie;
        }

        public List<Movie> GetMovies()
        {

            string sql = "SELECT * FROM movie";
            List<Movie> collection = new List<Movie>();
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
                            Movie temp = new Movie();
                            temp.Id = Convert.ToInt32(reader["movie_id"]);
                            temp.Title = Convert.ToString(reader["title"]);
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

        public List<Movie> GetMoviesByDirectorNameAndBetweenYears(string directorName, int startYear, int endYear, bool useWildCard)
        {

            List<Movie> movies = new List<Movie>();

            DateTime startDate = new DateTime(startYear, 01, 01);
            DateTime endDate = new DateTime(endYear, 12, 31);
            string sql = "SELECT director_id " +
           ",release_date " +
           ",person_name " +
           "FROM movie " +
           "JOIN person ON person.person_id = movie.director_id " +
           "WHERE release_date BETWEEN  @startYear AND @endYear";
            //create new instance of datetime startDate and endDate 

            if (useWildCard)
            {
                directorName = "%" + directorName + "%";
                sql += " AND person_name LIKE @person_name;";
            }
            else
            {
                sql += " AND person_name = @person_name;";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@person_name", directorName);
                    cmd.Parameters.AddWithValue("@startYear", startDate);
                    cmd.Parameters.AddWithValue("@endYear", endDate);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Movie temp = new Movie();
                        temp.DirectorId = Convert.ToInt32(reader["director_id"]);
                        temp.ReleaseDate = SqlUtil.NullableDateTime(reader["release_date"]);
                        

                        movies.Add(temp);

                    }
                }
            }
            return movies;
        }

        public List<Movie> GetMoviesByTitle(string title, bool useWildCard)
        {

            List<Movie> movie = new List<Movie>();
            string sql = "SELECT title FROM movie WHERE title ";
            if (useWildCard)
            {
                title = "%" + title + "%";
                sql += "LIKE @title;";
            }
            else
            {
                sql += "= @title;";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Movie temp = new Movie();
                        temp.Title = Convert.ToString(reader["title"]);
                        movie.Add(temp);
                    }
                }
            }
            return movie;
        }
    }
}
