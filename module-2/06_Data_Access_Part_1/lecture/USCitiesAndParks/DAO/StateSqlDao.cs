﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class StateSqlDao : IStateDao
    {
        private readonly string connectionString;

        public StateSqlDao(string connString)
        {
            connectionString = connString;
        }

        public State GetStateByAbbreviation(string stateAbbreviation)
        {
            State state = null;

            string sql = "SELECT state_abbreviation, state_name FROM state WHERE state_abbreviation = @state_abbreviation;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    state = MapRowToState(reader);
                }
            }

            return state;
        }

        public State GetStateByCapital(int cityId)
        {
            State state = null;

            string sql = "SELECT state_abbreviation, state_name FROM state WHERE capital = @city_id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@city_id", cityId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    state = MapRowToState(reader);
                }
            }

            return state;
        }

        public IList<State> GetStates()
        {
            IList<State> states = new List<State>();

            string sql = "SELECT state_abbreviation, state_name FROM state;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    State state = MapRowToState(reader);
                    states.Add(state);
                }
            }

            return states;
        }

        private State MapRowToState(SqlDataReader reader)
        {
            State state = new State();
            state.StateAbbreviation = Convert.ToString(reader["state_abbreviation"]);
            state.StateName = Convert.ToString(reader["state_name"]);

            return state;
        }

    }
}
