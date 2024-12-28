using System;
using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS
{
    public class DanhMucBUS
    {
        private DanhMucDAO danhMucDAO;

        public DanhMucBUS()
        {
            danhMucDAO = new DanhMucDAO();
        }

        // Lấy danh sách tất cả danh mục
        public List<DanhMucDTO> GetAllDanhMuc()
        {
            try
            {
                return danhMucDAO.GetAllDanhMuc();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách danh mục từ DAO: " + ex.Message);
            }
        }

        // Thêm danh mục
        public bool AddDanhMuc(DanhMucDTO danhMuc)
        {
            try
            {
                if (string.IsNullOrEmpty(danhMuc.TenDanhMuc))
                {
                    throw new ArgumentException("Tên danh mục không được để trống.");
                }

                return danhMucDAO.AddDanhMuc(danhMuc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm danh mục vào DAO: " + ex.Message);
            }
        }

        // Cập nhật danh mục
        public bool UpdateDanhMuc(DanhMucDTO danhMuc)
        {
            try
            {
                if (danhMuc.Id_danhMuc <= 0 || string.IsNullOrEmpty(danhMuc.TenDanhMuc))
                {
                    throw new ArgumentException("Thông tin danh mục không hợp lệ.");
                }

                return danhMucDAO.UpdateDanhMuc(danhMuc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật danh mục vào DAO: " + ex.Message);
            }
        }

        // Xóa danh mục theo ID
        public bool DeleteDanhMuc(int idDanhMuc)
        {
            try
            {
                if (idDanhMuc <= 0)
                {
                    throw new ArgumentException("ID danh mục không hợp lệ.");
                }

                return danhMucDAO.DeleteDanhMuc(idDanhMuc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa danh mục từ DAO: " + ex.Message);
            }
        }

        // Lấy danh mục theo ID
        public DanhMucDTO GetDanhMucById(int idDanhMuc)
        {
            try
            {
                if (idDanhMuc <= 0)
                {
                    throw new ArgumentException("ID danh mục không hợp lệ.");
                }

                return danhMucDAO.GetDanhMucById(idDanhMuc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh mục từ DAO: " + ex.Message);
            }
        }
    }
}
