using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using StudentMVC.Models;

namespace StudentMVC.Repository
{
    public class StudentRepository
    {
        private SqlConnection con;

        //To establish connection between server and the application
        private void connection()
        {
            string conn = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(conn);

        }
        /// <summary>
        /// Insert the student details to database
        /// </summary>
        /// <param name="obj"> Student Model instance</param>
        /// <returns></returns>
        public bool AddStudent(StudentModel obj)
        {
            try {
                connection();
                SqlCommand com = new SqlCommand("SP_CreateStudent", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FirstName", obj.FirstName);
                com.Parameters.AddWithValue("@LastName", obj.LastName);
                com.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);
                com.Parameters.AddWithValue("@Address", obj.Address);
                com.Parameters.AddWithValue("@Email", obj.Email);
                com.Parameters.AddWithValue("@Image", obj.Image);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
            }catch (Exception )
            {
                return false;
            }
            finally { con.Close(); }
        }

        /// <summary>
        /// Display all the students
        /// </summary>
        /// <returns></returns>
        public List<StudentModel> GetAllStudents()
        {

            connection();
            List<StudentModel  > studentList = new List<StudentModel>();

            SqlCommand com = new SqlCommand("SP_GetAllStudents", con); 
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            { 
                studentList.Add(
                    new StudentModel
                    {
                        StudentId = Convert.ToInt32(dr["StudentID"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]).Date,
                        Address = Convert.ToString(dr["Address"]),
                        Email = Convert.ToString(dr["Email"]),
                        ImageBase64 = Convert.ToBase64String((byte[])dr["Image"])
                    });
            }

            return studentList;
        }
        /// <summary>
        /// Update student details
        /// </summary>
        /// <param name="obj">Student model instance</param>
        /// <returns></returns>
        public bool UpdateStudent(StudentModel obj,int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("SP_UpdateStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", id);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@Email", obj.Email);

            string sqlQuery = cmd.CommandText;

            // Log the SQL query to the console
            Debug.WriteLine("Generated SQL Query:");
            Debug.WriteLine(sqlQuery);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Method for delete student details from database
        /// </summary>
        /// <param name="id"> Student id</param>
        /// <returns></returns>
        public bool DeleteStudent(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("SP_DeleteStudent", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", id);
            con.Open();
            int i= cmd.ExecuteNonQuery();
            con.Close();
            return i >= 1;
        }
    }
}