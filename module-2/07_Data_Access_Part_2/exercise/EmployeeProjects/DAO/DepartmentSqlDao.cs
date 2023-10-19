using EmployeeProjects.Exceptions;
using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class DepartmentSqlDao : IDepartmentDao
    {
        private readonly string connectionString;

        public DepartmentSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Department GetDepartmentById(int departmentId)
        {

            Department department = null;

            string sql = @"SELECT department_id, name FROM department 
                           WHERE department_id = @department_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@department_id", ((object)departmentId ?? DBNull.Value));

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        department = MapRowToDepartment(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }
            return department;
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            string sql = "SELECT department_id, name FROM department;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Department department = MapRowToDepartment(reader);
                        departments.Add(department);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }
            return departments;
        }

        public Department CreateDepartment(Department department)
        {
            Department department1 = new Department();
            string sql = "INSERT INTO department (name) " +
              "OUTPUT INSERTED.department_id VALUES (@name);";

            try
            {
                int newDepartmentID;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", department.Name);

                    newDepartmentID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                department1 = GetDepartmentById(newDepartmentID);
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }

            return department1;
        }


        public Department UpdateDepartment(Department department)
        {
            Department department1 = new Department();

            string sql = "UPDATE department SET name = @name  WHERE department_id = @department_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", department.Name);
                    cmd.Parameters.AddWithValue("@department_id", department.DepartmentId);

                    int numberOfRows = cmd.ExecuteNonQuery();
                    if (numberOfRows == 0)
                    {
                        return null;
                    }
                }
                department1 = GetDepartmentById(department.DepartmentId);
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }
            return GetDepartmentById(department.DepartmentId);

        }

        public int DeleteDepartmentById(int id)
        {
            int numberofRows = 0;
            int numberOfR = 0;

            string sql = "DELETE FROM department WHERE department_id = @department_id;";
            string sql2 = "UPDATE employee SET department_id = 0 WHERE department_id = @department_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    cmd2.Parameters.AddWithValue("@department_id", id);
                    numberofRows = cmd2.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@department_id", id);

                    numberOfR = cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }
            return numberOfR;





        }
        private Department MapRowToDepartment(SqlDataReader reader)
        {
            Department department = new Department();
            department.DepartmentId = Convert.ToInt32(reader["department_id"]);
            department.Name = Convert.ToString(reader["name"]);

            return department;
        }
    }
}
