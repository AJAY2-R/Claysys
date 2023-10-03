using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace JobPortal.Repository
{
    public class JobSeekerRepository
    {
        private SqlConnection con;

        /// <summary>
        /// To establish connection between server and the application
        /// </summary>
        private void connection()
        {
            string conn = ConfigurationManager.ConnectionStrings["mycon"].ToString();
            con = new SqlConnection(conn);

        }
        /// <summary>
        /// Register Job seeker 
        /// </summary>
        /// <param name="seeker">Job seeker model objct</param>
        /// <param name="imageUpload">Profile picture</param>
        /// <param name="resumeUpload">Resume</param>
        /// <returns></returns>
        public string JobSeekerRegiser(JobSeekerModel seeker,HttpPostedFileBase imageUpload, HttpPostedFileBase resumeUpload)
        {
            try
            {
                using (BinaryReader binaryReader = new BinaryReader(imageUpload.InputStream))
                {
                    seeker.Image = binaryReader.ReadBytes(imageUpload.ContentLength);
                }
                using (BinaryReader binaryReader = new BinaryReader(resumeUpload.InputStream))
                {
                    seeker.Resume = binaryReader.ReadBytes(resumeUpload.ContentLength);
                }
                connection();
                SqlCommand com = new SqlCommand("SP_CreateJobSeeker", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FirstName", seeker.FirstName);
                com.Parameters.AddWithValue("@LastName", seeker.LastName);
                com.Parameters.AddWithValue("BirthDate", seeker.Birthdate);
                com.Parameters.AddWithValue("Email", seeker.Email);
                com.Parameters.AddWithValue("@Gender", seeker.Gender);
                com.Parameters.AddWithValue("@PhoneNumber", seeker.PhoneNumber);
                com.Parameters.AddWithValue("Password", seeker.Password);
                com.Parameters.AddWithValue("@Experience", seeker.Experience);
                com.Parameters.AddWithValue("@Image", seeker.Image);
                com.Parameters.AddWithValue("@Resume", seeker.Resume);
                com.Parameters.AddWithValue("@State", seeker.State);
                com.Parameters.AddWithValue("@City", seeker.City);
                com.Parameters.AddWithValue("@Username", seeker.Username);
                com.Parameters.AddWithValue("@Address", seeker.Address);
                con.Open();
                int i = com.ExecuteNonQuery();
                return "Regsitered";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// Login method for 
        /// </summary>
        /// <param name="username">Username or Email</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public int JobSeekerLogin(String username,String password)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_JobSeekerLogin", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Username", username);
                com.Parameters.AddWithValue("@Password", password);
                con.Open();
                int seekerid = (int)com.ExecuteScalar();
                if (seekerid != 0)
                    return seekerid;
                else
                    return 0;
            }
            catch (Exception )
            {
                return 0;
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// Display the job seeker deatails
        /// </summary>
        /// <param name="id">Jobseeker id</param>
        /// <returns></returns>
        public List<JobSeekerModel> JobSeekers ()
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_ReadJobSeeker", con);
                List<JobSeekerModel> jobSeeker = new List<JobSeekerModel>();
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);

                foreach(DataRow dr in dt.Rows)
                {
                    jobSeeker.Add(new JobSeekerModel()
                    {
                        SeekerId = Convert.ToInt32(dr["SeekerID"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Birthdate = Convert.ToDateTime(dr["Birthdate"]).Date,
                        State = Convert.ToString(dr["State"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"]),
                        Email = Convert.ToString(dr["Email"]),
                        Image = (byte[])dr["ProfilePicture"],
                        Gender = Convert.ToString(dr["Gender"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        Experience = Convert.ToInt32(dr["Experience"])
                    }) ; 
                }
                return jobSeeker;
            }finally { con.Close(); }
        }
    }
}