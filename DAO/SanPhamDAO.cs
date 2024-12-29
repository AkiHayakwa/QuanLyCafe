using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Data;
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
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SanPhamDTO sanPham = new SanPhamDTO(
                        Convert.ToInt32(reader["id_SanPham"]),
                        reader["TenSanPham"].ToString(),
                        Convert.ToDecimal(reader["giaMua"]),
                        Convert.ToInt32(reader["SoLuongTon"]),
                        reader["TrangThai"].ToString(),
                        Convert.ToInt32(reader["id_DanhMuc"])
                    );
                    sanPhamList.Add(sanPham);
                }
                reader.Close();
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
                conn.OpenConnection(); // Mở kết nối đến CSDL

                string queryInsertSanPham = "INSERT INTO SanPham (id_SanPham, TenSanPham, giaMua, SoLuongTon, TrangThai, id_DanhMuc) " +
                                        "VALUES (@id_SanPham, @TenSanPham, @giaMua, @SoLuongTon, @TrangThai, @id_DanhMuc)";

                SqlCommand commandInsertSanPham = new SqlCommand(queryInsertSanPham, conn.GetConnection());
                commandInsertSanPham.Parameters.AddWithValue("@id_SanPham", sanPham.Id_SanPham);
                commandInsertSanPham.Parameters.AddWithValue("@TenSanPham", sanPham.TenSanPham);
                commandInsertSanPham.Parameters.AddWithValue("@giaMua", sanPham.GiaMua);
                commandInsertSanPham.Parameters.AddWithValue("@SoLuongTon", sanPham.SoLuongTon);
                commandInsertSanPham.Parameters.AddWithValue("@TrangThai", sanPham.TrangThai);
                commandInsertSanPham.Parameters.AddWithValue("@id_DanhMuc", sanPham.Id_DanhMuc);

                int rowsAffected = commandInsertSanPham.ExecuteNonQuery();

                // Nếu có ít nhất 1 dòng bị ảnh hưởng thì trả về true
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm sản phẩm: " + ex.Message);
                return false;
            }
            finally
            {
                conn.CloseConnection(); // Đảm bảo đóng kết nối
            }
        }

        // Cập nhật sản phẩm
        public bool UpdateSanPham(SanPhamDTO sanPham)
        {
            try
            {
                // Mở kết nối với cơ sở dữ liệu
                conn.OpenConnection();

                // Cập nhật câu lệnh SQL
                string query = "UPDATE SanPham SET TenSanPham = @TenSanPham, giaMua = @GiaMua, SoLuongTon = @SoLuongTon, " +
                               "TrangThai = @TrangThai, id_DanhMuc = @Id_DanhMuc WHERE id_SanPham = @Id_SanPham";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());

                // Thêm các tham số vào câu lệnh SQL
                command.Parameters.AddWithValue("@TenSanPham", sanPham.TenSanPham);
                command.Parameters.AddWithValue("@GiaMua", sanPham.GiaMua);
                command.Parameters.AddWithValue("@SoLuongTon", sanPham.SoLuongTon);
                command.Parameters.AddWithValue("@TrangThai", sanPham.TrangThai);
                command.Parameters.AddWithValue("@Id_DanhMuc", sanPham.Id_DanhMuc);
                command.Parameters.AddWithValue("@Id_SanPham", sanPham.Id_SanPham);

                // Thực thi câu lệnh SQL
                int result = command.ExecuteNonQuery();

                // Kiểm tra xem có dòng nào bị ảnh hưởng không
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện câu lệnh SQL: " + ex.Message);
            }
            finally
            {
                // Đảm bảo đóng kết nối
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
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@Id", idSanPham);

                int result = command.ExecuteNonQuery();
                return result > 0;
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
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@Id", idSanPham);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    sanPham = new SanPhamDTO(
                        Convert.ToInt32(reader["id_SanPham"]),
                        reader["TenSanPham"].ToString(),
                        Convert.ToDecimal(reader["giaMua"]),
                        Convert.ToInt32(reader["SoLuongTon"]),
                        reader["TrangThai"].ToString(),
                        Convert.ToInt32(reader["id_DanhMuc"])
                    );
                }
                reader.Close();
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

        public List<SanPhamDTO> GetSanPhamByIdDanhMuc(int idDanhMuc)
        {
            try
            {
                string query = "SELECT sp.id_SanPham, sp.TenSanPham, sp.giaMua, sp.SoLuongTon, sp.TrangThai " +
                               "FROM SanPham sp " +
                               "WHERE sp.id_DanhMuc = @IdDanhMuc";

                List<SanPhamDTO> sanPhamList = new List<SanPhamDTO>();

                // Mở kết nối
                conn.OpenConnection();

                // Tạo SqlCommand để thực thi câu truy vấn
                SqlCommand command = new SqlCommand(query, conn.GetConnection());

                // Thêm tham số vào câu truy vấn
                command.Parameters.AddWithValue("@IdDanhMuc", idDanhMuc);

                // Sử dụng SqlDataAdapter để lấy dữ liệu vào DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Chuyển đổi dữ liệu từ DataTable sang List<SanPhamDTO>
                    foreach (DataRow row in dt.Rows)
                    {
                        SanPhamDTO sanPham = new SanPhamDTO
                        {
                            Id_SanPham = Convert.ToInt32(row["id_SanPham"]),
                            TenSanPham = row["TenSanPham"].ToString(),
                            GiaMua = Convert.ToDecimal(row["giaMua"]),
                            SoLuongTon = Convert.ToInt32(row["SoLuongTon"]),
                            TrangThai = row["TrangThai"].ToString()
                        };
                        sanPhamList.Add(sanPham);
                    }
                }

                return sanPhamList;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn sản phẩm theo ID danh mục: " + ex.Message);
            }
        }

        public bool UpdateSoLuongTon(int idSanPham, int soLuongMoi)
        {
            try
            {
                conn.OpenConnection();
                string query = "UPDATE SanPham SET SoLuongTon = @SoLuongMoi WHERE id_SanPham = @Id";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@SoLuongMoi", soLuongMoi);
                command.Parameters.AddWithValue("@Id", idSanPham);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
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

    }
}

