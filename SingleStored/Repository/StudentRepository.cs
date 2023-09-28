using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using SingleStored.Models;
using System.IO;

namespace SingleStored.Repository
{
    public class StudentRepository

    {
       private SqlConnection con;

        /// <summary>
        /// To establish connection between application and server
        /// </summary>
       private void  connection()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            con =new SqlConnection(connectionstring);
        }

        /// <summary>
        /// To add student details to database
        /// </summary>
        /// <param name="student">Student Model</param>
        /// <param name="imageUpload">Student image </param>
        /// <returns></returns>
        public string AddStudent(StudentModel student,HttpPostedFileBase imageUpload)
        {
            try
            {
                connection();
                using (var binaryReader =new BinaryReader(imageUpload.InputStream))
                {
                    student.Image = binaryReader.ReadBytes(imageUpload.ContentLength);
                }
                SqlCommand com = new SqlCommand("SP_Student", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Operation", "INSERT");
                com.Parameters.AddWithValue("@FirstName", student.FirstName);
                com.Parameters.AddWithValue("@LastName", student.LastName);
                com.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                com.Parameters.AddWithValue("@Address", student.Address);
                com.Parameters.AddWithValue("@Email", student.Email);
                com.Parameters.AddWithValue("@Image", student.Image);

                con.Open();

                int i = com.ExecuteNonQuery();
                return "Student details addded successfully ";
            }
            catch (Exception ex )
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> student = new List<StudentModel>();
            connection();
            SqlCommand com = new SqlCommand("SP_Student", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Operation", "DISPLAY");
            DataTable dt = new DataTable();

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                student.Add(new StudentModel()
                {
                    StudentId = Convert.ToInt32(dr["StudentID"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]).Date,
                    Address = Convert.ToString(dr["Address"]),
                    Email = Convert.ToString(dr["Email"]),
                    Image = (byte[])dr["Image"]
                });
            }
            con.Close();
            return student; 
        }

        public string UpdateStudent(StudentModel student, HttpPostedFileBase imageUpload)
        {
            try
            {
                connection();
                if (imageUpload != null  && imageUpload.ContentLength >0 )
                {
                    using (var binaryReder = new BinaryReader(imageUpload.InputStream))
                    {
                        student.Image = binaryReder.ReadBytes(imageUpload.ContentLength);
                    }
                }
                else
                {
                    var OldData = GetAllStudents().Find(stud => stud.StudentId == student.StudentId);
                    student.Image = OldData.Image;
                }
                SqlCommand com = new SqlCommand("SP_Student", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Operation", "UPDATE");
                com.Parameters.AddWithValue("@StudentId", student.StudentId);
                com.Parameters.AddWithValue("@FirstName", student.FirstName);
                com.Parameters.AddWithValue("@LastName", student.LastName);
                com.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                com.Parameters.AddWithValue("@Address", student.Address);
                com.Parameters.AddWithValue("@Email", student.Email);
                com.Parameters.AddWithValue("@Image", student.Image);
                con.Open();
                int i = com.ExecuteNonQuery();
                return "Student details updated successfully ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DeleteStudent(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("SP_Student", con);
            com.CommandType= CommandType.StoredProcedure;   
            com.Parameters.AddWithValue("@Operation", "DELETE");
            com.Parameters.AddWithValue("@StudentId", id);
            con.Open();
            int i =com.ExecuteNonQuery();
            con.Close();
            return i > 0;
        }
    }
}