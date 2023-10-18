using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class ParkSqlDao : IParkDao
    {
        private readonly string connectionString;
        private readonly string sqlGetParksByState =
            "SELECT park.park_id " +
            ",[park_name] " +
            ",[date_established] " +
            ",[area] " +
            ",[has_camping] " +
            "FROM[UnitedStates].[dbo].[park] " +
            "JOIN park_state ON park_state.park_id = park.park_id " +
            "WHERE state_abbreviation = @state_abbreviation ";

        public ParkSqlDao(string connString)
        {
            connectionString = connString;
        }

        public int GetParkCount()
        {
            return 0;
        }

        public DateTime GetOldestParkDate()
        {
            return DateTime.Now;
        }

        public decimal GetAverageParkArea()
        {
            return 0.0M;
        }

        public IList<string> GetParkNames()
        {
            return new List<string>();
        }

        public Park GetRandomPark()
        {
            return null;
        }

        public IList<Park> GetParksWithCamping()
        {
            return new List<Park>();
        }

        public Park GetParkById(int parkId)
        {
            return null;
        }



        public IList<Park> GetParksByState(string stateAbbreviation)
        {
            IList<Park> result = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlGetParksByState, conn))
                    {

                        cmd.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read() == true)
                        {
                            Park temp = new Park();
                            temp.ParkId = Convert.ToInt32(reader["park_id"]);
                            temp.ParkName = Convert.ToString(reader["park_name"]);
                            temp.Area = Convert.ToDecimal(reader["area"]);
                            result.Add(temp);
                        }




                    }

                }
            }
            catch (SqlException ex)
            {

            }





            return result;
        }

        public IList<Park> GetParksByName(string name, bool useWildCard)
        {
            return new List<Park>();
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            return new Park();
        }
    }
}
