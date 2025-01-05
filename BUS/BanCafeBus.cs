using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
namespace BUS
{
    public class BanCafeBus
    {
        private BanCafeDAO banCafeDAO;

        public BanCafeBus()
        {
            banCafeDAO = new BanCafeDAO();
        }
        public List<BanCafeDTO> GetAllTables()
        {
            return banCafeDAO.GetAllBanCafe();
        }

            public void UpdateTableStatus(int id_Ban, string status)
            {
                banCafeDAO.UpdateTableStatus(id_Ban, status);
            }

            public bool DeleteTable(int id_Ban)
            {
                try
                {
                    if (id_Ban <= 0)
                    {
                        throw new ArgumentException("ID bàn không hợp lệ.");
                    }

                    banCafeDAO.UpdateTableStatus(id_Ban, "Deleted");
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi xóa bàn: " + ex.Message);
            }
        }
        public List<BanCafeDTO> LayBanChuaCoHoaDon() { 
            return banCafeDAO.LayBanChuaCoHoaDon(); 
        }
    }
}
