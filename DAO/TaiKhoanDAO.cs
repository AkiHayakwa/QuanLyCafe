using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
namespace DAO
{
    public class TaiKhoanDAO
    {
        private DatabaseConnection conn;

        public TaiKhoanDAO()
        {
            conn = new DatabaseConnection();
        }

        // Lấy danh sách tất cả tài khoản
        public List<TaiKhoanDTO> GetAllTaiKhoan()
        {
            List<TaiKhoanDTO> taiKhoanList = new List<TaiKhoanDTO>();
            try
            {
                conn.OpenConnection();
                string query = "SELECT * FROM TaiKhoan";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TaiKhoanDTO taiKhoan = new TaiKhoanDTO(
                        Convert.ToInt32(reader["id_TaiKhoan"]),
                        reader["TenNguoiDung"].ToString(),
                        reader["MatKhau"].ToString(),
                        reader["TrangThai"].ToString(),
                        reader["Quyen"].ToString()
                    );
                    taiKhoanList.Add(taiKhoan);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tài khoản: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return taiKhoanList;
        }

        public bool AddTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            try
            {
                // Mở kết nối
                conn.OpenConnection();  // Nếu conn là đối tượng kết nối của bạn
                string query = "INSERT INTO TaiKhoan (TenNguoiDung, MatKhau, TrangThai, Quyen) " +
                               "VALUES (@TenNguoiDung, @MatKhau, @TrangThai, @Quyen)";

                // Tạo SqlCommand và truyền query vào
                SqlCommand command = new SqlCommand(query, conn.GetConnection());

                // Thêm tham số vào command với kiểu dữ liệu rõ ràng
                command.Parameters.Add("@TenNguoiDung", SqlDbType.NVarChar).Value = taiKhoan.TenNguoiDung;
                command.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = taiKhoan.MatKhau;
                command.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = taiKhoan.TrangThai;
                command.Parameters.Add("@Quyen", SqlDbType.NVarChar).Value = taiKhoan.Quyen;


                // Thực thi câu lệnh INSERT và kiểm tra xem có bản ghi nào được thêm không
                int result = command.ExecuteNonQuery();

                // Nếu thêm thành công, trả về true, nếu không thì false
                return result > 0;
            }
            catch (Exception ex)
            {
                // In chi tiết lỗi nếu có
                Console.WriteLine(ex.Message);
                throw new Exception("Lỗi khi thêm tài khoản: " + ex.Message);
            }
            finally
            {
                // Đảm bảo đóng kết nối sau khi hoàn tất
                conn.CloseConnection();
            }
        }

        public bool UpdateTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            try
            {
                conn.OpenConnection();
                // Truy vấn UPDATE với @Id_TaiKhoan là bắt buộc
                string query = "UPDATE TaiKhoan SET TenNguoiDung = @TenNguoiDung, MatKhau = @MatKhau, TrangThai = @TrangThai, Quyen = @Quyen WHERE Id_TaiKhoan = @Id_TaiKhoan";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());

                // Thêm các tham số vào câu lệnh SQL
                command.Parameters.AddWithValue("@TenNguoiDung", taiKhoan.TenNguoiDung);
                command.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                command.Parameters.AddWithValue("@TrangThai", taiKhoan.TrangThai);
                command.Parameters.AddWithValue("@Quyen", taiKhoan.Quyen);

                // Cung cấp giá trị ID của tài khoản để xác định bản ghi cần cập nhật
                command.Parameters.AddWithValue("@Id_TaiKhoan", taiKhoan.Id_TaiKhoan);

                int result = command.ExecuteNonQuery();
                return result > 0; // Kiểm tra xem có dòng nào bị ảnh hưởng không
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện câu lệnh SQL: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }



        // Xóa tài khoản theo ID
        public bool DeleteTaiKhoan(int idTaiKhoan)
        {
            try
            {
                conn.OpenConnection();
                string query = "DELETE FROM TaiKhoan WHERE id_TaiKhoan = @Id";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@Id", idTaiKhoan);
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa tài khoản: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public TaiKhoanDTO GetTaiKhoanById(int idTaiKhoan)
        {
            TaiKhoanDTO taiKhoan = null;
            try
            {
                conn.OpenConnection();
                string query = "SELECT * FROM TaiKhoan WHERE id_TaiKhoan = @Id";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@Id", idTaiKhoan);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    taiKhoan = new TaiKhoanDTO(
                         Convert.ToInt32(reader["id_TaiKhoan"]),
                        reader["TenNguoiDung"].ToString(),
                        reader["MatKhau"].ToString() ,
                        reader["Quyen"].ToString() ,
                        reader["TrangThai"].ToString()
                    );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tài khoản theo ID: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return taiKhoan;
        }

        public string Login(string tenNguoiDung, string matKhau)
        {
            try
            {
                conn.OpenConnection();
                string query = "SELECT Quyen FROM TaiKhoan WHERE TenNguoiDung = @TenNguoiDung AND MatKhau = @MatKhau AND TrangThai = N'Hoạt động'";
                SqlCommand command = new SqlCommand(query, conn.GetConnection());
                command.Parameters.AddWithValue("@TenNguoiDung", tenNguoiDung);
                command.Parameters.AddWithValue("@MatKhau", matKhau);

                object result = command.ExecuteScalar(); // Trả về quyền của người dùng nếu đăng nhập hợp lệ

                if (result != null)
                {
                    return result.ToString(); // Trả về quyền của người dùng
                }
                return null; // Nếu không có tài khoản hoặc mật khẩu không chính xác
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng nhập: " + ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public bool ResetPassword(string username, string newPassword)
        {
            try
            {

                conn.OpenConnection();
                string query = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE TenNguoiDung = @TenNguoiDung";

                SqlCommand cmd = new SqlCommand(query, conn.GetConnection());

                cmd.Parameters.AddWithValue("@MatKhau", newPassword);
                cmd.Parameters.AddWithValue("@TenNguoiDung", username);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;  // Nếu có ít nhất 1 dòng bị ảnh hưởng, trả về true
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                throw new Exception("Lỗi khi reset mật khẩu: " + ex.Message);
            }
        }
    }
}
