using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;
using DAO;

public class HoaDonDAO
{
    private DatabaseConnection conn;

    public HoaDonDAO()
    {
        conn = new DatabaseConnection();
    }

    public int CreateInvoice(HoaDonDTO hoaDon)
    {
        string query = "INSERT INTO HoaDon (id_Ban, Ngay, TongTien, GiamGia) OUTPUT INSERTED.id_HoaDon VALUES (@id_Ban, @Ngay, @TongTien, @GiamGia)";
        int idHoaDon = 0;

        try
        {
            conn.OpenConnection();
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.Parameters.AddWithValue("@id_Ban", hoaDon.IdBan);
            cmd.Parameters.AddWithValue("@Ngay", hoaDon.Ngay);
            cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
            cmd.Parameters.AddWithValue("@GiamGia", hoaDon.GiamGia);

            idHoaDon = (int)cmd.ExecuteScalar();
        }
        catch (SqlException sqlEx)
        {
            // Log SQL exception details
            Console.WriteLine("SQL Error: " + sqlEx.Message);
            throw new Exception("Lỗi SQL khi tạo hóa đơn: " + sqlEx.Message, sqlEx);
        }
        catch (Exception ex)
        {
            // Log generic exception details
            Console.WriteLine("Error: " + ex.Message);
            throw new Exception("Lỗi khi tạo hóa đơn: " + ex.Message, ex);
        }
        finally
        {
            conn.CloseConnection();
        }

        return idHoaDon;
    }



    public void UpdateTotalAmount(int id_HoaDon, float newTotal)
    {
        string query = "UPDATE HoaDon SET TongTien = @TongTien WHERE id_HoaDon = @id_HoaDon";

        try
        {
            conn.OpenConnection();
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.Parameters.AddWithValue("@TongTien", newTotal);
            cmd.Parameters.AddWithValue("@id_HoaDon", id_HoaDon);
            cmd.ExecuteNonQuery();
        }
        finally
        {
            conn.CloseConnection();
        }
    }

    public HoaDonDTO LayHoaDonTheoBan(int id_Ban)
    {
        string query = "SELECT TOP 1 * FROM HoaDon WHERE id_Ban = @id_Ban ORDER BY Ngay DESC";
        HoaDonDTO hoaDon = null;

        try
        {
            conn.OpenConnection();
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            cmd.Parameters.AddWithValue("@id_Ban", id_Ban);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                hoaDon = new HoaDonDTO
                {
                    IdHoaDon = reader.GetInt32(reader.GetOrdinal("id_HoaDon")),
                    IdBan = reader.GetInt32(reader.GetOrdinal("id_Ban")),
                    Ngay = reader.GetDateTime(reader.GetOrdinal("Ngay")),
                    TongTien = (float)reader.GetDouble(reader.GetOrdinal("TongTien")),
                    GiamGia = reader.GetDecimal(reader.GetOrdinal("GiamGia"))
                };

                if(hoaDon.TongTien == 0)
                {
                    hoaDon = null;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi lấy hóa đơn theo bàn: " + ex.Message);
        }
        finally
        {
            conn.CloseConnection();
        }

        return hoaDon;
    }

    public List<HoaDonDTO> LayTatCaHoaDonCoChiTiet()
    {
        List<HoaDonDTO> hoaDonList = new List<HoaDonDTO>();
        string query = "SELECT DISTINCT hd.id_HoaDon, hd.id_Ban FROM HoaDon hd INNER JOIN ChiTietHoaDon cthd ON hd.id_HoaDon = cthd.id_HoaDon";
        try
        {
            conn.OpenConnection();
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HoaDonDTO hoaDon = new HoaDonDTO
                {
                    IdHoaDon = reader.GetInt32(reader.GetOrdinal("id_HoaDon")),
                    IdBan = reader.GetInt32(reader.GetOrdinal("id_Ban"))
                };
                hoaDonList.Add(hoaDon);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
        }
        finally
        {
            conn.CloseConnection();
        }
        return hoaDonList;
    }

    public List<int> LayTatCaBanDaCoHoaDon() {
        List<int> danhSachBan = new List<int>(); 
        string query = "SELECT DISTINCT id_Ban FROM HoaDon"; 
        try { 
            conn.OpenConnection(); 
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader(); while (reader.Read()) { 
                danhSachBan.Add(reader.GetInt32(reader.GetOrdinal("id_Ban")));
            } 
            reader.Close();
        } catch (Exception ex) { 
            throw new Exception("Lỗi khi lấy danh sách bàn đã có hóa đơn: " + ex.Message); 
        } finally {
            conn.CloseConnection();
        } 
        return danhSachBan; 
    }

    public void UpdateBanChoHoaDon(HoaDonDTO hoaDon) { 
        string query = "UPDATE HoaDon SET id_Ban = @id_Ban WHERE id_HoaDon = @id_HoaDon"; 
        try { 
            conn.OpenConnection(); 
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection()); 
            cmd.Parameters.AddWithValue("@id_Ban", hoaDon.IdBan); 
            cmd.Parameters.AddWithValue("@id_HoaDon", hoaDon.IdHoaDon); 
            cmd.ExecuteNonQuery();
        } catch (Exception ex) {
            throw new Exception("Lỗi khi cập nhật bàn cho hóa đơn: " + ex.Message); 
        } finally { 
            conn.CloseConnection();
        } 
    }

    public HoaDonDTO LayHoaDonTongTienBang0()
    {
        string query = "SELECT TOP 1 * FROM HoaDon WHERE TongTien = 0 ORDER BY Ngay DESC";
        HoaDonDTO hoaDon = null;

        try
        {
            conn.OpenConnection();
            SqlCommand cmd = new SqlCommand(query, conn.GetConnection());

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                hoaDon = new HoaDonDTO
                {
                    IdHoaDon = reader.GetInt32(reader.GetOrdinal("id_HoaDon")),
                    IdBan = reader.GetInt32(reader.GetOrdinal("id_Ban")),
                    Ngay = reader.GetDateTime(reader.GetOrdinal("Ngay")),
                    TongTien = (float)reader.GetDouble(reader.GetOrdinal("TongTien")),
                    GiamGia = reader.GetDecimal(reader.GetOrdinal("GiamGia"))
                };
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi lấy hóa đơn có tổng tiền = 0: " + ex.Message);
        }
        finally
        {
            conn.CloseConnection();
        }

        return hoaDon;
    }

}
