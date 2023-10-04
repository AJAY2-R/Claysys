using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace JobPortal.Repository
{
    public class AdminRepository
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
        /// Admin login process
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public bool AdminLogin(string username,string password)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_AdminLogin", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Username", username);
                com.Parameters.AddWithValue("@Password",password);
                con.Open();
                int res = Convert.ToInt32(com.ExecuteScalar());
                return res > 0;
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// Insert skills to the database
        /// </summary>
        /// <param name="obj">Skills model instance</param>
        /// <returns></returns>
        public bool AddSkill(Skills obj)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_CreateSkill", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@SkillName", obj.SkillName);
                con.Open();
                int i = com.ExecuteNonQuery();
                return i > 0;
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// Edit skill
        /// </summary>
        /// <param name="id">Skill id</param>
        /// <returns></returns>
        public bool EditSkill(Skills obj,int id)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_UpdateSkill", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@SkillName", obj.SkillName);
                com.Parameters.AddWithValue("@SkillId", id);
                con.Open();
                int i = com.ExecuteNonQuery();
                return i > 0;
            }
            finally { con.Close(); }
        }
        /// <summary>
        /// Insert category to database
        /// </summary>
        /// <param name="cat">Category instance</param>
        /// <returns></returns>
        public bool AddCategory(Category cat)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("SP_CreateCategory", con);
                com.Parameters.AddWithValue("@CategoryName", cat.CategoryName);
                com.CommandType = CommandType.StoredProcedure;

                con.Open();
                int i = com.ExecuteNonQuery();
                return i > 0;
            }
            finally { con.Close(); }
        }
    }

}