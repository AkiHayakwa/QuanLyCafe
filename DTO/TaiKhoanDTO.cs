using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   

    public class TaiKhoanDTO
    {
        public int Id_TaiKhoan { get; set; }
        public string TenNguoiDung { get; set; }
        public string MatKhau { get; set; }
        public string TrangThai { get; set; }
        public string Quyen { get; set; }

        public TaiKhoanDTO() { }

        public TaiKhoanDTO(int id, string tenNguoiDung, string matKhau, string trangThai, string quyen)
        {
            Id_TaiKhoan = id;
            TenNguoiDung = tenNguoiDung;
            MatKhau = matKhau;
            TrangThai = trangThai;
            Quyen = quyen;
        }

    }
}
