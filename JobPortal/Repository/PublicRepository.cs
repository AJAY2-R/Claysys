using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Helpers;
using System.Web.Mvc;

namespace JobPortal.Repository
{

    public class PublicRepository
    {
        /// <summary>
        /// Connection veriable
        /// </summary>
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
        /// Display all the skills
        /// </summary>
        public List<Skills> DisplaySkills()
        {
            List<Skills> skill = new List<Skills>();
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand("SP_ReadSkills",con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da =new SqlDataAdapter(cmd);
                DataTable dt =new DataTable();
                con.Open();
                da.Fill(dt);
                foreach(DataRow dr in  dt.Rows) {
                    skill.Add(new Skills()
                    {
                        SkillId = Convert.ToInt32(dr["SkillID"]),
                        SkillName = Convert.ToString(dr["SkillName"])
                    }); 
                }
                return skill;
            }
            finally { con.Close(); }
        }

        /// <summary>
        /// Display Job vacancy list
        /// </summary>
        /// <returns></returns>
        public List<JobVacancy> GetJobVacancies()
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_ReadJobVacancy", con);
                List<JobVacancy> jobVacancies = new List<JobVacancy>();
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    jobVacancies.Add(new JobVacancy()
                    {
                        VacancyID = Convert.ToInt32(dr["VacancyID"]),
                        EmployerID = Convert.ToInt32(dr["EmployerID"]),
                        JobTitle = Convert.ToString(dr["JobTitle"]),
                        Description = Convert.ToString(dr["Description"]),
                        CategoryID = Convert.ToInt32(dr["CategoryID"]),
                        Location = Convert.ToString(dr["Location"]),
                        Salary = Convert.ToDecimal(dr["Salary"]),
                        EmploymentType = Convert.ToString(dr["EmploymentType"]),
                        ApplicationDeadline = Convert.ToDateTime(dr["ApplicationDeadline"]),
                        IsPublished = Convert.ToBoolean(dr["IsPublished"])
                    });
                }

                return jobVacancies;
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// Display categories
        /// </summary>
        /// <returns></returns>
        public List<Category> DisplayCategories()
        {
            List<Category> skill = new List<Category>();
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand("SP_ReadCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    skill.Add(new Category()
                    {
                        CategoryId = Convert.ToInt32(dr["CategoryID"]),
                        CategoryName = Convert.ToString(dr["CategoryName"])
                    });
                }
                return skill;
            }
            finally { con.Close(); }
        }

        public List<JobDetails> GetJobDetails()
        {
            try
            {
            connection();
            SqlCommand com = new SqlCommand("SP_ReadJobDetails", con);
            List<JobDetails> jobDetails = new List<JobDetails>();
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                jobDetails.Add(new JobDetails()
                {
                    JobID = Convert.ToInt32(dr["VacancyID"]),
                    EmployerID = Convert.ToInt32(dr["EmployerID"]),
                    JobTitle = Convert.ToString(dr["JobTitle"]),
                    Description = Convert.ToString(dr["Description"]),
                    CategoryName = Convert.ToString(dr["Category"]),
                    Location = Convert.ToString(dr["Location"]),
                    Salary = Convert.ToDecimal(dr["Salary"]),
                    EmploymentType = Convert.ToString(dr["EmploymentType"]),
                    ApplicationDeadline = Convert.ToDateTime(dr["ApplicationDeadline"]),
                    CompanyName = Convert.ToString(dr["CompanyName"]),
                    OfficialEmail = Convert.ToString(dr["OfficialEmail"]),
                    Email = Convert.ToString(dr["Email"]),
                    ContactPhone = Convert.ToString(dr["ContactPhone"]),
                    Website = Convert.ToString(dr["Website"]),
                    EmployerName = Convert.ToString(dr["EmployerName"]),
                    Designation = Convert.ToString(dr["Designation"]),
                    CompanyLogo = (byte[])dr["CompanyLogo"],

                });
            }

            return jobDetails;
            }
            finally { con.Close(); }
        }
    }
}