using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using DTO;

namespace DAO
{
    public class BanCafeDAO
    {

        DatabaseConnection conn;

        public BanCafeDAO()
        {
            conn = new DatabaseConnection();
        }
        public List<BanCafeDTO> GetAllTables()
        {
            var list = new List<BanCafeDTO>();
            conn.OpenConnection();
            string query = "SELECT * FROM BanCafe";
            SqlCommand command = new SqlCommand(query, conn.GetConnection());
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new BanCafeDTO
                {
                    IdBan = reader.GetInt32(0),
                    TenBan = reader.GetString(1),
                    TrangThai = reader.GetString(2)
                });
            }

            return list;
        }

        public void UpdateTableStatus(int id_Ban, string status)
        {
            string query = "UPDATE BanCafe SET TrangThai = @TrangThai WHERE id_Ban = @id_Ban";
                conn.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
                cmd.Parameters.AddWithValue("@TrangThai", status);
                cmd.Parameters.AddWithValue("@id_Ban", id_Ban);
                cmd.ExecuteNonQuery();
            }
        }
    }
