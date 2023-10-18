using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Movies.DAO
{
    public class CollectionSqlDao : ICollectionDao
    {
        private readonly string connectionString;
      

        public CollectionSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Collection GetCollectionById(int id)
        {
            Collection collection = null;
            string sql = "SELECT collection_id, collection_name FROM collection WHERE collection_id = @collection_id;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@collection_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        Collection temp = new Collection();
                        temp.Id = Convert.ToInt32(reader["collection_id"]);
                        temp.Name = Convert.ToString(reader["collection_name"]);
                        return temp;
                    }
                }
            }
            return collection;
        }

        public List<Collection> GetCollections()
        {
            string sql = "SELECT * FROM collection";
            List <Collection> collection = new List<Collection>();
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
                            Collection temp = new Collection();
                            temp.Id = Convert.ToInt32(reader["collection_id"]);
                            temp.Name = Convert.ToString(reader["collection_name"]);
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

        public List<Collection> GetCollectionsByName(string name, bool useWildCard)
        {
            List<Collection> collections = new List<Collection>();
            string sql = "SELECT collection_id, collection_name FROM collection WHERE collection_name ";
            if (useWildCard)
            {
                name = "%" + name + "%";
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
                    cmd.Parameters.AddWithValue("@collection_name", name);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Collection temp = new Collection();
                        temp.Name = Convert.ToString(reader["collection_name"]);
                        temp.Id = Convert.ToInt32(reader["collection_id"]);
                        collections.Add(temp);
                    }
                }
            }
            return collections;
        }
    }
    
}
