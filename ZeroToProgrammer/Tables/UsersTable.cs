using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;

namespace ZeroToProgrammer.Tables
{
    public class UsersTable
    {
        private static readonly string Conn_String = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static void Add(string user_name, string password_hash, string email,
                               string first_name = null, string last_name = null, string age = null)
        {
            using (SqlConnection conn = new SqlConnection(Conn_String))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    string.Format("INSERT INTO Users (user_name, password, email, first_name, last_name, age, last_login)" +
                                   "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                   user_name, password_hash, email, first_name, last_name, age, DateTime.Now), conn);

                cmd.ExecuteNonQuery();

            }
        }

        public static DataTable Get_User(string user_name)
        {

            using (SqlConnection conn = new SqlConnection(Conn_String))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT user_name, password, first_name, last_login FROM Users WHERE user_name = '" + user_name + "'", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable users = new DataTable();
                    users.Load(reader);
                    return users;
                }
            }

        }

        public static DataTable Get_User_Names()
        {

            using (SqlConnection conn = new SqlConnection(Conn_String))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT user_name FROM Users", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable users = new DataTable();
                    users.Load(reader);
                    return users;
                }
            }

        }

        public static void Update_Last_Login(string user_name)
        {

            using (SqlConnection conn = new SqlConnection(Conn_String))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Users SET last_login='" + DateTime.Now + "' WHERE user_name='" + user_name + "'", conn);

                cmd.ExecuteNonQuery();

            }

        }
    }
}