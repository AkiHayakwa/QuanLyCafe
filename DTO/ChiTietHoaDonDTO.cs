using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonDTO
    {
        public int Id { get; set; }
        public int IdHoaDon { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public float GiaBan { get; set; }

        public float TongTien { get; set; }

        public ChiTietHoaDonDTO() { }

        public ChiTietHoaDonDTO( int idHoaDon, int idSanPham, int soLuong, float giaBan, float tongTien)
        {
            IdHoaDon = idHoaDon;
            IdSanPham = idSanPham;
            SoLuong = soLuong;
            GiaBan = giaBan;
            TongTien = tongTien;
        }
    }
}
