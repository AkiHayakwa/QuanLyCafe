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
        public List<BanCafeDTO> GetAllBanCafe()
        {
            List<BanCafeDTO> banCafeList = new List<BanCafeDTO>();

            conn.OpenConnection();
            string query = "SELECT * FROM BanCafe";
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BanCafeDTO banCafe = new BanCafeDTO
                {
                    Id_Ban = Convert.ToInt32(reader["id_Ban"]),
                    TenBan = reader["TenBan"].ToString(),
                    TrangThai = reader["TrangThai"].ToString()
                };
                banCafeList.Add(banCafe);
            }

            return banCafeList;
        }
        public void UpdateTableStatus(int id_Ban, string status)
        {

            conn.OpenConnection();
            string query = "UPDATE BanCafe SET TrangThai = @TrangThai WHERE id_Ban = @Id_Ban";
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.Parameters.AddWithValue("@TrangThai", status);
            cmd.Parameters.AddWithValue("@Id_Ban", id_Ban);
            cmd.ExecuteNonQuery();
        }

        public List<BanCafeDTO> LayBanChuaCoHoaDon() { 
            List<BanCafeDTO> banCafeList = new List<BanCafeDTO>(); 
            try { 
                conn.OpenConnection(); 
                string query = @" SELECT * FROM BanCafe bc WHERE bc.id_Ban NOT IN (SELECT DISTINCT hd.id_Ban FROM HoaDon hd)"; 
                SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
                SqlDataReader reader = cmd.ExecuteReader(); 
                while (reader.Read()) {
                    BanCafeDTO banCafe = new BanCafeDTO {
                        Id_Ban = Convert.ToInt32(reader["id_Ban"]), 
                        TenBan = reader["TenBan"].ToString(),
                        TrangThai = reader["TrangThai"].ToString() 
                    }; 
                    banCafeList.Add(banCafe); 
                }
                reader.Close(); 
            } catch (Exception ex) {
                throw new Exception("Lỗi khi lấy danh sách bàn chưa có hóa đơn: " + ex.Message); 
            } finally { 
                conn.CloseConnection(); 
            } return banCafeList; 
        }
    }
}
