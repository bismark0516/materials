using EmployeeProjects.Exceptions;
using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace EmployeeProjects.DAO
{
    public class ProjectSqlDao : IProjectDao
    {
        private readonly string connectionString;

        public ProjectSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Project GetProjectById(int projectId)
        {
            Project project = null;
            string sql = "SELECT project_id, name, from_date, to_date FROM project WHERE project_id = @project_id;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@project_id", projectId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        project = MapRowToProject(reader);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw new DaoException(ex.Message);
            }
            return project;
        }

        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            string sql = "SELECT project_id, name, from_date, to_date FROM project;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Project project = MapRowToProject(reader);
                        projects.Add(project);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }

            return projects;
        }

        public Project CreateProject(Project newProject)
        {
            Project project = new Project();
            //Project result = null;
            //Project project = null;

            string sql = "INSERT INTO project (name, from_date, to_date) " +
                         "OUTPUT INSERTED.project_id VALUES (@name, @from_date, @to_date);";

            try
            {
                int newProjectId;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", newProject.Name);
                    cmd.Parameters.AddWithValue("@from_date", newProject.FromDate);
                    cmd.Parameters.AddWithValue("@to_date", newProject.ToDate);


                    newProjectId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                newProject = GetProjectById(newProjectId);
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }

            return newProject;
        }

        public void LinkProjectEmployee(int projectId, int employeeId)
        {
            Project project = new Project();
            int numberOfRows = 0;

            string sql = "INSERT INTO project_employee" +
                "(project_id, employee_id)" +
                "VALUES ( @project_id,@employee_id) ";
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@project_id", projectId);
                    cmd.Parameters.AddWithValue("@employee_id", employeeId);

                    numberOfRows = cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {

                throw new DaoException(ex.Message);
            }

        }

        public void UnlinkProjectEmployee(int projectId, int employeeId)
        {
            Project project = new Project();
            int numberOfRows = 0;

            string sql = "DELETE FROM project_employee " +
                "WHERE (project_id = @project_id AND employee_id  = @employee_id) ";
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@project_id", projectId);
                    cmd.Parameters.AddWithValue("@employee_id", employeeId);

                    numberOfRows = cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {

                throw new DaoException(ex.Message);
            }

        }//department_id, first_name, last_name, birth_date, hire_date

        public Project UpdateProject(Project project)
        {
            Project updatedProject = new Project();

            string sql = "UPDATE project SET name = @name, from_date = @from_date, to_date = @to_date WHERE project_id = @project_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", project.Name);
                    cmd.Parameters.AddWithValue("@from_date", project.FromDate);
                    cmd.Parameters.AddWithValue("@to_date", project.ToDate);
                    cmd.Parameters.AddWithValue("@project_id", project.ProjectId);

                    int numberOfRows = cmd.ExecuteNonQuery();
                    if (numberOfRows == 0)
                    {
                        return null;
                    }
                }
                updatedProject = GetProjectById(project.ProjectId);
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }

            return updatedProject;
        }

        public int DeleteProjectById(int projectId)
        {
            int numberOfRows = 0;
            string sql2 = "DELETE FROM project_employee WHERE project_employee.project_id = @project_id;";
            string sql = "DELETE FROM project WHERE project_id = @project_id;";
            string sql3 = "DELETE FROM employee WHERE employee_id = @project_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    cmd2.Parameters.AddWithValue("@project_id", projectId);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    cmd3.Parameters.AddWithValue("@project_id", projectId);
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@project_id", projectId);
                    numberOfRows = cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {
                throw new DaoException(ex.Message);
            }
            return numberOfRows;
        }

        private Project MapRowToProject(SqlDataReader reader)
        {
            Project project = new Project();
            project.ProjectId = Convert.ToInt32(reader["project_id"]);
            project.Name = Convert.ToString(reader["name"]);
            if (reader["from_date"] is DBNull)
            {
                project.FromDate = null;
            }
            else
            {
                project.FromDate = Convert.ToDateTime(reader["from_date"]);
            }
            if (reader["to_date"] is DBNull)
            {
                project.ToDate = null;
            }
            else
            {
                project.ToDate = Convert.ToDateTime(reader["to_date"]);
            }

            return project;
        }
    }
}
