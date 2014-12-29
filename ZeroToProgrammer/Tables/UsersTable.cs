using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ZeroToProgrammer.Tables
{
    public class UsersTable
    {
        private static readonly string Conn_String = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static void Add(string user_name, string password, string email,
                               string first_name = null, string last_name = null, string age = null)
        {
            using (SqlConnection conn = new SqlConnection(Conn_String))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    string.Format("INSERT INTO Users (user_name, password, email, first_name, last_name, age)" +
                                   "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                                   user_name, password, email, first_name, last_name, age), conn);

                cmd.ExecuteNonQuery();

            }
        }

        public static DataTable Get_Users()
        {
            using (SqlConnection conn = new SqlConnection(Conn_String))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT user_name, password FROM Users", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable users = new DataTable();
                    users.Load(reader);
                    return users;
                }

            }
        }
    }
}