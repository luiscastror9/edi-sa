using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace Intranet.Handlers
{
    /// <summary>
    /// Summary description for PersonalHandler
    /// </summary>
    public class PersonalHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string searchTerm = context.Request["search"];

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("Buscar_Personal_SEL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Buscar", SqlDbType.NVarChar, 50).Value = searchTerm;
            cmd.Connection = con;

            SqlDataReader dr = cmd.ExecuteReader();

            List<string> list = new List<string>();
            while (dr.Read())
            {
                var personal = dr["Apellido"].ToString().Trim();
                personal += ", " + dr["Nombres"].ToString().Trim();
                list.Add(personal);
            }
            con.Close();

            var result = new
            {
                personal = list
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(list));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}