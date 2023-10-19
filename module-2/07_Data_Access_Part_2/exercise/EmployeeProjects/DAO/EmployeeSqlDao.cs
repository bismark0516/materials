using EmployeeProjects.Exceptions;
using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class EmployeeSqlDao : IEmployeeDao
    {
        private readonly string connectionString;

        public EmployeeSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            string sql = @"SELECT * FROM employee
                           WHERE employee_id = @employee_id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        employee = MapRowToEmployee(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }

            return employee;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string sql = @"SELECT employee_id, department_id, first_name, last_name, birth_date, hire_date FROM employee;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = MapRowToEmployee(reader);
                        employees.Add(employee);
                    }
                }
            }

            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }

            return employees;
        }

        public List<Employee> GetEmployeesByFirstNameLastName(string firstNameSearch, string lastNameSearch)
        {
            List<Employee> employees = new List<Employee>();
            string sql = @"SELECT employee_id, department_id, first_name, last_name, birth_date, hire_date FROM employee 
                           WHERE first_name LIKE @first_name AND last_name LIKE @last_name;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@first_name", "%" + firstNameSearch + "%");
                    cmd.Parameters.AddWithValue("@last_name", "%" + lastNameSearch + "%");

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = MapRowToEmployee(reader);
                        employees.Add(employee);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }
            return employees;
        }

        public List<Employee> GetEmployeesByProjectId(int projectId)
        {
            List<Employee> employees = new List<Employee>();
            string sql = @"SELECT e.employee_id, department_id, first_name, last_name, birth_date, hire_date FROM employee e 
                           JOIN project_employee pe ON e.employee_id = pe.employee_id 
                           WHERE pe.project_id = @project_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@project_id", projectId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = MapRowToEmployee(reader);
                        employees.Add(employee);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }

            return employees;
        }

        public List<Employee> GetEmployeesWithoutProjects()
        {
            List<Employee> employees = new List<Employee>();
            string sql = @"SELECT employee_id, department_id, first_name, last_name, birth_date, hire_date FROM employee 
                           WHERE employee_id NOT IN (SELECT employee_id FROM project_employee);";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = MapRowToEmployee(reader);
                        employees.Add(employee);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }

            return employees;
        }

        public Employee CreateEmployee(Employee employee)
        {

            string sql = "INSERT INTO employee (department_id, first_name, last_name, birth_date, hire_date) " +
                "OUTPUT INSERTED.employee_id" +
              " VALUES (@department_id, @first_name, @last_name, @birth_date, @hire_date)";

            try
            {
                int newEmployeeID;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@department_id", employee.DepartmentId);
                    cmd.Parameters.AddWithValue("@first_name", employee.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", employee.LastName);
                    cmd.Parameters.AddWithValue("@hire_date", employee.HireDate);
                    cmd.Parameters.AddWithValue("@birth_date", employee.BirthDate);

                    newEmployeeID = Convert.ToInt32(cmd.ExecuteScalar());
                    employee.EmployeeId = newEmployeeID;
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }
            return employee;
        }
        public Employee UpdateEmployee(Employee employee)
        {

            Employee updatedEmployee = new Employee();

            string sql = "UPDATE employee SET department_id = @department_id, first_name = @first_name, last_name = @last_name, birth_date = @birth_date, hire_date = @hire_date WHERE employee_id = @employee_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@department_id", employee.DepartmentId);
                    cmd.Parameters.AddWithValue("@first_name", employee.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", employee.LastName);
                    cmd.Parameters.AddWithValue("@hire_date", employee.HireDate);
                    cmd.Parameters.AddWithValue("@birth_date", employee.BirthDate);
                    cmd.Parameters.AddWithValue("employee_id", employee.EmployeeId);

                    int numberOfRows = cmd.ExecuteNonQuery();
                    if (numberOfRows == 0)
                    {
                        return null;
                    }
                }
                updatedEmployee = GetEmployeeById(employee.EmployeeId);
                   
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }

            return updatedEmployee;
        }

        public int DeleteEmployeeById(int id)
        {
            int numberOfRows = 0;
            string sql = "DELETE FROM project_employee WHERE project_employee.employee_id = @employee_id; ";
            string sql2 = "DELETE FROM employee WHERE employee_id = @employee_id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@employee_id", id);
                    numberOfRows = cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    cmd2.Parameters.AddWithValue("@employee_id", id);
                    cmd2.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }
            return numberOfRows; ;
        }

        public int DeleteEmployeesByDepartmentId(int departmentId)
        {
            int numberOfRows = 0;
            int numberOfR = 0;
            string sql = "DELETE FROM project_employee WHERE employee_id IN (SELECT employee_id FROM department WHERE department_id = @department_id);";
            string sql2 = "DELETE FROM employee WHERE department_id = @department_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@department_id", departmentId);
                        numberOfRows = cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd2 = new SqlCommand(sql2, conn))
                    {
                        cmd2.Parameters.AddWithValue("@department_id", departmentId);
                        numberOfR = cmd2.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }
            return numberOfR; ;
        }


        private Employee MapRowToEmployee(SqlDataReader reader)
        {
            Employee employee = new Employee();
            employee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
            employee.DepartmentId = Convert.ToInt32(reader["department_id"]);
            employee.FirstName = Convert.ToString(reader["first_name"]);
            employee.LastName = Convert.ToString(reader["last_name"]);
            employee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
            employee.HireDate = Convert.ToDateTime(reader["hire_date"]);

            return employee;
        }


    }
}
