using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace DAO
{
    public class DatabaseConnection
    {
        private SqlConnection connection;

        private string connectionString = @"Data Source=LAPTOP-SEICFSG7\SQLEXPRESS;Initial Catalog=QlyCafe;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


        public DatabaseConnection()
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Kết nối thành công!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
