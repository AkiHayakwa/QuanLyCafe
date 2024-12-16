using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DAO;

namespace BUS
{
    public class TaiKhoanBus
    {
        private TaiKhoanDAO taiKhoanDao;

        public TaiKhoanBus()
        {
            taiKhoanDao = new TaiKhoanDAO();
        }

        // Lấy danh sách tất cả tài khoản
        public List<TaiKhoanDTO> GetAllTaiKhoan()
        {
            try
            {
                return taiKhoanDao.GetAllTaiKhoan();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                throw new Exception("Lỗi khi lấy danh sách tài khoản: " + ex.Message);
            }
        }

        // Thêm tài khoản mới
        public bool AddTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            try
            {
                return taiKhoanDao.AddTaiKhoan(taiKhoan);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                throw new Exception("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }

        // Xóa tài khoản theo ID
        public bool DeleteTaiKhoan(int idTaiKhoan)
        {
            try
            {
                return taiKhoanDao.DeleteTaiKhoan(idTaiKhoan);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                throw new Exception("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }

        // Cập nhật thông tin tài khoản
        public bool UpdateTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            try
            {
                return taiKhoanDao.UpdateTaiKhoan(taiKhoan);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                throw new Exception("Lỗi khi cập nhật tài khoản: " + ex.Message);
            }
        }

        // Lấy tài khoản theo ID
        public TaiKhoanDTO GetTaiKhoanById(int idTaiKhoan)
        {
            try
            {
                return taiKhoanDao.GetTaiKhoanById(idTaiKhoan);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                throw new Exception("Lỗi khi lấy tài khoản theo ID: " + ex.Message);
            }
        }

        public bool Login(string tenNguoiDung, string matKhau)
        {
            try
            {
                return taiKhoanDao.Login(tenNguoiDung, matKhau);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng nhập: " + ex.Message);
            }
        }

    }
}
