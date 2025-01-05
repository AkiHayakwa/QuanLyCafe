using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class ChiTietHoaDonDAO
    {
        private DatabaseConnection conn;

        public ChiTietHoaDonDAO()
        {
            conn = new DatabaseConnection();
        }

        public void AddInvoiceDetail(ChiTietHoaDonDTO chiTiet)
        {
            string query = "INSERT INTO ChiTietHoaDon (id_HoaDon, id_SanPham, SoLuong, GiaBan, TongTien) VALUES (@IdHoaDon, @IdSanPham, @SoLuong, @DonGia, @TongTien)";
            try
            {
                conn.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
                cmd.Parameters.AddWithValue("@IdHoaDon", chiTiet.IdHoaDon);
                cmd.Parameters.AddWithValue("@IdSanPham", chiTiet.IdSanPham);
                cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", chiTiet.GiaBan);
                cmd.Parameters.AddWithValue("@TongTien", chiTiet.TongTien);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public List<ChiTietHoaDonDTO> GetInvoiceDetails(int id_HoaDon)
        {
            List<ChiTietHoaDonDTO> chiTietList = new List<ChiTietHoaDonDTO>();
            string query = "SELECT * FROM ChiTietHoaDon WHERE id_HoaDon = @id_HoaDon";
            try
            {
                conn.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
                cmd.Parameters.AddWithValue("@id_HoaDon", id_HoaDon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        // In giá trị thực tế để kiểm tra
                        Console.WriteLine("GiaBan: " + reader["GiaBan"]);
                        Console.WriteLine("TongTien: " + reader["TongTien"]);

                        ChiTietHoaDonDTO chiTiet = new ChiTietHoaDonDTO
                        {
                            IdHoaDon = reader.GetInt32(reader.GetOrdinal("id_HoaDon")),
                            IdSanPham = reader.GetInt32(reader.GetOrdinal("id_SanPham")),
                            SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                            GiaBan = Convert.ToSingle(reader["GiaBan"]), // Sử dụng Convert.ToSingle
                            TongTien = Convert.ToSingle(reader["TongTien"]) // Sử dụng Convert.ToSingle
                        };
                        chiTietList.Add(chiTiet);
                    }
                    catch (InvalidCastException ex)
                    {
                        throw new Exception("Lỗi chuyển đổi dữ liệu: " + ex.Message);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return chiTietList;
        }


        public void UpdateInvoiceDetail(int idHoaDon, int idSanPham, int soLuong, float giaBan)
          {
            string query = "UPDATE ChiTietHoaDon SET SoLuong = @SoLuong, GiaBan = @GiaBan, TongTien = @TongTien WHERE id_HoaDon = @idHoaDon AND id_SanPham = @idSanPham";
            try
            {
                conn.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                cmd.Parameters.AddWithValue("@TongTien", soLuong * giaBan);
                cmd.Parameters.AddWithValue("@idHoaDon", idHoaDon);
                cmd.Parameters.AddWithValue("@idSanPham", idSanPham);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

            public void DeleteInvoiceDetail(int id)
            {
                string query = "DELETE FROM ChiTietHoaDon WHERE IdChiTietHoaDon = @IdChiTietHoaDon";
                try
                {
                    conn.OpenConnection();
                    SqlCommand cmd = new SqlCommand(query, conn.GetConnection());
                    cmd.Parameters.AddWithValue("@IdChiTietHoaDon", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message);
                }
                finally
                {
                    conn.CloseConnection();
                }
            }
        }
    }
