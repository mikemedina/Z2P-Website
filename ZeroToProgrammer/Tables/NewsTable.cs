using System;
using System.Data.SqlClient;
using System.Configuration;
namespace ZeroToProgrammer.Tables
{
    public static class NewsTable
    {
        private static readonly string Conn_String = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static void Add(string title, string content)
        {
            using (SqlConnection conn = new SqlConnection(Conn_String))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO NEWS (title, content) VALUES ('{0}', '{1}')", title, content), conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}