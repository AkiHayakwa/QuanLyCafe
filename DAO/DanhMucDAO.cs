using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DanhMucDAO
    {
        private DatabaseConnection conn;

        public DanhMucDAO()
        {
            conn = new DatabaseConnection();
        }

        // Lấy danh sách tất cả danh mục
        public List<DanhMucDTO> GetAllDanhMuc()
        {
            List<DanhMucDTO> danhMucList = new List<DanhMucDTO>();
            try
            {
                conn.OpenConnection(); // Mở kết nối đến CSDL
                string query = "SELECT id_DanhMuc, TenDanhMuc FROM DanhMuc"; // Truy vấn lấy danh mục
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DanhMucDTO danhMuc = new DanhMucDTO(
                        Convert.ToInt32(reader["id_DanhMuc"]),
                        reader["TenDanhMuc"].ToString()
                    );
                    danhMucList.Add(danhMuc);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách danh mục: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection(); // Đảm bảo đóng kết nối
            }

            return danhMucList; // Trả về danh sách danh mục
        }


        // Thêm danh mục
        public bool AddDanhMuc(DanhMucDTO danhMuc)
        {
            try
            {
                conn.OpenConnection();
                string query = "INSERT INTO DanhMuc (TenDanhMuc) VALUES (@TenDanhMuc)";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@TenDanhMuc", danhMuc.TenDanhMuc);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm danh mục: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        // Cập nhật danh mục
        public bool UpdateDanhMuc(DanhMucDTO danhMuc)
        {
            try
            {
                conn.OpenConnection();
                string query = "UPDATE DanhMuc SET TenDanhMuc = @TenDanhMuc WHERE id_DanhMuc = @Id_DanhMuc";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@TenDanhMuc", danhMuc.TenDanhMuc);
                command.Parameters.AddWithValue("@Id_DanhMuc", danhMuc.Id_danhMuc);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật danh mục: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        // Xóa danh mục
        public bool DeleteDanhMuc(int idDanhMuc)
        {
            try
            {
                conn.OpenConnection();
                string query = "DELETE FROM DanhMuc WHERE id_DanhMuc = @Id";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@Id", idDanhMuc);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa danh mục: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        // Lấy danh mục theo ID
        public DanhMucDTO GetDanhMucById(int idDanhMuc)
        {
            DanhMucDTO danhMuc = null;
            try
            {
                conn.OpenConnection();
                string query = "SELECT * FROM DanhMuc WHERE id_DanhMuc = @Id";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@Id", idDanhMuc);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    danhMuc = new DanhMucDTO(
                        Convert.ToInt32(reader["id_DanhMuc"]),
                        reader["TenDanhMuc"].ToString()
                    );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh mục theo ID: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return danhMuc;
        }
    }
}
