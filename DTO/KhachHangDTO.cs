using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class KhachHangDTO
    {
        public int IdKhachHang { get; set; }
        public string TenKH { get; set; }
        public string Dt { get; set; }
        public string Email { get; set; }

        public KhachHangDTO() { }

        public KhachHangDTO(int idKhachHang, string tenKH, string dt, string email)
        {
            IdKhachHang = idKhachHang;
            TenKH = tenKH;
            Dt = dt;
            Email = email;
        }
    }
}
