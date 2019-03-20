using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PStorage.View;

namespace PStorage.Helper
{

    public static class DBHelper
    {
        private static MySqlConnection connection;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;


        /// <summary>
        /// подключение к БД.
        /// </summary>
        public static void EstablishConnection()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";
                builder.UserID = "root";
                builder.Password = "rootpass";
                builder.Database = "dbloginpage";
                builder.SslMode = MySqlSslMode.None;
                connection = new MySqlConnection(builder.ToString());
                MessageBox.Show("Database connection successfull", "Connection", MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("connection Failed");
            }
        }

        public static MySqlCommand RunQuery(string query, string username) 
        {
            try
            {
                if(connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                connection.Close();
            }
            return cmd;
        }
    }
}
