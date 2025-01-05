using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class SanPhamDAO
    {
        private DatabaseConnection conn;

        public SanPhamDAO()
        {
            conn = new DatabaseConnection();
        }

        // Lấy danh sách tất cả sản phẩm
        public List<SanPhamDTO> GetAllSanPham()
        {
            List<SanPhamDTO> sanPhamList = new List<SanPhamDTO>();
            try
            {
                conn.OpenConnection();
                string query = "SELECT * FROM SanPham";
                using (SqlCommand command = new SqlCommand(query, conn.GetConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamDTO sanPham = new SanPhamDTO(
                            Convert.ToInt32(reader["id_SanPham"]),
                            reader["TenSanPham"].ToString(),
                            Convert.ToSingle(reader["giaMua"]), // Sửa lại để chuyển đổi thành float
                            Convert.ToInt32(reader["SoLuongTon"]),
                            reader["TrangThai"].ToString(),
                            Convert.ToInt32(reader["id_DanhMuc"])
                             );
                            sanPhamList.Add(sanPham);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return sanPhamList;
        }

        // Thêm sản phẩm
        public bool AddSanPham(SanPhamDTO sanPham)
        {
            try
            {
                conn.OpenConnection();
                string query = "INSERT INTO SanPham (id_SanPham, TenSanPham, giaMua, SoLuongTon, TrangThai, id_DanhMuc) " +
                               "VALUES (@id_SanPham, @TenSanPham, @giaMua, @SoLuongTon, @TrangThai, @id_DanhMuc)";

                using (SqlCommand command = new SqlCommand(query, conn.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id_SanPham", sanPham.Id_SanPham);
                    command.Parameters.AddWithValue("@TenSanPham", sanPham.TenSanPham);
                    command.Parameters.AddWithValue("@giaMua", sanPham.GiaMua);
                    command.Parameters.AddWithValue("@SoLuongTon", sanPham.SoLuongTon);
                    command.Parameters.AddWithValue("@TrangThai", sanPham.TrangThai);
                    command.Parameters.AddWithValue("@id_DanhMuc", sanPham.Id_DanhMuc);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        // Cập nhật sản phẩm
        public bool UpdateSanPham(SanPhamDTO sanPham)
        {
            try
            {
                conn.OpenConnection();
                string query = "UPDATE SanPham SET TenSanPham = @TenSanPham, giaMua = @GiaMua, SoLuongTon = @SoLuongTon, " +
                               "TrangThai = @TrangThai, id_DanhMuc = @Id_DanhMuc WHERE id_SanPham = @Id_SanPham";

                using (SqlCommand command = new SqlCommand(query, conn.GetConnection()))
                {
                    command.Parameters.AddWithValue("@TenSanPham", sanPham.TenSanPham);
                    command.Parameters.AddWithValue("@GiaMua", sanPham.GiaMua);
                    command.Parameters.AddWithValue("@SoLuongTon", sanPham.SoLuongTon);
                    command.Parameters.AddWithValue("@TrangThai", sanPham.TrangThai);
                    command.Parameters.AddWithValue("@Id_DanhMuc", sanPham.Id_DanhMuc);
                    command.Parameters.AddWithValue("@Id_SanPham", sanPham.Id_SanPham);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật sản phẩm: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        // Xóa sản phẩm
        public bool DeleteSanPham(int idSanPham)
        {
            try
            {
                if (idSanPham <= 0)
                {
                    throw new ArgumentException("ID sản phẩm không hợp lệ.");
                }

                conn.OpenConnection();
                string query = "DELETE FROM SanPham WHERE id_SanPham = @Id";

                using (SqlCommand command = new SqlCommand(query, conn.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Id", idSanPham);
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        // Lấy sản phẩm theo ID
        public SanPhamDTO GetSanPhamById(int idSanPham)
        {
            SanPhamDTO sanPham = null;
            try
            {
                conn.OpenConnection();
                string query = "SELECT * FROM SanPham WHERE id_SanPham = @Id";

                using (SqlCommand command = new SqlCommand(query, conn.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Id", idSanPham);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sanPham = new SanPhamDTO(
                                Convert.ToInt32(reader["id_SanPham"]),
                                reader["TenSanPham"].ToString(),
                                Convert.ToSingle(reader["GiaMua"]), 
                                Convert.ToInt32(reader["SoLuongTon"]),
                                reader["TrangThai"].ToString(),
                                Convert.ToInt32(reader["id_DanhMuc"])
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy sản phẩm theo ID: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return sanPham;
        }

        // Lấy sản phẩm theo ID danh mục
        public List<SanPhamDTO> GetSanPhamByIdDanhMuc(int idDanhMuc)
        {
            List<SanPhamDTO> sanPhamList = new List<SanPhamDTO>();
            try
            {
                conn.OpenConnection();
                string query = "SELECT id_SanPham, TenSanPham, giaMua, SoLuongTon, TrangThai FROM SanPham WHERE id_DanhMuc = @IdDanhMuc";

                using (SqlCommand command = new SqlCommand(query, conn.GetConnection()))
                {
                    command.Parameters.AddWithValue("@IdDanhMuc", idDanhMuc);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamDTO sanPham = new SanPhamDTO
                            {
                                Id_SanPham = Convert.ToInt32(reader["id_SanPham"]),
                                TenSanPham = reader["TenSanPham"].ToString(),
                                GiaMua = Convert.ToSingle(reader["GiaMua"]),
                                SoLuongTon = Convert.ToInt32(reader["SoLuongTon"]),
                                TrangThai = reader["TrangThai"].ToString()
                            };
                            sanPhamList.Add(sanPham);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn sản phẩm theo ID danh mục: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return sanPhamList;
        }

        // Cập nhật số lượng tồn kho
        public bool UpdateSoLuongTon(int idSanPham, int soLuongMoi)
        {
            try
            {
                conn.OpenConnection();
                string query = "UPDATE SanPham SET SoLuongTon = @SoLuongMoi WHERE id_SanPham = @Id";

                using (SqlCommand command = new SqlCommand(query, conn.GetConnection()))
                {
                    command.Parameters.AddWithValue("@SoLuongMoi", soLuongMoi);
                    command.Parameters.AddWithValue("@Id", idSanPham);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật số lượng tồn: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }
        public string LayTenSanPham(int id_SanPham) {
            string tenSanPham = null; 
            string query = "SELECT TenSanPham FROM SanPham WHERE id_SanPham = @id_SanPham"; 
            try { 
                conn.OpenConnection(); 
                SqlCommand cmd = new SqlCommand(query, conn.GetConnection()); 
                cmd.Parameters.AddWithValue("@id_SanPham", id_SanPham); 
                SqlDataReader reader = cmd.ExecuteReader(); 
                if (reader.Read()) { 
                    tenSanPham = reader.GetString(0); 
                } 
            } finally { 
                conn.CloseConnection(); 
            } 
            return tenSanPham; 
        }
    }
}
