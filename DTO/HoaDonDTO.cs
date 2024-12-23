using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class HoaDonDTO
    {
        public int IdHoaDon { get; set; }
        public int IdBan { get; set; }
        public int IdKhachHang { get; set; }
        public DateTime Ngay { get; set; }
        public decimal TongTien { get; set; }
        public decimal GiamGia { get; set; }

        public HoaDonDTO() { }

        public HoaDonDTO(int idHoaDon, int idBan, int idKhachHang, DateTime ngay, decimal tongTien, decimal giamGia)
        {
            IdHoaDon = idHoaDon;
            IdBan = idBan;
            IdKhachHang = idKhachHang;
            Ngay = ngay;
            TongTien = tongTien;
            GiamGia = giamGia;
        }
    }
}
