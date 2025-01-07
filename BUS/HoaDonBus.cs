using DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class HoaDonBus
    {
        private HoaDonDAO hoaDonDAO;

        public HoaDonBus()
        {
            hoaDonDAO = new HoaDonDAO();
        }


        public int CreateInvoice(HoaDonDTO hoaDon)
        {
            try
            {
                return hoaDonDAO.CreateInvoice(hoaDon);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo hóa đơn: " + ex.Message, ex);
            }
        }


        public void UpdateTotalAmount(int id_HoaDon, float newTotal)
        {
            try
            {
                hoaDonDAO.UpdateTotalAmount(id_HoaDon, newTotal);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật tổng tiền hóa đơn: " + ex.Message);
            }
        }

        public HoaDonDTO LayHoaDonTheoBan(int id_Ban)
        {
            try
            {
                return hoaDonDAO.LayHoaDonTheoBan(id_Ban);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hóa đơn theo bàn: " + ex.Message);
            }
        }

        public bool DeleteInvoice(int id_HoaDon)
        {
            try
            {
                if (id_HoaDon <= 0)
                {
                    throw new ArgumentException("ID hóa đơn không hợp lệ.");
                }

                // Logic to set invoice status as deleted or remove it if necessary
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa hóa đơn: " + ex.Message);
            }
        }

        public List<HoaDonDTO> LayTatCaHoaDonCoChiTiet()
        {
            try
            {
                return hoaDonDAO.LayTatCaHoaDonCoChiTiet();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hóa đơn: " + ex.Message);
            }
        }

        public void UpdateBanChoHoaDon(HoaDonDTO hoaDon)
        {
            try
            {
                hoaDonDAO.UpdateBanChoHoaDon(hoaDon);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật bàn cho hóa đơn: " + ex.Message);
            }
        }

        public HoaDonDTO LayHoaDonCoTongTien0()
        {
            try
            {
               return hoaDonDAO.LayHoaDonTongTienBang0();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật bàn cho hóa đơn: " + ex.Message);
            }
        }
    }
}
