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
    }
}