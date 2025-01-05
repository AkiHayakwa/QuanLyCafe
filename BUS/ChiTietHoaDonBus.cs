using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class ChiTietHoaDonBus
    {
        private ChiTietHoaDonDAO chiTietHoaDonDAO;

        public ChiTietHoaDonBus()
        {
            chiTietHoaDonDAO = new ChiTietHoaDonDAO();
        }

        // Method to add an invoice detail
        public void AddInvoiceDetail(ChiTietHoaDonDTO chiTiet)
        {
            try
            {
                chiTietHoaDonDAO.AddInvoiceDetail(chiTiet);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
            }
        }

        // Method to retrieve all invoice details by invoice ID
        public List<ChiTietHoaDonDTO> GetInvoiceDetails(int id_HoaDon)
        {
            try
            {
                return chiTietHoaDonDAO.GetInvoiceDetails(id_HoaDon);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin chi tiết hóa đơn: " + ex.Message);
            }
        }

        // Method to update an invoice detail
        public void UpdateInvoiceDetail(int idHoaDon , int idSanPham, int soLuong, float giaBan)
        {
            try
            {
                chiTietHoaDonDAO.UpdateInvoiceDetail(idHoaDon , idSanPham, soLuong, giaBan);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật chi tiết hóa đơn: " + ex.Message);
            }
        }

        // Method to delete an invoice detail
        public void DeleteInvoiceDetail(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("ID chi tiết hóa đơn không hợp lệ.");
                }

                chiTietHoaDonDAO.DeleteInvoiceDetail(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message);
            }
        }
    }
}
