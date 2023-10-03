using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        public string EmployerRegister(EmployerModel emp,HttpPostedFileBase logoUpload)
        {
            try
            {
                connection();
                using (BinaryReader binaryReader =new BinaryReader(logoUpload.InputStream))
                {
                    emp.CompanyLogo = binaryReader.ReadBytes(logoUpload.ContentLength);
                }
                SqlCommand com = new SqlCommand("SP_CreateEmployer", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@CompanyName", emp.CompanyName);
                com.Parameters.AddWithValue("@OfficialEmail", emp.OfficialEmail);
                com.Parameters.AddWithValue("@ContactEmail", emp.ContactEmail);
                com.Parameters.AddWithValue("@ContactPhone", emp.ContactPhone);
                com.Parameters.AddWithValue("@Website", emp.Website);
                com.Parameters.AddWithValue("@Name", emp.Name);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                com.Parameters.AddWithValue("@CompanyLogo", emp.CompanyLogo);

                con.Open();
                int i = com.ExecuteNonQuery();
                return "Registered";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally { con.Close(); }
        }
        public int EmployerLogin(String username, String password)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_EmployerLogin", con);
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
            catch (Exception)
            {
                return 0;
            }
            finally { con.Close(); }
        }
    }
}