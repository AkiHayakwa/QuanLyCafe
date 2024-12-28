using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal class HoaDonBus
    {
        private HoaDonDAO hoaDonDAO;

        public HoaDonBus()
        {
            hoaDonDAO = new  HoaDonDAO();
        }

        public int CreateInvoice(HoaDonDTO hoaDon)
        {
            return hoaDonDAO.CreateInvoice(hoaDon);
        }

        public void UpdateTotalAmount(int id_HoaDon, decimal newTotal)
        {
            hoaDonDAO.UpdateTotalAmount(id_HoaDon, newTotal);
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
    }
}
