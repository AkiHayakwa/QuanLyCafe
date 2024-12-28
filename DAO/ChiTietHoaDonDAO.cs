using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using DTO;

namespace DAO
{
    public class ChiTietHoaDonDAO
    {
        DatabaseConnection conn;

        public ChiTietHoaDonDAO()
        {
            conn = new DatabaseConnection();
        }

        public void AddInvoiceDetail(ChiTietHoaDonDTO chiTiet)
        {
            string query = "INSERT INTO ChiTietHoaDon (id_HoaDon, id_SanPham, SoLuong, GiaBan) VALUES (@id_HoaDon, @id_SanPham, @SoLuong, @GiaBan)";

            conn.OpenConnection();
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.Parameters.AddWithValue("@id_HoaDon", chiTiet.IdHoaDon);
            cmd.Parameters.AddWithValue("@id_SanPham", chiTiet.IdSanPham);
            cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
            cmd.Parameters.AddWithValue("@GiaBan", chiTiet.GiaBan);
            cmd.ExecuteNonQuery();

        }

        public List<ChiTietHoaDonDTO> GetInvoiceDetails(int id_HoaDon)
        {
            var list = new List<ChiTietHoaDonDTO>();
            string query = "SELECT * FROM ChiTietHoaDon WHERE id_HoaDon = @id_HoaDon";


            conn.OpenConnection();
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.Parameters.AddWithValue("@id_HoaDon", id_HoaDon);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ChiTietHoaDonDTO
                {
                    Id = reader.GetInt32(0),
                    IdHoaDon = reader.GetInt32(1),
                    IdSanPham = reader.GetInt32(2),
                    SoLuong = reader.GetInt32(3),
                    GiaBan = reader.GetFloat(4)
                });
            }
            return list;
        }

         

        public void UpdateInvoiceDetail(int id, int soLuong, float giaBan)
        {
            string query = "UPDATE ChiTietHoaDon SET SoLuong = @SoLuong, GiaBan = @GiaBan WHERE id = @id";

           
                conn.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            
        }

        public void DeleteInvoiceDetail(int id)
        {
            string query = "DELETE FROM ChiTietHoaDon WHERE id = @id";

          
                conn.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            
        }
    }
}
