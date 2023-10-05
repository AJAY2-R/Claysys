using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace JobPortal.Repository
{
    public class EmployerRepository
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
        /// Employer registration
        /// </summary>
        /// <param name="emp">Employe instance</param>
        /// <param name="logoUpload">Company logo </param>
        /// <returns></returns>
        public bool EmployerRegister(EmployerModel emp, HttpPostedFileBase logoUpload)
        {
            try
            {
                connection();
                using (BinaryReader binaryReader = new BinaryReader(logoUpload.InputStream))
                {
                    emp.CompanyLogo = binaryReader.ReadBytes(logoUpload.ContentLength);
                }
                emp.SetPassword(emp.Password);
                SqlCommand com = new SqlCommand("SP_CreateEmployer", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@CompanyName", emp.CompanyName);
                com.Parameters.AddWithValue("@OfficialEmail", emp.OfficialEmail);
                com.Parameters.AddWithValue("@Email", emp.Email);
                com.Parameters.AddWithValue("@ContactPhone", emp.ContactPhone);
                com.Parameters.AddWithValue("@Website", emp.Website);
                com.Parameters.AddWithValue("@Name", emp.Name);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                com.Parameters.AddWithValue("@CompanyLogo", emp.CompanyLogo);
                com.Parameters.AddWithValue("@Password", emp.Password);
                con.Open();
                int i = com.ExecuteNonQuery();
                return i > 0;
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// Employer login 
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool EmployerLogin(string email, string password)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_EmployerLogin", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Email", email);
                con.Open();
                string res = Convert.ToString(com.ExecuteScalar());
                return BCrypt.Net.BCrypt.Verify(password, res);
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// Details of all employer 
        /// </summary>
        /// <returns></returns>
        public List<EmployerModel> Employers()
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_ReadEmployer", con);
                List<EmployerModel> employers = new List<EmployerModel>();
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    employers.Add(new EmployerModel()
                    {
                        EmployerID = Convert.ToInt32(dr["EmployerID"]),
                        CompanyName = Convert.ToString(dr["CompanyName"]),
                        OfficialEmail = Convert.ToString(dr["OfficialEmail"]),
                        Email = Convert.ToString(dr["Email"]),
                        ContactPhone = Convert.ToString(dr["ContactPhone"]),
                        Website = Convert.ToString(dr["Website"]),
                        Name = Convert.ToString(dr["Name"]),
                        Designation = Convert.ToString(dr["Designation"]),
                        CompanyLogo = (byte[])dr["CompanyLogo"],
                        Status = Convert.ToString(dr["Status"])
                    });
                }

                return employers;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Add Job vaccancy
        /// </summary>
        /// <param name="obj">Job vaccency object</param>
        /// <param name="employerId">Emplyer who post vaccency </param>
        /// <returns></returns>
        public bool AddJobVacancy(JobVacancy obj, int employerId)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_CreateJobVacancy", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmployerID", employerId);
                com.Parameters.AddWithValue("@JobTitle", obj.JobTitle);
                com.Parameters.AddWithValue("@Description", obj.Description);
                com.Parameters.AddWithValue("@CategoryID", obj.CategoryID);
                com.Parameters.AddWithValue("@Location", obj.Location);
                com.Parameters.AddWithValue("@Salary", obj.Salary);
                com.Parameters.AddWithValue("@EmploymentType", obj.EmploymentType);
                com.Parameters.AddWithValue("@ApplicationDeadline", obj.ApplicationDeadline);
                con.Open();
                int i = com.ExecuteNonQuery();
                return i > 0;
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// Approve job application
        /// </summary>
        /// <param name="id">Application id</param>
        /// <returns></returns>
        public bool JobApplicationApprove(int id)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_JobApplicationApprove", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ApplicationId", id);

                con.Open();
                int i = com.ExecuteNonQuery();
                return i >= 0;
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// JobApplication reject
        /// </summary>
        /// <param name="id"> Employer id</param>
        /// <returns></returns>
        public bool JobApplicationReject(int id)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_JobApplicationReject", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ApplicationId", id);
                con.Open();
                int i = com.ExecuteNonQuery();
                return i >= 0;
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// Display job application for a particular job
        /// </summary>
        /// <param name="JobId">Job id</param>
        /// <returns></returns>
        public List<JobApplication> GetJobApplications(int JobId)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_ReadJobApplication", con);
                List<JobApplication> jobApplications = new List<JobApplication>();
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@JobId", JobId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    jobApplications.Add(new JobApplication()
                    {
                        JobApplicationID = Convert.ToInt32(dr["ApplicationID"]),
                        JobId = Convert.ToInt32(dr["JobId"]),
                        SeekerId = Convert.ToInt32(dr["SeekerID"]),
                        ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]),
                        Status = Convert.ToString(dr["Status"])
                    });
                }
                return jobApplications;
            }finally { con.Close(); }
        }
    }
}