using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class ChiTietHoaDonDTO
    {
        public int Id { get; set; }
        public int IdHoaDon { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public float GiaBan { get; set; }

        public ChiTietHoaDonDTO() { }

        public ChiTietHoaDonDTO(int id, int idHoaDon, int idSanPham, int soLuong, float giaBan)
        {
            Id = id;
            IdHoaDon = idHoaDon;
            IdSanPham = idSanPham;
            SoLuong = soLuong;
            GiaBan = giaBan;
        }
    }
}
