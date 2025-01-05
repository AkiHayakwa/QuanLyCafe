    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DTO
    {
        public class SanPhamDTO
        {
            public int Id_SanPham { get; set; }
            public string TenSanPham { get; set; }
            public float GiaMua { get; set; }
            public int SoLuongTon { get; set; }
            public string TrangThai { get; set; }
            public int Id_DanhMuc { get; set; }

            public SanPhamDTO() { }

            public SanPhamDTO(int id_SanPham, string tenSanPham, float giaMua, int soLuongTon, string trangThai, int id_DanhMuc)
            {
                Id_SanPham = id_SanPham;
                TenSanPham = tenSanPham;
                GiaMua = giaMua;
                SoLuongTon = soLuongTon;
                TrangThai = trangThai;
                Id_DanhMuc = id_DanhMuc;
            }
        }
    }
