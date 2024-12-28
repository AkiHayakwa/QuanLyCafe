using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using DTO;

namespace DAO
{
    public class HoaDonDAO
    {
        DatabaseConnection conn;

        public HoaDonDAO()
        {
            conn = new DatabaseConnection();
        }

        public int CreateInvoice(HoaDonDTO hoaDon)
        {
            string query = "INSERT INTO HoaDon (id_Ban, id_KhachHang, Ngay, TongTien, GiamGia) OUTPUT INSERTED.id_HoaDon VALUES (@id_Ban, @id_KhachHang, @Ngay, @TongTien, @GiamGia)";

            conn.OpenConnection();
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.Parameters.AddWithValue("@id_Ban", hoaDon.IdBan);
            cmd.Parameters.AddWithValue("@id_KhachHang", hoaDon.IdKhachHang);
            cmd.Parameters.AddWithValue("@Ngay", hoaDon.Ngay);
            cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
            cmd.Parameters.AddWithValue("@GiamGia", hoaDon.GiamGia);

            return (int)cmd.ExecuteScalar();

        }

        public void UpdateTotalAmount(int id_HoaDon, decimal newTotal)
        {
            string query = "UPDATE HoaDon SET TongTien = @TongTien WHERE id_HoaDon = @id_HoaDon";
            conn.OpenConnection();
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.Parameters.AddWithValue("@TongTien", newTotal);
            cmd.Parameters.AddWithValue("@id_HoaDon", id_HoaDon);
            cmd.ExecuteNonQuery();

        }
    }
}
