using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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

        public static DataTable Get_News()
        {
            using (SqlConnection conn = new SqlConnection(Conn_String))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT title, content, modified_date FROM News", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable news = new DataTable();
                    news.Load(reader);
                    return news;
                }

            }
        }
    }
}