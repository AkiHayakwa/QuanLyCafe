using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public int IdHoaDon { get; set; }
        public int IdBan { get; set; } 
        public DateTime Ngay { get; set; }
        public float TongTien { get; set; }
        public decimal GiamGia { get; set; }

        public HoaDonDTO() { }

        public HoaDonDTO(int idHoaDon, int idBan, DateTime ngay, float tongTien, decimal giamGia)
        {
            IdHoaDon = idHoaDon;
            IdBan = idBan;
            Ngay = ngay;
            TongTien = tongTien;
            GiamGia = giamGia;
        }
    }
}
