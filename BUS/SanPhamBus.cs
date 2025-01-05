    using System;
    using System.Collections.Generic;
    using DAO;
    using DTO;

    namespace BUS
    {
    public class SanPhamBUS
    {
        private SanPhamDAO sanPhamDAO;

        public SanPhamBUS()
        {
            sanPhamDAO = new SanPhamDAO();
        }

        // Lấy danh sách tất cả sản phẩm
        public List<SanPhamDTO> GetAllSanPham()
        {
            try
            {
                return sanPhamDAO.GetAllSanPham();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm từ DAO: " + ex.Message);
            }
        }

        // Thêm sản phẩm
        public bool AddSanPham(SanPhamDTO sanPham)
        {
            try
            {
                if (string.IsNullOrEmpty(sanPham.TenSanPham) || sanPham.GiaMua <= 0 || sanPham.SoLuongTon < 0)
                {
                    throw new ArgumentException("Thông tin sản phẩm không hợp lệ.");
                }

                return sanPhamDAO.AddSanPham(sanPham);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm vào DAO: " + ex.Message);
            }
        }

        // Cập nhật sản phẩm
        public bool UpdateSanPham(SanPhamDTO sanPham)
        {
            try
            {
                if (sanPham.Id_SanPham <= 0 || string.IsNullOrEmpty(sanPham.TenSanPham) || sanPham.GiaMua <= 0 || sanPham.SoLuongTon < 0)
                {
                    throw new ArgumentException("Thông tin sản phẩm không hợp lệ.");
                }

                return sanPhamDAO.UpdateSanPham(sanPham);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật sản phẩm vào DAO: " + ex.Message);
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

                return sanPhamDAO.DeleteSanPham(idSanPham);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sản phẩm từ DAO: " + ex.Message);
            }
        }

        // Lấy sản phẩm theo ID
        public SanPhamDTO GetSanPhamById(int idSanPham)
        {
            try
            {
                if (idSanPham <= 0)
                {
                    throw new ArgumentException("ID sản phẩm không hợp lệ.");
                }

                return sanPhamDAO.GetSanPhamById(idSanPham);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy sản phẩm từ DAO: " + ex.Message);
            }
        }

        public List<SanPhamDTO> GetSanPhamByIdDanhMuc(int idDanhMuc)
        {
            try
            {
                if (idDanhMuc <= 0)
                {
                    throw new ArgumentException("ID danh mục không hợp lệ.");
                }

                return sanPhamDAO.GetSanPhamByIdDanhMuc(idDanhMuc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy sản phẩm theo ID danh mục từ DAO: " + ex.Message);
            }
        }

        public bool GiamSoLuongTon(int idSanPham, int soLuongGiam)
        {
            try
            {
                SanPhamDTO sanPham = sanPhamDAO.GetSanPhamById(idSanPham);
                if (sanPham.SoLuongTon < soLuongGiam)
                {
                    throw new Exception("Số lượng tồn không đủ.");
                }
                return sanPhamDAO.UpdateSoLuongTon(idSanPham, sanPham.SoLuongTon - soLuongGiam);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi giảm số lượng tồn: " + ex.Message);
            }
        }

        public string LayTenSanPham(int id_SanPham)
        {
            try
            {
                return sanPhamDAO.LayTenSanPham(id_SanPham);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tên sản phẩm: " + ex.Message);
            }
        }
    }
}
