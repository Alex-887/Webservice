using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentDB : IStudentDB
    {
        private string connectionString = null;
        public StudentDB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DemoDB"].ConnectionString;
        }


        public Student GetStudentById(int id)
        {
            Student result = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Student where Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new Student();

                            result.Id = (int)dr["Id"];
                            result.Username = (string)dr["Username"];
                            result.Balance = (decimal)dr["Balance"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public void ChargeAccount(int id, decimal balance)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE STUDENT SET Balance = @balance WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@balance", balance);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) ;

                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int AddStudent(Student student)
        {

            int Id = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    String query = "INSERT INTO Student(Username,Balance) values(@Username,@Balance); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Username", student.Username);
                    cmd.Parameters.AddWithValue("@Balance", student.Balance);
                    cn.Open();
                    student.Id = Convert.ToInt32(cmd.ExecuteScalar());

                    Id = student.Id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Id;
        }

        public Student GetStudentByUsername(string Username)
        {
            Student result = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM STUDENT WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new Student();

                            result.Id = (int)dr["Id"];
                            result.Username = (string)dr["Username"];
                            result.Balance = (decimal)dr["Balance"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

       
    }
}
